using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.Text.RegularExpressions;
using Client.Helpers;
using DarkClient.Unit;
using Newtonsoft.Json;
using DarkChat.Helpers;
using Client.Unit;


namespace Client
{
    public partial class FrmMainChat: Form
    {
        Thread thrdClient = null;
        Socket sockClient = null;

        public FrmMainChat()
        {
            InitializeComponent();
            this.lblTitle.Text = Settings.Version;
            // Show the horizontal scrollbar of log listbox
            this.lstLogs.HorizontalScrollbar = true;
            this.rdMale.Checked = true;
            this.btnConn.Tag = false;

            // UI notify
            ConnectUINotify(false);

            Logger.SubLogger(Log);
        }

        public void Log(string msg)
        {
            string log = $"[{DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss")}]: {msg}";
            if (this.lstLogs.InvokeRequired)
            {
                this.lstLogs.Invoke(new Action(() =>
                {
                    this.lstLogs.Items.Add(log);
                }));
            }
            else
            {
                this.lstLogs.Items.Add(log);
            }
        }

        private void btnConn_Click(object sender, EventArgs e)
        {
            try
            {
                string ip = this.txtIP.Text.Trim();
                string sport = this.txtPort.Text.Trim();

                // Check if the format of IP is right
                if (ip.Length > 0)
                {
                    string ipv4Pattern = @"^((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$";
                    Regex reg = new Regex(ipv4Pattern);
                    if (!reg.IsMatch(ip))
                    {
                        Logger.Log("Please input the correct server IP");
                        return;
                    }
                }

                // Check if the format of port is right
                int port = 0;
                if (sport.Length > 0)
                {
                    if (!int.TryParse(sport, out port) || (port < 0 || port > 65535))
                    {
                        Logger.Log("Port can only range from 0 to 65535");
                        return;
                    }
                }
                else
                {
                    Logger.Log("Please input server port");
                    return;
                }

                if (this.txtName.Text.Length <= 0)
                {
                    MessageBox.Show("You must input a name.");
                    return;
                }
                
                if ((bool)this.btnConn.Tag == false)
                {
                    // Connect to server
                    IPAddress address = IPAddress.Parse(ip);
                    IPEndPoint pt = new IPEndPoint(address, port);

                    this.sockClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                    this.sockClient.Connect(pt);

                    Logger.Log("Connect to server successfully");

                    // Create working thread
                    this.thrdClient = new Thread(ReceiveServerMsg);
                    this.thrdClient.IsBackground = true;
                    this.thrdClient.Start();
                }
                else
                {
                    Disconnect();
                }
            }
            catch (Exception ex)
            {
                Logger.Log($"{ex.Message}");
            }
        }

        private void ReceiveServerMsg()
        {
            Logger.Log("Prepare to communicate with server...");

            // Send join command to server
            DarkMsg joinPkg = FillJoinCommand(CommandCode.COMMAND_JOIN);
            if (!Package.SendCmdPkg(sockClient, joinPkg))
            {
                Logger.Log($"Failed to communicate with server");
                return;
            }

            DarkMsg darkMsg = null;

            while (true)
            {
                if (!Package.RecvCmdPkg(sockClient, out darkMsg))
                {
                    Disconnect();
                    Logger.Log($"Disconnect with server");
                    break;
                }
                switch (darkMsg.code)
                {
                    case CommandCode.TOKEN_JOIN:
                        {
                            // Reply from server indicates communicate with it successfully
                            ConnectUINotify(true);
                            // Start heartbeat thread
                            HeartBeatMgr.StartHeartbeat(this.sockClient);
                            break;
                        }
                    case CommandCode.TOKEN_LEAVE:
                        {
                            // 用户端离开了聊天室
                            
                            break;
                        }
                    case CommandCode.TOKEN_MSG:
                        {
                            // Msg from clients
                            if (this.lstTalkRecord.InvokeRequired)
                            {
                                this.lstTalkRecord.Invoke(new Action(() =>
                                {
                                    this.lstTalkRecord.Items.Add(darkMsg.msg);
                                }));
                            }
                            else
                            {
                                this.lstTalkRecord.Items.Add(darkMsg.msg);
                            }
                            break;
                        }
                    case CommandCode.TOKEN_PONG:
                        {
                            HeartBeatMgr.ReceivePong(darkMsg.lastSeen);
                            break;
                        }
                }
            }
        }

        public DarkMsg FillJoinCommand(CommandCode code)
        {
            // Nickname
            string nickName = null;
            if (this.txtName.InvokeRequired)
            {
                this.txtName.Invoke((MethodInvoker)delegate
                {
                    nickName = this.txtName.Text;
                });
            }
            else
            {
                nickName = this.txtName.Text;
            }

            if (nickName.Length == 0)
            {
                nickName = "N/A";
            }

            // Sex
            Sex gender = Sex.MALE;
            if (this.rdFemale.InvokeRequired)
            {
                this.rdFemale.Invoke((MethodInvoker)delegate
                {
                    if (this.rdFemale.Checked)
                    {
                        gender = Sex.FEMALE;
                    }
                });
            }
            else
            {
                if (this.rdFemale.Checked)
                {
                    gender = Sex.FEMALE;
                }
            }

            // Note
            string note = null;
            if (this.txtNote.InvokeRequired)
            {
                this.txtNote.Invoke((MethodInvoker)delegate
                {
                    note = this.txtNote.Text;
                });
            }
            else
            {
                note = this.txtNote.Text;
            }

            if (note.Length == 0)
            {
                note = "N/A";
            }

            ClientInfo info = new ClientInfo()
            {
                nickName = nickName,
                gender = gender,
                area = null,
                note = note
            };

            string strInfo = JsonConvert.SerializeObject(info);

            DarkMsg darkMsg = new DarkMsg()
            {
                code = code,
                msg = strInfo,
                lastSeen = DateTime.UtcNow
            };

            return darkMsg;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string strMsg = this.txtChat.Text;

            // Can't send empty shit
            if (strMsg.Length <= 0)
            {
                return;
            }
            // Get the information of client
            DarkMsg msgInfo = new DarkMsg()
            {
                code = CommandCode.COMMAND_MSG,
                msg = strMsg,
                lastSeen = DateTime.UtcNow
            };
            
            // Send chatting msg package
            Package.SendCmdPkg(sockClient, msgInfo);
            // Clear the input text box
            this.txtChat.Text = "";
            this.txtChat.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Disconnect();
            this.Dispose();
        }

        private void ConnectUINotify(bool fConnect)
        {
            if (this.txtName.InvokeRequired)
            {
                this.txtName.Invoke(new Action(() =>
                {
                    this.txtName.Enabled = !fConnect;
                }));
            }
            else
            {
                this.txtName.Enabled = !fConnect;
            }
            if (this.btnConn.InvokeRequired)
            {
                this.btnConn.Invoke(new Action(() =>
                {
                    this.btnConn.Tag = fConnect;
                    if (fConnect)
                    {
                        this.btnConn.Text = "Disconnect";
                        this.btnConn.Tag = true;
                    }
                    else
                    {
                        this.btnConn.Text = "Connect";
                        this.btnConn.Tag = false;
                    }
                }));
            }
            else
            {
                this.btnConn.Tag = fConnect;
                if (fConnect)
                {
                    this.btnConn.Text = "Disconnect";
                    this.btnConn.Tag = true;
                }
                else
                {
                    this.btnConn.Text = "Connect";
                    this.btnConn.Tag = false;
                }
            }

            if (this.rdMale.InvokeRequired)
            {
                this.rdMale.Invoke(new Action(() =>
                {
                    this.rdMale.Enabled = !fConnect;
                }));
            }
            else
            {
                this.rdMale.Enabled = !fConnect;
            }

            if (this.rdFemale.InvokeRequired)
            {
                this.rdFemale.Invoke(new Action(() =>
                {
                    this.rdFemale.Enabled = !fConnect;
                }));
            }
            else
            {
                this.rdFemale.Enabled = !fConnect;
            }

            if (this.rdUnknown.InvokeRequired)
            {
                this.rdUnknown.Invoke(new Action(() =>
                {
                    this.rdUnknown.Enabled = !fConnect;
                }));
            }
            else
            {
                this.rdUnknown.Enabled = !fConnect;
            }

            if (this.txtNote.InvokeRequired)
            {
                this.txtNote.Invoke(new Action(() =>
                {
                    this.txtNote.Enabled = !fConnect;
                }));
            }
            else
            {
                this.txtNote.Enabled = !fConnect;
            }

            if (this.txtIP.InvokeRequired)
            {
                this.txtIP.Invoke(new Action(() =>
                {
                    this.txtIP.Enabled = !fConnect;
                }));
            }
            else
            {
                this.txtIP.Enabled = !fConnect;
            }

            if (this.txtPort.InvokeRequired)
            {
                this.txtPort.Invoke(new Action(() =>
                {
                    this.txtPort.Enabled = !fConnect;
                }));
            }
            else
            {
                this.txtPort.Enabled = !fConnect;
            }

            if (this.txtChat.InvokeRequired)
            {
                this.txtChat.Invoke(new Action(() =>
                {
                    this.txtChat.Enabled = fConnect;
                }));
            }
            else
            {
                this.txtChat.Enabled = fConnect;
            }

            if (this.lstTalkRecord.InvokeRequired)
            {
                this.lstTalkRecord.Invoke(new Action(() =>
                {
                    this.lstTalkRecord.Enabled = fConnect;
                }));
            }
            else
            {
                this.lstTalkRecord.Enabled = fConnect;
            }

            if (this.btnSend.InvokeRequired)
            {
                this.btnSend.Invoke(new Action(() =>
                {
                    this.btnSend.Enabled = fConnect;
                }));
            }
            else
            {
                this.btnSend.Enabled = fConnect;
            }

            // Notify Toolbar flag status
            ToolbarUINotify(fConnect);
        }

        private void ToolbarUINotify(bool fConnect)
        {
            if (fConnect)
            {
                if (this.tlStatus.InvokeRequired)
                {
                    this.tlStatus.Invoke(new Action(() =>
                    {
                        if (fConnect)
                        {
                            this.tlItemOnline.ForeColor = Color.Green;
                            this.tlItemOnline.Text = "Status: Online";
                        }
                        else
                        {
                            this.tlItemOnline.ForeColor = Color.Red;
                            this.tlItemOnline.Text = "Status: Offline";
                        } 
                    }));
                }
                else
                {
                    if (fConnect)
                    {
                        this.tlItemOnline.ForeColor = Color.Green;
                        this.tlItemOnline.Text = "Status: Online";
                    }
                    else
                    {
                        this.tlItemOnline.ForeColor = Color.Red;
                        this.tlItemOnline.Text = "Status: Offline";
                    }
                }
            }
        }

        private void Disconnect()
        {
            // UI notify
            ConnectUINotify(false);
            // Shutdown the heartbeat
            HeartBeatMgr.StopHeartbeat();
            // Shift to offline
            if (this.tlStatus.InvokeRequired)
            {
                this.tlStatus.Invoke(new Action(() =>
                {
                    this.tlItemOnline.Text = "Status: Offline";
                    this.tlItemOnline.ForeColor = Color.Red;
                }));
            }
            else
            {
                this.tlItemOnline.Text = "Status: Offline";
                this.tlItemOnline.ForeColor = Color.Red;
            }
            Logger.Log("Disconnect with server");
        }

        private void btnMinimum_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void plTitle_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender == this.plTitle)
            {
                if (e.Button == MouseButtons.Left)
                {
                    Native.ReleaseCapture();

                    Native.SendMessage(this.Handle, Native.WM_NCLBUTTONDOWN, (IntPtr)Native.HT_CAPTION, IntPtr.Zero);
                }
            }
        }

        private void FrmMainChat_KeyDown(object sender, KeyEventArgs e)
        {
            int index = this.tabMain.SelectedIndex;
            if (1 == index)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    this.btnSend_Click(sender, e);
                }
            }
        }
    }
}

