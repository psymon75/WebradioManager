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
            this.generateAllConfigsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbcTabs = new System.Windows.Forms.TabControl();
            this.tbpStatus = new System.Windows.Forms.TabPage();
            this.groupBox24 = new System.Windows.Forms.GroupBox();
            this.groupBox25 = new System.Windows.Forms.GroupBox();
            this.lblAverageTime = new System.Windows.Forms.Label();
            this.lblUniqueListeners = new System.Windows.Forms.Label();
            this.lblPeakListeners = new System.Windows.Forms.Label();
            this.lblNumberListeners = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.btnUpdateListeners = new System.Windows.Forms.Button();
            this.dgvServerListeners = new System.Windows.Forms.DataGridView();
            this.colHostname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUserAgent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colConnectTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox22 = new System.Windows.Forms.GroupBox();
            this.dgvCurrentTracks = new System.Windows.Forms.DataGridView();
            this.colTranscoderName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colArtist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAlbum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox21 = new System.Windows.Forms.GroupBox();
            this.lsbStatus = new System.Windows.Forms.ListBox();
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
            this.txbSearchPlaylistContent = new System.Windows.Forms.TextBox();
            this.btnRemoveFromPlaylist = new System.Windows.Forms.Button();
            this.dgvPlaylistContent = new System.Windows.Forms.DataGridView();
            this.colIdPlaylist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTitlePlaylist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colArtistPlaylist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAlbumPlaylist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colYearPlaylist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLabelPlaylist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDurationPlaylist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGenderPlaylist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPathPlaylist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.lblPlaylistDuration = new System.Windows.Forms.Label();
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
            this.mtbDuration = new System.Windows.Forms.MaskedTextBox();
            this.mtbStartTime = new System.Windows.Forms.MaskedTextBox();
            this.btnCreateEvent = new System.Windows.Forms.Button();
            this.nudPriority = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.ckbShuffle = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
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
            this.groupBox23 = new System.Windows.Forms.GroupBox();
            this.btnStopCapture = new System.Windows.Forms.Button();
            this.btnStartCapture = new System.Windows.Forms.Button();
            this.label38 = new System.Windows.Forms.Label();
            this.btnUpdateAudioDevice = new System.Windows.Forms.Button();
            this.cmbAudioDevice = new System.Windows.Forms.ComboBox();
            this.label37 = new System.Windows.Forms.Label();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.btnNextTrack = new System.Windows.Forms.Button();
            this.ckbTranscoderDebug = new System.Windows.Forms.CheckBox();
            this.btnStopTranscoder = new System.Windows.Forms.Button();
            this.btnStartTranscoder = new System.Windows.Forms.Button();
            this.lblStatusTranscoder = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.btnShowTranscoderLog = new System.Windows.Forms.Button();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.btnClearHistory = new System.Windows.Forms.Button();
            this.btnGenerateHistory = new System.Windows.Forms.Button();
            this.btnDeleteTranscoder = new System.Windows.Forms.Button();
            this.lsbTranscoders = new System.Windows.Forms.ListBox();
            this.label28 = new System.Windows.Forms.Label();
            this.cmbEncoderEdit = new System.Windows.Forms.ComboBox();
            this.label27 = new System.Windows.Forms.Label();
            this.cmbBitrateEdit = new System.Windows.Forms.ComboBox();
            this.label26 = new System.Windows.Forms.Label();
            this.cmbSampleRateEdit = new System.Windows.Forms.ComboBox();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.label36 = new System.Windows.Forms.Label();
            this.nudAdminPortEdit = new System.Windows.Forms.NumericUpDown();
            this.btnResolveEdit = new System.Windows.Forms.Button();
            this.txbServerIPEdit = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.nudPortEdit = new System.Windows.Forms.NumericUpDown();
            this.txbServerPasswordEdit = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.txbStreamNameEdit = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.txbStreamUrlEdit = new System.Windows.Forms.TextBox();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.nudAdminPort = new System.Windows.Forms.NumericUpDown();
            this.label21 = new System.Windows.Forms.Label();
            this.btnResolve = new System.Windows.Forms.Button();
            this.txbServerIP = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.btnCreateTranscoder = new System.Windows.Forms.Button();
            this.txbServerPassword = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.nudPort = new System.Windows.Forms.NumericUpDown();
            this.label18 = new System.Windows.Forms.Label();
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox19 = new System.Windows.Forms.GroupBox();
            this.btnShowServerLog = new System.Windows.Forms.Button();
            this.btnClearLogServer = new System.Windows.Forms.Button();
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
            this.ckbServerDebug = new System.Windows.Forms.CheckBox();
            this.btnShowWebAdministration = new System.Windows.Forms.Button();
            this.btnShowWebInterface = new System.Windows.Forms.Button();
            this.btnStopServer = new System.Windows.Forms.Button();
            this.btnStartServer = new System.Windows.Forms.Button();
            this.lblStatusServer = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.FBD = new System.Windows.Forms.FolderBrowserDialog();
            this.OFD = new System.Windows.Forms.OpenFileDialog();
            this.checkLibraryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsMain.SuspendLayout();
            this.tbcTabs.SuspendLayout();
            this.tbpStatus.SuspendLayout();
            this.groupBox24.SuspendLayout();
            this.groupBox25.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServerListeners)).BeginInit();
            this.groupBox22.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrentTracks)).BeginInit();
            this.groupBox21.SuspendLayout();
            this.groupBox20.SuspendLayout();
            this.tbpLibrary.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAds)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMusics)).BeginInit();
            this.tbpPlaylists.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlaylistContent)).BeginInit();
            this.groupBox7.SuspendLayout();
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
            this.groupBox23.SuspendLayout();
            this.groupBox16.SuspendLayout();
            this.groupBox15.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.groupBox13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAdminPortEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPortEdit)).BeginInit();
            this.groupBox11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAdminPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPort)).BeginInit();
            this.tbpServer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.dvwTimetable.AllowDrop = true;
            this.dvwTimetable.AllowInplaceEditing = false;
            this.dvwTimetable.AllowNew = false;
            this.dvwTimetable.AmPmDisplay = false;
            this.dvwTimetable.AppHeightMode = Calendar.DayView.AppHeightDrawMode.TrueHeightAll;
            this.dvwTimetable.DaysToShow = 7;
            this.dvwTimetable.DrawAllAppBorder = false;
            this.dvwTimetable.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.dvwTimetable.ImeMode = System.Windows.Forms.ImeMode.NoControl;
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
            this.dvwTimetable.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dvwTimetable_MouseClick);
            this.dvwTimetable.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dvwTimetable_MouseUp);
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
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generateAllConfigsToolStripMenuItem,
            this.checkLibraryToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // generateAllConfigsToolStripMenuItem
            // 
            this.generateAllConfigsToolStripMenuItem.Name = "generateAllConfigsToolStripMenuItem";
            this.generateAllConfigsToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.generateAllConfigsToolStripMenuItem.Text = "Generate all configs";
            this.generateAllConfigsToolStripMenuItem.Click += new System.EventHandler(this.generateAllConfigsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
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
            this.tbpStatus.Controls.Add(this.groupBox24);
            this.tbpStatus.Controls.Add(this.groupBox22);
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
            // groupBox24
            // 
            this.groupBox24.Controls.Add(this.groupBox25);
            this.groupBox24.Controls.Add(this.btnUpdateListeners);
            this.groupBox24.Controls.Add(this.dgvServerListeners);
            this.groupBox24.Location = new System.Drawing.Point(214, 7);
            this.groupBox24.Name = "groupBox24";
            this.groupBox24.Size = new System.Drawing.Size(615, 195);
            this.groupBox24.TabIndex = 4;
            this.groupBox24.TabStop = false;
            this.groupBox24.Text = "Server listeners";
            // 
            // groupBox25
            // 
            this.groupBox25.Controls.Add(this.lblAverageTime);
            this.groupBox25.Controls.Add(this.lblUniqueListeners);
            this.groupBox25.Controls.Add(this.lblPeakListeners);
            this.groupBox25.Controls.Add(this.lblNumberListeners);
            this.groupBox25.Controls.Add(this.label42);
            this.groupBox25.Controls.Add(this.label41);
            this.groupBox25.Controls.Add(this.label40);
            this.groupBox25.Controls.Add(this.label39);
            this.groupBox25.Location = new System.Drawing.Point(88, 9);
            this.groupBox25.Name = "groupBox25";
            this.groupBox25.Size = new System.Drawing.Size(518, 41);
            this.groupBox25.TabIndex = 2;
            this.groupBox25.TabStop = false;
            this.groupBox25.Text = "Infos";
            // 
            // lblAverageTime
            // 
            this.lblAverageTime.AutoSize = true;
            this.lblAverageTime.Location = new System.Drawing.Point(405, 16);
            this.lblAverageTime.Name = "lblAverageTime";
            this.lblAverageTime.Size = new System.Drawing.Size(13, 13);
            this.lblAverageTime.TabIndex = 7;
            this.lblAverageTime.Text = "0";
            // 
            // lblUniqueListeners
            // 
            this.lblUniqueListeners.AutoSize = true;
            this.lblUniqueListeners.Location = new System.Drawing.Point(305, 16);
            this.lblUniqueListeners.Name = "lblUniqueListeners";
            this.lblUniqueListeners.Size = new System.Drawing.Size(13, 13);
            this.lblUniqueListeners.TabIndex = 6;
            this.lblUniqueListeners.Text = "0";
            // 
            // lblPeakListeners
            // 
            this.lblPeakListeners.AutoSize = true;
            this.lblPeakListeners.Location = new System.Drawing.Point(186, 16);
            this.lblPeakListeners.Name = "lblPeakListeners";
            this.lblPeakListeners.Size = new System.Drawing.Size(13, 13);
            this.lblPeakListeners.TabIndex = 5;
            this.lblPeakListeners.Text = "0";
            // 
            // lblNumberListeners
            // 
            this.lblNumberListeners.AutoSize = true;
            this.lblNumberListeners.Location = new System.Drawing.Point(82, 16);
            this.lblNumberListeners.Name = "lblNumberListeners";
            this.lblNumberListeners.Size = new System.Drawing.Size(13, 13);
            this.lblNumberListeners.TabIndex = 4;
            this.lblNumberListeners.Text = "0";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(324, 16);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(75, 13);
            this.label42.TabIndex = 3;
            this.label42.Text = "Average time :";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(205, 16);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(94, 13);
            this.label41.TabIndex = 2;
            this.label41.Text = "Unique listener(s) :";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(101, 16);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(79, 13);
            this.label40.TabIndex = 1;
            this.label40.Text = "Peak listeners :";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(1, 16);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(79, 13);
            this.label39.TabIndex = 0;
            this.label39.Text = "# of listener(s) :";
            // 
            // btnUpdateListeners
            // 
            this.btnUpdateListeners.Location = new System.Drawing.Point(7, 20);
            this.btnUpdateListeners.Name = "btnUpdateListeners";
            this.btnUpdateListeners.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateListeners.TabIndex = 1;
            this.btnUpdateListeners.Text = "Update";
            this.btnUpdateListeners.UseVisualStyleBackColor = true;
            this.btnUpdateListeners.Click += new System.EventHandler(this.btnUpdateListeners_Click);
            // 
            // dgvServerListeners
            // 
            this.dgvServerListeners.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvServerListeners.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colHostname,
            this.colUserAgent,
            this.colConnectTime,
            this.colUID});
            this.dgvServerListeners.Location = new System.Drawing.Point(7, 56);
            this.dgvServerListeners.Name = "dgvServerListeners";
            this.dgvServerListeners.ReadOnly = true;
            this.dgvServerListeners.Size = new System.Drawing.Size(599, 133);
            this.dgvServerListeners.TabIndex = 0;
            // 
            // colHostname
            // 
            this.colHostname.HeaderText = "Hostname";
            this.colHostname.Name = "colHostname";
            this.colHostname.ReadOnly = true;
            // 
            // colUserAgent
            // 
            this.colUserAgent.HeaderText = "User agent";
            this.colUserAgent.Name = "colUserAgent";
            this.colUserAgent.ReadOnly = true;
            // 
            // colConnectTime
            // 
            this.colConnectTime.HeaderText = "Connection time (s)";
            this.colConnectTime.Name = "colConnectTime";
            this.colConnectTime.ReadOnly = true;
            // 
            // colUID
            // 
            this.colUID.HeaderText = "UID";
            this.colUID.Name = "colUID";
            this.colUID.ReadOnly = true;
            // 
            // groupBox22
            // 
            this.groupBox22.Controls.Add(this.dgvCurrentTracks);
            this.groupBox22.Location = new System.Drawing.Point(214, 208);
            this.groupBox22.Name = "groupBox22";
            this.groupBox22.Size = new System.Drawing.Size(612, 228);
            this.groupBox22.TabIndex = 3;
            this.groupBox22.TabStop = false;
            this.groupBox22.Text = "Current tracks";
            // 
            // dgvCurrentTracks
            // 
            this.dgvCurrentTracks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCurrentTracks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCurrentTracks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTranscoderName,
            this.colTitle,
            this.colArtist,
            this.colAlbum});
            this.dgvCurrentTracks.Location = new System.Drawing.Point(7, 19);
            this.dgvCurrentTracks.Name = "dgvCurrentTracks";
            this.dgvCurrentTracks.ReadOnly = true;
            this.dgvCurrentTracks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCurrentTracks.Size = new System.Drawing.Size(599, 203);
            this.dgvCurrentTracks.TabIndex = 0;
            // 
            // colTranscoderName
            // 
            this.colTranscoderName.HeaderText = "Transcoder";
            this.colTranscoderName.Name = "colTranscoderName";
            this.colTranscoderName.ReadOnly = true;
            // 
            // colTitle
            // 
            this.colTitle.HeaderText = "Title";
            this.colTitle.Name = "colTitle";
            this.colTitle.ReadOnly = true;
            // 
            // colArtist
            // 
            this.colArtist.HeaderText = "Artist";
            this.colArtist.Name = "colArtist";
            this.colArtist.ReadOnly = true;
            // 
            // colAlbum
            // 
            this.colAlbum.HeaderText = "Album";
            this.colAlbum.Name = "colAlbum";
            this.colAlbum.ReadOnly = true;
            // 
            // groupBox21
            // 
            this.groupBox21.Controls.Add(this.lsbStatus);
            this.groupBox21.Location = new System.Drawing.Point(7, 208);
            this.groupBox21.Name = "groupBox21";
            this.groupBox21.Size = new System.Drawing.Size(200, 228);
            this.groupBox21.TabIndex = 2;
            this.groupBox21.TabStop = false;
            this.groupBox21.Text = "Status";
            // 
            // lsbStatus
            // 
            this.lsbStatus.FormattingEnabled = true;
            this.lsbStatus.Location = new System.Drawing.Point(8, 20);
            this.lsbStatus.Name = "lsbStatus";
            this.lsbStatus.Size = new System.Drawing.Size(186, 160);
            this.lsbStatus.TabIndex = 0;
            // 
            // groupBox20
            // 
            this.groupBox20.Controls.Add(this.btnModifyName);
            this.groupBox20.Controls.Add(this.txbWebradioName);
            this.groupBox20.Location = new System.Drawing.Point(8, 43);
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
            this.btnModifyName.Click += new System.EventHandler(this.btnModifyName_Click);
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
            this.lblWebradioTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWebradioTitle.Location = new System.Drawing.Point(3, 7);
            this.lblWebradioTitle.Name = "lblWebradioTitle";
            this.lblWebradioTitle.Size = new System.Drawing.Size(70, 24);
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
            this.btnDeleteAd.Click += new System.EventHandler(this.btnDeleteLibrary_Click);
            // 
            // dgvAds
            // 
            this.dgvAds.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
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
            this.dgvAds.Tag = "Ad";
            this.dgvAds.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCellEndEdit);
            // 
            // colIdAd
            // 
            this.colIdAd.HeaderText = "Id";
            this.colIdAd.Name = "colIdAd";
            this.colIdAd.ReadOnly = true;
            this.colIdAd.Width = 41;
            // 
            // colTitleAd
            // 
            this.colTitleAd.HeaderText = "Title";
            this.colTitleAd.Name = "colTitleAd";
            this.colTitleAd.ReadOnly = true;
            this.colTitleAd.Width = 52;
            // 
            // colArtistAd
            // 
            this.colArtistAd.HeaderText = "Artist";
            this.colArtistAd.Name = "colArtistAd";
            this.colArtistAd.ReadOnly = true;
            this.colArtistAd.Width = 55;
            // 
            // colAlbumAd
            // 
            this.colAlbumAd.HeaderText = "Album";
            this.colAlbumAd.Name = "colAlbumAd";
            this.colAlbumAd.ReadOnly = true;
            this.colAlbumAd.Width = 61;
            // 
            // colYearAd
            // 
            this.colYearAd.HeaderText = "Year";
            this.colYearAd.Name = "colYearAd";
            this.colYearAd.ReadOnly = true;
            this.colYearAd.Width = 54;
            // 
            // colLabelAd
            // 
            this.colLabelAd.HeaderText = "Label";
            this.colLabelAd.Name = "colLabelAd";
            this.colLabelAd.ReadOnly = true;
            this.colLabelAd.Width = 58;
            // 
            // colDurationAd
            // 
            this.colDurationAd.HeaderText = "Duration";
            this.colDurationAd.Name = "colDurationAd";
            this.colDurationAd.ReadOnly = true;
            this.colDurationAd.Width = 72;
            // 
            // colGenderAd
            // 
            this.colGenderAd.HeaderText = "Gender";
            this.colGenderAd.Name = "colGenderAd";
            this.colGenderAd.ReadOnly = true;
            this.colGenderAd.Width = 67;
            // 
            // colPathAd
            // 
            this.colPathAd.HeaderText = "Path";
            this.colPathAd.Name = "colPathAd";
            this.colPathAd.ReadOnly = true;
            this.colPathAd.Width = 54;
            // 
            // cmbPlaylistsAd
            // 
            this.cmbPlaylistsAd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            this.btnAddToAd.Tag = "Ad";
            this.btnAddToAd.Text = "Add selected to :";
            this.btnAddToAd.UseVisualStyleBackColor = true;
            this.btnAddToAd.Click += new System.EventHandler(this.btnAddToClick);
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
            this.btnDeleteMusic.Click += new System.EventHandler(this.btnDeleteLibrary_Click);
            // 
            // cmbPlaylistsMusic
            // 
            this.cmbPlaylistsMusic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            this.btnAddToMusic.Tag = "Music";
            this.btnAddToMusic.Text = "Add selected to :";
            this.btnAddToMusic.UseVisualStyleBackColor = true;
            this.btnAddToMusic.Click += new System.EventHandler(this.btnAddToClick);
            // 
            // dgvMusics
            // 
            this.dgvMusics.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
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
            this.dgvMusics.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMusics.Size = new System.Drawing.Size(802, 162);
            this.dgvMusics.TabIndex = 3;
            this.dgvMusics.Tag = "Music";
            this.dgvMusics.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCellEndEdit);
            // 
            // colIdMusic
            // 
            this.colIdMusic.HeaderText = "Id";
            this.colIdMusic.Name = "colIdMusic";
            this.colIdMusic.ReadOnly = true;
            this.colIdMusic.Width = 41;
            // 
            // colTitleMusic
            // 
            this.colTitleMusic.HeaderText = "Title";
            this.colTitleMusic.Name = "colTitleMusic";
            this.colTitleMusic.Width = 52;
            // 
            // colArtistMusic
            // 
            this.colArtistMusic.HeaderText = "Artist";
            this.colArtistMusic.Name = "colArtistMusic";
            this.colArtistMusic.Width = 55;
            // 
            // colAlbumMusic
            // 
            this.colAlbumMusic.HeaderText = "Album";
            this.colAlbumMusic.Name = "colAlbumMusic";
            this.colAlbumMusic.Width = 61;
            // 
            // colYearMusic
            // 
            this.colYearMusic.HeaderText = "Year";
            this.colYearMusic.Name = "colYearMusic";
            this.colYearMusic.Width = 54;
            // 
            // colLabelMusic
            // 
            this.colLabelMusic.HeaderText = "Label";
            this.colLabelMusic.Name = "colLabelMusic";
            this.colLabelMusic.Width = 58;
            // 
            // colDurationMusic
            // 
            this.colDurationMusic.HeaderText = "Duration";
            this.colDurationMusic.Name = "colDurationMusic";
            this.colDurationMusic.ReadOnly = true;
            this.colDurationMusic.Width = 72;
            // 
            // colGenderMusic
            // 
            this.colGenderMusic.HeaderText = "Gender";
            this.colGenderMusic.Name = "colGenderMusic";
            this.colGenderMusic.Width = 67;
            // 
            // colPathMusic
            // 
            this.colPathMusic.HeaderText = "Path";
            this.colPathMusic.Name = "colPathMusic";
            this.colPathMusic.ReadOnly = true;
            this.colPathMusic.Width = 54;
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
            this.tbpPlaylists.Controls.Add(this.txbSearchPlaylistContent);
            this.tbpPlaylists.Controls.Add(this.btnRemoveFromPlaylist);
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
            // txbSearchPlaylistContent
            // 
            this.txbSearchPlaylistContent.Location = new System.Drawing.Point(188, 127);
            this.txbSearchPlaylistContent.Name = "txbSearchPlaylistContent";
            this.txbSearchPlaylistContent.Size = new System.Drawing.Size(100, 20);
            this.txbSearchPlaylistContent.TabIndex = 7;
            this.txbSearchPlaylistContent.Text = "Search...";
            this.txbSearchPlaylistContent.TextChanged += new System.EventHandler(this.txbSearchPlaylistContent_TextChanged);
            this.txbSearchPlaylistContent.Enter += new System.EventHandler(this.txbSearchEnter);
            this.txbSearchPlaylistContent.Leave += new System.EventHandler(this.txbSearchLeave);
            // 
            // btnRemoveFromPlaylist
            // 
            this.btnRemoveFromPlaylist.Location = new System.Drawing.Point(716, 126);
            this.btnRemoveFromPlaylist.Name = "btnRemoveFromPlaylist";
            this.btnRemoveFromPlaylist.Size = new System.Drawing.Size(102, 23);
            this.btnRemoveFromPlaylist.TabIndex = 6;
            this.btnRemoveFromPlaylist.Text = "Remove selected";
            this.btnRemoveFromPlaylist.UseVisualStyleBackColor = true;
            this.btnRemoveFromPlaylist.Click += new System.EventHandler(this.btnRemoveFromPlaylist_Click);
            // 
            // dgvPlaylistContent
            // 
            this.dgvPlaylistContent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvPlaylistContent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlaylistContent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdPlaylist,
            this.colTitlePlaylist,
            this.colArtistPlaylist,
            this.colAlbumPlaylist,
            this.colYearPlaylist,
            this.colLabelPlaylist,
            this.colDurationPlaylist,
            this.colGenderPlaylist,
            this.colPathPlaylist});
            this.dgvPlaylistContent.Location = new System.Drawing.Point(188, 155);
            this.dgvPlaylistContent.Name = "dgvPlaylistContent";
            this.dgvPlaylistContent.ReadOnly = true;
            this.dgvPlaylistContent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPlaylistContent.Size = new System.Drawing.Size(636, 287);
            this.dgvPlaylistContent.TabIndex = 5;
            // 
            // colIdPlaylist
            // 
            this.colIdPlaylist.HeaderText = "Id";
            this.colIdPlaylist.Name = "colIdPlaylist";
            this.colIdPlaylist.ReadOnly = true;
            this.colIdPlaylist.Width = 41;
            // 
            // colTitlePlaylist
            // 
            this.colTitlePlaylist.HeaderText = "Title";
            this.colTitlePlaylist.Name = "colTitlePlaylist";
            this.colTitlePlaylist.ReadOnly = true;
            this.colTitlePlaylist.Width = 52;
            // 
            // colArtistPlaylist
            // 
            this.colArtistPlaylist.HeaderText = "Artist";
            this.colArtistPlaylist.Name = "colArtistPlaylist";
            this.colArtistPlaylist.ReadOnly = true;
            this.colArtistPlaylist.Width = 55;
            // 
            // colAlbumPlaylist
            // 
            this.colAlbumPlaylist.HeaderText = "Album";
            this.colAlbumPlaylist.Name = "colAlbumPlaylist";
            this.colAlbumPlaylist.ReadOnly = true;
            this.colAlbumPlaylist.Width = 61;
            // 
            // colYearPlaylist
            // 
            this.colYearPlaylist.HeaderText = "Year";
            this.colYearPlaylist.Name = "colYearPlaylist";
            this.colYearPlaylist.ReadOnly = true;
            this.colYearPlaylist.Width = 54;
            // 
            // colLabelPlaylist
            // 
            this.colLabelPlaylist.HeaderText = "Label";
            this.colLabelPlaylist.Name = "colLabelPlaylist";
            this.colLabelPlaylist.ReadOnly = true;
            this.colLabelPlaylist.Width = 58;
            // 
            // colDurationPlaylist
            // 
            this.colDurationPlaylist.HeaderText = "Duration";
            this.colDurationPlaylist.Name = "colDurationPlaylist";
            this.colDurationPlaylist.ReadOnly = true;
            this.colDurationPlaylist.Width = 72;
            // 
            // colGenderPlaylist
            // 
            this.colGenderPlaylist.HeaderText = "Gender";
            this.colGenderPlaylist.Name = "colGenderPlaylist";
            this.colGenderPlaylist.ReadOnly = true;
            this.colGenderPlaylist.Width = 67;
            // 
            // colPathPlaylist
            // 
            this.colPathPlaylist.HeaderText = "Path";
            this.colPathPlaylist.Name = "colPathPlaylist";
            this.colPathPlaylist.ReadOnly = true;
            this.colPathPlaylist.Width = 54;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.lblPlaylistDuration);
            this.groupBox7.Location = new System.Drawing.Point(312, 79);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(398, 69);
            this.groupBox7.TabIndex = 4;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Informations";
            // 
            // lblPlaylistDuration
            // 
            this.lblPlaylistDuration.AutoSize = true;
            this.lblPlaylistDuration.Location = new System.Drawing.Point(7, 20);
            this.lblPlaylistDuration.Name = "lblPlaylistDuration";
            this.lblPlaylistDuration.Size = new System.Drawing.Size(53, 13);
            this.lblPlaylistDuration.TabIndex = 0;
            this.lblPlaylistDuration.Text = "Duration :";
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
            this.btnDeletePlaylistAd.Tag = "Ad";
            this.btnDeletePlaylistAd.Text = "Delete";
            this.btnDeletePlaylistAd.UseVisualStyleBackColor = true;
            this.btnDeletePlaylistAd.Click += new System.EventHandler(this.btnDeletePlaylistClick);
            // 
            // lsbPlaylistsAd
            // 
            this.lsbPlaylistsAd.FormattingEnabled = true;
            this.lsbPlaylistsAd.Location = new System.Drawing.Point(7, 19);
            this.lsbPlaylistsAd.Name = "lsbPlaylistsAd";
            this.lsbPlaylistsAd.ScrollAlwaysVisible = true;
            this.lsbPlaylistsAd.Size = new System.Drawing.Size(159, 121);
            this.lsbPlaylistsAd.TabIndex = 1;
            this.lsbPlaylistsAd.Tag = "Ad";
            this.lsbPlaylistsAd.SelectedIndexChanged += new System.EventHandler(this.lsbPlaylistsSelectedIndexChanged);
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
            this.btnDeletePlaylistMusic.Tag = "Music";
            this.btnDeletePlaylistMusic.Text = "Delete";
            this.btnDeletePlaylistMusic.UseVisualStyleBackColor = true;
            this.btnDeletePlaylistMusic.Click += new System.EventHandler(this.btnDeletePlaylistClick);
            // 
            // lsbPlaylistsMusic
            // 
            this.lsbPlaylistsMusic.FormattingEnabled = true;
            this.lsbPlaylistsMusic.Location = new System.Drawing.Point(7, 20);
            this.lsbPlaylistsMusic.Name = "lsbPlaylistsMusic";
            this.lsbPlaylistsMusic.ScrollAlwaysVisible = true;
            this.lsbPlaylistsMusic.Size = new System.Drawing.Size(159, 121);
            this.lsbPlaylistsMusic.TabIndex = 0;
            this.lsbPlaylistsMusic.Tag = "Music";
            this.lsbPlaylistsMusic.SelectedIndexChanged += new System.EventHandler(this.lsbPlaylistsSelectedIndexChanged);
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
            this.nudDurationGenerate.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDurationGenerate.Name = "nudDurationGenerate";
            this.nudDurationGenerate.Size = new System.Drawing.Size(77, 20);
            this.nudDurationGenerate.TabIndex = 12;
            this.nudDurationGenerate.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnGeneratePlaylist
            // 
            this.btnGeneratePlaylist.Location = new System.Drawing.Point(462, 34);
            this.btnGeneratePlaylist.Name = "btnGeneratePlaylist";
            this.btnGeneratePlaylist.Size = new System.Drawing.Size(75, 23);
            this.btnGeneratePlaylist.TabIndex = 11;
            this.btnGeneratePlaylist.Text = "Generate";
            this.btnGeneratePlaylist.UseVisualStyleBackColor = true;
            this.btnGeneratePlaylist.Click += new System.EventHandler(this.btnGeneratePlaylist_Click);
            // 
            // cmbGenderGenerate
            // 
            this.cmbGenderGenerate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGenderGenerate.FormattingEnabled = true;
            this.cmbGenderGenerate.Items.AddRange(new object[] {
            "Music",
            "Ad"});
            this.cmbGenderGenerate.Location = new System.Drawing.Point(352, 34);
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
            this.cmbTypePlaylistGenerate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTypePlaylistGenerate.FormattingEnabled = true;
            this.cmbTypePlaylistGenerate.Items.AddRange(new object[] {
            "Music",
            "Ad"});
            this.cmbTypePlaylistGenerate.Location = new System.Drawing.Point(269, 35);
            this.cmbTypePlaylistGenerate.Name = "cmbTypePlaylistGenerate";
            this.cmbTypePlaylistGenerate.Size = new System.Drawing.Size(58, 21);
            this.cmbTypePlaylistGenerate.TabIndex = 6;
            this.cmbTypePlaylistGenerate.SelectedIndexChanged += new System.EventHandler(this.cmbTypePlaylistGenerate_SelectedIndexChanged);
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
            this.cmbTypePlaylist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            this.groupBox8.Controls.Add(this.mtbDuration);
            this.groupBox8.Controls.Add(this.mtbStartTime);
            this.groupBox8.Controls.Add(this.btnCreateEvent);
            this.groupBox8.Controls.Add(this.nudPriority);
            this.groupBox8.Controls.Add(this.label11);
            this.groupBox8.Controls.Add(this.ckbShuffle);
            this.groupBox8.Controls.Add(this.label10);
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
            // mtbDuration
            // 
            this.mtbDuration.Location = new System.Drawing.Point(536, 44);
            this.mtbDuration.Mask = "00:00:00";
            this.mtbDuration.Name = "mtbDuration";
            this.mtbDuration.PromptChar = '0';
            this.mtbDuration.Size = new System.Drawing.Size(100, 20);
            this.mtbDuration.TabIndex = 14;
            this.mtbDuration.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            // 
            // mtbStartTime
            // 
            this.mtbStartTime.Location = new System.Drawing.Point(536, 17);
            this.mtbStartTime.Mask = "00:00:00";
            this.mtbStartTime.Name = "mtbStartTime";
            this.mtbStartTime.PromptChar = '0';
            this.mtbStartTime.Size = new System.Drawing.Size(100, 20);
            this.mtbStartTime.TabIndex = 13;
            this.mtbStartTime.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.mtbStartTime.ValidatingType = typeof(System.DateTime);
            // 
            // btnCreateEvent
            // 
            this.btnCreateEvent.Location = new System.Drawing.Point(760, 28);
            this.btnCreateEvent.Name = "btnCreateEvent";
            this.btnCreateEvent.Size = new System.Drawing.Size(54, 23);
            this.btnCreateEvent.TabIndex = 12;
            this.btnCreateEvent.Text = "Create";
            this.btnCreateEvent.UseVisualStyleBackColor = true;
            this.btnCreateEvent.Click += new System.EventHandler(this.btnCreateEvent_Click);
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
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(473, 46);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 13);
            this.label10.TabIndex = 7;
            this.label10.Text = "Duration :";
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
            this.ckbAll.Location = new System.Drawing.Point(191, 16);
            this.ckbAll.Name = "ckbAll";
            this.ckbAll.Size = new System.Drawing.Size(37, 17);
            this.ckbAll.TabIndex = 7;
            this.ckbAll.Text = "All";
            this.ckbAll.UseVisualStyleBackColor = true;
            this.ckbAll.CheckedChanged += new System.EventHandler(this.ckbCheckedChanged);
            // 
            // ckbSunday
            // 
            this.ckbSunday.AutoSize = true;
            this.ckbSunday.Location = new System.Drawing.Point(191, 35);
            this.ckbSunday.Name = "ckbSunday";
            this.ckbSunday.Size = new System.Drawing.Size(41, 17);
            this.ckbSunday.TabIndex = 6;
            this.ckbSunday.Text = "SU";
            this.ckbSunday.UseVisualStyleBackColor = true;
            this.ckbSunday.CheckedChanged += new System.EventHandler(this.ckbCheckedChanged);
            // 
            // ckbSaturday
            // 
            this.ckbSaturday.AutoSize = true;
            this.ckbSaturday.Location = new System.Drawing.Point(145, 35);
            this.ckbSaturday.Name = "ckbSaturday";
            this.ckbSaturday.Size = new System.Drawing.Size(40, 17);
            this.ckbSaturday.TabIndex = 5;
            this.ckbSaturday.Text = "SA";
            this.ckbSaturday.UseVisualStyleBackColor = true;
            this.ckbSaturday.CheckedChanged += new System.EventHandler(this.ckbCheckedChanged);
            // 
            // ckbFriday
            // 
            this.ckbFriday.AutoSize = true;
            this.ckbFriday.Location = new System.Drawing.Point(98, 35);
            this.ckbFriday.Name = "ckbFriday";
            this.ckbFriday.Size = new System.Drawing.Size(40, 17);
            this.ckbFriday.TabIndex = 4;
            this.ckbFriday.Text = "FR";
            this.ckbFriday.UseVisualStyleBackColor = true;
            this.ckbFriday.CheckedChanged += new System.EventHandler(this.ckbCheckedChanged);
            // 
            // ckbThursday
            // 
            this.ckbThursday.AutoSize = true;
            this.ckbThursday.Location = new System.Drawing.Point(49, 35);
            this.ckbThursday.Name = "ckbThursday";
            this.ckbThursday.Size = new System.Drawing.Size(41, 17);
            this.ckbThursday.TabIndex = 3;
            this.ckbThursday.Text = "TH";
            this.ckbThursday.UseVisualStyleBackColor = true;
            this.ckbThursday.CheckedChanged += new System.EventHandler(this.ckbCheckedChanged);
            // 
            // ckbWednesday
            // 
            this.ckbWednesday.AutoSize = true;
            this.ckbWednesday.Location = new System.Drawing.Point(145, 16);
            this.ckbWednesday.Name = "ckbWednesday";
            this.ckbWednesday.Size = new System.Drawing.Size(44, 17);
            this.ckbWednesday.TabIndex = 2;
            this.ckbWednesday.Text = "WE";
            this.ckbWednesday.UseVisualStyleBackColor = true;
            this.ckbWednesday.CheckedChanged += new System.EventHandler(this.ckbCheckedChanged);
            // 
            // ckbTuesday
            // 
            this.ckbTuesday.AutoSize = true;
            this.ckbTuesday.Location = new System.Drawing.Point(98, 16);
            this.ckbTuesday.Name = "ckbTuesday";
            this.ckbTuesday.Size = new System.Drawing.Size(41, 17);
            this.ckbTuesday.TabIndex = 1;
            this.ckbTuesday.Text = "TU";
            this.ckbTuesday.UseVisualStyleBackColor = true;
            this.ckbTuesday.CheckedChanged += new System.EventHandler(this.ckbCheckedChanged);
            // 
            // ckbMonday
            // 
            this.ckbMonday.AutoSize = true;
            this.ckbMonday.Location = new System.Drawing.Point(49, 16);
            this.ckbMonday.Name = "ckbMonday";
            this.ckbMonday.Size = new System.Drawing.Size(43, 17);
            this.ckbMonday.TabIndex = 0;
            this.ckbMonday.Text = "MO";
            this.ckbMonday.UseVisualStyleBackColor = true;
            this.ckbMonday.CheckedChanged += new System.EventHandler(this.ckbCheckedChanged);
            // 
            // cmbPlaylistEvent
            // 
            this.cmbPlaylistEvent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            this.groupBox12.Controls.Add(this.groupBox23);
            this.groupBox12.Controls.Add(this.groupBox16);
            this.groupBox12.Controls.Add(this.groupBox15);
            this.groupBox12.Controls.Add(this.groupBox14);
            this.groupBox12.Controls.Add(this.btnDeleteTranscoder);
            this.groupBox12.Controls.Add(this.lsbTranscoders);
            this.groupBox12.Controls.Add(this.label28);
            this.groupBox12.Controls.Add(this.cmbEncoderEdit);
            this.groupBox12.Controls.Add(this.label27);
            this.groupBox12.Controls.Add(this.cmbBitrateEdit);
            this.groupBox12.Controls.Add(this.label26);
            this.groupBox12.Controls.Add(this.cmbSampleRateEdit);
            this.groupBox12.Controls.Add(this.groupBox13);
            this.groupBox12.Location = new System.Drawing.Point(204, 4);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(620, 432);
            this.groupBox12.TabIndex = 1;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Transcoders";
            // 
            // groupBox23
            // 
            this.groupBox23.Controls.Add(this.btnStopCapture);
            this.groupBox23.Controls.Add(this.btnStartCapture);
            this.groupBox23.Controls.Add(this.label38);
            this.groupBox23.Controls.Add(this.btnUpdateAudioDevice);
            this.groupBox23.Controls.Add(this.cmbAudioDevice);
            this.groupBox23.Controls.Add(this.label37);
            this.groupBox23.Location = new System.Drawing.Point(7, 277);
            this.groupBox23.Name = "groupBox23";
            this.groupBox23.Size = new System.Drawing.Size(607, 149);
            this.groupBox23.TabIndex = 40;
            this.groupBox23.TabStop = false;
            this.groupBox23.Text = "Live capture";
            // 
            // btnStopCapture
            // 
            this.btnStopCapture.Enabled = false;
            this.btnStopCapture.Location = new System.Drawing.Point(510, 18);
            this.btnStopCapture.Name = "btnStopCapture";
            this.btnStopCapture.Size = new System.Drawing.Size(75, 23);
            this.btnStopCapture.TabIndex = 5;
            this.btnStopCapture.Text = "Stop";
            this.btnStopCapture.UseVisualStyleBackColor = true;
            this.btnStopCapture.Click += new System.EventHandler(this.btnStopCapture_Click);
            // 
            // btnStartCapture
            // 
            this.btnStartCapture.Location = new System.Drawing.Point(429, 19);
            this.btnStartCapture.Name = "btnStartCapture";
            this.btnStartCapture.Size = new System.Drawing.Size(75, 23);
            this.btnStartCapture.TabIndex = 4;
            this.btnStartCapture.Text = "Start";
            this.btnStartCapture.UseVisualStyleBackColor = true;
            this.btnStartCapture.Click += new System.EventHandler(this.btnStartCapture_Click);
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(373, 24);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(50, 13);
            this.label38.TabIndex = 3;
            this.label38.Text = "Capture :";
            // 
            // btnUpdateAudioDevice
            // 
            this.btnUpdateAudioDevice.Location = new System.Drawing.Point(292, 18);
            this.btnUpdateAudioDevice.Name = "btnUpdateAudioDevice";
            this.btnUpdateAudioDevice.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateAudioDevice.TabIndex = 2;
            this.btnUpdateAudioDevice.Text = "Update list";
            this.btnUpdateAudioDevice.UseVisualStyleBackColor = true;
            this.btnUpdateAudioDevice.Click += new System.EventHandler(this.btnUpdateAudioDevice_Click);
            // 
            // cmbAudioDevice
            // 
            this.cmbAudioDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAudioDevice.FormattingEnabled = true;
            this.cmbAudioDevice.Location = new System.Drawing.Point(79, 20);
            this.cmbAudioDevice.Name = "cmbAudioDevice";
            this.cmbAudioDevice.Size = new System.Drawing.Size(207, 21);
            this.cmbAudioDevice.TabIndex = 1;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(6, 23);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(67, 13);
            this.label37.TabIndex = 0;
            this.label37.Text = "Devices list :";
            // 
            // groupBox16
            // 
            this.groupBox16.Controls.Add(this.btnNextTrack);
            this.groupBox16.Controls.Add(this.ckbTranscoderDebug);
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
            // btnNextTrack
            // 
            this.btnNextTrack.Location = new System.Drawing.Point(375, 13);
            this.btnNextTrack.Name = "btnNextTrack";
            this.btnNextTrack.Size = new System.Drawing.Size(75, 23);
            this.btnNextTrack.TabIndex = 5;
            this.btnNextTrack.Text = "Next track";
            this.btnNextTrack.UseVisualStyleBackColor = true;
            this.btnNextTrack.Click += new System.EventHandler(this.btnNextTrack_Click);
            // 
            // ckbTranscoderDebug
            // 
            this.ckbTranscoderDebug.AutoSize = true;
            this.ckbTranscoderDebug.Checked = true;
            this.ckbTranscoderDebug.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbTranscoderDebug.Location = new System.Drawing.Point(256, 17);
            this.ckbTranscoderDebug.Name = "ckbTranscoderDebug";
            this.ckbTranscoderDebug.Size = new System.Drawing.Size(58, 17);
            this.ckbTranscoderDebug.TabIndex = 4;
            this.ckbTranscoderDebug.Text = "Debug";
            this.ckbTranscoderDebug.UseVisualStyleBackColor = true;
            // 
            // btnStopTranscoder
            // 
            this.btnStopTranscoder.Enabled = false;
            this.btnStopTranscoder.Location = new System.Drawing.Point(173, 13);
            this.btnStopTranscoder.Name = "btnStopTranscoder";
            this.btnStopTranscoder.Size = new System.Drawing.Size(75, 23);
            this.btnStopTranscoder.TabIndex = 3;
            this.btnStopTranscoder.Text = "Stop";
            this.btnStopTranscoder.UseVisualStyleBackColor = true;
            this.btnStopTranscoder.Click += new System.EventHandler(this.btnStopTranscoder_Click);
            // 
            // btnStartTranscoder
            // 
            this.btnStartTranscoder.Location = new System.Drawing.Point(92, 13);
            this.btnStartTranscoder.Name = "btnStartTranscoder";
            this.btnStartTranscoder.Size = new System.Drawing.Size(75, 23);
            this.btnStartTranscoder.TabIndex = 2;
            this.btnStartTranscoder.Text = "Start";
            this.btnStartTranscoder.UseVisualStyleBackColor = true;
            this.btnStartTranscoder.Click += new System.EventHandler(this.btnStartTranscoder_Click);
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
            this.groupBox15.Controls.Add(this.btnShowTranscoderLog);
            this.groupBox15.Location = new System.Drawing.Point(7, 224);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new System.Drawing.Size(607, 51);
            this.groupBox15.TabIndex = 39;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "Log";
            // 
            // btnShowTranscoderLog
            // 
            this.btnShowTranscoderLog.Location = new System.Drawing.Point(6, 19);
            this.btnShowTranscoderLog.Name = "btnShowTranscoderLog";
            this.btnShowTranscoderLog.Size = new System.Drawing.Size(75, 23);
            this.btnShowTranscoderLog.TabIndex = 2;
            this.btnShowTranscoderLog.Text = "Show logfile";
            this.btnShowTranscoderLog.UseVisualStyleBackColor = true;
            this.btnShowTranscoderLog.Click += new System.EventHandler(this.btnShowTranscoderLog_Click);
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.btnClearHistory);
            this.groupBox14.Controls.Add(this.btnGenerateHistory);
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
            this.btnClearHistory.Click += new System.EventHandler(this.btnClearHistory_Click);
            // 
            // btnGenerateHistory
            // 
            this.btnGenerateHistory.Location = new System.Drawing.Point(6, 18);
            this.btnGenerateHistory.Name = "btnGenerateHistory";
            this.btnGenerateHistory.Size = new System.Drawing.Size(75, 23);
            this.btnGenerateHistory.TabIndex = 0;
            this.btnGenerateHistory.Text = "Generate";
            this.btnGenerateHistory.UseVisualStyleBackColor = true;
            this.btnGenerateHistory.Click += new System.EventHandler(this.btnGenerateHistory_Click);
            // 
            // btnDeleteTranscoder
            // 
            this.btnDeleteTranscoder.Location = new System.Drawing.Point(33, 147);
            this.btnDeleteTranscoder.Name = "btnDeleteTranscoder";
            this.btnDeleteTranscoder.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteTranscoder.TabIndex = 1;
            this.btnDeleteTranscoder.Text = "Delete";
            this.btnDeleteTranscoder.UseVisualStyleBackColor = true;
            this.btnDeleteTranscoder.Click += new System.EventHandler(this.btnDeleteTranscoder_Click);
            // 
            // lsbTranscoders
            // 
            this.lsbTranscoders.FormattingEnabled = true;
            this.lsbTranscoders.Location = new System.Drawing.Point(7, 20);
            this.lsbTranscoders.Name = "lsbTranscoders";
            this.lsbTranscoders.ScrollAlwaysVisible = true;
            this.lsbTranscoders.Size = new System.Drawing.Size(132, 121);
            this.lsbTranscoders.TabIndex = 0;
            this.lsbTranscoders.SelectedIndexChanged += new System.EventHandler(this.lsbTranscoders_SelectedIndexChanged);
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
            this.cmbEncoderEdit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEncoderEdit.FormattingEnabled = true;
            this.cmbEncoderEdit.Items.AddRange(new object[] {
            "MP3",
            "AAC+"});
            this.cmbEncoderEdit.Location = new System.Drawing.Point(222, 32);
            this.cmbEncoderEdit.Name = "cmbEncoderEdit";
            this.cmbEncoderEdit.Size = new System.Drawing.Size(71, 21);
            this.cmbEncoderEdit.TabIndex = 21;
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
            // cmbBitrateEdit
            // 
            this.cmbBitrateEdit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBitrateEdit.FormattingEnabled = true;
            this.cmbBitrateEdit.Location = new System.Drawing.Point(348, 32);
            this.cmbBitrateEdit.Name = "cmbBitrateEdit";
            this.cmbBitrateEdit.Size = new System.Drawing.Size(71, 21);
            this.cmbBitrateEdit.TabIndex = 23;
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
            // cmbSampleRateEdit
            // 
            this.cmbSampleRateEdit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSampleRateEdit.FormattingEnabled = true;
            this.cmbSampleRateEdit.Location = new System.Drawing.Point(500, 32);
            this.cmbSampleRateEdit.Name = "cmbSampleRateEdit";
            this.cmbSampleRateEdit.Size = new System.Drawing.Size(71, 21);
            this.cmbSampleRateEdit.TabIndex = 25;
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.label36);
            this.groupBox13.Controls.Add(this.nudAdminPortEdit);
            this.groupBox13.Controls.Add(this.btnResolveEdit);
            this.groupBox13.Controls.Add(this.txbServerIPEdit);
            this.groupBox13.Controls.Add(this.btnUpdate);
            this.groupBox13.Controls.Add(this.label22);
            this.groupBox13.Controls.Add(this.label29);
            this.groupBox13.Controls.Add(this.nudPortEdit);
            this.groupBox13.Controls.Add(this.txbServerPasswordEdit);
            this.groupBox13.Controls.Add(this.label25);
            this.groupBox13.Controls.Add(this.txbStreamNameEdit);
            this.groupBox13.Controls.Add(this.label23);
            this.groupBox13.Controls.Add(this.label24);
            this.groupBox13.Controls.Add(this.txbStreamUrlEdit);
            this.groupBox13.Location = new System.Drawing.Point(158, 16);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(456, 157);
            this.groupBox13.TabIndex = 37;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Edit";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(182, 40);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(63, 13);
            this.label36.TabIndex = 40;
            this.label36.Text = "Admin port :";
            // 
            // nudAdminPortEdit
            // 
            this.nudAdminPortEdit.Location = new System.Drawing.Point(185, 56);
            this.nudAdminPortEdit.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudAdminPortEdit.Name = "nudAdminPortEdit";
            this.nudAdminPortEdit.Size = new System.Drawing.Size(74, 20);
            this.nudAdminPortEdit.TabIndex = 41;
            this.nudAdminPortEdit.Value = new decimal(new int[] {
            9000,
            0,
            0,
            0});
            // 
            // btnResolveEdit
            // 
            this.btnResolveEdit.Location = new System.Drawing.Point(99, 94);
            this.btnResolveEdit.Name = "btnResolveEdit";
            this.btnResolveEdit.Size = new System.Drawing.Size(75, 23);
            this.btnResolveEdit.TabIndex = 22;
            this.btnResolveEdit.Tag = "Edit";
            this.btnResolveEdit.Text = "Resolve";
            this.btnResolveEdit.UseVisualStyleBackColor = true;
            this.btnResolveEdit.Click += new System.EventHandler(this.btnResolve_Click);
            // 
            // txbServerIPEdit
            // 
            this.txbServerIPEdit.Location = new System.Drawing.Point(8, 96);
            this.txbServerIPEdit.Name = "txbServerIPEdit";
            this.txbServerIPEdit.Size = new System.Drawing.Size(85, 20);
            this.txbServerIPEdit.TabIndex = 39;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(305, 121);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 38;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(182, 80);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(65, 13);
            this.label22.TabIndex = 32;
            this.label22.Text = "Server port :";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(264, 80);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(92, 13);
            this.label29.TabIndex = 20;
            this.label29.Text = "Server password :";
            // 
            // nudPortEdit
            // 
            this.nudPortEdit.Location = new System.Drawing.Point(185, 96);
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
            this.txbServerPasswordEdit.Location = new System.Drawing.Point(267, 95);
            this.txbServerPasswordEdit.Name = "txbServerPasswordEdit";
            this.txbServerPasswordEdit.PasswordChar = '*';
            this.txbServerPasswordEdit.Size = new System.Drawing.Size(176, 20);
            this.txbServerPasswordEdit.TabIndex = 34;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(7, 40);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(75, 13);
            this.label25.TabIndex = 26;
            this.label25.Text = "Stream name :";
            // 
            // txbStreamNameEdit
            // 
            this.txbStreamNameEdit.Location = new System.Drawing.Point(8, 56);
            this.txbStreamNameEdit.Name = "txbStreamNameEdit";
            this.txbStreamNameEdit.Size = new System.Drawing.Size(176, 20);
            this.txbStreamNameEdit.TabIndex = 27;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(10, 80);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(57, 13);
            this.label23.TabIndex = 30;
            this.label23.Text = "Server IP :";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(264, 40);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(71, 13);
            this.label24.TabIndex = 28;
            this.label24.Text = "Stream URL :";
            // 
            // txbStreamUrlEdit
            // 
            this.txbStreamUrlEdit.Location = new System.Drawing.Point(267, 56);
            this.txbStreamUrlEdit.Name = "txbStreamUrlEdit";
            this.txbStreamUrlEdit.Size = new System.Drawing.Size(176, 20);
            this.txbStreamUrlEdit.TabIndex = 29;
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.nudAdminPort);
            this.groupBox11.Controls.Add(this.label21);
            this.groupBox11.Controls.Add(this.btnResolve);
            this.groupBox11.Controls.Add(this.txbServerIP);
            this.groupBox11.Controls.Add(this.label20);
            this.groupBox11.Controls.Add(this.btnCreateTranscoder);
            this.groupBox11.Controls.Add(this.txbServerPassword);
            this.groupBox11.Controls.Add(this.label19);
            this.groupBox11.Controls.Add(this.nudPort);
            this.groupBox11.Controls.Add(this.label18);
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
            // nudAdminPort
            // 
            this.nudAdminPort.Location = new System.Drawing.Point(6, 224);
            this.nudAdminPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudAdminPort.Name = "nudAdminPort";
            this.nudAdminPort.Size = new System.Drawing.Size(74, 20);
            this.nudAdminPort.TabIndex = 23;
            this.nudAdminPort.Value = new decimal(new int[] {
            9000,
            0,
            0,
            0});
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(6, 208);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(63, 13);
            this.label21.TabIndex = 22;
            this.label21.Text = "Admin port :";
            // 
            // btnResolve
            // 
            this.btnResolve.Location = new System.Drawing.Point(103, 277);
            this.btnResolve.Name = "btnResolve";
            this.btnResolve.Size = new System.Drawing.Size(75, 23);
            this.btnResolve.TabIndex = 21;
            this.btnResolve.Text = "Resolve";
            this.btnResolve.UseVisualStyleBackColor = true;
            this.btnResolve.Click += new System.EventHandler(this.btnResolve_Click);
            // 
            // txbServerIP
            // 
            this.txbServerIP.Location = new System.Drawing.Point(6, 279);
            this.txbServerIP.Name = "txbServerIP";
            this.txbServerIP.Size = new System.Drawing.Size(92, 20);
            this.txbServerIP.TabIndex = 20;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(67, 86);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(30, 13);
            this.label20.TabIndex = 19;
            this.label20.Text = "Kb/s";
            // 
            // btnCreateTranscoder
            // 
            this.btnCreateTranscoder.Location = new System.Drawing.Point(52, 394);
            this.btnCreateTranscoder.Name = "btnCreateTranscoder";
            this.btnCreateTranscoder.Size = new System.Drawing.Size(75, 23);
            this.btnCreateTranscoder.TabIndex = 17;
            this.btnCreateTranscoder.Text = "Create";
            this.btnCreateTranscoder.UseVisualStyleBackColor = true;
            this.btnCreateTranscoder.Click += new System.EventHandler(this.btnCreateTranscoder_Click);
            // 
            // txbServerPassword
            // 
            this.txbServerPassword.Location = new System.Drawing.Point(6, 356);
            this.txbServerPassword.Name = "txbServerPassword";
            this.txbServerPassword.PasswordChar = '*';
            this.txbServerPassword.Size = new System.Drawing.Size(176, 20);
            this.txbServerPassword.TabIndex = 16;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(6, 340);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(92, 13);
            this.label19.TabIndex = 15;
            this.label19.Text = "Server password :";
            // 
            // nudPort
            // 
            this.nudPort.Location = new System.Drawing.Point(6, 317);
            this.nudPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudPort.Name = "nudPort";
            this.nudPort.Size = new System.Drawing.Size(74, 20);
            this.nudPort.TabIndex = 14;
            this.nudPort.Value = new decimal(new int[] {
            8000,
            0,
            0,
            0});
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 301);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(65, 13);
            this.label18.TabIndex = 12;
            this.label18.Text = "Server port :";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 262);
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
            this.cmbSampleRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSampleRate.FormattingEnabled = true;
            this.cmbSampleRate.Items.AddRange(new object[] {
            "44100"});
            this.cmbSampleRate.Location = new System.Drawing.Point(103, 83);
            this.cmbSampleRate.Name = "cmbSampleRate";
            this.cmbSampleRate.Size = new System.Drawing.Size(71, 21);
            this.cmbSampleRate.TabIndex = 5;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(103, 66);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(69, 13);
            this.label14.TabIndex = 4;
            this.label14.Text = "Sample rate :";
            // 
            // cmbBitrate
            // 
            this.cmbBitrate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBitrate.FormattingEnabled = true;
            this.cmbBitrate.Location = new System.Drawing.Point(6, 83);
            this.cmbBitrate.Name = "cmbBitrate";
            this.cmbBitrate.Size = new System.Drawing.Size(57, 21);
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
            this.cmbEncoder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            this.tbpServer.Controls.Add(this.pictureBox1);
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
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WebradioManager.Properties.Resources.shoutcast;
            this.pictureBox1.Location = new System.Drawing.Point(127, 255);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(626, 148);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox19
            // 
            this.groupBox19.Controls.Add(this.btnShowServerLog);
            this.groupBox19.Controls.Add(this.btnClearLogServer);
            this.groupBox19.Location = new System.Drawing.Point(215, 59);
            this.groupBox19.Name = "groupBox19";
            this.groupBox19.Size = new System.Drawing.Size(184, 54);
            this.groupBox19.TabIndex = 2;
            this.groupBox19.TabStop = false;
            this.groupBox19.Text = "Log";
            // 
            // btnShowServerLog
            // 
            this.btnShowServerLog.Location = new System.Drawing.Point(89, 19);
            this.btnShowServerLog.Name = "btnShowServerLog";
            this.btnShowServerLog.Size = new System.Drawing.Size(75, 23);
            this.btnShowServerLog.TabIndex = 2;
            this.btnShowServerLog.Text = "Show logfile";
            this.btnShowServerLog.UseVisualStyleBackColor = true;
            this.btnShowServerLog.Click += new System.EventHandler(this.btnShowServerLog_Click);
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
            this.btnSaveServer.Click += new System.EventHandler(this.btnSaveServer_Click);
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
            this.groupBox17.Controls.Add(this.ckbServerDebug);
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
            // ckbServerDebug
            // 
            this.ckbServerDebug.AutoSize = true;
            this.ckbServerDebug.Checked = true;
            this.ckbServerDebug.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbServerDebug.Location = new System.Drawing.Point(246, 19);
            this.ckbServerDebug.Name = "ckbServerDebug";
            this.ckbServerDebug.Size = new System.Drawing.Size(58, 17);
            this.ckbServerDebug.TabIndex = 6;
            this.ckbServerDebug.Text = "Debug";
            this.ckbServerDebug.UseVisualStyleBackColor = true;
            // 
            // btnShowWebAdministration
            // 
            this.btnShowWebAdministration.Location = new System.Drawing.Point(500, 15);
            this.btnShowWebAdministration.Name = "btnShowWebAdministration";
            this.btnShowWebAdministration.Size = new System.Drawing.Size(150, 23);
            this.btnShowWebAdministration.TabIndex = 5;
            this.btnShowWebAdministration.Text = "Show web administration";
            this.btnShowWebAdministration.UseVisualStyleBackColor = true;
            this.btnShowWebAdministration.Click += new System.EventHandler(this.btnShowWebAdministration_Click);
            // 
            // btnShowWebInterface
            // 
            this.btnShowWebInterface.Location = new System.Drawing.Point(344, 15);
            this.btnShowWebInterface.Name = "btnShowWebInterface";
            this.btnShowWebInterface.Size = new System.Drawing.Size(150, 23);
            this.btnShowWebInterface.TabIndex = 4;
            this.btnShowWebInterface.Text = "Show web interface";
            this.btnShowWebInterface.UseVisualStyleBackColor = true;
            this.btnShowWebInterface.Click += new System.EventHandler(this.btnShowWebInterface_Click);
            // 
            // btnStopServer
            // 
            this.btnStopServer.Location = new System.Drawing.Point(165, 15);
            this.btnStopServer.Name = "btnStopServer";
            this.btnStopServer.Size = new System.Drawing.Size(75, 23);
            this.btnStopServer.TabIndex = 3;
            this.btnStopServer.Text = "Stop";
            this.btnStopServer.UseVisualStyleBackColor = true;
            this.btnStopServer.Click += new System.EventHandler(this.btnStopServer_Click);
            // 
            // btnStartServer
            // 
            this.btnStartServer.Location = new System.Drawing.Point(84, 15);
            this.btnStartServer.Name = "btnStartServer";
            this.btnStartServer.Size = new System.Drawing.Size(75, 23);
            this.btnStartServer.TabIndex = 2;
            this.btnStartServer.Text = "Start";
            this.btnStartServer.UseVisualStyleBackColor = true;
            this.btnStartServer.Click += new System.EventHandler(this.btnStartServer_Click);
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
            // checkLibraryToolStripMenuItem
            // 
            this.checkLibraryToolStripMenuItem.Name = "checkLibraryToolStripMenuItem";
            this.checkLibraryToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.checkLibraryToolStripMenuItem.Text = "Check  library";
            this.checkLibraryToolStripMenuItem.Click += new System.EventHandler(this.checkLibraryToolStripMenuItem_Click);
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
            this.MaximizeBox = false;
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
            this.groupBox24.ResumeLayout(false);
            this.groupBox25.ResumeLayout(false);
            this.groupBox25.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServerListeners)).EndInit();
            this.groupBox22.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrentTracks)).EndInit();
            this.groupBox21.ResumeLayout(false);
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
            this.tbpPlaylists.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlaylistContent)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
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
            this.groupBox23.ResumeLayout(false);
            this.groupBox23.PerformLayout();
            this.groupBox16.ResumeLayout(false);
            this.groupBox16.PerformLayout();
            this.groupBox15.ResumeLayout(false);
            this.groupBox14.ResumeLayout(false);
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAdminPortEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPortEdit)).EndInit();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAdminPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPort)).EndInit();
            this.tbpServer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.Label label10;
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
        private System.Windows.Forms.NumericUpDown nudPort;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox txbServerPasswordEdit;
        private System.Windows.Forms.NumericUpDown nudPortEdit;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ComboBox cmbEncoderEdit;
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
        private System.Windows.Forms.Button btnGenerateHistory;
        private System.Windows.Forms.GroupBox groupBox15;
        private System.Windows.Forms.GroupBox groupBox16;
        private System.Windows.Forms.Button btnStopTranscoder;
        private System.Windows.Forms.Button btnStartTranscoder;
        private System.Windows.Forms.Label lblStatusTranscoder;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.GroupBox groupBox19;
        private System.Windows.Forms.Button btnClearLogServer;
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
        private System.Windows.Forms.GroupBox groupBox21;
        private System.Windows.Forms.GroupBox groupBox20;
        private System.Windows.Forms.Button btnModifyName;
        private System.Windows.Forms.TextBox txbWebradioName;
        private System.Windows.Forms.Label lblWebradioTitle;
        private System.Windows.Forms.FolderBrowserDialog FBD;
        private System.Windows.Forms.OpenFileDialog OFD;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdPlaylist;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTitlePlaylist;
        private System.Windows.Forms.DataGridViewTextBoxColumn colArtistPlaylist;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAlbumPlaylist;
        private System.Windows.Forms.DataGridViewTextBoxColumn colYearPlaylist;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLabelPlaylist;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDurationPlaylist;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGenderPlaylist;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPathPlaylist;
        private System.Windows.Forms.Button btnRemoveFromPlaylist;
        private System.Windows.Forms.TextBox txbSearchPlaylistContent;
        private System.Windows.Forms.Label lblPlaylistDuration;
        private System.Windows.Forms.MaskedTextBox mtbDuration;
        private System.Windows.Forms.MaskedTextBox mtbStartTime;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button btnShowTranscoderLog;
        private System.Windows.Forms.ToolStripMenuItem generateAllConfigsToolStripMenuItem;
        private System.Windows.Forms.ListBox lsbStatus;
        private System.Windows.Forms.CheckBox ckbServerDebug;
        private System.Windows.Forms.CheckBox ckbTranscoderDebug;
        private System.Windows.Forms.Button btnShowServerLog;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txbServerIP;
        private System.Windows.Forms.TextBox txbServerIPEdit;
        private System.Windows.Forms.Button btnResolve;
        private System.Windows.Forms.Button btnResolveEdit;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.NumericUpDown nudAdminPortEdit;
        private System.Windows.Forms.NumericUpDown nudAdminPort;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button btnNextTrack;
        private System.Windows.Forms.GroupBox groupBox22;
        private System.Windows.Forms.DataGridView dgvCurrentTracks;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTranscoderName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colArtist;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAlbum;
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
        private System.Windows.Forms.GroupBox groupBox23;
        private System.Windows.Forms.Button btnUpdateAudioDevice;
        private System.Windows.Forms.ComboBox cmbAudioDevice;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Button btnStopCapture;
        private System.Windows.Forms.Button btnStartCapture;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.GroupBox groupBox24;
        private System.Windows.Forms.DataGridView dgvServerListeners;
        private System.Windows.Forms.Button btnUpdateListeners;
        private System.Windows.Forms.GroupBox groupBox25;
        private System.Windows.Forms.Label lblAverageTime;
        private System.Windows.Forms.Label lblUniqueListeners;
        private System.Windows.Forms.Label lblPeakListeners;
        private System.Windows.Forms.Label lblNumberListeners;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHostname;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserAgent;
        private System.Windows.Forms.DataGridViewTextBoxColumn colConnectTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUID;
        private System.Windows.Forms.ToolStripMenuItem checkLibraryToolStripMenuItem;


    }
}

