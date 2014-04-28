namespace WebradioManager
{
    partial class AdminView
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            Calendar.DrawTool drawTool1 = new Calendar.DrawTool();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminView));
            this.dvwTimetable = new Calendar.DayView();
            this.mnsMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbcTabs = new System.Windows.Forms.TabControl();
            this.tbpStatus = new System.Windows.Forms.TabPage();
            this.groupBox21 = new System.Windows.Forms.GroupBox();
            this.groupBox20 = new System.Windows.Forms.GroupBox();
            this.btnModifyName = new System.Windows.Forms.Button();
            this.txbWebradioName = new System.Windows.Forms.TextBox();
            this.lblWebradioTitle = new System.Windows.Forms.Label();
            this.tbpLibrary = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDeleteAd = new System.Windows.Forms.Button();
            this.dgvAds = new System.Windows.Forms.DataGridView();
            this.colIdAd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTitleAd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colArtistAd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAlbumAd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colYearAd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLabelAd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDurationAd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGenderAd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPathAd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbPlaylistsAd = new System.Windows.Forms.ComboBox();
            this.txbSearchAd = new System.Windows.Forms.TextBox();
            this.btnAddToAd = new System.Windows.Forms.Button();
            this.btnImportFolderAd = new System.Windows.Forms.Button();
            this.btnImportFilesAd = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDeleteMusic = new System.Windows.Forms.Button();
            this.cmbPlaylistsMusic = new System.Windows.Forms.ComboBox();
            this.btnAddToMusic = new System.Windows.Forms.Button();
            this.dgvMusics = new System.Windows.Forms.DataGridView();
            this.colIdMusic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTitleMusic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colArtistMusic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAlbumMusic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colYearMusic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLabelMusic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDurationMusic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGenderMusic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPathMusic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnImportFilesMusic = new System.Windows.Forms.Button();
            this.btnImportFolderMusic = new System.Windows.Forms.Button();
            this.txbSearchMusic = new System.Windows.Forms.TextBox();
            this.tbpPlaylists = new System.Windows.Forms.TabPage();
            this.dgvPlaylistContent = new System.Windows.Forms.DataGridView();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnDeletePlaylistAd = new System.Windows.Forms.Button();
            this.lsbPlaylistsAd = new System.Windows.Forms.ListBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnDeletePlaylistMusic = new System.Windows.Forms.Button();
            this.lsbPlaylistsMusic = new System.Windows.Forms.ListBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.nudDurationGenerate = new System.Windows.Forms.NumericUpDown();
            this.btnGeneratePlaylist = new System.Windows.Forms.Button();
            this.cmbGenderGenerate = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbTypePlaylistGenerate = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txbPlaylistNameGenerate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnCreatePlaylist = new System.Windows.Forms.Button();
            this.cmbTypePlaylist = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbPlaylistName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbpTimetable = new System.Windows.Forms.TabPage();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.btnCreateEvent = new System.Windows.Forms.Button();
            this.nudPriority = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.ckbShuffle = new System.Windows.Forms.CheckBox();
            this.txbDuration = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txbStartTime = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.ckbAll = new System.Windows.Forms.CheckBox();
            this.ckbSunday = new System.Windows.Forms.CheckBox();
            this.ckbSaturday = new System.Windows.Forms.CheckBox();
            this.ckbFriday = new System.Windows.Forms.CheckBox();
            this.ckbThursday = new System.Windows.Forms.CheckBox();
            this.ckbWednesday = new System.Windows.Forms.CheckBox();
            this.ckbTuesday = new System.Windows.Forms.CheckBox();
            this.ckbMonday = new System.Windows.Forms.CheckBox();
            this.cmbPlaylistEvent = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txbEventName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbpTranscoders = new System.Windows.Forms.TabPage();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.btnStopTranscoder = new System.Windows.Forms.Button();
            this.btnStartTranscoder = new System.Windows.Forms.Button();
            this.lblStatusTranscoder = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.btnClearLogTranscoder = new System.Windows.Forms.Button();
            this.lsbTranscoderLog = new System.Windows.Forms.ListBox();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.btnClearHistory = new System.Windows.Forms.Button();
            this.btnShowHistory = new System.Windows.Forms.Button();
            this.txbTranscoderNameEdit = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.btnDeleteTranscoder = new System.Windows.Forms.Button();
            this.lsbTranscoders = new System.Windows.Forms.ListBox();
            this.label28 = new System.Windows.Forms.Label();
            this.cmbEncoderEdit = new System.Windows.Forms.ComboBox();
            this.txbServerIpEdit = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.cmbBitrateEdit = new System.Windows.Forms.ComboBox();
            this.txbStreamUrlEdit = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.cmbSampleRateEdit = new System.Windows.Forms.ComboBox();
            this.txbStreamNameEdit = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.nudPortEdit = new System.Windows.Forms.NumericUpDown();
            this.txbServerPasswordEdit = new System.Windows.Forms.TextBox();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.btnCreateTranscoder = new System.Windows.Forms.Button();
            this.txbServerPassword = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.nupPort = new System.Windows.Forms.NumericUpDown();
            this.label18 = new System.Windows.Forms.Label();
            this.txbServerIp = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txbStreamUrl = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txbStreamName = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cmbSampleRate = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbBitrate = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbEncoder = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbpServer = new System.Windows.Forms.TabPage();
            this.groupBox19 = new System.Windows.Forms.GroupBox();
            this.btnClearLogServer = new System.Windows.Forms.Button();
            this.lsbLogServer = new System.Windows.Forms.ListBox();
            this.groupBox18 = new System.Windows.Forms.GroupBox();
            this.btnSaveServer = new System.Windows.Forms.Button();
            this.nudMaxListener = new System.Windows.Forms.NumericUpDown();
            this.label35 = new System.Windows.Forms.Label();
            this.txbLocalServerAdminPassword = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.txbLocalServerPassword = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.nudPortServer = new System.Windows.Forms.NumericUpDown();
            this.label32 = new System.Windows.Forms.Label();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.btnShowWebAdministration = new System.Windows.Forms.Button();
            this.btnShowWebInterface = new System.Windows.Forms.Button();
            this.btnStopServer = new System.Windows.Forms.Button();
            this.btnStartServer = new System.Windows.Forms.Button();
            this.lblStatusServer = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.FBD = new System.Windows.Forms.FolderBrowserDialog();
            this.OFD = new System.Windows.Forms.OpenFileDialog();
            this.mnsMain.SuspendLayout();
            this.tbcTabs.SuspendLayout();
            this.tbpStatus.SuspendLayout();
            this.groupBox20.SuspendLayout();
            this.tbpLibrary.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAds)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMusics)).BeginInit();
            this.tbpPlaylists.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlaylistContent)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDurationGenerate)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.tbpTimetable.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPriority)).BeginInit();
            this.groupBox10.SuspendLayout();
            this.tbpTranscoders.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox16.SuspendLayout();
            this.groupBox15.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.groupBox13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPortEdit)).BeginInit();
            this.groupBox11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupPort)).BeginInit();
            this.tbpServer.SuspendLayout();
            this.groupBox19.SuspendLayout();
            this.groupBox18.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxListener)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPortServer)).BeginInit();
            this.groupBox17.SuspendLayout();
            this.SuspendLayout();
            // 
            // dvwTimetable
            // 
            drawTool1.DayView = this.dvwTimetable;
            this.dvwTimetable.ActiveTool = drawTool1;
            this.dvwTimetable.AmPmDisplay = false;
            this.dvwTimetable.AppHeightMode = Calendar.DayView.AppHeightDrawMode.TrueHeightAll;
            this.dvwTimetable.DaysToShow = 7;
            this.dvwTimetable.DrawAllAppBorder = false;
            this.dvwTimetable.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.dvwTimetable.Location = new System.Drawing.Point(7, 20);
            this.dvwTimetable.MinHalfHourApp = false;
            this.dvwTimetable.Name = "dvwTimetable";
            this.dvwTimetable.SelectionEnd = new System.DateTime(((long)(0)));
            this.dvwTimetable.SelectionStart = new System.DateTime(((long)(0)));
            this.dvwTimetable.Size = new System.Drawing.Size(807, 332);
            this.dvwTimetable.SlotsPerHour = 2;
            this.dvwTimetable.StartDate = new System.DateTime(((long)(0)));
            this.dvwTimetable.TabIndex = 0;
            this.dvwTimetable.Text = "dayView1";
            this.dvwTimetable.WorkingHourEnd = 23;
            this.dvwTimetable.WorkingHourStart = 0;
            this.dvwTimetable.WorkingMinuteEnd = 59;
            this.dvwTimetable.WorkingMinuteStart = 0;
            this.dvwTimetable.SelectionChanged += new System.EventHandler(this.dvwTimetable_SelectionChanged);
            this.dvwTimetable.ResolveAppointments += new Calendar.ResolveAppointmentsEventHandler(this.dvwTimetable_ResolveAppointments);
            this.dvwTimetable.NewAppointment += new Calendar.NewAppointmentEventHandler(this.dvwTimetable_NewAppointment);
            // 
            // mnsMain
            // 
            this.mnsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.mnsMain.Location = new System.Drawing.Point(0, 0);
            this.mnsMain.Name = "mnsMain";
            this.mnsMain.Size = new System.Drawing.Size(840, 24);
            this.mnsMain.TabIndex = 0;
            this.mnsMain.Text = "mnsMain";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // tbcTabs
            // 
            this.tbcTabs.Controls.Add(this.tbpStatus);
            this.tbcTabs.Controls.Add(this.tbpLibrary);
            this.tbcTabs.Controls.Add(this.tbpPlaylists);
            this.tbcTabs.Controls.Add(this.tbpTimetable);
            this.tbcTabs.Controls.Add(this.tbpTranscoders);
            this.tbcTabs.Controls.Add(this.tbpServer);
            this.tbcTabs.Location = new System.Drawing.Point(0, 28);
            this.tbcTabs.Multiline = true;
            this.tbcTabs.Name = "tbcTabs";
            this.tbcTabs.SelectedIndex = 0;
            this.tbcTabs.Size = new System.Drawing.Size(840, 471);
            this.tbcTabs.TabIndex = 1;
            // 
            // tbpStatus
            // 
            this.tbpStatus.Controls.Add(this.groupBox21);
            this.tbpStatus.Controls.Add(this.groupBox20);
            this.tbpStatus.Controls.Add(this.lblWebradioTitle);
            this.tbpStatus.Location = new System.Drawing.Point(4, 22);
            this.tbpStatus.Name = "tbpStatus";
            this.tbpStatus.Padding = new System.Windows.Forms.Padding(3);
            this.tbpStatus.Size = new System.Drawing.Size(832, 445);
            this.tbpStatus.TabIndex = 0;
            this.tbpStatus.Text = "Status";
            this.tbpStatus.UseVisualStyleBackColor = true;
            // 
            // groupBox21
            // 
            this.groupBox21.Location = new System.Drawing.Point(7, 246);
            this.groupBox21.Name = "groupBox21";
            this.groupBox21.Size = new System.Drawing.Size(200, 190);
            this.groupBox21.TabIndex = 2;
            this.groupBox21.TabStop = false;
            this.groupBox21.Text = "Status";
            // 
            // groupBox20
            // 
            this.groupBox20.Controls.Add(this.btnModifyName);
            this.groupBox20.Controls.Add(this.txbWebradioName);
            this.groupBox20.Location = new System.Drawing.Point(7, 162);
            this.groupBox20.Name = "groupBox20";
            this.groupBox20.Size = new System.Drawing.Size(200, 78);
            this.groupBox20.TabIndex = 1;
            this.groupBox20.TabStop = false;
            this.groupBox20.Text = "Name";
            // 
            // btnModifyName
            // 
            this.btnModifyName.Location = new System.Drawing.Point(64, 46);
            this.btnModifyName.Name = "btnModifyName";
            this.btnModifyName.Size = new System.Drawing.Size(75, 23);
            this.btnModifyName.TabIndex = 1;
            this.btnModifyName.Text = "Modify";
            this.btnModifyName.UseVisualStyleBackColor = true;
            // 
            // txbWebradioName
            // 
            this.txbWebradioName.Location = new System.Drawing.Point(7, 20);
            this.txbWebradioName.Name = "txbWebradioName";
            this.txbWebradioName.Size = new System.Drawing.Size(187, 20);
            this.txbWebradioName.TabIndex = 0;
            // 
            // lblWebradioTitle
            // 
            this.lblWebradioTitle.AutoSize = true;
            this.lblWebradioTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWebradioTitle.Location = new System.Drawing.Point(9, 7);
            this.lblWebradioTitle.Name = "lblWebradioTitle";
            this.lblWebradioTitle.Size = new System.Drawing.Size(109, 33);
            this.lblWebradioTitle.TabIndex = 0;
            this.lblWebradioTitle.Text = "label20";
            // 
            // tbpLibrary
            // 
            this.tbpLibrary.Controls.Add(this.groupBox2);
            this.tbpLibrary.Controls.Add(this.groupBox1);
            this.tbpLibrary.Location = new System.Drawing.Point(4, 22);
            this.tbpLibrary.Name = "tbpLibrary";
            this.tbpLibrary.Padding = new System.Windows.Forms.Padding(3);
            this.tbpLibrary.Size = new System.Drawing.Size(832, 445);
            this.tbpLibrary.TabIndex = 1;
            this.tbpLibrary.Text = "Library";
            this.tbpLibrary.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDeleteAd);
            this.groupBox2.Controls.Add(this.dgvAds);
            this.groupBox2.Controls.Add(this.cmbPlaylistsAd);
            this.groupBox2.Controls.Add(this.txbSearchAd);
            this.groupBox2.Controls.Add(this.btnAddToAd);
            this.groupBox2.Controls.Add(this.btnImportFolderAd);
            this.groupBox2.Controls.Add(this.btnImportFilesAd);
            this.groupBox2.Location = new System.Drawing.Point(3, 226);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(815, 215);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ad";
            // 
            // btnDeleteAd
            // 
            this.btnDeleteAd.Location = new System.Drawing.Point(709, 17);
            this.btnDeleteAd.Name = "btnDeleteAd";
            this.btnDeleteAd.Size = new System.Drawing.Size(100, 23);
            this.btnDeleteAd.TabIndex = 13;
            this.btnDeleteAd.Tag = "Ad";
            this.btnDeleteAd.Text = "Delete selected";
            this.btnDeleteAd.UseVisualStyleBackColor = true;
            this.btnDeleteAd.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dgvAds
            // 
            this.dgvAds.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAds.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdAd,
            this.colTitleAd,
            this.colArtistAd,
            this.colAlbumAd,
            this.colYearAd,
            this.colLabelAd,
            this.colDurationAd,
            this.colGenderAd,
            this.colPathAd});
            this.dgvAds.Location = new System.Drawing.Point(7, 47);
            this.dgvAds.Name = "dgvAds";
            this.dgvAds.ReadOnly = true;
            this.dgvAds.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAds.Size = new System.Drawing.Size(802, 162);
            this.dgvAds.TabIndex = 10;
            // 
            // colIdAd
            // 
            this.colIdAd.HeaderText = "Id";
            this.colIdAd.Name = "colIdAd";
            this.colIdAd.ReadOnly = true;
            // 
            // colTitleAd
            // 
            this.colTitleAd.HeaderText = "Title";
            this.colTitleAd.Name = "colTitleAd";
            this.colTitleAd.ReadOnly = true;
            // 
            // colArtistAd
            // 
            this.colArtistAd.HeaderText = "Artist";
            this.colArtistAd.Name = "colArtistAd";
            this.colArtistAd.ReadOnly = true;
            // 
            // colAlbumAd
            // 
            this.colAlbumAd.HeaderText = "Album";
            this.colAlbumAd.Name = "colAlbumAd";
            this.colAlbumAd.ReadOnly = true;
            // 
            // colYearAd
            // 
            this.colYearAd.HeaderText = "Year";
            this.colYearAd.Name = "colYearAd";
            this.colYearAd.ReadOnly = true;
            // 
            // colLabelAd
            // 
            this.colLabelAd.HeaderText = "Label";
            this.colLabelAd.Name = "colLabelAd";
            this.colLabelAd.ReadOnly = true;
            // 
            // colDurationAd
            // 
            this.colDurationAd.HeaderText = "Duration";
            this.colDurationAd.Name = "colDurationAd";
            this.colDurationAd.ReadOnly = true;
            // 
            // colGenderAd
            // 
            this.colGenderAd.HeaderText = "Gender";
            this.colGenderAd.Name = "colGenderAd";
            this.colGenderAd.ReadOnly = true;
            // 
            // colPathAd
            // 
            this.colPathAd.HeaderText = "Path";
            this.colPathAd.Name = "colPathAd";
            this.colPathAd.ReadOnly = true;
            // 
            // cmbPlaylistsAd
            // 
            this.cmbPlaylistsAd.FormattingEnabled = true;
            this.cmbPlaylistsAd.Location = new System.Drawing.Point(522, 19);
            this.cmbPlaylistsAd.Name = "cmbPlaylistsAd";
            this.cmbPlaylistsAd.Size = new System.Drawing.Size(121, 21);
            this.cmbPlaylistsAd.TabIndex = 12;
            // 
            // txbSearchAd
            // 
            this.txbSearchAd.Location = new System.Drawing.Point(7, 20);
            this.txbSearchAd.Name = "txbSearchAd";
            this.txbSearchAd.Size = new System.Drawing.Size(100, 20);
            this.txbSearchAd.TabIndex = 7;
            this.txbSearchAd.Tag = "Ad";
            this.txbSearchAd.Text = "Search...";
            this.txbSearchAd.TextChanged += new System.EventHandler(this.txbSearchTextChanged);
            this.txbSearchAd.Enter += new System.EventHandler(this.txbSearchEnter);
            this.txbSearchAd.Leave += new System.EventHandler(this.txbSearchLeave);
            // 
            // btnAddToAd
            // 
            this.btnAddToAd.Location = new System.Drawing.Point(415, 18);
            this.btnAddToAd.Name = "btnAddToAd";
            this.btnAddToAd.Size = new System.Drawing.Size(100, 23);
            this.btnAddToAd.TabIndex = 11;
            this.btnAddToAd.Text = "Add selected to :";
            this.btnAddToAd.UseVisualStyleBackColor = true;
            // 
            // btnImportFolderAd
            // 
            this.btnImportFolderAd.Location = new System.Drawing.Point(113, 18);
            this.btnImportFolderAd.Name = "btnImportFolderAd";
            this.btnImportFolderAd.Size = new System.Drawing.Size(112, 23);
            this.btnImportFolderAd.TabIndex = 8;
            this.btnImportFolderAd.Tag = "Ad";
            this.btnImportFolderAd.Text = "Import from folder...";
            this.btnImportFolderAd.UseVisualStyleBackColor = true;
            this.btnImportFolderAd.Click += new System.EventHandler(this.ImportFolder_Click);
            // 
            // btnImportFilesAd
            // 
            this.btnImportFilesAd.Location = new System.Drawing.Point(231, 18);
            this.btnImportFilesAd.Name = "btnImportFilesAd";
            this.btnImportFilesAd.Size = new System.Drawing.Size(112, 23);
            this.btnImportFilesAd.TabIndex = 9;
            this.btnImportFilesAd.Tag = "Ad";
            this.btnImportFilesAd.Text = "Import from files...";
            this.btnImportFilesAd.UseVisualStyleBackColor = true;
            this.btnImportFilesAd.Click += new System.EventHandler(this.ImportFiles_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDeleteMusic);
            this.groupBox1.Controls.Add(this.cmbPlaylistsMusic);
            this.groupBox1.Controls.Add(this.btnAddToMusic);
            this.groupBox1.Controls.Add(this.dgvMusics);
            this.groupBox1.Controls.Add(this.btnImportFilesMusic);
            this.groupBox1.Controls.Add(this.btnImportFolderMusic);
            this.groupBox1.Controls.Add(this.txbSearchMusic);
            this.groupBox1.Location = new System.Drawing.Point(3, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(815, 215);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Music";
            // 
            // btnDeleteMusic
            // 
            this.btnDeleteMusic.Location = new System.Drawing.Point(709, 17);
            this.btnDeleteMusic.Name = "btnDeleteMusic";
            this.btnDeleteMusic.Size = new System.Drawing.Size(100, 23);
            this.btnDeleteMusic.TabIndex = 6;
            this.btnDeleteMusic.Tag = "Music";
            this.btnDeleteMusic.Text = "Delete selected";
            this.btnDeleteMusic.UseVisualStyleBackColor = true;
            this.btnDeleteMusic.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // cmbPlaylistsMusic
            // 
            this.cmbPlaylistsMusic.FormattingEnabled = true;
            this.cmbPlaylistsMusic.Location = new System.Drawing.Point(522, 19);
            this.cmbPlaylistsMusic.Name = "cmbPlaylistsMusic";
            this.cmbPlaylistsMusic.Size = new System.Drawing.Size(121, 21);
            this.cmbPlaylistsMusic.TabIndex = 5;
            // 
            // btnAddToMusic
            // 
            this.btnAddToMusic.Location = new System.Drawing.Point(415, 18);
            this.btnAddToMusic.Name = "btnAddToMusic";
            this.btnAddToMusic.Size = new System.Drawing.Size(100, 23);
            this.btnAddToMusic.TabIndex = 4;
            this.btnAddToMusic.Text = "Add selected to :";
            this.btnAddToMusic.UseVisualStyleBackColor = true;
            // 
            // dgvMusics
            // 
            this.dgvMusics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMusics.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdMusic,
            this.colTitleMusic,
            this.colArtistMusic,
            this.colAlbumMusic,
            this.colYearMusic,
            this.colLabelMusic,
            this.colDurationMusic,
            this.colGenderMusic,
            this.colPathMusic});
            this.dgvMusics.Location = new System.Drawing.Point(7, 47);
            this.dgvMusics.Name = "dgvMusics";
            this.dgvMusics.ReadOnly = true;
            this.dgvMusics.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMusics.Size = new System.Drawing.Size(802, 162);
            this.dgvMusics.TabIndex = 3;
            // 
            // colIdMusic
            // 
            this.colIdMusic.HeaderText = "Id";
            this.colIdMusic.Name = "colIdMusic";
            this.colIdMusic.ReadOnly = true;
            // 
            // colTitleMusic
            // 
            this.colTitleMusic.HeaderText = "Title";
            this.colTitleMusic.Name = "colTitleMusic";
            this.colTitleMusic.ReadOnly = true;
            // 
            // colArtistMusic
            // 
            this.colArtistMusic.HeaderText = "Artist";
            this.colArtistMusic.Name = "colArtistMusic";
            this.colArtistMusic.ReadOnly = true;
            // 
            // colAlbumMusic
            // 
            this.colAlbumMusic.HeaderText = "Album";
            this.colAlbumMusic.Name = "colAlbumMusic";
            this.colAlbumMusic.ReadOnly = true;
            // 
            // colYearMusic
            // 
            this.colYearMusic.HeaderText = "Year";
            this.colYearMusic.Name = "colYearMusic";
            this.colYearMusic.ReadOnly = true;
            // 
            // colLabelMusic
            // 
            this.colLabelMusic.HeaderText = "Label";
            this.colLabelMusic.Name = "colLabelMusic";
            this.colLabelMusic.ReadOnly = true;
            // 
            // colDurationMusic
            // 
            this.colDurationMusic.HeaderText = "Duration";
            this.colDurationMusic.Name = "colDurationMusic";
            this.colDurationMusic.ReadOnly = true;
            // 
            // colGenderMusic
            // 
            this.colGenderMusic.HeaderText = "Gender";
            this.colGenderMusic.Name = "colGenderMusic";
            this.colGenderMusic.ReadOnly = true;
            // 
            // colPathMusic
            // 
            this.colPathMusic.HeaderText = "Path";
            this.colPathMusic.Name = "colPathMusic";
            this.colPathMusic.ReadOnly = true;
            // 
            // btnImportFilesMusic
            // 
            this.btnImportFilesMusic.Location = new System.Drawing.Point(231, 18);
            this.btnImportFilesMusic.Name = "btnImportFilesMusic";
            this.btnImportFilesMusic.Size = new System.Drawing.Size(112, 23);
            this.btnImportFilesMusic.TabIndex = 2;
            this.btnImportFilesMusic.Tag = "Music";
            this.btnImportFilesMusic.Text = "Import from files...";
            this.btnImportFilesMusic.UseVisualStyleBackColor = true;
            this.btnImportFilesMusic.Click += new System.EventHandler(this.ImportFiles_Click);
            // 
            // btnImportFolderMusic
            // 
            this.btnImportFolderMusic.Location = new System.Drawing.Point(113, 18);
            this.btnImportFolderMusic.Name = "btnImportFolderMusic";
            this.btnImportFolderMusic.Size = new System.Drawing.Size(112, 23);
            this.btnImportFolderMusic.TabIndex = 1;
            this.btnImportFolderMusic.Tag = "Music";
            this.btnImportFolderMusic.Text = "Import from folder...";
            this.btnImportFolderMusic.UseVisualStyleBackColor = true;
            this.btnImportFolderMusic.Click += new System.EventHandler(this.ImportFolder_Click);
            // 
            // txbSearchMusic
            // 
            this.txbSearchMusic.Location = new System.Drawing.Point(7, 20);
            this.txbSearchMusic.Name = "txbSearchMusic";
            this.txbSearchMusic.Size = new System.Drawing.Size(100, 20);
            this.txbSearchMusic.TabIndex = 0;
            this.txbSearchMusic.Tag = "Music";
            this.txbSearchMusic.Text = "Search...";
            this.txbSearchMusic.TextChanged += new System.EventHandler(this.txbSearchTextChanged);
            this.txbSearchMusic.Enter += new System.EventHandler(this.txbSearchEnter);
            this.txbSearchMusic.Leave += new System.EventHandler(this.txbSearchLeave);
            // 
            // tbpPlaylists
            // 
            this.tbpPlaylists.Controls.Add(this.dgvPlaylistContent);
            this.tbpPlaylists.Controls.Add(this.groupBox7);
            this.tbpPlaylists.Controls.Add(this.groupBox6);
            this.tbpPlaylists.Controls.Add(this.groupBox5);
            this.tbpPlaylists.Controls.Add(this.groupBox4);
            this.tbpPlaylists.Controls.Add(this.groupBox3);
            this.tbpPlaylists.Location = new System.Drawing.Point(4, 22);
            this.tbpPlaylists.Name = "tbpPlaylists";
            this.tbpPlaylists.Size = new System.Drawing.Size(832, 445);
            this.tbpPlaylists.TabIndex = 2;
            this.tbpPlaylists.Text = "Playlists";
            this.tbpPlaylists.UseVisualStyleBackColor = true;
            // 
            // dgvPlaylistContent
            // 
            this.dgvPlaylistContent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlaylistContent.Location = new System.Drawing.Point(188, 155);
            this.dgvPlaylistContent.Name = "dgvPlaylistContent";
            this.dgvPlaylistContent.Size = new System.Drawing.Size(636, 287);
            this.dgvPlaylistContent.TabIndex = 5;
            // 
            // groupBox7
            // 
            this.groupBox7.Location = new System.Drawing.Point(188, 79);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(636, 69);
            this.groupBox7.TabIndex = 4;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Informations";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnDeletePlaylistAd);
            this.groupBox6.Controls.Add(this.lsbPlaylistsAd);
            this.groupBox6.Location = new System.Drawing.Point(9, 261);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(172, 181);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Ad";
            // 
            // btnDeletePlaylistAd
            // 
            this.btnDeletePlaylistAd.Location = new System.Drawing.Point(48, 152);
            this.btnDeletePlaylistAd.Name = "btnDeletePlaylistAd";
            this.btnDeletePlaylistAd.Size = new System.Drawing.Size(75, 23);
            this.btnDeletePlaylistAd.TabIndex = 2;
            this.btnDeletePlaylistAd.Text = "Delete";
            this.btnDeletePlaylistAd.UseVisualStyleBackColor = true;
            // 
            // lsbPlaylistsAd
            // 
            this.lsbPlaylistsAd.FormattingEnabled = true;
            this.lsbPlaylistsAd.Location = new System.Drawing.Point(7, 19);
            this.lsbPlaylistsAd.Name = "lsbPlaylistsAd";
            this.lsbPlaylistsAd.Size = new System.Drawing.Size(159, 121);
            this.lsbPlaylistsAd.TabIndex = 1;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnDeletePlaylistMusic);
            this.groupBox5.Controls.Add(this.lsbPlaylistsMusic);
            this.groupBox5.Location = new System.Drawing.Point(9, 79);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(172, 181);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Music";
            // 
            // btnDeletePlaylistMusic
            // 
            this.btnDeletePlaylistMusic.Location = new System.Drawing.Point(48, 152);
            this.btnDeletePlaylistMusic.Name = "btnDeletePlaylistMusic";
            this.btnDeletePlaylistMusic.Size = new System.Drawing.Size(75, 23);
            this.btnDeletePlaylistMusic.TabIndex = 1;
            this.btnDeletePlaylistMusic.Text = "Delete";
            this.btnDeletePlaylistMusic.UseVisualStyleBackColor = true;
            // 
            // lsbPlaylistsMusic
            // 
            this.lsbPlaylistsMusic.FormattingEnabled = true;
            this.lsbPlaylistsMusic.Location = new System.Drawing.Point(7, 20);
            this.lsbPlaylistsMusic.Name = "lsbPlaylistsMusic";
            this.lsbPlaylistsMusic.Size = new System.Drawing.Size(159, 121);
            this.lsbPlaylistsMusic.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.nudDurationGenerate);
            this.groupBox4.Controls.Add(this.btnGeneratePlaylist);
            this.groupBox4.Controls.Add(this.cmbGenderGenerate);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.cmbTypePlaylistGenerate);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.txbPlaylistNameGenerate);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Location = new System.Drawing.Point(281, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(543, 68);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Generate";
            // 
            // nudDurationGenerate
            // 
            this.nudDurationGenerate.Location = new System.Drawing.Point(161, 35);
            this.nudDurationGenerate.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudDurationGenerate.Name = "nudDurationGenerate";
            this.nudDurationGenerate.Size = new System.Drawing.Size(77, 20);
            this.nudDurationGenerate.TabIndex = 12;
            // 
            // btnGeneratePlaylist
            // 
            this.btnGeneratePlaylist.Location = new System.Drawing.Point(462, 32);
            this.btnGeneratePlaylist.Name = "btnGeneratePlaylist";
            this.btnGeneratePlaylist.Size = new System.Drawing.Size(75, 23);
            this.btnGeneratePlaylist.TabIndex = 11;
            this.btnGeneratePlaylist.Text = "Generate";
            this.btnGeneratePlaylist.UseVisualStyleBackColor = true;
            // 
            // cmbGenderGenerate
            // 
            this.cmbGenderGenerate.FormattingEnabled = true;
            this.cmbGenderGenerate.Items.AddRange(new object[] {
            "Music",
            "Ad"});
            this.cmbGenderGenerate.Location = new System.Drawing.Point(352, 37);
            this.cmbGenderGenerate.Name = "cmbGenderGenerate";
            this.cmbGenderGenerate.Size = new System.Drawing.Size(93, 21);
            this.cmbGenderGenerate.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(349, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Gender :";
            // 
            // cmbTypePlaylistGenerate
            // 
            this.cmbTypePlaylistGenerate.FormattingEnabled = true;
            this.cmbTypePlaylistGenerate.Items.AddRange(new object[] {
            "Music",
            "Ad"});
            this.cmbTypePlaylistGenerate.Location = new System.Drawing.Point(269, 37);
            this.cmbTypePlaylistGenerate.Name = "cmbTypePlaylistGenerate";
            this.cmbTypePlaylistGenerate.Size = new System.Drawing.Size(58, 21);
            this.cmbTypePlaylistGenerate.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(266, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Type :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(158, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Duration (minute) :";
            // 
            // txbPlaylistNameGenerate
            // 
            this.txbPlaylistNameGenerate.Location = new System.Drawing.Point(9, 36);
            this.txbPlaylistNameGenerate.Name = "txbPlaylistNameGenerate";
            this.txbPlaylistNameGenerate.Size = new System.Drawing.Size(146, 20);
            this.txbPlaylistNameGenerate.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Playlist name :";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnCreatePlaylist);
            this.groupBox3.Controls.Add(this.cmbTypePlaylist);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.txbPlaylistName);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(9, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(266, 68);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Create";
            // 
            // btnCreatePlaylist
            // 
            this.btnCreatePlaylist.Location = new System.Drawing.Point(179, 36);
            this.btnCreatePlaylist.Name = "btnCreatePlaylist";
            this.btnCreatePlaylist.Size = new System.Drawing.Size(75, 23);
            this.btnCreatePlaylist.TabIndex = 4;
            this.btnCreatePlaylist.Text = "Create";
            this.btnCreatePlaylist.UseVisualStyleBackColor = true;
            this.btnCreatePlaylist.Click += new System.EventHandler(this.btnCreatePlaylist_Click);
            // 
            // cmbTypePlaylist
            // 
            this.cmbTypePlaylist.FormattingEnabled = true;
            this.cmbTypePlaylist.Items.AddRange(new object[] {
            "Music",
            "Ad"});
            this.cmbTypePlaylist.Location = new System.Drawing.Point(114, 37);
            this.cmbTypePlaylist.Name = "cmbTypePlaylist";
            this.cmbTypePlaylist.Size = new System.Drawing.Size(58, 21);
            this.cmbTypePlaylist.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(111, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Type :";
            // 
            // txbPlaylistName
            // 
            this.txbPlaylistName.Location = new System.Drawing.Point(10, 37);
            this.txbPlaylistName.Name = "txbPlaylistName";
            this.txbPlaylistName.Size = new System.Drawing.Size(100, 20);
            this.txbPlaylistName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Playlist name :";
            // 
            // tbpTimetable
            // 
            this.tbpTimetable.Controls.Add(this.groupBox9);
            this.tbpTimetable.Controls.Add(this.groupBox8);
            this.tbpTimetable.Location = new System.Drawing.Point(4, 22);
            this.tbpTimetable.Name = "tbpTimetable";
            this.tbpTimetable.Size = new System.Drawing.Size(832, 445);
            this.tbpTimetable.TabIndex = 3;
            this.tbpTimetable.Text = "Timetable";
            this.tbpTimetable.UseVisualStyleBackColor = true;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.dvwTimetable);
            this.groupBox9.Location = new System.Drawing.Point(4, 84);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(820, 358);
            this.groupBox9.TabIndex = 1;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Timetable";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.btnCreateEvent);
            this.groupBox8.Controls.Add(this.nudPriority);
            this.groupBox8.Controls.Add(this.label11);
            this.groupBox8.Controls.Add(this.ckbShuffle);
            this.groupBox8.Controls.Add(this.txbDuration);
            this.groupBox8.Controls.Add(this.label10);
            this.groupBox8.Controls.Add(this.txbStartTime);
            this.groupBox8.Controls.Add(this.label9);
            this.groupBox8.Controls.Add(this.groupBox10);
            this.groupBox8.Controls.Add(this.cmbPlaylistEvent);
            this.groupBox8.Controls.Add(this.label8);
            this.groupBox8.Controls.Add(this.txbEventName);
            this.groupBox8.Controls.Add(this.label7);
            this.groupBox8.Location = new System.Drawing.Point(4, 4);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(820, 74);
            this.groupBox8.TabIndex = 0;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Create event";
            // 
            // btnCreateEvent
            // 
            this.btnCreateEvent.Location = new System.Drawing.Point(760, 28);
            this.btnCreateEvent.Name = "btnCreateEvent";
            this.btnCreateEvent.Size = new System.Drawing.Size(54, 23);
            this.btnCreateEvent.TabIndex = 12;
            this.btnCreateEvent.Text = "Create";
            this.btnCreateEvent.UseVisualStyleBackColor = true;
            // 
            // nudPriority
            // 
            this.nudPriority.Location = new System.Drawing.Point(692, 44);
            this.nudPriority.Name = "nudPriority";
            this.nudPriority.Size = new System.Drawing.Size(47, 20);
            this.nudPriority.TabIndex = 11;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(642, 47);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "Priority :";
            // 
            // ckbShuffle
            // 
            this.ckbShuffle.AutoSize = true;
            this.ckbShuffle.Location = new System.Drawing.Point(642, 20);
            this.ckbShuffle.Name = "ckbShuffle";
            this.ckbShuffle.Size = new System.Drawing.Size(59, 17);
            this.ckbShuffle.TabIndex = 9;
            this.ckbShuffle.Text = "Shuffle";
            this.ckbShuffle.UseVisualStyleBackColor = true;
            // 
            // txbDuration
            // 
            this.txbDuration.Location = new System.Drawing.Point(536, 43);
            this.txbDuration.Name = "txbDuration";
            this.txbDuration.Size = new System.Drawing.Size(100, 20);
            this.txbDuration.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(473, 46);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 13);
            this.label10.TabIndex = 7;
            this.label10.Text = "Duration :";
            // 
            // txbStartTime
            // 
            this.txbStartTime.Location = new System.Drawing.Point(536, 17);
            this.txbStartTime.Name = "txbStartTime";
            this.txbStartTime.Size = new System.Drawing.Size(100, 20);
            this.txbStartTime.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(473, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Start time :";
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.ckbAll);
            this.groupBox10.Controls.Add(this.ckbSunday);
            this.groupBox10.Controls.Add(this.ckbSaturday);
            this.groupBox10.Controls.Add(this.ckbFriday);
            this.groupBox10.Controls.Add(this.ckbThursday);
            this.groupBox10.Controls.Add(this.ckbWednesday);
            this.groupBox10.Controls.Add(this.ckbTuesday);
            this.groupBox10.Controls.Add(this.ckbMonday);
            this.groupBox10.Location = new System.Drawing.Point(193, 8);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(276, 58);
            this.groupBox10.TabIndex = 4;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Event days";
            // 
            // ckbAll
            // 
            this.ckbAll.AutoSize = true;
            this.ckbAll.Location = new System.Drawing.Point(233, 24);
            this.ckbAll.Name = "ckbAll";
            this.ckbAll.Size = new System.Drawing.Size(37, 17);
            this.ckbAll.TabIndex = 7;
            this.ckbAll.Text = "All";
            this.ckbAll.UseVisualStyleBackColor = true;
            // 
            // ckbSunday
            // 
            this.ckbSunday.AutoSize = true;
            this.ckbSunday.Location = new System.Drawing.Point(192, 24);
            this.ckbSunday.Name = "ckbSunday";
            this.ckbSunday.Size = new System.Drawing.Size(41, 17);
            this.ckbSunday.TabIndex = 6;
            this.ckbSunday.Text = "SU";
            this.ckbSunday.UseVisualStyleBackColor = true;
            // 
            // ckbSaturday
            // 
            this.ckbSaturday.AutoSize = true;
            this.ckbSaturday.Location = new System.Drawing.Point(146, 24);
            this.ckbSaturday.Name = "ckbSaturday";
            this.ckbSaturday.Size = new System.Drawing.Size(40, 17);
            this.ckbSaturday.TabIndex = 5;
            this.ckbSaturday.Text = "SA";
            this.ckbSaturday.UseVisualStyleBackColor = true;
            // 
            // ckbFriday
            // 
            this.ckbFriday.AutoSize = true;
            this.ckbFriday.Location = new System.Drawing.Point(71, 34);
            this.ckbFriday.Name = "ckbFriday";
            this.ckbFriday.Size = new System.Drawing.Size(40, 17);
            this.ckbFriday.TabIndex = 4;
            this.ckbFriday.Text = "FR";
            this.ckbFriday.UseVisualStyleBackColor = true;
            // 
            // ckbThursday
            // 
            this.ckbThursday.AutoSize = true;
            this.ckbThursday.Location = new System.Drawing.Point(24, 34);
            this.ckbThursday.Name = "ckbThursday";
            this.ckbThursday.Size = new System.Drawing.Size(41, 17);
            this.ckbThursday.TabIndex = 3;
            this.ckbThursday.Text = "TH";
            this.ckbThursday.UseVisualStyleBackColor = true;
            // 
            // ckbWednesday
            // 
            this.ckbWednesday.AutoSize = true;
            this.ckbWednesday.Location = new System.Drawing.Point(103, 20);
            this.ckbWednesday.Name = "ckbWednesday";
            this.ckbWednesday.Size = new System.Drawing.Size(44, 17);
            this.ckbWednesday.TabIndex = 2;
            this.ckbWednesday.Text = "WE";
            this.ckbWednesday.UseVisualStyleBackColor = true;
            // 
            // ckbTuesday
            // 
            this.ckbTuesday.AutoSize = true;
            this.ckbTuesday.Location = new System.Drawing.Point(56, 20);
            this.ckbTuesday.Name = "ckbTuesday";
            this.ckbTuesday.Size = new System.Drawing.Size(41, 17);
            this.ckbTuesday.TabIndex = 1;
            this.ckbTuesday.Text = "TU";
            this.ckbTuesday.UseVisualStyleBackColor = true;
            // 
            // ckbMonday
            // 
            this.ckbMonday.AutoSize = true;
            this.ckbMonday.Location = new System.Drawing.Point(7, 20);
            this.ckbMonday.Name = "ckbMonday";
            this.ckbMonday.Size = new System.Drawing.Size(43, 17);
            this.ckbMonday.TabIndex = 0;
            this.ckbMonday.Text = "MO";
            this.ckbMonday.UseVisualStyleBackColor = true;
            // 
            // cmbPlaylistEvent
            // 
            this.cmbPlaylistEvent.FormattingEnabled = true;
            this.cmbPlaylistEvent.Location = new System.Drawing.Point(54, 45);
            this.cmbPlaylistEvent.Name = "cmbPlaylistEvent";
            this.cmbPlaylistEvent.Size = new System.Drawing.Size(118, 21);
            this.cmbPlaylistEvent.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Playlist :";
            // 
            // txbEventName
            // 
            this.txbEventName.Location = new System.Drawing.Point(54, 17);
            this.txbEventName.Name = "txbEventName";
            this.txbEventName.Size = new System.Drawing.Size(100, 20);
            this.txbEventName.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Name :";
            // 
            // tbpTranscoders
            // 
            this.tbpTranscoders.Controls.Add(this.groupBox12);
            this.tbpTranscoders.Controls.Add(this.groupBox11);
            this.tbpTranscoders.Location = new System.Drawing.Point(4, 22);
            this.tbpTranscoders.Name = "tbpTranscoders";
            this.tbpTranscoders.Size = new System.Drawing.Size(832, 445);
            this.tbpTranscoders.TabIndex = 4;
            this.tbpTranscoders.Text = "Transcoders";
            this.tbpTranscoders.UseVisualStyleBackColor = true;
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.groupBox16);
            this.groupBox12.Controls.Add(this.groupBox15);
            this.groupBox12.Controls.Add(this.groupBox14);
            this.groupBox12.Controls.Add(this.txbTranscoderNameEdit);
            this.groupBox12.Controls.Add(this.label21);
            this.groupBox12.Controls.Add(this.btnDeleteTranscoder);
            this.groupBox12.Controls.Add(this.lsbTranscoders);
            this.groupBox12.Controls.Add(this.label28);
            this.groupBox12.Controls.Add(this.cmbEncoderEdit);
            this.groupBox12.Controls.Add(this.txbServerIpEdit);
            this.groupBox12.Controls.Add(this.label27);
            this.groupBox12.Controls.Add(this.label23);
            this.groupBox12.Controls.Add(this.cmbBitrateEdit);
            this.groupBox12.Controls.Add(this.txbStreamUrlEdit);
            this.groupBox12.Controls.Add(this.label26);
            this.groupBox12.Controls.Add(this.label24);
            this.groupBox12.Controls.Add(this.cmbSampleRateEdit);
            this.groupBox12.Controls.Add(this.txbStreamNameEdit);
            this.groupBox12.Controls.Add(this.label25);
            this.groupBox12.Controls.Add(this.groupBox13);
            this.groupBox12.Location = new System.Drawing.Point(204, 4);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(620, 432);
            this.groupBox12.TabIndex = 1;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Transcoders";
            // 
            // groupBox16
            // 
            this.groupBox16.Controls.Add(this.btnStopTranscoder);
            this.groupBox16.Controls.Add(this.btnStartTranscoder);
            this.groupBox16.Controls.Add(this.lblStatusTranscoder);
            this.groupBox16.Controls.Add(this.label30);
            this.groupBox16.Location = new System.Drawing.Point(158, 176);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Size = new System.Drawing.Size(456, 47);
            this.groupBox16.TabIndex = 39;
            this.groupBox16.TabStop = false;
            this.groupBox16.Text = "Status";
            // 
            // btnStopTranscoder
            // 
            this.btnStopTranscoder.Enabled = false;
            this.btnStopTranscoder.Location = new System.Drawing.Point(250, 13);
            this.btnStopTranscoder.Name = "btnStopTranscoder";
            this.btnStopTranscoder.Size = new System.Drawing.Size(75, 23);
            this.btnStopTranscoder.TabIndex = 3;
            this.btnStopTranscoder.Text = "Stop";
            this.btnStopTranscoder.UseVisualStyleBackColor = true;
            // 
            // btnStartTranscoder
            // 
            this.btnStartTranscoder.Location = new System.Drawing.Point(169, 13);
            this.btnStartTranscoder.Name = "btnStartTranscoder";
            this.btnStartTranscoder.Size = new System.Drawing.Size(75, 23);
            this.btnStartTranscoder.TabIndex = 2;
            this.btnStartTranscoder.Text = "Start";
            this.btnStartTranscoder.UseVisualStyleBackColor = true;
            // 
            // lblStatusTranscoder
            // 
            this.lblStatusTranscoder.AutoSize = true;
            this.lblStatusTranscoder.Location = new System.Drawing.Point(57, 18);
            this.lblStatusTranscoder.Name = "lblStatusTranscoder";
            this.lblStatusTranscoder.Size = new System.Drawing.Size(21, 13);
            this.lblStatusTranscoder.TabIndex = 1;
            this.lblStatusTranscoder.Text = "Off";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(7, 18);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(43, 13);
            this.label30.TabIndex = 0;
            this.label30.Text = "Status :";
            // 
            // groupBox15
            // 
            this.groupBox15.Controls.Add(this.btnClearLogTranscoder);
            this.groupBox15.Controls.Add(this.lsbTranscoderLog);
            this.groupBox15.Location = new System.Drawing.Point(7, 224);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new System.Drawing.Size(607, 202);
            this.groupBox15.TabIndex = 39;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "Log";
            // 
            // btnClearLogTranscoder
            // 
            this.btnClearLogTranscoder.Location = new System.Drawing.Point(7, 20);
            this.btnClearLogTranscoder.Name = "btnClearLogTranscoder";
            this.btnClearLogTranscoder.Size = new System.Drawing.Size(75, 23);
            this.btnClearLogTranscoder.TabIndex = 1;
            this.btnClearLogTranscoder.Text = "Clear";
            this.btnClearLogTranscoder.UseVisualStyleBackColor = true;
            // 
            // lsbTranscoderLog
            // 
            this.lsbTranscoderLog.FormattingEnabled = true;
            this.lsbTranscoderLog.Location = new System.Drawing.Point(7, 46);
            this.lsbTranscoderLog.Name = "lsbTranscoderLog";
            this.lsbTranscoderLog.ScrollAlwaysVisible = true;
            this.lsbTranscoderLog.Size = new System.Drawing.Size(594, 147);
            this.lsbTranscoderLog.TabIndex = 0;
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.btnClearHistory);
            this.groupBox14.Controls.Add(this.btnShowHistory);
            this.groupBox14.Location = new System.Drawing.Point(7, 176);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(145, 47);
            this.groupBox14.TabIndex = 38;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "History";
            // 
            // btnClearHistory
            // 
            this.btnClearHistory.Location = new System.Drawing.Point(81, 18);
            this.btnClearHistory.Name = "btnClearHistory";
            this.btnClearHistory.Size = new System.Drawing.Size(51, 23);
            this.btnClearHistory.TabIndex = 1;
            this.btnClearHistory.Text = "Clear";
            this.btnClearHistory.UseVisualStyleBackColor = true;
            // 
            // btnShowHistory
            // 
            this.btnShowHistory.Location = new System.Drawing.Point(6, 18);
            this.btnShowHistory.Name = "btnShowHistory";
            this.btnShowHistory.Size = new System.Drawing.Size(51, 23);
            this.btnShowHistory.TabIndex = 0;
            this.btnShowHistory.Text = "Show";
            this.btnShowHistory.UseVisualStyleBackColor = true;
            // 
            // txbTranscoderNameEdit
            // 
            this.txbTranscoderNameEdit.Location = new System.Drawing.Point(166, 72);
            this.txbTranscoderNameEdit.Name = "txbTranscoderNameEdit";
            this.txbTranscoderNameEdit.Size = new System.Drawing.Size(176, 20);
            this.txbTranscoderNameEdit.TabIndex = 36;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(163, 56);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(96, 13);
            this.label21.TabIndex = 35;
            this.label21.Text = "Transcoder name :";
            // 
            // btnDeleteTranscoder
            // 
            this.btnDeleteTranscoder.Location = new System.Drawing.Point(33, 147);
            this.btnDeleteTranscoder.Name = "btnDeleteTranscoder";
            this.btnDeleteTranscoder.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteTranscoder.TabIndex = 1;
            this.btnDeleteTranscoder.Text = "Delete";
            this.btnDeleteTranscoder.UseVisualStyleBackColor = true;
            // 
            // lsbTranscoders
            // 
            this.lsbTranscoders.FormattingEnabled = true;
            this.lsbTranscoders.Location = new System.Drawing.Point(7, 20);
            this.lsbTranscoders.Name = "lsbTranscoders";
            this.lsbTranscoders.Size = new System.Drawing.Size(132, 121);
            this.lsbTranscoders.TabIndex = 0;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(163, 35);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(53, 13);
            this.label28.TabIndex = 20;
            this.label28.Text = "Encoder :";
            // 
            // cmbEncoderEdit
            // 
            this.cmbEncoderEdit.FormattingEnabled = true;
            this.cmbEncoderEdit.Items.AddRange(new object[] {
            "MP3",
            "AAC+"});
            this.cmbEncoderEdit.Location = new System.Drawing.Point(222, 32);
            this.cmbEncoderEdit.Name = "cmbEncoderEdit";
            this.cmbEncoderEdit.Size = new System.Drawing.Size(71, 21);
            this.cmbEncoderEdit.TabIndex = 21;
            // 
            // txbServerIpEdit
            // 
            this.txbServerIpEdit.Location = new System.Drawing.Point(345, 111);
            this.txbServerIpEdit.Name = "txbServerIpEdit";
            this.txbServerIpEdit.Size = new System.Drawing.Size(112, 20);
            this.txbServerIpEdit.TabIndex = 31;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(299, 35);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(43, 13);
            this.label27.TabIndex = 22;
            this.label27.Text = "Bitrate :";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(345, 95);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(57, 13);
            this.label23.TabIndex = 30;
            this.label23.Text = "Server IP :";
            // 
            // cmbBitrateEdit
            // 
            this.cmbBitrateEdit.FormattingEnabled = true;
            this.cmbBitrateEdit.Location = new System.Drawing.Point(348, 32);
            this.cmbBitrateEdit.Name = "cmbBitrateEdit";
            this.cmbBitrateEdit.Size = new System.Drawing.Size(71, 21);
            this.cmbBitrateEdit.TabIndex = 23;
            // 
            // txbStreamUrlEdit
            // 
            this.txbStreamUrlEdit.Location = new System.Drawing.Point(166, 111);
            this.txbStreamUrlEdit.Name = "txbStreamUrlEdit";
            this.txbStreamUrlEdit.Size = new System.Drawing.Size(176, 20);
            this.txbStreamUrlEdit.TabIndex = 29;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(425, 35);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(69, 13);
            this.label26.TabIndex = 24;
            this.label26.Text = "Sample rate :";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(163, 95);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(71, 13);
            this.label24.TabIndex = 28;
            this.label24.Text = "Stream URL :";
            // 
            // cmbSampleRateEdit
            // 
            this.cmbSampleRateEdit.FormattingEnabled = true;
            this.cmbSampleRateEdit.Items.AddRange(new object[] {
            "44,1 kHz"});
            this.cmbSampleRateEdit.Location = new System.Drawing.Point(500, 32);
            this.cmbSampleRateEdit.Name = "cmbSampleRateEdit";
            this.cmbSampleRateEdit.Size = new System.Drawing.Size(71, 21);
            this.cmbSampleRateEdit.TabIndex = 25;
            // 
            // txbStreamNameEdit
            // 
            this.txbStreamNameEdit.Location = new System.Drawing.Point(346, 72);
            this.txbStreamNameEdit.Name = "txbStreamNameEdit";
            this.txbStreamNameEdit.Size = new System.Drawing.Size(176, 20);
            this.txbStreamNameEdit.TabIndex = 27;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(345, 56);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(75, 13);
            this.label25.TabIndex = 26;
            this.label25.Text = "Stream name :";
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.btnUpdate);
            this.groupBox13.Controls.Add(this.label22);
            this.groupBox13.Controls.Add(this.label29);
            this.groupBox13.Controls.Add(this.nudPortEdit);
            this.groupBox13.Controls.Add(this.txbServerPasswordEdit);
            this.groupBox13.Location = new System.Drawing.Point(158, 16);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(456, 157);
            this.groupBox13.TabIndex = 37;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Edit";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(301, 128);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 38;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(299, 79);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(65, 13);
            this.label22.TabIndex = 32;
            this.label22.Text = "Server port :";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(5, 118);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(92, 13);
            this.label29.TabIndex = 20;
            this.label29.Text = "Server password :";
            // 
            // nudPortEdit
            // 
            this.nudPortEdit.Location = new System.Drawing.Point(302, 95);
            this.nudPortEdit.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudPortEdit.Name = "nudPortEdit";
            this.nudPortEdit.Size = new System.Drawing.Size(74, 20);
            this.nudPortEdit.TabIndex = 33;
            this.nudPortEdit.Value = new decimal(new int[] {
            8000,
            0,
            0,
            0});
            // 
            // txbServerPasswordEdit
            // 
            this.txbServerPasswordEdit.Location = new System.Drawing.Point(8, 134);
            this.txbServerPasswordEdit.Name = "txbServerPasswordEdit";
            this.txbServerPasswordEdit.PasswordChar = '*';
            this.txbServerPasswordEdit.Size = new System.Drawing.Size(176, 20);
            this.txbServerPasswordEdit.TabIndex = 34;
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.btnCreateTranscoder);
            this.groupBox11.Controls.Add(this.txbServerPassword);
            this.groupBox11.Controls.Add(this.label19);
            this.groupBox11.Controls.Add(this.nupPort);
            this.groupBox11.Controls.Add(this.label18);
            this.groupBox11.Controls.Add(this.txbServerIp);
            this.groupBox11.Controls.Add(this.label17);
            this.groupBox11.Controls.Add(this.txbStreamUrl);
            this.groupBox11.Controls.Add(this.label16);
            this.groupBox11.Controls.Add(this.txbStreamName);
            this.groupBox11.Controls.Add(this.label15);
            this.groupBox11.Controls.Add(this.cmbSampleRate);
            this.groupBox11.Controls.Add(this.label14);
            this.groupBox11.Controls.Add(this.cmbBitrate);
            this.groupBox11.Controls.Add(this.label13);
            this.groupBox11.Controls.Add(this.cmbEncoder);
            this.groupBox11.Controls.Add(this.label12);
            this.groupBox11.Location = new System.Drawing.Point(9, 4);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(189, 432);
            this.groupBox11.TabIndex = 0;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Create";
            // 
            // btnCreateTranscoder
            // 
            this.btnCreateTranscoder.Location = new System.Drawing.Point(52, 343);
            this.btnCreateTranscoder.Name = "btnCreateTranscoder";
            this.btnCreateTranscoder.Size = new System.Drawing.Size(75, 23);
            this.btnCreateTranscoder.TabIndex = 17;
            this.btnCreateTranscoder.Text = "Create";
            this.btnCreateTranscoder.UseVisualStyleBackColor = true;
            // 
            // txbServerPassword
            // 
            this.txbServerPassword.Location = new System.Drawing.Point(6, 317);
            this.txbServerPassword.Name = "txbServerPassword";
            this.txbServerPassword.PasswordChar = '*';
            this.txbServerPassword.Size = new System.Drawing.Size(176, 20);
            this.txbServerPassword.TabIndex = 16;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(6, 301);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(92, 13);
            this.label19.TabIndex = 15;
            this.label19.Text = "Server password :";
            // 
            // nupPort
            // 
            this.nupPort.Location = new System.Drawing.Point(6, 278);
            this.nupPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nupPort.Name = "nupPort";
            this.nupPort.Size = new System.Drawing.Size(74, 20);
            this.nupPort.TabIndex = 14;
            this.nupPort.Value = new decimal(new int[] {
            8000,
            0,
            0,
            0});
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 262);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(65, 13);
            this.label18.TabIndex = 12;
            this.label18.Text = "Server port :";
            // 
            // txbServerIp
            // 
            this.txbServerIp.Location = new System.Drawing.Point(6, 239);
            this.txbServerIp.Name = "txbServerIp";
            this.txbServerIp.Size = new System.Drawing.Size(176, 20);
            this.txbServerIp.TabIndex = 11;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 223);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(57, 13);
            this.label17.TabIndex = 10;
            this.label17.Text = "Server IP :";
            // 
            // txbStreamUrl
            // 
            this.txbStreamUrl.Location = new System.Drawing.Point(6, 185);
            this.txbStreamUrl.Name = "txbStreamUrl";
            this.txbStreamUrl.Size = new System.Drawing.Size(176, 20);
            this.txbStreamUrl.TabIndex = 9;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(3, 169);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(71, 13);
            this.label16.TabIndex = 8;
            this.label16.Text = "Stream URL :";
            // 
            // txbStreamName
            // 
            this.txbStreamName.Location = new System.Drawing.Point(6, 146);
            this.txbStreamName.Name = "txbStreamName";
            this.txbStreamName.Size = new System.Drawing.Size(176, 20);
            this.txbStreamName.TabIndex = 7;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(5, 130);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(75, 13);
            this.label15.TabIndex = 6;
            this.label15.Text = "Stream name :";
            // 
            // cmbSampleRate
            // 
            this.cmbSampleRate.FormattingEnabled = true;
            this.cmbSampleRate.Items.AddRange(new object[] {
            "44,1 kHz"});
            this.cmbSampleRate.Location = new System.Drawing.Point(87, 83);
            this.cmbSampleRate.Name = "cmbSampleRate";
            this.cmbSampleRate.Size = new System.Drawing.Size(71, 21);
            this.cmbSampleRate.TabIndex = 5;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(87, 66);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(69, 13);
            this.label14.TabIndex = 4;
            this.label14.Text = "Sample rate :";
            // 
            // cmbBitrate
            // 
            this.cmbBitrate.FormattingEnabled = true;
            this.cmbBitrate.Location = new System.Drawing.Point(6, 83);
            this.cmbBitrate.Name = "cmbBitrate";
            this.cmbBitrate.Size = new System.Drawing.Size(71, 21);
            this.cmbBitrate.TabIndex = 3;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 66);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(43, 13);
            this.label13.TabIndex = 2;
            this.label13.Text = "Bitrate :";
            // 
            // cmbEncoder
            // 
            this.cmbEncoder.FormattingEnabled = true;
            this.cmbEncoder.Items.AddRange(new object[] {
            "MP3",
            "AAC+"});
            this.cmbEncoder.Location = new System.Drawing.Point(6, 42);
            this.cmbEncoder.Name = "cmbEncoder";
            this.cmbEncoder.Size = new System.Drawing.Size(71, 21);
            this.cmbEncoder.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 25);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Encoder :";
            // 
            // tbpServer
            // 
            this.tbpServer.Controls.Add(this.groupBox19);
            this.tbpServer.Controls.Add(this.groupBox18);
            this.tbpServer.Controls.Add(this.groupBox17);
            this.tbpServer.Location = new System.Drawing.Point(4, 22);
            this.tbpServer.Name = "tbpServer";
            this.tbpServer.Size = new System.Drawing.Size(832, 445);
            this.tbpServer.TabIndex = 5;
            this.tbpServer.Text = "Server";
            this.tbpServer.UseVisualStyleBackColor = true;
            // 
            // groupBox19
            // 
            this.groupBox19.Controls.Add(this.btnClearLogServer);
            this.groupBox19.Controls.Add(this.lsbLogServer);
            this.groupBox19.Location = new System.Drawing.Point(9, 221);
            this.groupBox19.Name = "groupBox19";
            this.groupBox19.Size = new System.Drawing.Size(820, 221);
            this.groupBox19.TabIndex = 2;
            this.groupBox19.TabStop = false;
            this.groupBox19.Text = "Log";
            // 
            // btnClearLogServer
            // 
            this.btnClearLogServer.Location = new System.Drawing.Point(7, 20);
            this.btnClearLogServer.Name = "btnClearLogServer";
            this.btnClearLogServer.Size = new System.Drawing.Size(75, 23);
            this.btnClearLogServer.TabIndex = 1;
            this.btnClearLogServer.Text = "Clear";
            this.btnClearLogServer.UseVisualStyleBackColor = true;
            // 
            // lsbLogServer
            // 
            this.lsbLogServer.FormattingEnabled = true;
            this.lsbLogServer.Location = new System.Drawing.Point(6, 49);
            this.lsbLogServer.Name = "lsbLogServer";
            this.lsbLogServer.Size = new System.Drawing.Size(808, 160);
            this.lsbLogServer.TabIndex = 0;
            // 
            // groupBox18
            // 
            this.groupBox18.Controls.Add(this.btnSaveServer);
            this.groupBox18.Controls.Add(this.nudMaxListener);
            this.groupBox18.Controls.Add(this.label35);
            this.groupBox18.Controls.Add(this.txbLocalServerAdminPassword);
            this.groupBox18.Controls.Add(this.label34);
            this.groupBox18.Controls.Add(this.txbLocalServerPassword);
            this.groupBox18.Controls.Add(this.label33);
            this.groupBox18.Controls.Add(this.nudPortServer);
            this.groupBox18.Controls.Add(this.label32);
            this.groupBox18.Location = new System.Drawing.Point(9, 59);
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.Size = new System.Drawing.Size(200, 155);
            this.groupBox18.TabIndex = 1;
            this.groupBox18.TabStop = false;
            this.groupBox18.Text = "Configuration";
            // 
            // btnSaveServer
            // 
            this.btnSaveServer.Location = new System.Drawing.Point(49, 122);
            this.btnSaveServer.Name = "btnSaveServer";
            this.btnSaveServer.Size = new System.Drawing.Size(75, 23);
            this.btnSaveServer.TabIndex = 8;
            this.btnSaveServer.Text = "Save";
            this.btnSaveServer.UseVisualStyleBackColor = true;
            // 
            // nudMaxListener
            // 
            this.nudMaxListener.Location = new System.Drawing.Point(84, 96);
            this.nudMaxListener.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nudMaxListener.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMaxListener.Name = "nudMaxListener";
            this.nudMaxListener.Size = new System.Drawing.Size(55, 20);
            this.nudMaxListener.TabIndex = 7;
            this.nudMaxListener.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(9, 98);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(69, 13);
            this.label35.TabIndex = 6;
            this.label35.Text = "Max listener :";
            // 
            // txbLocalServerAdminPassword
            // 
            this.txbLocalServerAdminPassword.Location = new System.Drawing.Point(84, 70);
            this.txbLocalServerAdminPassword.Name = "txbLocalServerAdminPassword";
            this.txbLocalServerAdminPassword.PasswordChar = '*';
            this.txbLocalServerAdminPassword.Size = new System.Drawing.Size(100, 20);
            this.txbLocalServerAdminPassword.TabIndex = 5;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(13, 73);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(65, 13);
            this.label34.TabIndex = 4;
            this.label34.Text = "Admin pwd :";
            // 
            // txbLocalServerPassword
            // 
            this.txbLocalServerPassword.Location = new System.Drawing.Point(84, 44);
            this.txbLocalServerPassword.Name = "txbLocalServerPassword";
            this.txbLocalServerPassword.PasswordChar = '*';
            this.txbLocalServerPassword.Size = new System.Drawing.Size(100, 20);
            this.txbLocalServerPassword.TabIndex = 3;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(19, 47);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(59, 13);
            this.label33.TabIndex = 2;
            this.label33.Text = "Password :";
            // 
            // nudPortServer
            // 
            this.nudPortServer.Location = new System.Drawing.Point(84, 18);
            this.nudPortServer.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudPortServer.Name = "nudPortServer";
            this.nudPortServer.Size = new System.Drawing.Size(55, 20);
            this.nudPortServer.TabIndex = 1;
            this.nudPortServer.Value = new decimal(new int[] {
            8000,
            0,
            0,
            0});
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(46, 20);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(32, 13);
            this.label32.TabIndex = 0;
            this.label32.Text = "Port :";
            // 
            // groupBox17
            // 
            this.groupBox17.Controls.Add(this.btnShowWebAdministration);
            this.groupBox17.Controls.Add(this.btnShowWebInterface);
            this.groupBox17.Controls.Add(this.btnStopServer);
            this.groupBox17.Controls.Add(this.btnStartServer);
            this.groupBox17.Controls.Add(this.lblStatusServer);
            this.groupBox17.Controls.Add(this.label31);
            this.groupBox17.Location = new System.Drawing.Point(9, 4);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(815, 48);
            this.groupBox17.TabIndex = 0;
            this.groupBox17.TabStop = false;
            this.groupBox17.Text = "Controls";
            // 
            // btnShowWebAdministration
            // 
            this.btnShowWebAdministration.Location = new System.Drawing.Point(500, 15);
            this.btnShowWebAdministration.Name = "btnShowWebAdministration";
            this.btnShowWebAdministration.Size = new System.Drawing.Size(150, 23);
            this.btnShowWebAdministration.TabIndex = 5;
            this.btnShowWebAdministration.Text = "Show web administration";
            this.btnShowWebAdministration.UseVisualStyleBackColor = true;
            // 
            // btnShowWebInterface
            // 
            this.btnShowWebInterface.Location = new System.Drawing.Point(344, 15);
            this.btnShowWebInterface.Name = "btnShowWebInterface";
            this.btnShowWebInterface.Size = new System.Drawing.Size(150, 23);
            this.btnShowWebInterface.TabIndex = 4;
            this.btnShowWebInterface.Text = "Show web interface";
            this.btnShowWebInterface.UseVisualStyleBackColor = true;
            // 
            // btnStopServer
            // 
            this.btnStopServer.Location = new System.Drawing.Point(165, 15);
            this.btnStopServer.Name = "btnStopServer";
            this.btnStopServer.Size = new System.Drawing.Size(75, 23);
            this.btnStopServer.TabIndex = 3;
            this.btnStopServer.Text = "Stop";
            this.btnStopServer.UseVisualStyleBackColor = true;
            // 
            // btnStartServer
            // 
            this.btnStartServer.Location = new System.Drawing.Point(84, 15);
            this.btnStartServer.Name = "btnStartServer";
            this.btnStartServer.Size = new System.Drawing.Size(75, 23);
            this.btnStartServer.TabIndex = 2;
            this.btnStartServer.Text = "Start";
            this.btnStartServer.UseVisualStyleBackColor = true;
            // 
            // lblStatusServer
            // 
            this.lblStatusServer.AutoSize = true;
            this.lblStatusServer.Location = new System.Drawing.Point(57, 20);
            this.lblStatusServer.Name = "lblStatusServer";
            this.lblStatusServer.Size = new System.Drawing.Size(21, 13);
            this.lblStatusServer.TabIndex = 1;
            this.lblStatusServer.Text = "Off";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(7, 20);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(43, 13);
            this.label31.TabIndex = 0;
            this.label31.Text = "Status :";
            // 
            // OFD
            // 
            this.OFD.FileName = "*.mp3";
            this.OFD.Filter = "MP3 Files|*.mp3";
            this.OFD.Multiselect = true;
            // 
            // AdminView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 498);
            this.Controls.Add(this.tbcTabs);
            this.Controls.Add(this.mnsMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnsMain;
            this.MinimizeBox = false;
            this.Name = "AdminView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WebradioManager - ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdminView_FormClosing);
            this.mnsMain.ResumeLayout(false);
            this.mnsMain.PerformLayout();
            this.tbcTabs.ResumeLayout(false);
            this.tbpStatus.ResumeLayout(false);
            this.tbpStatus.PerformLayout();
            this.groupBox20.ResumeLayout(false);
            this.groupBox20.PerformLayout();
            this.tbpLibrary.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAds)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMusics)).EndInit();
            this.tbpPlaylists.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlaylistContent)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDurationGenerate)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tbpTimetable.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPriority)).EndInit();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.tbpTranscoders.ResumeLayout(false);
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.groupBox16.ResumeLayout(false);
            this.groupBox16.PerformLayout();
            this.groupBox15.ResumeLayout(false);
            this.groupBox14.ResumeLayout(false);
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPortEdit)).EndInit();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupPort)).EndInit();
            this.tbpServer.ResumeLayout(false);
            this.groupBox19.ResumeLayout(false);
            this.groupBox18.ResumeLayout(false);
            this.groupBox18.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxListener)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPortServer)).EndInit();
            this.groupBox17.ResumeLayout(false);
            this.groupBox17.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnsMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.TabControl tbcTabs;
        private System.Windows.Forms.TabPage tbpStatus;
        private System.Windows.Forms.TabPage tbpLibrary;
        private System.Windows.Forms.TabPage tbpPlaylists;
        private System.Windows.Forms.TabPage tbpTimetable;
        private System.Windows.Forms.TabPage tbpTranscoders;
        private System.Windows.Forms.TabPage tbpServer;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDeleteMusic;
        private System.Windows.Forms.ComboBox cmbPlaylistsMusic;
        private System.Windows.Forms.Button btnAddToMusic;
        private System.Windows.Forms.DataGridView dgvMusics;
        private System.Windows.Forms.Button btnImportFilesMusic;
        private System.Windows.Forms.Button btnImportFolderMusic;
        private System.Windows.Forms.TextBox txbSearchMusic;
        private System.Windows.Forms.Button btnDeleteAd;
        private System.Windows.Forms.DataGridView dgvAds;
        private System.Windows.Forms.ComboBox cmbPlaylistsAd;
        private System.Windows.Forms.TextBox txbSearchAd;
        private System.Windows.Forms.Button btnAddToAd;
        private System.Windows.Forms.Button btnImportFolderAd;
        private System.Windows.Forms.Button btnImportFilesAd;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cmbTypePlaylist;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbPlaylistName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCreatePlaylist;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txbPlaylistNameGenerate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbTypePlaylistGenerate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudDurationGenerate;
        private System.Windows.Forms.Button btnGeneratePlaylist;
        private System.Windows.Forms.ComboBox cmbGenderGenerate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvPlaylistContent;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btnDeletePlaylistAd;
        private System.Windows.Forms.ListBox lsbPlaylistsAd;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnDeletePlaylistMusic;
        private System.Windows.Forms.ListBox lsbPlaylistsMusic;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.NumericUpDown nudPriority;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox ckbShuffle;
        private System.Windows.Forms.TextBox txbDuration;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txbStartTime;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.CheckBox ckbAll;
        private System.Windows.Forms.CheckBox ckbSunday;
        private System.Windows.Forms.CheckBox ckbSaturday;
        private System.Windows.Forms.CheckBox ckbFriday;
        private System.Windows.Forms.CheckBox ckbThursday;
        private System.Windows.Forms.CheckBox ckbWednesday;
        private System.Windows.Forms.CheckBox ckbTuesday;
        private System.Windows.Forms.CheckBox ckbMonday;
        private System.Windows.Forms.ComboBox cmbPlaylistEvent;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txbEventName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnCreateEvent;
        private Calendar.DayView dvwTimetable;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txbStreamUrl;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txbStreamName;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cmbSampleRate;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cmbBitrate;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbEncoder;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.Button btnDeleteTranscoder;
        private System.Windows.Forms.ListBox lsbTranscoders;
        private System.Windows.Forms.Button btnCreateTranscoder;
        private System.Windows.Forms.TextBox txbServerPassword;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.NumericUpDown nupPort;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txbServerIp;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox txbTranscoderNameEdit;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txbServerPasswordEdit;
        private System.Windows.Forms.NumericUpDown nudPortEdit;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ComboBox cmbEncoderEdit;
        private System.Windows.Forms.TextBox txbServerIpEdit;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ComboBox cmbBitrateEdit;
        private System.Windows.Forms.TextBox txbStreamUrlEdit;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.ComboBox cmbSampleRateEdit;
        private System.Windows.Forms.TextBox txbStreamNameEdit;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.GroupBox groupBox14;
        private System.Windows.Forms.Button btnClearHistory;
        private System.Windows.Forms.Button btnShowHistory;
        private System.Windows.Forms.GroupBox groupBox15;
        private System.Windows.Forms.ListBox lsbTranscoderLog;
        private System.Windows.Forms.GroupBox groupBox16;
        private System.Windows.Forms.Button btnStopTranscoder;
        private System.Windows.Forms.Button btnStartTranscoder;
        private System.Windows.Forms.Label lblStatusTranscoder;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.GroupBox groupBox19;
        private System.Windows.Forms.Button btnClearLogServer;
        private System.Windows.Forms.ListBox lsbLogServer;
        private System.Windows.Forms.GroupBox groupBox18;
        private System.Windows.Forms.Button btnSaveServer;
        private System.Windows.Forms.NumericUpDown nudMaxListener;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.TextBox txbLocalServerAdminPassword;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.TextBox txbLocalServerPassword;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.NumericUpDown nudPortServer;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.GroupBox groupBox17;
        private System.Windows.Forms.Button btnShowWebAdministration;
        private System.Windows.Forms.Button btnShowWebInterface;
        private System.Windows.Forms.Button btnStopServer;
        private System.Windows.Forms.Button btnStartServer;
        private System.Windows.Forms.Label lblStatusServer;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Button btnClearLogTranscoder;
        private System.Windows.Forms.GroupBox groupBox21;
        private System.Windows.Forms.GroupBox groupBox20;
        private System.Windows.Forms.Button btnModifyName;
        private System.Windows.Forms.TextBox txbWebradioName;
        private System.Windows.Forms.Label lblWebradioTitle;
        private System.Windows.Forms.FolderBrowserDialog FBD;
        private System.Windows.Forms.OpenFileDialog OFD;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdAd;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTitleAd;
        private System.Windows.Forms.DataGridViewTextBoxColumn colArtistAd;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAlbumAd;
        private System.Windows.Forms.DataGridViewTextBoxColumn colYearAd;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLabelAd;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDurationAd;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGenderAd;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPathAd;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdMusic;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTitleMusic;
        private System.Windows.Forms.DataGridViewTextBoxColumn colArtistMusic;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAlbumMusic;
        private System.Windows.Forms.DataGridViewTextBoxColumn colYearMusic;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLabelMusic;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDurationMusic;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGenderMusic;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPathMusic;


    }
}

