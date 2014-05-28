/**
// \file SelectionView.cs
//
// \brief Implements the selection view class.
**/

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WebradioManager
{
    /**
    // \class SelectionView
    //
    // \brief A selection view.
    //
    // \author Simon Menetrey
    // \date 26.05.2014
    **/

    public partial class SelectionView : Form
    {
        #region Const
        // \brief The maximum name length.
        const int MAX_NAME_LENGTH = 255;
        #endregion

        #region Fields
        // \brief The controller.
        private SelectionController _controller;
        #endregion

        #region Properties

        /**
        // \property public SelectionController Controller
        //
        // \brief Gets or sets the controller.
        //
        // \return The controller.
        **/

        public SelectionController Controller
        {
            get { return _controller; }
            set { _controller = value; }
        }
        #endregion

        #region Methods

        /**
        // \fn public SelectionView()
        //
        // \brief Default constructor.
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        **/

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

        /**
        // \fn public void UpdateView()
        //
        // \brief Updates the view.
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        **/

        public void UpdateView()
        {
            lsbSelection.Items.Clear();
            List<Webradio> webradios = this.Controller.GetWebradios();
            foreach(Webradio wr in webradios)
            {
                lsbSelection.Items.Add(wr);
            }
        }

        /**
        // \fn private void btnNew_Click(object sender, EventArgs e)
        //
        // \brief Event handler. Called by btnNew for click events.
        //        Create a webradio
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        //
        // \param sender Source of the event.
        // \param e      Event information.
        **/

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txbName.Text.Trim()) && txbName.Text.Length <= MAX_NAME_LENGTH)
            {
                if (this.Controller.CreateWebradio(txbName.Text))
                    MessageBox.Show("Webradio created !");
                else
                    MessageBox.Show("An error occured. (Invalid name or cannot create folders and files.)", "Error");
                this.UpdateView();
            }
            else
                MessageBox.Show("Please enter a valid webradio's name. (1-255 characters)", "Error");
        }

        /**
        // \fn private void btnDelete_Click(object sender, EventArgs e)
        //
        // \brief Event handler. Called by btnDelete for click events.
        //        Delete a webradio
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        //
        // \param sender Source of the event.
        // \param e      Event information.
        **/

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

        /**
        // \fn private void btnDuplicate_Click(object sender, EventArgs e)
        //
        // \brief Event handler. Called by btnDuplicate for click events.
        //        Duplicate a webradio
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        //
        // \param sender Source of the event.
        // \param e      Event information.
        **/

        private void btnDuplicate_Click(object sender, EventArgs e)
        {
            if(this.lsbSelection.SelectedIndex >= 0)
            {
                int id = ((Webradio)this.lsbSelection.SelectedItem).Id;
                if (!this.Controller.DuplicateWebradio(id))
                    MessageBox.Show("An error occured", "Error");
            }
            else
                MessageBox.Show("Please select a webradio to duplicate.", "No webradio selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /**
        // \fn private void btnOpen_Click(object sender, EventArgs e)
        //
        // \brief Event handler. Called by btnOpen for click events.
        //        Open a webradio
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        //
        // \param sender Source of the event.
        // \param e      Event information.
        **/

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if(this.lsbSelection.SelectedIndex >= 0)
                this.Controller.OpenWebradio(((Webradio)this.lsbSelection.SelectedItem).Id);
            
        }

        /**
        // \fn private void SelectionView_FormClosing(object sender, FormClosingEventArgs e)
        //
        // \brief Event handler. Called by SelectionView for form closing events.
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        //
        // \param sender Source of the event.
        // \param e      Form closing event information.
        **/

        private void SelectionView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("All transcoders and all servers will be shuting down. Are you sure ?", "Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (!this.Controller.StopAllProcess())
                {
                    MessageBox.Show("An error has occured", "Error");
                    e.Cancel = true;
                }
            }
            else
                e.Cancel = true;
        }
        #endregion
    }
}
