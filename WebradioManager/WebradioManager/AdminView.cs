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
        List<Appointment> _events;

        #region Properties
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
            this.Text = "WebradioManager - " + webradio.Name;
            txbWebradioName.Text = webradio.Name;
            lblWebradioTitle.Text = webradio.Name;
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
            cmbPlaylistsMusic.Items.Clear();
            cmbPlaylistsAd.Items.Clear();
            cmbPlaylistEvent.Items.Clear();
            lsbPlaylistsAd.Items.Clear();
            lsbPlaylistsMusic.Items.Clear();

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
            //----
            //GENDER
            List<string> gender = this.Controller.GetGenders();
            cmbGenderGenerate.Items.Clear();
            cmbGenderGenerate.Items.AddRange(gender.ToArray());
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
            MessageBox.Show("");
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
                    if (!this.Controller.DeleteAudioFile(int.Parse(row.Cells[0].Value.ToString()), row.Cells[row.Cells.Count - 1].Value.ToString()))
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
            if ((sender as TextBox).Tag.ToString() == "Music")
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
                if (!this.Controller.CreatePlaylist(txbPlaylistName.Text, this.IdWebradio, (cmbTypePlaylist.SelectedItem.ToString() == "Music")?AudioType.Music:AudioType.Ad))
                    MessageBox.Show("Playlist already exist", "Playlist exist");
            }
            else
                MessageBox.Show("Please enter a playlist's name", "Empty name");
        }

    }
}
