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

        public AdminController(int id, WMModel model)
        {
            this.View = new AdminView(id,this);
            this.Model = model;
            this.UpdateView();
            this.View.Show();
        }
        public void UpdateView()
        {
            this.View.UpdateView();
        }

        public Webradio GetWebradio(int id)
        {
            return this.Model.GetWebradio(id);
        }

        public List<AudioFile> GetLibrary()
        {
            return this.Model.GetLibrary();
        }

        public List<string> GetGenders()
        {
            return this.Model.GetGenders();
        }

        public void FormClose()
        {
            this.Model.RemoveObserver(this);
        }

        public bool ImportFilesToLibrary(string[] filenames, AudioType type)
        {
            return this.Model.ImportFilesToLibrary(filenames, type);
        }

        public bool DeleteAudioFile(int id)
        {
            return this.Model.DeleteAudioFile(id);
        }
    }
}
