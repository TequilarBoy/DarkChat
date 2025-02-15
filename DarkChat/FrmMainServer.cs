using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;
using DarkChat.Unit;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Net;
using DarkChat.Helpers;
using System.IO;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using DarkClient.Unit;

namespace DarkChat
{
    public partial class FrmMainServer: Form
    {
        private Thread thrdListen = null;
        private Socket sockListen = null;

        private Dictionary<string, Thread> dictHandlers = new Dictionary<string, Thread>();

        private Dictionary<Socket, ClientInfo> dictClients = new Dictionary<Socket, ClientInfo>();

        private readonly object locker = new object();

        public FrmMainServer()
        {
            InitializeComponent();
            this.Text = Settings.Version;
            // Subscribe Logger
            Logger.SubLogEvent(UpdateLog);
        }

        private void ClientHandler(object obj)
        {
            Socket sockClient = obj as Socket;

            int recv = 0;
            long len = 0;
            byte[] byteslen = new byte[8];
            byte[] buffer = null;
            bool running = true;

            while (running)
            {
                try
                {
                    // The length of content
                    recv = sockClient.Receive(byteslen, byteslen.Length, SocketFlags.None);
                    len = BitConverter.ToInt64(byteslen, 0);
                    // Buffer to receive content
                    buffer = new byte[len];

                    if (len > 1000000)
                    {
                        // > 1MB read by block
                        long current = 0;
                        byte[] clip = new byte[1000000];
                        using (MemoryStream ms = new MemoryStream(buffer))
                        {
                            while (current < len)
                            {
                                // Move forward
                                ms.Seek(current, SeekOrigin.Begin);
                                // Receive content and write to buffer
                                recv = sockClient.Receive(clip);
                                ms.Write(clip, 0, recv);
                                current += recv;
                            }
                            buffer = ms.ToArray();
                        }
                    }
                    else
                    {
                        // Receive directly if package if less than 1MB
                        sockClient.Receive(buffer, (int)len, SocketFlags.None);
                    }
                    string strPkg = Encoding.UTF8.GetString(buffer);
                    DarkMsg darkMsg = JsonConvert.DeserializeObject<DarkMsg>(strPkg);

                    switch (darkMsg.code)
                    {
                        case CommandCode.COMMAND_JOIN:
                            {
                                ClientOnline(sockClient, darkMsg);
                                break;
                            }
                        case CommandCode.COMMAND_MSG:
                            {
                                DrawMsg(sockClient, darkMsg.msg);
                                break;
                            }
                    }
                }
                catch (SocketException ex)
                {
                    running = false;
                    ClientOffline(sockClient);
                }
                catch (Exception ex)
                {
                    Logger.Log(ex.Message);
                }
            }
        }

        private void DrawMsg(Socket sock, string msg)
        {
            string nickName = dictClients[sock].nickName;

            foreach (var client in dictClients)
            {
                string record = $"{nickName}[{DateTime.UtcNow.ToString("yyyy-MM-dd HH-mm-ss")}]:\n  {msg}";
                DarkMsg darkMsg = new DarkMsg()
                {
                    code = CommandCode.TOKEN_MSG,
                    msg = record
                };
                Package.SendCmdPkg(client.Key, darkMsg);
            }
        }

        private void ClientOnline(Socket sockClient, DarkMsg darkMsg)
        {
            IPEndPoint pt = (IPEndPoint)sockClient.RemoteEndPoint;

            var info = JsonConvert.DeserializeObject<ClientInfo>(darkMsg.msg);

            // Add new item to online clients list
            ListViewItem client = new ListViewItem(pt.Address.ToString());
            string city = GeoLocate.Locate(pt.Address.ToString());
            string sex = string.Empty;
            if (info.gender == Sex.FEMALE)
            {
                sex = "Female";
            }
            else if (info.gender == Sex.MALE)
            {
                sex = "Male";
            }
            else
            {
                sex = "Alien";
            }
            client.SubItems.Add(info.nickName);
            client.SubItems.Add(sex);
            client.SubItems.Add(city);
            client.SubItems.Add(info.note);

            client.Tag = sockClient;

            if (this.lsvOnlineClients.InvokeRequired)
            {
                this.lsvOnlineClients.Invoke(new Action(() => {
                    this.lsvOnlineClients.Items.Add(client);
                }));
            }
            else
            {
                this.lsvOnlineClients.Items.Add(client);
            } 

            lock (locker)
            {
                // Add clients to dictionaries
                dictHandlers.Add(sockClient.RemoteEndPoint.ToString(), Thread.CurrentThread);
                dictClients.Add(sockClient, info);
            }

            // Sending a reply indicates that the connection is successful
            DarkMsg replyMsg = new DarkMsg() { 
                code = CommandCode.TOKEN_JOIN,
                msg = null
            };

            Package.SendCmdPkg(sockClient, replyMsg);
            
            Logger.Log($"{pt.Address.ToString()} enter");
        }

