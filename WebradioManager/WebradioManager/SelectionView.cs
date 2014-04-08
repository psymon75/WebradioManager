﻿using System;
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
        }
    }
}