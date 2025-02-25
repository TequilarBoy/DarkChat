﻿namespace DarkChat
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
            this.colLastseen = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblIP = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblPorts = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.tagSafe = new System.Windows.Forms.TabPage();
            this.grpConfigKey = new System.Windows.Forms.GroupBox();
            this.lblBindStatus = new System.Windows.Forms.Label();
            this.btnBindPriKey = new System.Windows.Forms.Button();
            this.btnPriBrowse = new System.Windows.Forms.Button();
            this.txtPriKeyPath = new System.Windows.Forms.TextBox();
            this.lblUsePriKey = new System.Windows.Forms.Label();
            this.grpKeyGen = new System.Windows.Forms.GroupBox();
            this.btnGen = new System.Windows.Forms.Button();
            this.benBrowse = new System.Windows.Forms.Button();
            this.txtKeysPath = new System.Windows.Forms.TextBox();
            this.lblKeysSave = new System.Windows.Forms.Label();
            this.tabConfig = new System.Windows.Forms.TabPage();
            this.grpCurSetup = new System.Windows.Forms.GroupBox();
            this.lblCurDefSingleton = new System.Windows.Forms.Label();
            this.lblCurDefAutoStartup = new System.Windows.Forms.Label();
            this.lblCurDefPort = new System.Windows.Forms.Label();
            this.lblCurDefIP = new System.Windows.Forms.Label();
            this.lblCurDefPriKeyPath = new System.Windows.Forms.Label();
            this.grpServerConfig = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDefBrowse = new System.Windows.Forms.Button();
            this.txtDefPriKeyPath = new System.Windows.Forms.TextBox();
            this.lblDefPriKey = new System.Windows.Forms.Label();
            this.txtDefPort = new System.Windows.Forms.TextBox();
            this.txtDefIP = new System.Windows.Forms.TextBox();
            this.lblDefPort = new System.Windows.Forms.Label();
            this.lblDefIP = new System.Windows.Forms.Label();
            this.chkSingleton = new System.Windows.Forms.CheckBox();
            this.chkAutostartup = new System.Windows.Forms.CheckBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnDefPubKeyBrowse = new System.Windows.Forms.Button();
            this.txtDefPubKeyPath = new System.Windows.Forms.TextBox();
            this.lblDefPubKey = new System.Windows.Forms.Label();
            this.tabMain.SuspendLayout();
            this.tabServer.SuspendLayout();
            this.tagSafe.SuspendLayout();
            this.grpConfigKey.SuspendLayout();
            this.grpKeyGen.SuspendLayout();
            this.tabConfig.SuspendLayout();
            this.grpCurSetup.SuspendLayout();
            this.grpServerConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabServer);
            this.tabMain.Controls.Add(this.tagSafe);
            this.tabMain.Controls.Add(this.tabConfig);
            this.tabMain.Controls.Add(this.tabPage1);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(720, 530);
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
            this.tabServer.Size = new System.Drawing.Size(712, 500);
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
            this.lstLogs.Size = new System.Drawing.Size(706, 123);
            this.lstLogs.TabIndex = 14;
            // 
            // lsvOnlineClients
            // 
            this.lsvOnlineClients.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colIP,
            this.colNickName,
            this.colSex,
            this.colArea,
            this.colNote,
            this.colLastseen});
            this.lsvOnlineClients.FullRowSelect = true;
            this.lsvOnlineClients.GridLines = true;
            this.lsvOnlineClients.HideSelection = false;
            this.lsvOnlineClients.Location = new System.Drawing.Point(3, 74);
            this.lsvOnlineClients.Name = "lsvOnlineClients";
            this.lsvOnlineClients.Size = new System.Drawing.Size(706, 278);
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
            // colLastseen
            // 
            this.colLastseen.Text = "Lastseen";
            this.colLastseen.Width = 150;
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
            // tagSafe
            // 
            this.tagSafe.Controls.Add(this.grpConfigKey);
            this.tagSafe.Controls.Add(this.grpKeyGen);
            this.tagSafe.Location = new System.Drawing.Point(4, 26);
            this.tagSafe.Name = "tagSafe";
            this.tagSafe.Padding = new System.Windows.Forms.Padding(3);
            this.tagSafe.Size = new System.Drawing.Size(712, 500);
            this.tagSafe.TabIndex = 1;
            this.tagSafe.Text = "Config Key";
            this.tagSafe.UseVisualStyleBackColor = true;
            // 
            // grpConfigKey
            // 
            this.grpConfigKey.Controls.Add(this.lblBindStatus);
            this.grpConfigKey.Controls.Add(this.btnBindPriKey);
            this.grpConfigKey.Controls.Add(this.btnPriBrowse);
            this.grpConfigKey.Controls.Add(this.txtPriKeyPath);
            this.grpConfigKey.Controls.Add(this.lblUsePriKey);
            this.grpConfigKey.Location = new System.Drawing.Point(7, 144);
            this.grpConfigKey.Name = "grpConfigKey";
            this.grpConfigKey.Size = new System.Drawing.Size(697, 157);
            this.grpConfigKey.TabIndex = 1;
            this.grpConfigKey.TabStop = false;
            this.grpConfigKey.Text = "Keys Config";
            // 
            // lblBindStatus
            // 
            this.lblBindStatus.AutoSize = true;
            this.lblBindStatus.Location = new System.Drawing.Point(53, 124);
            this.lblBindStatus.Name = "lblBindStatus";
            this.lblBindStatus.Size = new System.Drawing.Size(92, 17);
            this.lblBindStatus.TabIndex = 6;
            this.lblBindStatus.Text = "Status: Unbind";
            // 
            // btnBindPriKey
            // 
            this.btnBindPriKey.Location = new System.Drawing.Point(93, 79);
            this.btnBindPriKey.Name = "btnBindPriKey";
            this.btnBindPriKey.Size = new System.Drawing.Size(501, 32);
            this.btnBindPriKey.TabIndex = 4;
            this.btnBindPriKey.Text = "Bind";
            this.btnBindPriKey.UseVisualStyleBackColor = true;
            this.btnBindPriKey.Click += new System.EventHandler(this.btnBindPriKey_Click);
            // 
            // btnPriBrowse
            // 
            this.btnPriBrowse.Location = new System.Drawing.Point(519, 34);
            this.btnPriBrowse.Name = "btnPriBrowse";
            this.btnPriBrowse.Size = new System.Drawing.Size(75, 25);
            this.btnPriBrowse.TabIndex = 5;
            this.btnPriBrowse.Text = "Browse";
            this.btnPriBrowse.UseVisualStyleBackColor = true;
            this.btnPriBrowse.Click += new System.EventHandler(this.btnPriBrowse_Click);
            // 
            // txtPriKeyPath
            // 
            this.txtPriKeyPath.Location = new System.Drawing.Point(159, 35);
            this.txtPriKeyPath.Name = "txtPriKeyPath";
            this.txtPriKeyPath.Size = new System.Drawing.Size(354, 23);
            this.txtPriKeyPath.TabIndex = 4;
            // 
            // lblUsePriKey
            // 
            this.lblUsePriKey.AutoSize = true;
            this.lblUsePriKey.Location = new System.Drawing.Point(53, 38);
            this.lblUsePriKey.Name = "lblUsePriKey";
            this.lblUsePriKey.Size = new System.Drawing.Size(104, 17);
            this.lblUsePriKey.TabIndex = 0;
            this.lblUsePriKey.Text = "Private Key Path:";
            // 
            // grpKeyGen
            // 
            this.grpKeyGen.Controls.Add(this.btnGen);
            this.grpKeyGen.Controls.Add(this.benBrowse);
            this.grpKeyGen.Controls.Add(this.txtKeysPath);
            this.grpKeyGen.Controls.Add(this.lblKeysSave);
            this.grpKeyGen.Location = new System.Drawing.Point(6, 6);
            this.grpKeyGen.Name = "grpKeyGen";
            this.grpKeyGen.Size = new System.Drawing.Size(698, 131);
            this.grpKeyGen.TabIndex = 0;
            this.grpKeyGen.TabStop = false;
            this.grpKeyGen.Text = "Keys Generator";
            // 
            // btnGen
            // 
            this.btnGen.Location = new System.Drawing.Point(94, 73);
            this.btnGen.Name = "btnGen";
            this.btnGen.Size = new System.Drawing.Size(501, 32);
            this.btnGen.TabIndex = 3;
            this.btnGen.Text = "Generate";
            this.btnGen.UseVisualStyleBackColor = true;
            this.btnGen.Click += new System.EventHandler(this.btnGen_Click);
            // 
            // benBrowse
            // 
            this.benBrowse.Location = new System.Drawing.Point(520, 30);
            this.benBrowse.Name = "benBrowse";
            this.benBrowse.Size = new System.Drawing.Size(75, 25);
            this.benBrowse.TabIndex = 2;
            this.benBrowse.Text = "Browse";
            this.benBrowse.UseVisualStyleBackColor = true;
            this.benBrowse.Click += new System.EventHandler(this.benBrowse_Click);
            // 
            // txtKeysPath
            // 
            this.txtKeysPath.Location = new System.Drawing.Point(160, 31);
            this.txtKeysPath.Name = "txtKeysPath";
            this.txtKeysPath.Size = new System.Drawing.Size(354, 23);
            this.txtKeysPath.TabIndex = 1;
            this.txtKeysPath.TextChanged += new System.EventHandler(this.txtKeysPath_TextChanged);
            // 
            // lblKeysSave
            // 
            this.lblKeysSave.AutoSize = true;
            this.lblKeysSave.Location = new System.Drawing.Point(60, 34);
            this.lblKeysSave.Name = "lblKeysSave";
            this.lblKeysSave.Size = new System.Drawing.Size(98, 17);
            this.lblKeysSave.TabIndex = 0;
            this.lblKeysSave.Text = "Keys Save Path:";
            // 
            // tabConfig
            // 
            this.tabConfig.Controls.Add(this.grpCurSetup);
            this.tabConfig.Controls.Add(this.grpServerConfig);
            this.tabConfig.Location = new System.Drawing.Point(4, 26);
            this.tabConfig.Name = "tabConfig";
            this.tabConfig.Padding = new System.Windows.Forms.Padding(3);
            this.tabConfig.Size = new System.Drawing.Size(712, 500);
            this.tabConfig.TabIndex = 2;
            this.tabConfig.Text = "Config File";
            this.tabConfig.UseVisualStyleBackColor = true;
            // 
            // grpCurSetup
            // 
            this.grpCurSetup.Controls.Add(this.lblCurDefSingleton);
            this.grpCurSetup.Controls.Add(this.lblCurDefAutoStartup);
            this.grpCurSetup.Controls.Add(this.lblCurDefPort);
            this.grpCurSetup.Controls.Add(this.lblCurDefIP);
            this.grpCurSetup.Controls.Add(this.lblCurDefPriKeyPath);
            this.grpCurSetup.Location = new System.Drawing.Point(8, 258);
            this.grpCurSetup.Name = "grpCurSetup";
            this.grpCurSetup.Size = new System.Drawing.Size(696, 234);
            this.grpCurSetup.TabIndex = 1;
            this.grpCurSetup.TabStop = false;
            this.grpCurSetup.Text = "Current Config";
            // 
            // lblCurDefSingleton
            // 
            this.lblCurDefSingleton.AutoSize = true;
            this.lblCurDefSingleton.Location = new System.Drawing.Point(16, 194);
            this.lblCurDefSingleton.Name = "lblCurDefSingleton";
            this.lblCurDefSingleton.Size = new System.Drawing.Size(107, 17);
            this.lblCurDefSingleton.TabIndex = 14;
            this.lblCurDefSingleton.Text = "Single Mode: No";
            // 
            // lblCurDefAutoStartup
            // 
            this.lblCurDefAutoStartup.AutoSize = true;
            this.lblCurDefAutoStartup.Location = new System.Drawing.Point(16, 157);
            this.lblCurDefAutoStartup.Name = "lblCurDefAutoStartup";
            this.lblCurDefAutoStartup.Size = new System.Drawing.Size(101, 17);
            this.lblCurDefAutoStartup.TabIndex = 13;
            this.lblCurDefAutoStartup.Text = "Autostartup: No";
            // 
            // lblCurDefPort
            // 
            this.lblCurDefPort.AutoSize = true;
            this.lblCurDefPort.Location = new System.Drawing.Point(16, 120);
            this.lblCurDefPort.Name = "lblCurDefPort";
            this.lblCurDefPort.Size = new System.Drawing.Size(116, 17);
            this.lblCurDefPort.TabIndex = 12;
            this.lblCurDefPort.Text = "Default Port: None";
            // 
            // lblCurDefIP
            // 
            this.lblCurDefIP.AutoSize = true;
            this.lblCurDefIP.Location = new System.Drawing.Point(16, 83);
            this.lblCurDefIP.Name = "lblCurDefIP";
            this.lblCurDefIP.Size = new System.Drawing.Size(103, 17);
            this.lblCurDefIP.TabIndex = 11;
            this.lblCurDefIP.Text = "Default IP: None";
            // 
            // lblCurDefPriKeyPath
            // 
            this.lblCurDefPriKeyPath.AutoSize = true;
            this.lblCurDefPriKeyPath.Location = new System.Drawing.Point(16, 46);
            this.lblCurDefPriKeyPath.Name = "lblCurDefPriKeyPath";
            this.lblCurDefPriKeyPath.Size = new System.Drawing.Size(185, 17);
            this.lblCurDefPriKeyPath.TabIndex = 10;
            this.lblCurDefPriKeyPath.Text = "Default Private Key Path: None";
            // 
            // grpServerConfig
            // 
            this.grpServerConfig.Controls.Add(this.btnDefPubKeyBrowse);
            this.grpServerConfig.Controls.Add(this.txtDefPubKeyPath);
            this.grpServerConfig.Controls.Add(this.lblDefPubKey);
            this.grpServerConfig.Controls.Add(this.btnSave);
            this.grpServerConfig.Controls.Add(this.btnDefBrowse);
            this.grpServerConfig.Controls.Add(this.txtDefPriKeyPath);
            this.grpServerConfig.Controls.Add(this.lblDefPriKey);
            this.grpServerConfig.Controls.Add(this.txtDefPort);
            this.grpServerConfig.Controls.Add(this.txtDefIP);
            this.grpServerConfig.Controls.Add(this.lblDefPort);
            this.grpServerConfig.Controls.Add(this.lblDefIP);
            this.grpServerConfig.Controls.Add(this.chkSingleton);
            this.grpServerConfig.Controls.Add(this.chkAutostartup);
            this.grpServerConfig.Location = new System.Drawing.Point(8, 6);
            this.grpServerConfig.Name = "grpServerConfig";
            this.grpServerConfig.Size = new System.Drawing.Size(696, 246);
            this.grpServerConfig.TabIndex = 0;
            this.grpServerConfig.TabStop = false;
            this.grpServerConfig.Text = "Server Config Generator";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(380, 137);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(245, 40);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDefBrowse
            // 
            this.btnDefBrowse.Location = new System.Drawing.Point(590, 28);
            this.btnDefBrowse.Name = "btnDefBrowse";
            this.btnDefBrowse.Size = new System.Drawing.Size(81, 25);
            this.btnDefBrowse.TabIndex = 8;
            this.btnDefBrowse.Text = "Browse";
            this.btnDefBrowse.UseVisualStyleBackColor = true;
            this.btnDefBrowse.Click += new System.EventHandler(this.btnDefBrowse_Click);
            // 
            // txtDefPriKeyPath
            // 
            this.txtDefPriKeyPath.Location = new System.Drawing.Point(184, 29);
            this.txtDefPriKeyPath.Name = "txtDefPriKeyPath";
            this.txtDefPriKeyPath.Size = new System.Drawing.Size(400, 23);
            this.txtDefPriKeyPath.TabIndex = 7;
            // 
            // lblDefPriKey
            // 
            this.lblDefPriKey.AutoSize = true;
            this.lblDefPriKey.Location = new System.Drawing.Point(29, 32);
            this.lblDefPriKey.Name = "lblDefPriKey";
            this.lblDefPriKey.Size = new System.Drawing.Size(149, 17);
            this.lblDefPriKey.TabIndex = 6;
            this.lblDefPriKey.Text = "Default Private Key Path:";
            // 
            // txtDefPort
            // 
            this.txtDefPort.Location = new System.Drawing.Point(108, 160);
            this.txtDefPort.Name = "txtDefPort";
            this.txtDefPort.Size = new System.Drawing.Size(196, 23);
            this.txtDefPort.TabIndex = 5;
            // 
            // txtDefIP
            // 
            this.txtDefIP.Location = new System.Drawing.Point(108, 121);
            this.txtDefIP.Name = "txtDefIP";
            this.txtDefIP.Size = new System.Drawing.Size(196, 23);
            this.txtDefIP.TabIndex = 4;
            // 
            // lblDefPort
            // 
            this.lblDefPort.AutoSize = true;
            this.lblDefPort.Location = new System.Drawing.Point(22, 163);
            this.lblDefPort.Name = "lblDefPort";
            this.lblDefPort.Size = new System.Drawing.Size(80, 17);
            this.lblDefPort.TabIndex = 3;
            this.lblDefPort.Text = "Default Port:";
            // 
            // lblDefIP
            // 
            this.lblDefIP.AutoSize = true;
            this.lblDefIP.Location = new System.Drawing.Point(35, 124);
            this.lblDefIP.Name = "lblDefIP";
            this.lblDefIP.Size = new System.Drawing.Size(67, 17);
            this.lblDefIP.TabIndex = 2;
            this.lblDefIP.Text = "Default IP:";
            // 
            // chkSingleton
            // 
            this.chkSingleton.AutoSize = true;
            this.chkSingleton.Location = new System.Drawing.Point(166, 202);
            this.chkSingleton.Name = "chkSingleton";
            this.chkSingleton.Size = new System.Drawing.Size(101, 21);
            this.chkSingleton.TabIndex = 1;
            this.chkSingleton.Text = "Single Mode";
            this.chkSingleton.UseVisualStyleBackColor = true;
            // 
            // chkAutostartup
            // 
            this.chkAutostartup.AutoSize = true;
            this.chkAutostartup.Location = new System.Drawing.Point(50, 202);
            this.chkAutostartup.Name = "chkAutostartup";
            this.chkAutostartup.Size = new System.Drawing.Size(96, 21);
            this.chkAutostartup.TabIndex = 0;
            this.chkAutostartup.Text = "AutoStartup";
            this.chkAutostartup.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(712, 500);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "Builder";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnDefPubKeyBrowse
            // 
            this.btnDefPubKeyBrowse.Location = new System.Drawing.Point(590, 70);
            this.btnDefPubKeyBrowse.Name = "btnDefPubKeyBrowse";
            this.btnDefPubKeyBrowse.Size = new System.Drawing.Size(81, 25);
            this.btnDefPubKeyBrowse.TabIndex = 12;
            this.btnDefPubKeyBrowse.Text = "Browse";
            this.btnDefPubKeyBrowse.UseVisualStyleBackColor = true;
            this.btnDefPubKeyBrowse.Click += new System.EventHandler(this.btnDefPubKeyBrowse_Click);
            // 
            // txtDefPubKeyPath
            // 
            this.txtDefPubKeyPath.Location = new System.Drawing.Point(184, 71);
            this.txtDefPubKeyPath.Name = "txtDefPubKeyPath";
            this.txtDefPubKeyPath.Size = new System.Drawing.Size(400, 23);
            this.txtDefPubKeyPath.TabIndex = 11;
            // 
            // lblDefPubKey
            // 
            this.lblDefPubKey.AutoSize = true;
            this.lblDefPubKey.Location = new System.Drawing.Point(29, 74);
            this.lblDefPubKey.Name = "lblDefPubKey";
            this.lblDefPubKey.Size = new System.Drawing.Size(144, 17);
            this.lblDefPubKey.TabIndex = 10;
            this.lblDefPubKey.Text = "Default Public Key Path:";
            // 
            // FrmMainServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 530);
            this.Controls.Add(this.tabMain);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmMainServer";
            this.Text = "DarkChat";
            this.tabMain.ResumeLayout(false);
            this.tabServer.ResumeLayout(false);
            this.tabServer.PerformLayout();
            this.tagSafe.ResumeLayout(false);
            this.grpConfigKey.ResumeLayout(false);
            this.grpConfigKey.PerformLayout();
            this.grpKeyGen.ResumeLayout(false);
            this.grpKeyGen.PerformLayout();
            this.tabConfig.ResumeLayout(false);
            this.grpCurSetup.ResumeLayout(false);
            this.grpCurSetup.PerformLayout();
            this.grpServerConfig.ResumeLayout(false);
            this.grpServerConfig.PerformLayout();
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
        private System.Windows.Forms.TabPage tagSafe;
        private System.Windows.Forms.ListBox lstLogs;
        private System.Windows.Forms.Label lblLogs;
        private System.Windows.Forms.ColumnHeader colLastseen;
        private System.Windows.Forms.GroupBox grpKeyGen;
        private System.Windows.Forms.Button btnGen;
        private System.Windows.Forms.Button benBrowse;
        private System.Windows.Forms.TextBox txtKeysPath;
        private System.Windows.Forms.Label lblKeysSave;
        private System.Windows.Forms.GroupBox grpConfigKey;
        private System.Windows.Forms.Button btnBindPriKey;
        private System.Windows.Forms.Button btnPriBrowse;
        private System.Windows.Forms.TextBox txtPriKeyPath;
        private System.Windows.Forms.Label lblUsePriKey;
        private System.Windows.Forms.Label lblBindStatus;
        private System.Windows.Forms.TabPage tabConfig;
        private System.Windows.Forms.GroupBox grpServerConfig;
        private System.Windows.Forms.TextBox txtDefPort;
        private System.Windows.Forms.TextBox txtDefIP;
        private System.Windows.Forms.Label lblDefPort;
        private System.Windows.Forms.Label lblDefIP;
        private System.Windows.Forms.CheckBox chkSingleton;
        private System.Windows.Forms.CheckBox chkAutostartup;
        private System.Windows.Forms.Label lblDefPriKey;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDefBrowse;
        private System.Windows.Forms.TextBox txtDefPriKeyPath;
        private System.Windows.Forms.GroupBox grpCurSetup;
        private System.Windows.Forms.Label lblCurDefSingleton;
        private System.Windows.Forms.Label lblCurDefAutoStartup;
        private System.Windows.Forms.Label lblCurDefPort;
        private System.Windows.Forms.Label lblCurDefIP;
        private System.Windows.Forms.Label lblCurDefPriKeyPath;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnDefPubKeyBrowse;
        private System.Windows.Forms.TextBox txtDefPubKeyPath;
        private System.Windows.Forms.Label lblDefPubKey;
    }
}

