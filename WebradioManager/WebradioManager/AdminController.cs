using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebradioManager
{
    public class AdminController : IController
    {
        private WMModel _model;
        private AdminView _view;

        public AdminView View
        {
            get { return _view; }
            set { _view = value; }
        }

        public WMModel Model
        {
            get { return _model; }
            set { _model = value; }
        }
    
        public void UpdateView()
        {
            throw new NotImplementedException();
        }
    }
}
