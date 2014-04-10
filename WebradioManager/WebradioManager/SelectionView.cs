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
    public partial class SelectionView : Form
    {
        private SelectionController _controller;

        public SelectionController Controller
        {
            get { return _controller; }
            set { _controller = value; }
        }
    
        public SelectionView()
        {
            InitializeComponent();
            this.Cursor = Cursors.WaitCursor;
            this.Controller = new SelectionController(this);
            this.Controller.LoadWebradios();
            this.Controller.LoadLibrary();
            this.UpdateView();
            this.Cursor = Cursors.Default;
        }

        public void UpdateView()
        {
            lsbSelection.Items.Clear();
            List<Webradio> webradios = this.Controller.GetWebradios();
            foreach(Webradio wr in webradios)
            {
                lsbSelection.Items.Add(wr.Name + " | ID = " + wr.Id);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if(txbName.Text != "")
            {
                if (this.Controller.CreateWebradio(txbName.Text))
                    MessageBox.Show("Webradio created !");
                this.UpdateView();
            }
        }
    }
}
