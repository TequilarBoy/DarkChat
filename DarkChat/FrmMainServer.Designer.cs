namespace DarkChat
{
    partial class FrmMainServer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMainServer));
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabServer = new System.Windows.Forms.TabPage();
            this.lblLogs = new System.Windows.Forms.Label();
            this.lstLogs = new System.Windows.Forms.ListBox();
            this.lsvOnlineClients = new System.Windows.Forms.ListView();
            this.colIP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNickName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colArea = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNote = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblIP = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblPorts = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.tabOthers = new System.Windows.Forms.TabPage();
            this.tabMain.SuspendLayout();
            this.tabServer.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabServer);
            this.tabMain.Controls.Add(this.tabOthers);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(596, 530);
            this.tabMain.TabIndex = 7;
            // 
            // tabServer
            // 
            this.tabServer.Controls.Add(this.lblLogs);
            this.tabServer.Controls.Add(this.lstLogs);
            this.tabServer.Controls.Add(this.lsvOnlineClients);
            this.tabServer.Controls.Add(this.lblIP);
            this.tabServer.Controls.Add(this.btnStart);
            this.tabServer.Controls.Add(this.lblPorts);
            this.tabServer.Controls.Add(this.txtPort);
            this.tabServer.Controls.Add(this.txtIP);
            this.tabServer.Location = new System.Drawing.Point(4, 26);
            this.tabServer.Name = "tabServer";
            this.tabServer.Padding = new System.Windows.Forms.Padding(3);
            this.tabServer.Size = new System.Drawing.Size(588, 500);
            this.tabServer.TabIndex = 0;
            this.tabServer.Text = "Server";
            this.tabServer.UseVisualStyleBackColor = true;
            // 
            // lblLogs
            // 
            this.lblLogs.AutoSize = true;
            this.lblLogs.Location = new System.Drawing.Point(9, 355);
            this.lblLogs.Name = "lblLogs";
            this.lblLogs.Size = new System.Drawing.Size(39, 17);
            this.lblLogs.TabIndex = 15;
            this.lblLogs.Text = "Logs:";
            // 
            // lstLogs
            // 
            this.lstLogs.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lstLogs.FormattingEnabled = true;
            this.lstLogs.ItemHeight = 17;
            this.lstLogs.Location = new System.Drawing.Point(3, 374);
            this.lstLogs.Name = "lstLogs";
            this.lstLogs.Size = new System.Drawing.Size(582, 123);
            this.lstLogs.TabIndex = 14;
            // 
            // lsvOnlineClients
            // 
            this.lsvOnlineClients.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colIP,
            this.colNickName,
            this.colSex,
            this.colArea,
            this.colNote});
            this.lsvOnlineClients.FullRowSelect = true;
            this.lsvOnlineClients.GridLines = true;
            this.lsvOnlineClients.HideSelection = false;
            this.lsvOnlineClients.Location = new System.Drawing.Point(3, 74);
            this.lsvOnlineClients.Name = "lsvOnlineClients";
            this.lsvOnlineClients.Size = new System.Drawing.Size(582, 278);
            this.lsvOnlineClients.TabIndex = 13;
            this.lsvOnlineClients.UseCompatibleStateImageBehavior = false;
            this.lsvOnlineClients.View = System.Windows.Forms.View.Details;
            // 
            // colIP
            // 
            this.colIP.Text = "Client IP";
            this.colIP.Width = 117;
            // 
            // colNickName
            // 
            this.colNickName.Text = "Nickname";
            this.colNickName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colNickName.Width = 120;
            // 
            // colSex
            // 
            this.colSex.Text = "Sex";
            this.colSex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colSex.Width = 40;
            // 
            // colArea
            // 
            this.colArea.Text = "Area";
            this.colArea.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colArea.Width = 150;
            // 
            // colNote
            // 
            this.colNote.Text = "Note";
            this.colNote.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colNote.Width = 150;
            // 
            // lblIP
            // 
            this.lblIP.AutoSize = true;
            this.lblIP.Location = new System.Drawing.Point(19, 10);
            this.lblIP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(26, 17);
            this.lblIP.TabIndex = 8;
            this.lblIP.Text = "IP: ";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(241, 7);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(88, 26);
            this.btnStart.TabIndex = 12;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblPorts
            // 
            this.lblPorts.AutoSize = true;
            this.lblPorts.Location = new System.Drawing.Point(6, 41);
            this.lblPorts.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPorts.Name = "lblPorts";
            this.lblPorts.Size = new System.Drawing.Size(35, 17);
            this.lblPorts.TabIndex = 9;
            this.lblPorts.Text = "Port:";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(49, 38);
            this.txtPort.Margin = new System.Windows.Forms.Padding(4);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(184, 23);
            this.txtPort.TabIndex = 11;
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(49, 7);
            this.txtIP.Margin = new System.Windows.Forms.Padding(4);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(184, 23);
            this.txtIP.TabIndex = 10;
            // 
            // tabOthers
            // 
            this.tabOthers.Location = new System.Drawing.Point(4, 26);
            this.tabOthers.Name = "tabOthers";
            this.tabOthers.Padding = new System.Windows.Forms.Padding(3);
            this.tabOthers.Size = new System.Drawing.Size(588, 500);
            this.tabOthers.TabIndex = 1;
            this.tabOthers.Text = "Others";
            this.tabOthers.UseVisualStyleBackColor = true;
            // 
            // FrmMainServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 530);
            this.Controls.Add(this.tabMain);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmMainServer";
            this.Text = "DarkChat";
            this.tabMain.ResumeLayout(false);
            this.tabServer.ResumeLayout(false);
            this.tabServer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabServer;
        private System.Windows.Forms.ListView lsvOnlineClients;
        private System.Windows.Forms.ColumnHeader colIP;
        private System.Windows.Forms.ColumnHeader colNickName;
        private System.Windows.Forms.ColumnHeader colSex;
        private System.Windows.Forms.ColumnHeader colNote;
        private System.Windows.Forms.ColumnHeader colArea;
        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblPorts;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.TabPage tabOthers;
        private System.Windows.Forms.ListBox lstLogs;
        private System.Windows.Forms.Label lblLogs;
    }
}

