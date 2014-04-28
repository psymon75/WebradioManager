using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
                lsbSelection.Items.Add(wr);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if(txbName.Text.Trim() != "")
            {
                if (this.Controller.CreateWebradio(txbName.Text))
                    MessageBox.Show("Webradio created !");
                else
                    MessageBox.Show("An error occured", "Error");
                this.UpdateView();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.lsbSelection.SelectedIndex >= 0)
            {
                int id = ((Webradio)this.lsbSelection.SelectedItem).Id;
                if (!this.Controller.DeleteWebradio(id))
                    MessageBox.Show("An error occured.", "Error");
                this.UpdateView();
            }
            else
                MessageBox.Show("Please select a webradio to delete.", "No webradio selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnDuplicate_Click(object sender, EventArgs e)
        {
            if(this.lsbSelection.SelectedIndex >= 0)
            {
                int id = ((Webradio)this.lsbSelection.SelectedItem).Id;
                if (!this.Controller.DuplicateWebradio(id))
                    MessageBox.Show("An error occured", "Error");
                this.UpdateView();
            }
            else
                MessageBox.Show("Please select a webradio to duplicate.", "No webradio selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        private void btnOpen_Click(object sender, EventArgs e)
        {
            this.Controller.OpenWebradio(((Webradio)this.lsbSelection.SelectedItem).Id);
            
        }
    }
}
