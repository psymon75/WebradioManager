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
