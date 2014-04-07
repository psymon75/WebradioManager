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
        List<Appointment> m_Appointments;
        private AdminController _controller;

        public AdminController Controller
        {
            get { return _controller; }
            set { _controller = value; }
        }

        public AdminView()
        {
            InitializeComponent();

            m_Appointments = new List<Appointment>();

            DateTime m_Date = DateTime.Now;

            m_Date = m_Date.AddHours(10 - m_Date.Hour);
            m_Date = m_Date.AddMinutes(-m_Date.Minute);

            Appointment m_Appointment = new Appointment();
            m_Appointment.StartDate = m_Date;
            m_Appointment.EndDate = m_Date.AddHours(2);
            m_Appointment.Title = "Playlist1";

            m_Appointments.Add(m_Appointment);

            m_Appointment = new Appointment();
            m_Appointment.StartDate = m_Date.AddHours(2);
            m_Appointment.EndDate = m_Date.AddHours(3);
            m_Appointment.Title = "Playlist2";
            m_Appointment.Color = System.Drawing.Color.LightBlue;
   

            m_Appointments.Add(m_Appointment);

            

            dayView1.StartDate = DateTime.Now;
            dayView1.NewAppointment += new NewAppointmentEventHandler(dayView1_NewAppointment);
            dayView1.ResolveAppointments += new Calendar.ResolveAppointmentsEventHandler(this.dayView1_ResolveAppointments);
            dayView1.SelectionChanged += dayView1_SelectionChanged;
        }

        void dayView1_SelectionChanged(object sender, EventArgs e)
        {
            MessageBox.Show("");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        private void dayView1_ResolveAppointments(object sender, ResolveAppointmentsEventArgs args)
        {
            List<Appointment> m_Apps = new List<Appointment>();

            foreach (Appointment m_App in m_Appointments)
                if ((m_App.StartDate >= args.StartDate) &&
                    (m_App.StartDate <= args.EndDate))
                    m_Apps.Add(m_App);

            args.Appointments = m_Apps;
        }

        void dayView1_NewAppointment(object sender, NewAppointmentEventArgs args)
        {
            Appointment m_Appointment = new Appointment();

            m_Appointment.StartDate = args.StartDate;
            m_Appointment.EndDate = args.EndDate;
            m_Appointment.Title = args.Title;

            m_Appointments.Add(m_Appointment);
        }
    }
}
