using Calendar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebradioManager
{
    public partial class AdminView : Form
    {
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

    }
}
