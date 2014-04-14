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

        public AdminView(int idWebradio, AdminController controller)
        {
            InitializeComponent();
            this.Controller = controller;
            this.IdWebradio = idWebradio;

        }

        public void UpdateView()
        {
            Webradio webradio = this.Controller.GetWebradio(this.IdWebradio);
            this.Text = "WebradioManager - " + webradio.Name;
        }

        void dayView1_SelectionChanged(object sender, EventArgs e)
        {
            MessageBox.Show("");
        }


        private void dayView1_ResolveAppointments(object sender, ResolveAppointmentsEventArgs args)
        {
            List<Appointment> m_Apps = new List<Appointment>();

        }

        void dayView1_NewAppointment(object sender, NewAppointmentEventArgs args)
        {

        }

        private void AdminView_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Controller.FormClose();
        }

    }
}