        private void RemoveOnlineClnts(Socket sockClient)
        {
            if (lsvOnlineClients.Items.Count > 0)
            {
                foreach (ListViewItem clnt in this.lsvOnlineClients.Items)
                {
                    IPEndPoint pt = sockClient.RemoteEndPoint as IPEndPoint;
                    if (clnt.Tag == sockClient)
                    {
                        this.lsvOnlineClients.Items.Remove(clnt);
                    }
                }
            }
        }

        private void ClientOffline(Socket sockClient)
        {
            // Remove from online list
            if (this.lsvOnlineClients.InvokeRequired)
            {
                this.lsvOnlineClients.Invoke(new Action(() =>
                {
                    RemoveOnlineClnts(sockClient);
                }));
            }
            else
            {
                RemoveOnlineClnts(sockClient);
            }

            IPEndPoint clientpt = sockClient.RemoteEndPoint as IPEndPoint;
            Logger.Log($"{clientpt.Address}:{clientpt.Port} leave");

            // Remove client from thread dict and client dict
            lock (locker)
            {
                dictHandlers.Remove(sockClient.RemoteEndPoint.ToString());
                dictClients.Remove(sockClient);
            }
        }
        
        private void ListenHandler()
        {
            while (true)
            {
                Socket sockClient = null;

                try
                {
                    // Blocking, wait for the connection of clients
                    sockClient = sockListen.Accept();

                    IPEndPoint pt = (IPEndPoint)sockClient.RemoteEndPoint;

                    // Create thread to serve clients
                    Thread thrdClient = new Thread(new ParameterizedThreadStart(ClientHandler));
                    thrdClient.IsBackground = true;
                    thrdClient.Start(sockClient);
                }
                catch (Exception ex)
                {

                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if the format of IP is right or not
                if (this.txtIP.Text.Length > 0)
                {
                    string ipv4Pattern = @"^((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$";
                    Regex reg = new Regex(ipv4Pattern);
                    if (!reg.IsMatch(this.txtIP.Text))
                    {
                        Logger.Log("Enter the correct format server IP address");
                        return;
                    }
                }

                sockListen = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                IPAddress address = (this.txtIP.Text.Length > 0) ? IPAddress.Parse(this.txtIP.Text) : IPAddress.Any;

                int port = 0;

                if (this.txtPort.Text.Length <= 0)
                {
                    port = new Random().Next(1025, ushort.MaxValue);
                    this.txtPort.Text = Convert.ToString(port);
                }
                
                if (!int.TryParse(this.txtPort.Text, out port))
                {
                    Logger.Log("Enter a port number that ranges from 0 to 65535");
                    return;
                }

                IPEndPoint endPoint = new IPEndPoint(address, port);

                sockListen.Bind(endPoint);

                sockListen.Listen(999999);

                if (this.txtIP.Text.Length <= 0)
                {
                    this.txtIP.Text = address.ToString();
                }

                Logger.Log($"Server is starting, listen on: {address}:{port}");

                // Start the thread of handling clients
                thrdListen = new Thread(ListenHandler);
                thrdListen.IsBackground = true;
                thrdListen.Start();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{ex.Message}");
            }
            
        }

        private void UpdateLog(string msg)
        {
            if (this.lstLogs.InvokeRequired)
            {
                lstLogs.Invoke(new Action<string>(UpdateLog), msg);
            }
            else
            {
                this.lstLogs.Items.Add($"{DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss")}: {msg}");
            }
        }
    }
}
