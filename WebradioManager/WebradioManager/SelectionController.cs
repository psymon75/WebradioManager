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

        public SelectionController(SelectionView view)
        {
            this.View = view;
            this.Model = new WMModel();
            this.Model.AddObserver(this);
        }

        public void LoadLibrary()
        {
            this.Model.LoadLibrary();
        }

        public void LoadWebradios()
        {
            this.Model.LoadWebradios();
        }

        public void UpdateView()
        {
            this.View.UpdateView();
        }

        public List<Webradio> GetWebradios()
        {
            return this.Model.GetWebradios();
        }

        public bool CreateWebradio(string name)
        {
            return this.Model.CreateWebradio(name);
        }
       
    }
}
