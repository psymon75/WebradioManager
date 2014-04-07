using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebradioManager
{
    public class SelectionController : IController
    {
        private SelectionView _view;
        private WMModel _model;

        public SelectionController(SelectionView view)
        {
            throw new System.NotImplementedException();
        }

        public WMModel Model
        {
            get { return _model; }
            set { _model = value; }
        }

        public SelectionView View
        {
            get { return _view; }
            set { _view = value; }
        }

        public void UpdateView()
        {
            throw new NotImplementedException();
        }
    }
}
