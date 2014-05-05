using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        public bool DeleteAudioFile(int id,string filename)
        {
            return this.Model.DeleteAudioFile(id,filename);
        }

        public bool CreatePlaylist(string name, string webradioName, int webradioId, AudioType type)
        {
            return this.Model.CreatePlaylist(name,webradioName,webradioId,type);
        }

        public bool DeletePlaylist(Playlist playlist, int webradioId)
        {
            return this.Model.DeletePlaylist(playlist, webradioId);
        }

        public bool AddToPlaylist(Playlist playlist, Dictionary<int, string> audioFiles)
        {
            if (playlist != null)
                return this.Model.AddToPlaylist(playlist, audioFiles);
            else
                return false;
        }

        public bool RemoveFromPlaylist(Playlist playlist, Dictionary<int,string> audioFiles)
        {
            return this.Model.RemoveFromPlaylist(audioFiles, playlist);
        }

        public List<AudioFile> GetPlaylistContent(Playlist playlist)
        {
            return this.Model.GetPlaylistContent(playlist);
        }

        public bool GeneratePlaylist(string name, TimeSpan duration, AudioType type, string gender, int webradioId, string webradioName)
        {
            return this.Model.GeneratePlaylist(name, duration, type, gender, webradioId, webradioName);
        }

        public bool CreateEvent(CalendarEvent newEvent, int webradioId)
        {
            return this.Model.CreateEvent(newEvent, webradioId);
        }

        public bool UpdateEvent(CalendarEvent aEvent, int webradioId)
        {
            return this.Model.UpdateEvent(aEvent,webradioId);
        }

        public bool DeleteEvent(CalendarEvent aEvent, int webradioId)
        {
            return this.Model.DeleteEvent(aEvent, webradioId);
        }

        public bool CreateTranscoder(string name, StreamType st, int sampleRate, int bitrate, string url, IPAddress ip, int port, string password, int webradioId)
        {
            return this.Model.CreateTranscoder(name, st, sampleRate, bitrate, url, ip, port, password, webradioId);
        }

        public bool DeleteTranscoder(WebradioTranscoder transcoder, int webradioId)
        {
            return this.Model.DeleteTranscoder(transcoder, webradioId);
        }
    }
}
