namespace Client
{
    partial class FrmMainChat
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMainChat));
            this.label1 = new System.Windows.Forms.Label();
            this.plTitle = new System.Windows.Forms.Panel();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.btnMinimum = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnConn = new System.Windows.Forms.Button();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabConfig = new System.Windows.Forms.TabPage();
            this.grpLog = new System.Windows.Forms.GroupBox();
            this.lstLogs = new System.Windows.Forms.ListBox();
            this.grpServer = new System.Windows.Forms.GroupBox();
            this.grpSelfConfig = new System.Windows.Forms.GroupBox();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.lblSig = new System.Windows.Forms.Label();
            this.rdUnknown = new System.Windows.Forms.RadioButton();
            this.rdFemale = new System.Windows.Forms.RadioButton();
            this.rdMale = new System.Windows.Forms.RadioButton();
            this.lblSex = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblNickName = new System.Windows.Forms.Label();
            this.tabTalk = new System.Windows.Forms.TabPage();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtChat = new System.Windows.Forms.TextBox();
            this.lstTalkRecord = new System.Windows.Forms.ListBox();
            this.tabOnline = new System.Windows.Forms.TabPage();
            this.tlStatus = new System.Windows.Forms.StatusStrip();
            this.tlItemOnline = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlItemPing = new System.Windows.Forms.ToolStripStatusLabel();
            this.plTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.tabMain.SuspendLayout();
            this.tabConfig.SuspendLayout();
            this.grpLog.SuspendLayout();
            this.grpServer.SuspendLayout();
            this.grpSelfConfig.SuspendLayout();
            this.tabTalk.SuspendLayout();
            this.tlStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server IP:";
            // 
            // plTitle
            // 
            this.plTitle.BackColor = System.Drawing.Color.Gray;
            this.plTitle.Controls.Add(this.picLogo);
            this.plTitle.Controls.Add(this.btnMinimum);
            this.plTitle.Controls.Add(this.btnClose);
            this.plTitle.Controls.Add(this.lblTitle);
            this.plTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.plTitle.Location = new System.Drawing.Point(0, 0);
            this.plTitle.Name = "plTitle";
            this.plTitle.Size = new System.Drawing.Size(706, 30);
            this.plTitle.TabIndex = 1;
            this.plTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.plTitle_MouseDown);
            // 
            // picLogo
            // 
            this.picLogo.BackColor = System.Drawing.Color.Transparent;
            this.picLogo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picLogo.BackgroundImage")));
            this.picLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picLogo.Location = new System.Drawing.Point(6, 5);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(20, 20);
            this.picLogo.TabIndex = 7;
            this.picLogo.TabStop = false;
            // 
            // btnMinimum
            // 
            this.btnMinimum.BackColor = System.Drawing.Color.Transparent;
            this.btnMinimum.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMinimum.BackgroundImage")));
            this.btnMinimum.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMinimum.ForeColor = System.Drawing.Color.Transparent;
            this.btnMinimum.Location = new System.Drawing.Point(650, 3);
            this.btnMinimum.Name = "btnMinimum";
            this.btnMinimum.Size = new System.Drawing.Size(25, 25);
            this.btnMinimum.TabIndex = 6;
            this.btnMinimum.UseVisualStyleBackColor = false;
            this.btnMinimum.Click += new System.EventHandler(this.btnMinimum_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClose.BackgroundImage")));
            this.btnClose.ForeColor = System.Drawing.Color.Transparent;
            this.btnClose.Location = new System.Drawing.Point(677, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(25, 25);
            this.btnClose.TabIndex = 5;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblTitle.Location = new System.Drawing.Point(26, 4);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(82, 21);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "DarkChat";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(88, 22);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(175, 23);
            this.txtIP.TabIndex = 2;
            this.txtIP.Text = "192.168.2.27";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(88, 54);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(175, 23);
            this.txtPort.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 57);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Server port:";
            // 
            // btnConn
            // 
            this.btnConn.Location = new System.Drawing.Point(33, 94);
            this.btnConn.Name = "btnConn";
            this.btnConn.Size = new System.Drawing.Size(230, 35);
            this.btnConn.TabIndex = 5;
            this.btnConn.Text = "Connect";
            this.btnConn.UseVisualStyleBackColor = true;
            this.btnConn.Click += new System.EventHandler(this.btnConn_Click);
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabConfig);
            this.tabMain.Controls.Add(this.tabTalk);
            this.tabMain.Controls.Add(this.tabOnline);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 30);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(706, 420);
            this.tabMain.TabIndex = 6;
            // 
            // tabConfig
            // 
            this.tabConfig.Controls.Add(this.grpLog);
            this.tabConfig.Controls.Add(this.grpServer);
            this.tabConfig.Controls.Add(this.grpSelfConfig);
            this.tabConfig.Location = new System.Drawing.Point(4, 26);
            this.tabConfig.Name = "tabConfig";
            this.tabConfig.Padding = new System.Windows.Forms.Padding(3);
            this.tabConfig.Size = new System.Drawing.Size(698, 390);
            this.tabConfig.TabIndex = 0;
            this.tabConfig.Text = "Config";
            this.tabConfig.UseVisualStyleBackColor = true;
            // 
            // grpLog
            // 
            this.grpLog.Controls.Add(this.lstLogs);
            this.grpLog.Location = new System.Drawing.Point(308, 6);
            this.grpLog.Name = "grpLog";
            this.grpLog.Size = new System.Drawing.Size(382, 351);
            this.grpLog.TabIndex = 8;
            this.grpLog.TabStop = false;
            this.grpLog.Text = "Logs";
            // 
            // lstLogs
            // 
            this.lstLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstLogs.FormattingEnabled = true;
            this.lstLogs.ItemHeight = 17;
            this.lstLogs.Location = new System.Drawing.Point(3, 19);
            this.lstLogs.Name = "lstLogs";
            this.lstLogs.Size = new System.Drawing.Size(376, 329);
            this.lstLogs.TabIndex = 0;
            // 
            // grpServer
            // 
            this.grpServer.Controls.Add(this.label1);
            this.grpServer.Controls.Add(this.txtPort);
            this.grpServer.Controls.Add(this.label3);
            this.grpServer.Controls.Add(this.txtIP);
            this.grpServer.Controls.Add(this.btnConn);
            this.grpServer.Location = new System.Drawing.Point(12, 208);
            this.grpServer.Name = "grpServer";
            this.grpServer.Size = new System.Drawing.Size(290, 149);
            this.grpServer.TabIndex = 7;
            this.grpServer.TabStop = false;
            this.grpServer.Text = "Server";
            // 
            // grpSelfConfig
            // 
            this.grpSelfConfig.Controls.Add(this.txtNote);
            this.grpSelfConfig.Controls.Add(this.lblSig);
            this.grpSelfConfig.Controls.Add(this.rdUnknown);
            this.grpSelfConfig.Controls.Add(this.rdFemale);
            this.grpSelfConfig.Controls.Add(this.rdMale);
            this.grpSelfConfig.Controls.Add(this.lblSex);
            this.grpSelfConfig.Controls.Add(this.txtName);
            this.grpSelfConfig.Controls.Add(this.lblNickName);
            this.grpSelfConfig.Location = new System.Drawing.Point(12, 6);
            this.grpSelfConfig.Name = "grpSelfConfig";
            this.grpSelfConfig.Size = new System.Drawing.Size(290, 196);
            this.grpSelfConfig.TabIndex = 6;
            this.grpSelfConfig.TabStop = false;
            this.grpSelfConfig.Text = "Personal";
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(62, 83);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(207, 95);
            this.txtNote.TabIndex = 7;
            // 
            // lblSig
            // 
            this.lblSig.AutoSize = true;
            this.lblSig.Location = new System.Drawing.Point(19, 83);
            this.lblSig.Name = "lblSig";
            this.lblSig.Size = new System.Drawing.Size(40, 17);
            this.lblSig.TabIndex = 6;
            this.lblSig.Text = "Note:";
            // 
            // rdUnknown
            // 
            this.rdUnknown.AutoSize = true;
            this.rdUnknown.Location = new System.Drawing.Point(215, 54);
            this.rdUnknown.Name = "rdUnknown";
            this.rdUnknown.Size = new System.Drawing.Size(54, 21);
            this.rdUnknown.TabIndex = 5;
            this.rdUnknown.TabStop = true;
            this.rdUnknown.Text = "Alien";
            this.rdUnknown.UseVisualStyleBackColor = true;
            // 
            // rdFemale
            // 
            this.rdFemale.AutoSize = true;
            this.rdFemale.Location = new System.Drawing.Point(132, 54);
            this.rdFemale.Name = "rdFemale";
            this.rdFemale.Size = new System.Drawing.Size(67, 21);
            this.rdFemale.TabIndex = 4;
            this.rdFemale.TabStop = true;
            this.rdFemale.Text = "Female";
            this.rdFemale.UseVisualStyleBackColor = true;
            // 
            // rdMale
            // 
            this.rdMale.AutoSize = true;
            this.rdMale.Location = new System.Drawing.Point(62, 54);
            this.rdMale.Name = "rdMale";
            this.rdMale.Size = new System.Drawing.Size(55, 21);
            this.rdMale.TabIndex = 3;
            this.rdMale.TabStop = true;
            this.rdMale.Text = "Male";
            this.rdMale.UseVisualStyleBackColor = true;
            // 
            // lblSex
            // 
            this.lblSex.AutoSize = true;
            this.lblSex.Location = new System.Drawing.Point(25, 54);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(31, 17);
            this.lblSex.TabIndex = 2;
            this.lblSex.Text = "Sex:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(62, 27);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(207, 23);
            this.txtName.TabIndex = 1;
            // 
            // lblNickName
            // 
            this.lblNickName.AutoSize = true;
            this.lblNickName.Location = new System.Drawing.Point(12, 30);
            this.lblNickName.Name = "lblNickName";
            this.lblNickName.Size = new System.Drawing.Size(46, 17);
            this.lblNickName.TabIndex = 0;
            this.lblNickName.Text = "Name:";
            // 
            // tabTalk
            // 
            this.tabTalk.Controls.Add(this.btnSend);
            this.tabTalk.Controls.Add(this.txtChat);
            this.tabTalk.Controls.Add(this.lstTalkRecord);
            this.tabTalk.Location = new System.Drawing.Point(4, 26);
            this.tabTalk.Name = "tabTalk";
            this.tabTalk.Padding = new System.Windows.Forms.Padding(3);
            this.tabTalk.Size = new System.Drawing.Size(698, 390);
            this.tabTalk.TabIndex = 1;
            this.tabTalk.Text = "Chat";
            this.tabTalk.UseVisualStyleBackColor = true;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(611, 291);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(79, 31);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtChat
            // 
            this.txtChat.Location = new System.Drawing.Point(8, 291);
            this.txtChat.Multiline = true;
            this.txtChat.Name = "txtChat";
            this.txtChat.Size = new System.Drawing.Size(597, 78);
            this.txtChat.TabIndex = 1;
            // 
            // lstTalkRecord
            // 
            this.lstTalkRecord.FormattingEnabled = true;
            this.lstTalkRecord.ItemHeight = 17;
            this.lstTalkRecord.Location = new System.Drawing.Point(8, 9);
            this.lstTalkRecord.Name = "lstTalkRecord";
            this.lstTalkRecord.Size = new System.Drawing.Size(682, 276);
            this.lstTalkRecord.TabIndex = 0;
            // 
            // tabOnline
            // 
            this.tabOnline.Location = new System.Drawing.Point(4, 26);
            this.tabOnline.Name = "tabOnline";
            this.tabOnline.Padding = new System.Windows.Forms.Padding(3);
            this.tabOnline.Size = new System.Drawing.Size(698, 390);
            this.tabOnline.TabIndex = 2;
            this.tabOnline.Text = "Room";
            this.tabOnline.UseVisualStyleBackColor = true;
            // 
            // tlStatus
            // 
            this.tlStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlItemOnline,
            this.tlItemPing});
            this.tlStatus.Location = new System.Drawing.Point(0, 428);
            this.tlStatus.Name = "tlStatus";
            this.tlStatus.Size = new System.Drawing.Size(706, 22);
            this.tlStatus.TabIndex = 7;
            // 
            // tlItemOnline
            // 
            this.tlItemOnline.Name = "tlItemOnline";
            this.tlItemOnline.Size = new System.Drawing.Size(81, 17);
            this.tlItemOnline.Text = "Status: Offline";
            // 
            // tlItemPing
            // 
            this.tlItemPing.Name = "tlItemPing";
            this.tlItemPing.Size = new System.Drawing.Size(59, 17);
            this.tlItemPing.Text = "Ping: 0ms";
            // 
            // FrmMainChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 450);
            this.Controls.Add(this.tlStatus);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.plTitle);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmMainChat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DarkChat";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmMainChat_KeyDown);
            this.plTitle.ResumeLayout(false);
            this.plTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.tabMain.ResumeLayout(false);
            this.tabConfig.ResumeLayout(false);
            this.grpLog.ResumeLayout(false);
            this.grpServer.ResumeLayout(false);
            this.grpServer.PerformLayout();
            this.grpSelfConfig.ResumeLayout(false);
            this.grpSelfConfig.PerformLayout();
            this.tabTalk.ResumeLayout(false);
            this.tabTalk.PerformLayout();
            this.tlStatus.ResumeLayout(false);
            this.tlStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel plTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnConn;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabConfig;
        private System.Windows.Forms.TabPage tabTalk;
        private System.Windows.Forms.StatusStrip tlStatus;
        private System.Windows.Forms.ToolStripStatusLabel tlItemOnline;
        private System.Windows.Forms.ToolStripStatusLabel tlItemPing;
        private System.Windows.Forms.GroupBox grpSelfConfig;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Label lblSig;
        private System.Windows.Forms.RadioButton rdUnknown;
        private System.Windows.Forms.RadioButton rdFemale;
        private System.Windows.Forms.RadioButton rdMale;
        private System.Windows.Forms.Label lblSex;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblNickName;
        private System.Windows.Forms.GroupBox grpLog;
        private System.Windows.Forms.GroupBox grpServer;
        private System.Windows.Forms.ListBox lstTalkRecord;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtChat;
        private System.Windows.Forms.TabPage tabOnline;
        private System.Windows.Forms.ListBox lstLogs;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMinimum;
        private System.Windows.Forms.PictureBox picLogo;
    }
}

