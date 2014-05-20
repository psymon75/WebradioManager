using Calendar;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebradioManager
{
    public partial class AdminView : Form
    {
        const string DEFAULT_SEARCH_STRING = "Search...";
        const int MAX_NAME_LENGTH = 255;

        private AdminController _controller;
        private int _idWebradio;
        private string _nameWebradio;
        List<EventAppointment> _events;


        #region Properties
        public string NameWebradio
        {
            get { return _nameWebradio; }
            set { _nameWebradio = value; }
        }
        public List<EventAppointment> EventsCalendar
        {
            get { return _events; }
            set { _events = value; }
        }

        public int IdWebradio
        {
            get { return _idWebradio; }
            set { _idWebradio = value; }
        }

        public AdminController Controller
        {
            get { return _controller; }
            set { _controller = value; }
        }
        #endregion

        public AdminView(int idWebradio, AdminController controller)
        {
            InitializeComponent();
            this.Controller = controller;
            this.IdWebradio = idWebradio;
            this.EventsCalendar = new List<EventAppointment>();
            this.UpdateAudioDevices();
            //this.Controller.CheckFolders(idWebradio);
        }


        public void UpdateView()
        {
            int index;
            Webradio webradio = this.Controller.GetWebradio(this.IdWebradio);
            this.NameWebradio = webradio.Name;
            this.Text = "WebradioManager - " + this.NameWebradio;
            txbWebradioName.Text = this.NameWebradio;
            lblWebradioTitle.Text = this.NameWebradio;
            cmbTypePlaylist.SelectedIndex = 0;
            cmbTypePlaylistGenerate.SelectedIndex = 0;

            //LIBRARY
            dgvMusics.Rows.Clear();
            dgvAds.Rows.Clear();
            List<AudioFile> audiofiles = this.Controller.GetLibrary();
            foreach (AudioFile file in audiofiles)
            {
                if (file is Music)
                    dgvMusics.Rows.Add(file.GetInfosArray());
                else if (file is Ad)
                    dgvAds.Rows.Add(file.GetInfosArray());
            }
            txbSearchAd.Text = (txbSearchAd.Text != DEFAULT_SEARCH_STRING)?txbSearchAd.Text:DEFAULT_SEARCH_STRING;
            txbSearchMusic.Text = (txbSearchMusic.Text != DEFAULT_SEARCH_STRING) ? txbSearchMusic.Text : DEFAULT_SEARCH_STRING;
            this.txbSearchTextChanged(txbSearchAd, new EventArgs());
            this.txbSearchTextChanged(txbSearchMusic, new EventArgs());
            //----
            //PLAYLIST
            lblPlaylistDuration.Text = "";
            cmbPlaylistsMusic.Items.Clear();
            cmbPlaylistsAd.Items.Clear();
            cmbPlaylistEvent.Items.Clear();
            lsbPlaylistsAd.Items.Clear();
            lsbPlaylistsMusic.Items.Clear();
            dgvPlaylistContent.Rows.Clear();

            cmbPlaylistEvent.Items.AddRange(webradio.Playlists.ToArray());
            foreach (Playlist playlist in webradio.Playlists)
            {
                if (playlist is PlaylistMusic)
                {
                    cmbPlaylistsMusic.Items.Add(playlist);
                    lsbPlaylistsMusic.Items.Add(playlist);
                }
                else if (playlist is PlaylistAd)
                {
                    cmbPlaylistsAd.Items.Add(playlist);
                    lsbPlaylistsAd.Items.Add(playlist);
                }
            }
            if (cmbPlaylistsAd.Items.Count > 0)
                cmbPlaylistsAd.SelectedIndex = 0;
            if (cmbPlaylistsMusic.Items.Count > 0)
                cmbPlaylistsMusic.SelectedIndex = 0;
            if (cmbPlaylistEvent.Items.Count > 0)
                cmbPlaylistEvent.SelectedIndex = 0;
            lsbPlaylistsAd.SelectedIndex = -1;
            lsbPlaylistsMusic.SelectedIndex = -1;
            //----
            //GENDER
            List<string> gender = this.Controller.GetGenders();
            cmbGenderGenerate.Items.Clear();
            cmbGenderGenerate.Items.AddRange(gender.ToArray());
            if (cmbGenderGenerate.Items.Count > 0)
                cmbGenderGenerate.SelectedIndex = 0;
            //----
            //EVENTS
            this.EventsCalendar.Clear();
            dvwTimetable.Refresh();
            dvwTimetable.Invalidate();
            foreach (CalendarEvent ev in webradio.Calendar.Events)
            {
                DayWeek dw = ev.GetSelectedDays();
                bool[] days = dw.ToArray();
                for (int i = 0; i < 7; i++)
                {
                    if (days[i])
                    {
                        EventAppointment m_Appointment = new EventAppointment();

                        m_Appointment.StartDate = new DateTime(dvwTimetable.StartDate.Year, dvwTimetable.StartDate.Month, (i + 1), ev.StartTime.Hours, ev.StartTime.Minutes, ev.StartTime.Seconds);
                        m_Appointment.EndDate = m_Appointment.StartDate.Add(ev.Duration);
                        m_Appointment.Title = ev.Name + "(" + ev.Priority.ToString() + ")\r\n " + ev.Playlist.Name + "\r\n Shuffle : " + ((ev.Shuffle) ? "True" : "False");
                        if (ev.Playlist.Type == AudioType.Music)
                        {
                            m_Appointment.BorderColor = Color.Blue;
                            //m_Appointment.Color = Color.Blue;
                        }
                        else
                        {
                            m_Appointment.BorderColor = Color.Red;
                            //m_Appointment.Color = Color.Red;
                        }
                        m_Appointment.Playlist = ev.Playlist;
                        m_Appointment.EventObject = ev;
                        this.EventsCalendar.Add(m_Appointment);
                    }
                }
            }
            //----
            //TRANSCODERS
            index = lsbTranscoders.SelectedIndex;
            lsbTranscoders.Items.Clear();
            lsbTranscoders.Items.AddRange(webradio.Transcoders.ToArray());
            lsbTranscoders.SelectedIndex = index;
            cmbBitrate.Items.Clear();
            index = cmbBitrateEdit.SelectedIndex;
            cmbBitrateEdit.Items.Clear();
            foreach (int bitrate in WebradioTranscoder.AvaliableBitrates)
            {
                cmbBitrate.Items.Add((bitrate / 1000));
                cmbBitrateEdit.Items.Add((bitrate / 1000));
            }
            cmbBitrate.SelectedIndex = 0;
            cmbBitrateEdit.SelectedIndex = index;

            cmbSampleRate.Items.Clear();
            index = cmbSampleRateEdit.SelectedIndex;
            cmbSampleRateEdit.Items.Clear();
            foreach (int samplerate in WebradioTranscoder.AvaliableSampleRates)
            {
                cmbSampleRate.Items.Add(samplerate.ToString());
                cmbSampleRateEdit.Items.Add(samplerate.ToString());
            }
            cmbSampleRate.SelectedIndex = 0;
            cmbSampleRateEdit.SelectedIndex = index;

            cmbEncoder.SelectedIndex = 0;

            lsbStatus.Items.Clear();
            dgvCurrentTracks.Rows.Clear();
            foreach(WebradioTranscoder transcoder in webradio.Transcoders)
            {
                lsbStatus.Items.Add(transcoder.Name + " : " + ((transcoder.IsRunning()) ? "On" : "Off"));
                if (transcoder.IsRunning())
                {
                    AudioFile file = this.Controller.GetAudioFileByFilename(transcoder.CurrentTrack);
                    if (file != null)
                    {
                        string[] values = new string[] { transcoder.Name, file.Title, file.Artist, file.Album };
                        dgvCurrentTracks.Rows.Add(values);
                    }
                }
            }

            //----
            //SERVER
            nudPortServer.Value = webradio.Server.Port;
            txbLocalServerPassword.Text = webradio.Server.Password;
            txbLocalServerAdminPassword.Text = webradio.Server.AdminPassword;
            nudMaxListener.Value = webradio.Server.MaxListener;
            bool running = webradio.Server.IsRunning();
            lblStatusServer.Text = (running) ? "On" : "Off";
            lblStatusServer.ForeColor = (running) ? Color.Green : Color.Red;
            btnStartServer.Enabled = (running) ? false : true;
            btnStopServer.Enabled = (running) ? true : false;

            if(webradio.Server.Stats != null)
                this.ShowServerStats(webradio.Server.Stats);
            //----            
        }

        private void ShowServerStats(WebradioServerStats stats)
        {
            lblNumberListeners.Text = stats.CurrentListeners.ToString();
            lblPeakListeners.Text = stats.PeakListeners.ToString();
            lblUniqueListeners.Text = stats.UniqueListeners.ToString();
            lblAverageTime.Text = stats.AverageTime.ToString();
        }

        private void UpdateAudioDevices()
        {
            ManagementObjectSearcher objSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_SoundDevice");

            ManagementObjectCollection objCollection = objSearcher.Get();
            cmbAudioDevice.Items.Clear();
            foreach (ManagementObject obj in objCollection)
            {
                foreach (PropertyData property in obj.Properties)
                {
                    if (property.Name == "Caption")
                        cmbAudioDevice.Items.Add(property.Value);
                }
            }
            
            if (cmbAudioDevice.Items.Count > 0)
                cmbAudioDevice.SelectedIndex = 0;
        }

        void dvwTimetable_SelectionChanged(object sender, EventArgs e)
        {
            ckbMonday.Checked = (dvwTimetable.SelectionStart.DayOfWeek == DayOfWeek.Monday) ? true : false;
            ckbTuesday.Checked = (dvwTimetable.SelectionStart.DayOfWeek == DayOfWeek.Tuesday) ? true : false;
            ckbWednesday.Checked = (dvwTimetable.SelectionStart.DayOfWeek == DayOfWeek.Wednesday) ? true : false;
            ckbThursday.Checked = (dvwTimetable.SelectionStart.DayOfWeek == DayOfWeek.Thursday) ? true : false;
            ckbFriday.Checked = (dvwTimetable.SelectionStart.DayOfWeek == DayOfWeek.Friday) ? true : false;
            ckbSaturday.Checked = (dvwTimetable.SelectionStart.DayOfWeek == DayOfWeek.Saturday) ? true : false;
            ckbSunday.Checked = (dvwTimetable.SelectionStart.DayOfWeek == DayOfWeek.Sunday) ? true : false;

            TimeSpan start = new TimeSpan();
            TimeSpan end = new TimeSpan();
            if (dvwTimetable.Selection == SelectionType.Appointment)
            {
                start = new TimeSpan(dvwTimetable.SelectedAppointment.StartDate.Hour, dvwTimetable.SelectedAppointment.StartDate.Minute, dvwTimetable.SelectedAppointment.StartDate.Second);
                end = new TimeSpan(dvwTimetable.SelectedAppointment.EndDate.Hour, dvwTimetable.SelectedAppointment.EndDate.Minute, dvwTimetable.SelectedAppointment.EndDate.Second);
            }
            else if (dvwTimetable.Selection == SelectionType.DateRange)
            {
                start = new TimeSpan(dvwTimetable.SelectionStart.Hour, dvwTimetable.SelectionStart.Minute, dvwTimetable.SelectionStart.Second);
                end = new TimeSpan(dvwTimetable.SelectionEnd.Hour, dvwTimetable.SelectionEnd.Minute, dvwTimetable.SelectionEnd.Second);
            }


            mtbStartTime.Text = start.ToString();
            mtbDuration.Text = (end - start).ToString();
        }


        private void dvwTimetable_ResolveAppointments(object sender, ResolveAppointmentsEventArgs args)
        {
            List<Appointment> m_Apps = new List<Appointment>();
            foreach (Appointment m_App in this.EventsCalendar)
                m_Apps.Add(m_App);

            args.Appointments = m_Apps;

        }


        private void AdminView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("All transcoders and the server will be shuting down. Are you sure ?", "Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (this.Controller.StopAllTranscoders(this.IdWebradio))
                    this.Controller.FormClose();
                else
                {
                    MessageBox.Show("An error has occured", "Error");
                    e.Cancel = true;
                }
            }
            else
                e.Cancel = true;
        }

        private void ImportFolder_Click(object sender, EventArgs e)
        {
            AudioType type;
            string[] filenames;
            if ((sender as Button).Tag.ToString() == AudioType.Music.ToString())
                type = AudioType.Music;
            else
                type = AudioType.Ad;
            if (FBD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //Recusively
                if (MessageBox.Show("Do you want to search recursively ?", "Recursively", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    filenames = Directory.GetFiles(FBD.SelectedPath, "*.mp3", SearchOption.AllDirectories);
                else
                    filenames = Directory.GetFiles(FBD.SelectedPath, "*.mp3", SearchOption.TopDirectoryOnly);

                if (this.Controller.ImportFilesToLibrary(filenames, type))
                    MessageBox.Show("Importation completed", "Success");
                else
                    MessageBox.Show("An error occured", "Error");
            }
        }

        private void ImportFiles_Click(object sender, EventArgs e)
        {
            AudioType type;
            if ((sender as Button).Tag.ToString() == AudioType.Music.ToString())
                type = AudioType.Music;
            else
                type = AudioType.Ad;
            if (OFD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (this.Controller.ImportFilesToLibrary(OFD.FileNames, type))
                    MessageBox.Show("Importation completed", "Success");
                else
                    MessageBox.Show("An error occured", "Error");
            }
        }

        private void txbSearchEnter(object sender, EventArgs e)
        {
            if ((sender as TextBox).Text == DEFAULT_SEARCH_STRING)
                (sender as TextBox).Text = "";
        }

        private void txbSearchLeave(object sender, EventArgs e)
        {
            if ((sender as TextBox).Text == "")
                (sender as TextBox).Text = "Search...";
        }

        private void btnDeleteLibrary_Click(object sender, EventArgs e)
        {
            AudioType type;
            bool state = true;

            if ((sender as Button).Tag.ToString() == AudioType.Music.ToString())
                type = AudioType.Music;
            else
                type = AudioType.Ad;

            DataGridViewSelectedRowCollection rows = ((sender as Button).Tag.ToString() == AudioType.Music.ToString()) ? dgvMusics.SelectedRows : dgvAds.SelectedRows;
            foreach (DataGridViewRow row in rows)
            {
                //Simple check if selected row is not the last empty row
                if (row.Cells[0].Value != null)
                    if (!this.Controller.DeleteAudioFile(int.Parse(row.Cells["colId" + type.ToString()].Value.ToString()), row.Cells["colPath" + type.ToString()].Value.ToString()))
                        state = false;
            }

            if (state)
                this.UpdateView();
            else
                MessageBox.Show("An error occured");
        }

        private void txbSearchTextChanged(object sender, EventArgs e)
        {
            AudioType type;
            bool valid = false;
            string searchString = "";
            if ((sender as TextBox).Tag.ToString() == AudioType.Music.ToString())
                type = AudioType.Music;
            else
                type = AudioType.Ad;


            if ((sender as TextBox).Text != "" && (sender as TextBox).Text != DEFAULT_SEARCH_STRING)
            {
                searchString = (sender as TextBox).Text.ToLower();
                foreach (DataGridViewRow row in ((type == AudioType.Music) ? dgvMusics.Rows : dgvAds.Rows))
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value.ToString().ToLower().Contains(searchString))
                        {
                            valid = true;
                            break;
                        }
                    }
                    row.Visible = (valid) ? true : false;
                    valid = false;
                }
            }
        }

        private void btnCreatePlaylist_Click(object sender, EventArgs e)
        {
            if (txbPlaylistName.Text.Trim() != "" && txbPlaylistName.Text.Length <= MAX_NAME_LENGTH)
            {
                if (!this.Controller.CreatePlaylist(txbPlaylistName.Text, this.NameWebradio, this.IdWebradio, (cmbTypePlaylist.SelectedItem.ToString() == "Music") ? AudioType.Music : AudioType.Ad))
                    MessageBox.Show("Playlist already exist or the name is invalid", "Error");
            }
            else
                MessageBox.Show("Please enter a valid playlist's name. (1-"+ MAX_NAME_LENGTH +" characters)", "Empty name");
        }

        private void btnDeletePlaylistClick(object sender, EventArgs e)
        {
            AudioType type;
            type = ((sender as Button).Tag.ToString() == AudioType.Music.ToString()) ? AudioType.Music : AudioType.Ad;

            if (((type == AudioType.Music) ? lsbPlaylistsMusic.SelectedIndex : lsbPlaylistsAd.SelectedIndex) >= 0)
                this.Controller.DeletePlaylist((Playlist)((type == AudioType.Music) ? lsbPlaylistsMusic.SelectedItem : lsbPlaylistsAd.SelectedItem), this.IdWebradio);
            else
                MessageBox.Show("Please select a playlist to delete.", "No playlist selected");
        }

        private void btnAddToClick(object sender, EventArgs e)
        {
            AudioType type = ((sender as Button).Tag.ToString() == AudioType.Music.ToString()) ? AudioType.Music : AudioType.Ad;
            Dictionary<int, string> audioFiles = new Dictionary<int, string>();
            DataGridViewSelectedRowCollection rows = ((type == AudioType.Music) ? dgvMusics.SelectedRows : dgvAds.SelectedRows);
            this.Cursor = Cursors.WaitCursor;
            foreach (DataGridViewRow row in rows)
            {
                //Simple check if selected row is not the last empty row
                if (row.Cells[0].Value != null)
                    audioFiles.Add(int.Parse(row.Cells["colId" + type.ToString()].Value.ToString()), row.Cells["colPath" + type.ToString()].Value.ToString());

            }
            this.Cursor = Cursors.Default;
            if (this.Controller.AddToPlaylist((Playlist)((type == AudioType.Music) ? cmbPlaylistsMusic.SelectedItem : cmbPlaylistsAd.SelectedItem),
                audioFiles))
                this.UpdateView();

        }

        private void lsbPlaylistsSelectedIndexChanged(object sender, EventArgs e)
        {
            AudioType type = ((sender as ListBox).Tag.ToString() == AudioType.Music.ToString()) ? AudioType.Music : AudioType.Ad;
            btnRemoveFromPlaylist.Tag = type;
            if ((sender as ListBox).SelectedIndex >= 0)
            {
                this.GetPlaylistContent((Playlist)(sender as ListBox).SelectedItem);
            }
        }

        private void GetPlaylistContent(Playlist playlist)
        {
            dgvPlaylistContent.Rows.Clear();
            TimeSpan totalDuration = new TimeSpan(0, 0, 0);
            List<AudioFile> audioFiles = this.Controller.GetPlaylistContent(playlist);
            foreach (AudioFile af in audioFiles)
            {
                totalDuration += af.Duration;
                dgvPlaylistContent.Rows.Add(af.GetInfosArray());
            }
            lblPlaylistDuration.Text = "Duration : " + totalDuration.ToString();
        }

        private void btnRemoveFromPlaylist_Click(object sender, EventArgs e)
        {
            if (btnRemoveFromPlaylist.Tag == null)
            {
                MessageBox.Show("No playlist selected", "No playlist");
                return;
            }
            AudioType type = (AudioType)btnRemoveFromPlaylist.Tag;
            Dictionary<int, string> audioFiles = new Dictionary<int, string>();
            this.Cursor = Cursors.WaitCursor;
            foreach (DataGridViewRow row in dgvPlaylistContent.SelectedRows)
            {
                //Simple check if selected row is not the last empty row
                if (row.Cells[0].Value != null)
                    audioFiles.Add(int.Parse(row.Cells["colIdPlaylist"].Value.ToString()), row.Cells["colPathPlaylist"].Value.ToString());

            }
            this.Cursor = Cursors.Default;
            Playlist selectedPlaylist = (Playlist)((type == AudioType.Music) ? lsbPlaylistsMusic.SelectedItem : lsbPlaylistsAd.SelectedItem);
            if (!this.Controller.RemoveFromPlaylist(selectedPlaylist, audioFiles))
                MessageBox.Show("An error occured", "Error");
            else
            {
                this.GetPlaylistContent(selectedPlaylist);
            }

        }

        private void txbSearchPlaylistContent_TextChanged(object sender, EventArgs e)
        {
            string searchString = "";
            bool valid = false;
            if (txbSearchPlaylistContent.Text != "" && txbSearchPlaylistContent.Text != DEFAULT_SEARCH_STRING)
            {
                searchString = txbSearchPlaylistContent.Text.ToLower();
                foreach (DataGridViewRow row in dgvPlaylistContent.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value.ToString().ToLower().Contains(searchString))
                        {
                            valid = true;
                            break;
                        }
                    }
                    row.Visible = (valid) ? true : false;
                    valid = false;
                }
            }
        }

        private void cmbTypePlaylistGenerate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTypePlaylistGenerate.SelectedItem.ToString() == AudioType.Ad.ToString())
                cmbGenderGenerate.Enabled = false;
            else
                cmbGenderGenerate.Enabled = true;
        }

        private void btnGeneratePlaylist_Click(object sender, EventArgs e)
        {
            if (txbPlaylistNameGenerate.Text.Trim() != "" && txbPlaylistNameGenerate.Text.Length <= MAX_NAME_LENGTH)
            {
                TimeSpan duration = new TimeSpan(0, (int)nudDurationGenerate.Value, 0);
                if (!this.Controller.GeneratePlaylist(txbPlaylistNameGenerate.Text, duration,
                    (cmbTypePlaylistGenerate.SelectedItem.ToString() == AudioType.Music.ToString()) ? AudioType.Music : AudioType.Ad,
                    cmbGenderGenerate.SelectedItem.ToString(), this.IdWebradio, this.NameWebradio))
                {
                    MessageBox.Show("Impossible to generate a playlist with these parameters. Some issues possible :\n - A playlist with this name and this type already exists\n - The given duration is too short for this gender", "Error");
                }
            }
            else
                MessageBox.Show("Please enter a valid playlist's name. (1-"+ MAX_NAME_LENGTH +" characters)", "Error");
        }

        private void ckbCheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Name == "ckbAll")
            {
                ckbMonday.Checked = ckbAll.Checked;
                ckbTuesday.Checked = ckbAll.Checked;
                ckbWednesday.Checked = ckbAll.Checked;
                ckbThursday.Checked = ckbAll.Checked;
                ckbFriday.Checked = ckbAll.Checked;
                ckbSaturday.Checked = ckbAll.Checked;
                ckbSunday.Checked = ckbAll.Checked;
            }

        }

        private void btnCreateEvent_Click(object sender, EventArgs e)
        {
            if (txbEventName.Text.Trim() != "" && txbEventName.Text.Length <= MAX_NAME_LENGTH)
            {
                TimeSpan start = new TimeSpan();
                if (!TimeSpan.TryParse(mtbStartTime.Text, out start))
                {
                    MessageBox.Show("Start time format is not correct.", "Error");
                    return;
                }
                TimeSpan duration = new TimeSpan();
                if (!TimeSpan.TryParse(mtbDuration.Text, out duration))
                {
                    MessageBox.Show("Duration time format is not correct.", "Error");
                    return;
                }
                TimeSpan minimumDuration = new TimeSpan(0, 1, 0);
                if (duration >= minimumDuration)
                {
                    int repeat = this.GetRepeatValue();
                    if (repeat > 0)
                    {
                        CalendarEvent newEvent = new CalendarEvent(txbEventName.Text, start, duration, repeat, (int)nudPriority.Value, ckbShuffle.Checked, true, (Playlist)cmbPlaylistEvent.SelectedItem);
                        if (!this.Controller.CreateEvent(newEvent, this.IdWebradio))
                            MessageBox.Show("Event already exists (with this name)", "Error");
                    }
                    else
                        MessageBox.Show("Please select a day", "Error");

                }
                else
                    MessageBox.Show("Duration must be longer or equal to " + minimumDuration.ToString());
            }
            else
                MessageBox.Show("Please enter a valid event's name. (1-"+ MAX_NAME_LENGTH +" characters)", "Error");
        }

        private void dvwTimetable_MouseUp(object sender, MouseEventArgs e)
        {
            if (dvwTimetable.Selection == SelectionType.Appointment)
            {
                EventAppointment app = (EventAppointment)dvwTimetable.SelectedAppointment;
                if (this.CheckMovePossible(app))
                {
                    CalendarEvent aEvent = app.EventObject;
                    TimeSpan start = new TimeSpan(app.StartDate.Hour, app.StartDate.Minute, app.StartDate.Second);
                    TimeSpan end = new TimeSpan(app.EndDate.Hour, app.EndDate.Minute, app.EndDate.Second);
                    aEvent.StartTime = start;
                    aEvent.Duration = end - start;

                    aEvent.Repeat = this.GetRepeatValueFromAppointement(this.GetAllRelatedAppointment(app));
                    if (!this.Controller.UpdateEvent(aEvent, this.IdWebradio))
                        MessageBox.Show("An error occured", "Error");
                }
                else
                {
                    MessageBox.Show("The same event can't be in the same day more than once.", "Error");
                    this.UpdateView();
                }
            }
        }

        private int GetRepeatValue()
        {
            int repeat = 0;
            repeat += (ckbMonday.Checked) ? (int)DayValue.Monday : 0;
            repeat += (ckbTuesday.Checked) ? (int)DayValue.Tuesday : 0;
            repeat += (ckbWednesday.Checked) ? (int)DayValue.Wednesday : 0;
            repeat += (ckbThursday.Checked) ? (int)DayValue.Thursday : 0;
            repeat += (ckbFriday.Checked) ? (int)DayValue.Friday : 0;
            repeat += (ckbSaturday.Checked) ? (int)DayValue.Saturday : 0;
            repeat += (ckbSunday.Checked) ? (int)DayValue.Sunday : 0;
            return repeat;
        }

        private List<EventAppointment> GetAllRelatedAppointment(EventAppointment app)
        {
            List<EventAppointment> eventList = new List<EventAppointment>();
            foreach (EventAppointment tmp in this.EventsCalendar)
            {
                if (tmp.EventObject.Id == app.EventObject.Id)
                    eventList.Add(tmp);
            }

            return eventList;
        }

        private int GetRepeatValueFromAppointement(List<EventAppointment> eventList)
        {
            int repeat = 0;
            foreach (EventAppointment ev in eventList)
            {
                repeat += (ev.StartDate.DayOfWeek == DayOfWeek.Monday) ? (int)DayValue.Monday : 0;
                repeat += (ev.StartDate.DayOfWeek == DayOfWeek.Tuesday) ? (int)DayValue.Tuesday : 0;
                repeat += (ev.StartDate.DayOfWeek == DayOfWeek.Wednesday) ? (int)DayValue.Wednesday : 0;
                repeat += (ev.StartDate.DayOfWeek == DayOfWeek.Thursday) ? (int)DayValue.Thursday : 0;
                repeat += (ev.StartDate.DayOfWeek == DayOfWeek.Friday) ? (int)DayValue.Friday : 0;
                repeat += (ev.StartDate.DayOfWeek == DayOfWeek.Saturday) ? (int)DayValue.Saturday : 0;
                repeat += (ev.StartDate.DayOfWeek == DayOfWeek.Sunday) ? (int)DayValue.Sunday : 0;
            }
            return repeat;
        }

        private bool CheckMovePossible(EventAppointment app)
        {
            bool result = true;
            foreach (EventAppointment ev in this.EventsCalendar)
            {
                if (ev.EventObject.Id == app.EventObject.Id && ev != app)
                {
                    if (ev.StartDate.DayOfWeek == app.StartDate.DayOfWeek)
                    {
                        result = false;
                        break;
                    }
                }
            }
            return result;
        }

        private void dvwTimetable_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (dvwTimetable.Selection == SelectionType.Appointment)
                {
                    if (MessageBox.Show("Do you really want to delete this event ?", "Delete event", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (!this.Controller.DeleteEvent((dvwTimetable.SelectedAppointment as EventAppointment).EventObject, this.IdWebradio))
                            MessageBox.Show("An error occured", "Error");
                    }
                }
            }
        }

        private void btnCreateTranscoder_Click(object sender, EventArgs e)
        {
            if (txbStreamName.Text.Trim() != "" && txbServerPassword.Text.Trim() != "" && txbStreamName.Text.Length <= MAX_NAME_LENGTH)
            {
                IPAddress ip;
                if (IPAddress.TryParse(txbServerIP.Text, out ip))
                {
                    if (cmbEncoder.SelectedItem.ToString() == StreamType.MP3.ToString())
                        MessageBox.Show("You have selected MP3. MP3 need a licence to broadcast. Currently the transcoder will not work. WIP");
                    bool result = this.Controller.CreateTranscoder(txbStreamName.Text,
                        (cmbEncoder.SelectedItem.ToString() == StreamType.MP3.ToString()) ? StreamType.MP3 : StreamType.AACPlus,
                        int.Parse(cmbSampleRate.SelectedItem.ToString()), int.Parse(cmbBitrate.SelectedItem.ToString()), txbStreamUrl.Text, ip, (int)nudPort.Value, (int)nudAdminPort.Value, txbServerPassword.Text, this.IdWebradio);
                    if (!result)
                        MessageBox.Show("Transcoder already exist or name is invalid", "Error");
                }
                else
                    MessageBox.Show("IP Address is invalid", "Error");
            }
            else
                MessageBox.Show("Please enter a valid stream's name and a server's password.(1-"+ MAX_NAME_LENGTH +" characters)", "Error");
        }

        private void btnDeleteTranscoder_Click(object sender, EventArgs e)
        {
            if (lsbTranscoders.SelectedIndex >= 0)
            {
                if (!this.Controller.DeleteTranscoder((WebradioTranscoder)lsbTranscoders.SelectedItem, this.IdWebradio))
                    MessageBox.Show("An error occured", "Error");
            }
            else
                MessageBox.Show("Please select a transcoder to delete", "Error");
        }

        private void lsbTranscoders_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ShowTranscoderInfos((WebradioTranscoder)lsbTranscoders.SelectedItem);
        }

        private void ShowTranscoderInfos(WebradioTranscoder transcoder)
        {
            if (transcoder != null)
             {
                txbStreamNameEdit.Text = transcoder.Name;
                txbStreamUrlEdit.Text = transcoder.Url;
                txbServerIPEdit.Text = transcoder.Ip.ToString();
                txbServerPasswordEdit.Text = transcoder.Password;
                nudPortEdit.Value = transcoder.Port;
                nudAdminPortEdit.Value = transcoder.AdminPort;
                cmbSampleRateEdit.SelectedItem = transcoder.SampleRate.ToString();
                cmbBitrateEdit.SelectedItem = transcoder.Birate;
                cmbEncoderEdit.SelectedItem = (transcoder.StreamType == StreamType.MP3) ? "MP3" : "AAC+";

                bool running = transcoder.IsRunning();
                lblStatusTranscoder.Text = (running) ? "On" : "Off";
                lblStatusTranscoder.ForeColor = (running) ? Color.Green : Color.Red;
                btnStartTranscoder.Enabled = !running;
                btnStopTranscoder.Enabled = running;
                btnNextTrack.Enabled = running;

                btnStartCapture.Enabled = !transcoder.Capture;
                btnStopCapture.Enabled = transcoder.Capture;

            }
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lsbTranscoders.SelectedIndex >= 0)
            {
                if (MessageBox.Show("Transcoder will restart if it's running after update. Do you really want to update ?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (txbStreamNameEdit.Text.Trim() != "" && txbServerPasswordEdit.Text.Trim() != "")
                    {
                        IPAddress ip;
                        if (IPAddress.TryParse(txbServerIPEdit.Text, out ip))
                        {
                            WebradioTranscoder transcoder = (WebradioTranscoder)lsbTranscoders.SelectedItem;
                            transcoder.Name = txbStreamNameEdit.Text;
                            transcoder.Url = txbStreamUrlEdit.Text;
                            transcoder.Password = txbServerPasswordEdit.Text;
                            transcoder.Ip = ip;
                            transcoder.Port = (int)nudPortEdit.Value;
                            transcoder.AdminPort = (int)nudAdminPortEdit.Value;
                            transcoder.Birate = int.Parse(cmbBitrateEdit.SelectedItem.ToString());
                            transcoder.SampleRate = int.Parse(cmbSampleRateEdit.SelectedItem.ToString());
                            transcoder.StreamType = (cmbEncoderEdit.SelectedItem.ToString() == StreamType.MP3.ToString()) ? StreamType.MP3 : StreamType.AACPlus;
                            if (!this.Controller.UpdateTranscoder(transcoder, ckbTranscoderDebug.Checked, this.IdWebradio))
                                MessageBox.Show("An error has occured", "Error");
                            else
                            {
                                this.ShowTranscoderInfos(transcoder);
                                MessageBox.Show("Update successful", "Succes");
                            }
                        }
                        else
                            MessageBox.Show("IP address is invalid", "Error");
                    }
                    else
                        MessageBox.Show("Please enter a name and a password", "Error");
                }
            }
            else
                MessageBox.Show("Please select a transcoder", "Error");
        }

        private void btnStartTranscoder_Click(object sender, EventArgs e)
        {
            if (lsbTranscoders.SelectedIndex >= 0)
            {
                WebradioTranscoder transcoder = (WebradioTranscoder)lsbTranscoders.SelectedItem;
                if (this.Controller.StartTranscoder(transcoder,ckbTranscoderDebug.Checked, this.IdWebradio))
                {
                    this.ShowTranscoderInfos(transcoder);

                }
                else
                    MessageBox.Show("An error has occured. Please terminate sc_trans process.", "Error");
            }
            else
                MessageBox.Show("Please select a transcoder", "Error");
        }


        private void btnStopTranscoder_Click(object sender, EventArgs e)
        {
            if (lsbTranscoders.SelectedIndex >= 0)
            {
                WebradioTranscoder transcoder = (WebradioTranscoder)lsbTranscoders.SelectedItem;
                if (this.Controller.StopTranscoder(transcoder, this.IdWebradio))
                {
                    this.ShowTranscoderInfos(transcoder);

                }
                else
                    MessageBox.Show("An error has occured.\n- Please terminate sc_trans process.\n- Please check that sc_trans.exe is in the shoutcast folder.", "Error");
            }
            else
                MessageBox.Show("Please select a transcoder", "Error");

        }

        private void btnShowTranscoderLog_Click(object sender, EventArgs e)
        {
            if (lsbTranscoders.SelectedIndex >= 0)
            {
                try
                {
                    Process.Start("notepad", Directory.GetCurrentDirectory() + "\\" + ((WebradioTranscoder)lsbTranscoders.SelectedItem).LogFilename.Replace("/", "\\"));
                }
                catch
                {
                    MessageBox.Show("Impossible to access logfile", "Error");
                }
            }
        }

        private void generateAllConfigsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Controller.GenerateAllConfigs(this.IdWebradio);
        }

        private void btnSaveServer_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Server will restart if it's running after update. Do you really want to update ?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (txbLocalServerPassword.Text.Trim() != "" && txbLocalServerAdminPassword.Text.Trim() != "")
                {
                    if (txbLocalServerPassword.Text != txbLocalServerAdminPassword.Text)
                    {
                        if (this.Controller.UpdateServer(ckbServerDebug.Checked,(int)nudPortServer.Value, txbLocalServerPassword.Text, txbLocalServerAdminPassword.Text, (int)nudMaxListener.Value, this.IdWebradio))
                            MessageBox.Show("Server informations updated.", "Success");
                        else
                            MessageBox.Show("An error has occured", "Error");
                    }
                    else
                        MessageBox.Show("Password must be different", "Error");
                }
                else
                    MessageBox.Show("Please enter a password and an admin password.", "Error");
            }
        }

        private void btnStartServer_Click(object sender, EventArgs e)
        {
            if (!this.Controller.StartServer(this.IdWebradio, ckbServerDebug.Checked))
                MessageBox.Show("An error has occured.\n- Please terminate sc_server process.\n- Please check that sc_serv.exe is in the shoutcast folder.", "Error");
        }

        private void btnStopServer_Click(object sender, EventArgs e)
        {
            if (!this.Controller.StopServer(this.IdWebradio))
                MessageBox.Show("An error has occured. Please terminate sc_server process.", "Error");
        }

        private void btnShowWebInterface_Click(object sender, EventArgs e)
        {
            this.Controller.ShowServerWebInterface(this.IdWebradio);
        }

        private void btnShowWebAdministration_Click(object sender, EventArgs e)
        {
            this.Controller.ShowServerWebAdmin(this.IdWebradio);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("WebradioManager V0.1\nSimon Menetrey\nTravail de diplôme 2014", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnShowServerLog_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("notepad", Directory.GetCurrentDirectory() + "\\" + this.Controller.GetWebradio(this.IdWebradio).Server.LogFilename.Replace("/", "\\"));
            }
            catch
            {
                MessageBox.Show("Impossible to access logfile", "Error");
            }
        }


        private void btnResolve_Click(object sender, EventArgs e)
        {
            bool editSection = false;
            if ((sender as Button).Tag != null)
                editSection = true;
            IPAddress ip;
            if (!GetResolvedConnecionIPAddress((editSection) ? txbServerIPEdit.Text : txbServerIP.Text, out ip))
                MessageBox.Show("Impossible to resolve this dns name", "Error");
            else
            {
                if (editSection)
                    txbServerIPEdit.Text = ip.ToString();
                else
                    txbServerIP.Text = ip.ToString();
            }

        }

        //http://www.codeproject.com/Tips/440861/Resolving-a-hostname-in-Csharp-and-retrieving-IP-v
        private bool GetResolvedConnecionIPAddress(string serverNameOrURL,
                   out IPAddress resolvedIPAddress)
        {
            bool isResolved = false;
            IPHostEntry hostEntry = null;
            IPAddress resolvIP = null;
            try
            {
                if (!IPAddress.TryParse(serverNameOrURL, out resolvIP))
                {
                    hostEntry = Dns.GetHostEntry(serverNameOrURL);

                    if (hostEntry != null && hostEntry.AddressList != null
                                 && hostEntry.AddressList.Length > 0)
                    {
                        if (hostEntry.AddressList.Length == 1)
                        {
                            resolvIP = hostEntry.AddressList[0];
                            isResolved = true;
                        }
                        else
                        {
                            foreach (IPAddress var in hostEntry.AddressList)
                            {
                                if (var.AddressFamily == AddressFamily.InterNetwork)
                                {
                                    resolvIP = var;
                                    isResolved = true;
                                    break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    isResolved = true;
                }
            }
            catch (Exception ex)
            {
                isResolved = false;
                resolvIP = null;
            }
            finally
            {
                resolvedIPAddress = resolvIP;
            }

            return isResolved;
        }

        private void btnNextTrack_Click(object sender, EventArgs e)
        {
            if (lsbTranscoders.SelectedIndex >= 0)
            {
                if (!this.Controller.TranscoderNextTrack((WebradioTranscoder)lsbTranscoders.SelectedItem))
                    MessageBox.Show("An error occured.", "Error");
            }
            else
                MessageBox.Show("Please select a running transcoder.", "Error");
        }

        private void btnClearHistory_Click(object sender, EventArgs e)
        {
            if (lsbTranscoders.SelectedIndex >= 0)
            {
                if (this.Controller.ClearHistory(((WebradioTranscoder)lsbTranscoders.SelectedItem).Id))
                    MessageBox.Show("History cleared", "Success");
                else
                    MessageBox.Show("An error has occured", "Error");
            }
            else
                MessageBox.Show("Please select a transcoder.", "Error");
        }

        private void btnGenerateHistory_Click(object sender, EventArgs e)
        {
            if (lsbTranscoders.SelectedIndex >= 0)
            {
                SaveFileDialog SFD = new SaveFileDialog();
                SFD.Filter = ".pdf|PDF";
                SFD.FileName = "history.pdf";
                if (SFD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (this.Controller.GenerateHistory(this.IdWebradio, ((WebradioTranscoder)lsbTranscoders.SelectedItem).Name, ((WebradioTranscoder)lsbTranscoders.SelectedItem).Id, SFD.FileName))
                    {
                        if(MessageBox.Show("Do you want to view the pdf file ?", "Success",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                            Process.Start(SFD.FileName);
                    }
                    else
                        MessageBox.Show("An error has occured", "Error");
                }
            }
            else
                MessageBox.Show("Please select a transcoder.", "Error");
        }

        private void btnModifyName_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("To rename this webradio, all running process (transcoder and server) will be shutting down. Are you sure ?", "Process", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (txbWebradioName.Name.Trim() != "" && txbWebradioName.Name.Length <= MAX_NAME_LENGTH)
                {
                    if (this.Controller.ModifyWebradioName(txbWebradioName.Text, this.IdWebradio))
                        MessageBox.Show("Modification completed", "Success");
                    else
                        MessageBox.Show("This name is already used", "Error");
                }
                else
                    MessageBox.Show("Please enter a valid name. (1-"+ MAX_NAME_LENGTH +" characters)", "Error");
            }
        }

        private void dgvCellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (sender as DataGridView);
            DataGridViewRow row = dgv.Rows[e.RowIndex];
            Dictionary<string, string> data = new Dictionary<string, string>();
            AudioFile file;
            if (dgv.Tag.ToString() == AudioType.Music.ToString())
            {
                file = new Music(int.Parse(row.Cells["colId" + dgv.Tag.ToString()].Value.ToString()),
                    row.Cells["colPath" + dgv.Tag.ToString()].Value.ToString(),
                    row.Cells["colTitle" + dgv.Tag.ToString()].Value.ToString(),
                    row.Cells["colArtist" + dgv.Tag.ToString()].Value.ToString(),
                    row.Cells["colAlbum" + dgv.Tag.ToString()].Value.ToString(),
                    int.Parse(row.Cells["colYear" + dgv.Tag.ToString()].Value.ToString()),
                    row.Cells["colLabel" + dgv.Tag.ToString()].Value.ToString(),
                    new TimeSpan(),
                    row.Cells["colGender" + dgv.Tag.ToString()].Value.ToString());
            }
            else
            {
                file = new Ad(int.Parse(row.Cells["colId" + dgv.Tag.ToString()].Value.ToString()),
                    row.Cells["colPath" + dgv.Tag.ToString()].Value.ToString(),
                row.Cells["colTitle" + dgv.Tag.ToString()].Value.ToString(),
                row.Cells["colArtist" + dgv.Tag.ToString()].Value.ToString(),
                row.Cells["colAlbum" + dgv.Tag.ToString()].Value.ToString(),
                int.Parse(row.Cells["colYear" + dgv.Tag.ToString()].Value.ToString()),
                row.Cells["colLabel" + dgv.Tag.ToString()].Value.ToString(),
                new TimeSpan(),
                row.Cells["colGender" + dgv.Tag.ToString()].Value.ToString());
            }
            if (!this.Controller.UpdateAudioFile(file))
                MessageBox.Show("An error has occured", "Error");
        }

        private void btnUpdateAudioDevice_Click(object sender, EventArgs e)
        {
            this.UpdateAudioDevices();
        }

        private void btnStartCapture_Click(object sender, EventArgs e)
        {
            if (lsbTranscoders.SelectedIndex >= 0)
            {
                this.Controller.TranscoderCapture(true, cmbAudioDevice.SelectedItem.ToString(), (WebradioTranscoder)lsbTranscoders.SelectedItem, this.IdWebradio);
            }
            else
                MessageBox.Show("Please select a transcoder.", "Error");
        }

        private void btnStopCapture_Click(object sender, EventArgs e)
        {
            if (lsbTranscoders.SelectedIndex >= 0)
            {
                this.Controller.TranscoderCapture(false, cmbAudioDevice.SelectedItem.ToString(), (WebradioTranscoder)lsbTranscoders.SelectedItem, this.IdWebradio);
            }
            else
                MessageBox.Show("Please select a transcoder.", "Error");
        }

        private void btnUpdateListeners_Click(object sender, EventArgs e)
        {
            List<WebradioListener> listeners = this.Controller.UpdateServerListeners(this.IdWebradio);
            dgvServerListeners.Rows.Clear();
            foreach(WebradioListener listener in listeners)
            {
                string[] infos = new string[] { listener.Hostname, listener.Useragent, listener.ConnectionTime.ToString(), listener.Uid.ToString() };
                dgvServerListeners.Rows.Add(infos);
            }
            this.Controller.UpdateServerStats(this.IdWebradio);
        }



    }
}
