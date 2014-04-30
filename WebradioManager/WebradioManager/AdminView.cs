using Calendar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebradioManager
{
    public partial class AdminView : Form
    {
        const string DEFAULT_SEARCH_STRING = "Search...";
        private AdminController _controller;
        private int _idWebradio;
        private string _nameWebradio;
        List<Appointment> _events;

        #region Properties
        public string NameWebradio
        {
            get { return _nameWebradio; }
            set { _nameWebradio = value; }
        }
        public List<Appointment> EventsCalendar
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
            this.EventsCalendar = new List<Appointment>();
        }

        public void UpdateView()
        {
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
            txbSearchAd.Text = DEFAULT_SEARCH_STRING;
            txbSearchMusic.Text = DEFAULT_SEARCH_STRING;
            List<AudioFile> audiofiles = this.Controller.GetLibrary();
            foreach (AudioFile file in audiofiles)
            {
                if (file is Music)
                    dgvMusics.Rows.Add(file.GetInfosArray());
                else if(file is Ad)
                    dgvAds.Rows.Add(file.GetInfosArray());
            }
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
            foreach(Playlist playlist in webradio.Playlists)
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
            if(cmbPlaylistsAd.Items.Count > 0)
                cmbPlaylistsAd.SelectedIndex = 0;
            if (cmbPlaylistsMusic.Items.Count > 0)
                cmbPlaylistsMusic.SelectedIndex = 0;
            lsbPlaylistsAd.SelectedIndex = -1;
            lsbPlaylistsMusic.SelectedIndex = -1;
            //----
            //GENDER
            List<string> gender = this.Controller.GetGenders();
            cmbGenderGenerate.Items.Clear();
            cmbGenderGenerate.Items.AddRange(gender.ToArray());
            if(cmbGenderGenerate.Items.Count > 0)
                cmbGenderGenerate.SelectedIndex = 0;
            //----
            //EVENTS
            this.EventsCalendar.Clear();
            foreach(CalendarEvent ev in webradio.Calendar.Events)
            {
                DayWeek dw = ev.GetSelectedDays();
                bool[] days = dw.ToArray();
                for(int i = 0; i < 7;i++)
                {
                    if(days[i])
                    {
                        Appointment m_Appointment = new Appointment();

                        m_Appointment.StartDate = new DateTime(dvwTimetable.StartDate.Year, dvwTimetable.StartDate.Month, (i + 1), ev.StartTime.Hours, ev.StartTime.Minutes, ev.StartTime.Seconds);
                        m_Appointment.EndDate = m_Appointment.StartDate.Add(ev.Duration);
                        m_Appointment.Title = ev.Name + "\r\n Playlist : " + ev.Playlist;

                        this.EventsCalendar.Add(m_Appointment);
                    }
                }        
            }
            //----
            //TRANSCODERS
            lsbTranscoders.Items.Clear();
            lsbTranscoderLog.Items.Clear();
            lsbTranscoders.Items.AddRange(webradio.Transcoders.ToArray());
            cmbBitrate.Items.Clear();
            cmbBitrateEdit.Items.Clear();
            foreach(int bitrate in WebradioTranscoder.AvaliableBitrates)
            {
                cmbBitrate.Items.Add((bitrate / 1000) + " kb/s");
                cmbBitrateEdit.Items.Add((bitrate / 1000) + " kb/s");
            }
            cmbBitrate.SelectedIndex = 0;
            cmbBitrateEdit.SelectedIndex = 0;

            cmbSampleRate.Items.Clear();
            cmbSampleRateEdit.Items.Clear();
            foreach (int samplerate in WebradioTranscoder.AvaliableSampleRates)
            {
                cmbSampleRate.Items.Add(samplerate.ToString() + " Hz");
                cmbSampleRateEdit.Items.Add(samplerate.ToString() + " Hz");
            }
            cmbSampleRate.SelectedIndex = 0;
            cmbSampleRateEdit.SelectedIndex = 0;

            cmbEncoder.SelectedIndex = 0;
            cmbEncoderEdit.SelectedIndex = 0;
            //----
            //SERVER
            lsbLogServer.Items.Clear();
            nudPortServer.Value = webradio.Server.Port;
            txbLocalServerPassword.Text = webradio.Server.Password;
            txbLocalServerAdminPassword.Text = webradio.Server.AdminPassword;
            nudMaxListener.Value = webradio.Server.MaxListener;
            //----
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

            TimeSpan start = new TimeSpan(dvwTimetable.SelectionStart.Hour,dvwTimetable.SelectionStart.Minute,dvwTimetable.SelectionStart.Second);
            TimeSpan end = new TimeSpan(dvwTimetable.SelectionEnd.Hour,dvwTimetable.SelectionEnd.Minute,dvwTimetable.SelectionEnd.Second);
            txbStartTime.Text = start.ToString();
            txbDuration.Text = (end-start).ToString();
        }


        private void dvwTimetable_ResolveAppointments(object sender, ResolveAppointmentsEventArgs args)
        {
            List<Appointment> m_Apps = new List<Appointment>();
            foreach (Appointment m_App in this.EventsCalendar)
                    m_Apps.Add(m_App);

            args.Appointments = m_Apps;

        }

        void dvwTimetable_NewAppointment(object sender, NewAppointmentEventArgs args)
        {

        }

        private void AdminView_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Controller.FormClose();
        }

        private void ImportFolder_Click(object sender, EventArgs e)
        {
            AudioType type;
            string[] filenames;
            if ((sender as Button).Tag.ToString() == AudioType.Music.ToString())
                type = AudioType.Music;
            else
                type = AudioType.Ad;
            if(FBD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
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
            if(OFD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if(this.Controller.ImportFilesToLibrary(OFD.FileNames,type))
                    MessageBox.Show("Importation completed", "Success");
                else
                    MessageBox.Show("An error occured", "Error");
            }
        }

        private void txbSearchEnter(object sender, EventArgs e)
        {
            if((sender as TextBox).Text == DEFAULT_SEARCH_STRING)
                (sender as TextBox).Text = "";
        }

        private void txbSearchLeave(object sender, EventArgs e)
        {
            if((sender as TextBox).Text == "")
                (sender as TextBox).Text = "Search...";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            AudioType type;
            bool state = true;

            if ((sender as Button).Tag.ToString() == AudioType.Music.ToString())
                type = AudioType.Music;
            else
                type = AudioType.Ad;

            foreach(DataGridViewRow row in ((type == AudioType.Music)?dgvMusics.SelectedRows:dgvAds.SelectedRows))
            {
                //Simple check if selected row is not the last empty row
                if(row.Cells[0].Value != null)
                    if (!this.Controller.DeleteAudioFile(int.Parse(row.Cells["colId"+type.ToString()].Value.ToString()), row.Cells["colPath"+type.ToString()].Value.ToString()))
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
                foreach(DataGridViewRow row in ((type == AudioType.Music)?dgvMusics.Rows:dgvAds.Rows))
                {
                    foreach(DataGridViewCell cell in row.Cells)
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
            if (txbPlaylistName.Text.Trim() != "")
            {
                if (!this.Controller.CreatePlaylist(txbPlaylistName.Text, this.NameWebradio, this.IdWebradio, (cmbTypePlaylist.SelectedItem.ToString() == "Music") ? AudioType.Music : AudioType.Ad))
                    MessageBox.Show("Playlist already exist", "Playlist exist");
            }
            else
                MessageBox.Show("Please enter a playlist's name", "Empty name");
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
            AudioType type = ((sender as Button).Tag.ToString() == AudioType.Music.ToString())?AudioType.Music:AudioType.Ad;
            Dictionary<int, string> audioFiles = new Dictionary<int, string>();
            DataGridViewSelectedRowCollection rows = ((type == AudioType.Music) ? dgvMusics.SelectedRows : dgvAds.SelectedRows);
            this.Cursor = Cursors.WaitCursor;
            foreach (DataGridViewRow row in rows)
            {
                //Simple check if selected row is not the last empty row
                if (row.Cells[0].Value != null)
                    audioFiles.Add(int.Parse(row.Cells["colId" + type.ToString()].Value.ToString()), row.Cells["colPath"+type.ToString()].Value.ToString());

            }
            this.Cursor = Cursors.Default;
            if (!this.Controller.AddToPlaylist((Playlist)((type == AudioType.Music) ? cmbPlaylistsMusic.SelectedItem : cmbPlaylistsAd.SelectedItem),
                audioFiles))
                MessageBox.Show("An error occured", "Error");
            else
                this.UpdateView();

        }

        private void lsbPlaylistsSelectedIndexChanged(object sender, EventArgs e)
        {
            AudioType type = ((sender as ListBox).Tag.ToString() == AudioType.Music.ToString())?AudioType.Music:AudioType.Ad;
            btnRemoveFromPlaylist.Tag = type;
            if((sender as ListBox).SelectedIndex >= 0)
            {
                this.GetPlaylistContent((Playlist)(sender as ListBox).SelectedItem);
            }
        }

        private void GetPlaylistContent(Playlist playlist)
        {
            dgvPlaylistContent.Rows.Clear();
            TimeSpan totalDuration = new TimeSpan(0,0,0);
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
            if(btnRemoveFromPlaylist.Tag == null)
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
            Playlist selectedPlaylist = (Playlist)((type == AudioType.Music) ? lsbPlaylistsMusic.SelectedItem:lsbPlaylistsAd.SelectedItem);
            if (!this.Controller.RemoveFromPlaylist(selectedPlaylist,audioFiles))
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
            if (txbPlaylistNameGenerate.Text.Trim() != "")
            {
                TimeSpan duration = new TimeSpan(0,(int)nudDurationGenerate.Value,0);
                if(!this.Controller.GeneratePlaylist(txbPlaylistNameGenerate.Text, duration,
                    (cmbTypePlaylistGenerate.SelectedItem.ToString() == AudioType.Music.ToString()) ? AudioType.Music : AudioType.Ad,
                    cmbGenderGenerate.SelectedItem.ToString(), this.IdWebradio, this.NameWebradio))
                {
                    MessageBox.Show("Impossible to generate a playlist with these parameters. Some issues possible :\n - A playlist with this name and this type already exists\n - The given duration is too short for this gender", "Error");
                }
            }
            else
                MessageBox.Show("Please enter a playlist's name", "Error");
        }

    }
}
