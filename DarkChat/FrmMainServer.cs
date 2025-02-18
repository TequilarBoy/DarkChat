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
using Test;

namespace DarkChat
{
    public partial class FrmMainServer: Form
    {
        private DarkNetwork darkNet;

        private HeartBeatMgr hearBeat;

        private ClientsHive hive;

        private RsaUtils rsa;

        public FrmMainServer()
        {
            InitializeComponent();
            // Set server version to form
            this.Text = Settings.Version;
            this.btnGen.Enabled = false;
            this.lblBindStatus.ForeColor = Color.Red;

            // Subscribe Logger
            Logger.SubLogEvent(UpdateLog);
            // Initialize heartbeat checking object
            hearBeat = new HeartBeatMgr();
            hearBeat.OnHeartbeatClientOffline += ClientOffline;
            // Initialize network 
            darkNet = new DarkNetwork(out hive, hearBeat);
            // Initialize cryptography object
            rsa = new RsaUtils();
            // Subscribles UI notify events
            darkNet.OnDrawMsg += DrawMsg;
            darkNet.OnClientOnline += ClientOnline;
            darkNet.OnClientOffline += ClientOffline;
        }

        public void DrawMsg(Socket sock, string msg)
        {
            lock (hive.lockerClients)
            {
                string nickName = hive.dictClients[sock].nickName;

                foreach (var client in hive.dictClients)
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
        }

        public void ClientOnline(Socket sockClient, DarkMsg darkMsg)
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
            client.SubItems.Add(darkMsg.lastSeen.ToString("yyyy-MM-dd HH:mm:ss"));

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
            
            lock (hive.lockerClients)
            {
                // Add clients to dictionaries
                hive.dictClients.Add(sockClient, info);
            }

            lock (hive.lockerHandlers)
            {
                // Add client handlers to dictionaries
                hive.dictHandlers.Add(sockClient.RemoteEndPoint.ToString(), Thread.CurrentThread);
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
            lock (hive.lockerClients)
            {
                hive.dictClients.Remove(sockClient);
            }
            lock (hive.lockerHandlers)
            {
                hive.dictHandlers.Remove(sockClient.RemoteEndPoint.ToString());
            }
        }
        
        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                int port = 0;
                string ip = this.txtIP.Text.Trim();

                // Check IP
                if (ip.Length > 0)
                {
                    string ipv4Pattern = @"^((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$";
                    Regex reg = new Regex(ipv4Pattern);
                    if (!reg.IsMatch(ip))
                    {
                        Logger.Log("Enter the correct format server IP address");
                        return;
                    }
                }

                if (ip.Length <= 0)
                {
                    this.txtIP.Text = "0.0.0.0";
                }

                // Check port
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

                // Start the server
                darkNet.StartServer(ip, port);
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

        private void benBrowse_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dlg = new FolderBrowserDialog())
            {
                if (DialogResult.OK == dlg.ShowDialog())
                {
                    this.txtKeysPath.Text = dlg.SelectedPath;
                    this.btnGen.Enabled = true;
                }
            }
        }

        private void txtKeysPath_TextChanged(object sender, EventArgs e)
        {
            TextBox txtKeysPath = (TextBox)sender;

            if (!Directory.Exists(txtKeysPath.Text))
            {
                this.txtKeysPath.Text = "";
                this.btnGen.Enabled = false;
                this.benBrowse.Focus();
            }
        }

        private void btnGen_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> lstKeys = rsa.Pkcs1Key(2048, true);
                string priKeyPath = string.Format(@"{0}\private.pem", this.txtKeysPath.Text);
                string pubKeyPath = string.Format(@"{0}\public.pem", this.txtKeysPath.Text);
                
                using (StreamWriter writer = new StreamWriter(priKeyPath))
                {
                    writer.Write(lstKeys[1]);
                    writer.Flush();
                }

                using (StreamWriter writer = new StreamWriter(pubKeyPath))
                {
                    writer.Write(lstKeys[0]);
                    writer.Flush();
                }

                MessageBox.Show("Generate the key pairs successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to create key pairs", "Error");   
            }
        }

        private void btnPriBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.InitialDirectory = Environment.CurrentDirectory;
                dlg.Filter = "Pem Files (.pem)|*.pem";

                if (DialogResult.OK == dlg.ShowDialog())
                {
                    this.txtPriKeyPath.Text = dlg.FileName;
                }
            }
        }

        private void btnBindPriKey_Click(object sender, EventArgs e)
        {
            string priKeyPath = this.txtPriKeyPath.Text.Trim();

            if (this.btnBindPriKey.Text == "Bind")
            {
                if (string.IsNullOrEmpty(priKeyPath))
                {
                    MessageBox.Show("Choosing private key path first", "Error");
                    return;
                }

                if (!File.Exists(priKeyPath))
                {
                    MessageBox.Show("Private key file doesn't exist, create keys pair firstly", "Error");
                    return;
                }
                this.lblBindStatus.Text = "Status: Bind";
                this.lblBindStatus.ForeColor = Color.Green;

                this.btnBindPriKey.Text = "Unbind";

                // Check if private key's format is right or not 
                Settings.PrivKey = IO.ReadTextFile(priKeyPath);
                MessageBox.Show("Bind private key successfully!", "Success", MessageBoxButtons.OK);
            }
            else
            {
                this.lblBindStatus.Text = "Status: Unbind";
                this.lblBindStatus.ForeColor = Color.Red;

                this.btnBindPriKey.Text = "Bind";

                Settings.PrivKey = "";

                MessageBox.Show("Unbind private key successfully!", "Success", MessageBoxButtons.OK);
            }
        }
    }
}
