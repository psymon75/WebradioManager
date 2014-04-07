using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebradioManager
{
    public class WMModel
    {
        private List<Webradio> _webradios;
        private List<IController> _observers;

        public WMModel()
        {
            throw new System.NotImplementedException();
        }

        public List<IController> Observers
        {
            get { return _observers; }
            set { _observers = value; }
        }

        public List<Webradio> Webradios
        {
            get { return _webradios; }
            set { _webradios = value; }
        }

        public void AddObserver(IController observer)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveObserver(IController observer)
        {
            throw new System.NotImplementedException();
        }
    }
}
