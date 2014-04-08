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

        }

        void dayView1_NewAppointment(object sender, NewAppointmentEventArgs args)
        {

        }

    }
}
