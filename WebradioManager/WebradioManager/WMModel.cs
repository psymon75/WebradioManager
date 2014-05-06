using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using TagLib;

namespace WebradioManager
{
    public class WMModel
    {
        //Defaults constants
        public const string DEFAULT_WEBRADIOS_FOLDER = "webradios/";
        const string DEFAULT_LOGFILENAME = "log.txt";
        const string DEFAULT_CONFIGFILENAME = "config.config";
        const string DEFAULT_PASSWORD = "1234";
        const int MAX_NAME_LENGTH = 255;
        
        //SERVER CONSTANTS
        const string DEFAULT_SERVER_FOLDER = "server/";
        const int DEFAULT_SERVER_PORT = 8000;
        const int DEFAULT_MAX_LISTENER = 32;
        //CALENDAR CONSTANTS
        public const string DEFAULT_CALENDAR_FILENAME = "calendar.xml";
        //PLAYLISTS CONSTANTS
        const string DEFAULT_PLAYLISTS_FOLDER = "playlists/";
        const int MAX_TRY_GENERATE = 10;
        //TRANSCODERS CONSTANTS
        const string DEFAULT_TRANSCODERS_FOLDER = "transcoders/";

        private Dictionary<int, Webradio> _webradios;
        private List<IController> _observers;
        private Bdd _bdd;
        private List<AudioFile> _library;

        #region Properties
        public Bdd Bdd
        {
            get { return _bdd; }
            set { _bdd = value; }
        }

        public List<IController> Observers
        {
            get { return _observers; }
            set { _observers = value; }
        }

        public Dictionary<int,Webradio> Webradios
        {
            get { return _webradios; }
            set { _webradios = value; }
        }

        public List<AudioFile> Library
        {
            get { return _library; }
            set { _library = value; }
        }
        #endregion

        public WMModel()
        {
            this.Webradios = new Dictionary<int, Webradio>();
            this.Observers = new List<IController>();
            this.Bdd = new Bdd();
            this.Library = new List<AudioFile>();
        }

        public void AddObserver(IController observer)
        {
            this.Observers.Add(observer);
        }

        public void RemoveObserver(IController observer)
        {
            this.Observers.Remove(observer);
        }

        private void UpdateObservers()
        {
            foreach(IController controller in this.Observers)
            {
                controller.UpdateView();
            }
        }

        public void LoadLibrary()
        {
            this.Library = this.Bdd.LoadLibrary();
        }

        public void LoadWebradios()
        {
            this.Webradios = this.Bdd.LoadWebradios();
        }

        public Webradio GetWebradio(int id)
        {
            return this.Webradios[id];
        }

        public List<Webradio> GetWebradios()
        {
            //Get only webradios with its name and id and without useless stuffs for SelectionView
            List<Webradio> list = new List<Webradio>();
            foreach(KeyValuePair<int,Webradio> wr in this.Webradios)
            {
                list.Add(new Webradio(wr.Value.Name, wr.Value.Id));
            }
            return list;
        }

        public bool CreateWebradio(string name)
        {
            string webradioFilename = DEFAULT_WEBRADIOS_FOLDER + name + "/";
            Webradio wr = new Webradio(name);
            WebradioServer server = new WebradioServer(DEFAULT_SERVER_PORT,
                webradioFilename + DEFAULT_SERVER_FOLDER + DEFAULT_LOGFILENAME,
                webradioFilename + DEFAULT_SERVER_FOLDER + DEFAULT_CONFIGFILENAME, DEFAULT_PASSWORD, DEFAULT_PASSWORD,DEFAULT_MAX_LISTENER);
            wr.Server = server;
            wr.Playlists = new List<Playlist>();
            wr.Calendar = new WebradioCalendar(webradioFilename + DEFAULT_CALENDAR_FILENAME);
            wr.Transcoders = new List<WebradioTranscoder>();
            try
            {
                wr.Id = this.Bdd.AddWebradio(wr);
                this.Webradios.Add(wr.Id,wr);
                //Directory creation
                Directory.CreateDirectory(webradioFilename);
                Directory.CreateDirectory(webradioFilename + DEFAULT_SERVER_FOLDER);
                Directory.CreateDirectory(webradioFilename + DEFAULT_PLAYLISTS_FOLDER);
                Directory.CreateDirectory(webradioFilename + DEFAULT_TRANSCODERS_FOLDER);
                Thread.Sleep(100);
                wr.GenerateConfigFiles();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool DeleteWebradio(int id)
        {
            bool output = false;
            output = this.Bdd.DeleteWebradio(id);
            //Delete webradio from model
            try
            {
                this.Webradios.Remove(id);
                output = true;
            }
            catch
            {
                output = false;
            }
            
            return output;
        }

        public bool DuplicateWebradio(int id)
        {
            //Webradio selected = null;
            //foreach (Webradio webradio in this.Webradios)
            //{
            //    if (webradio.Id == id)
            //    {
            //        selected = webradio;
            //        break;
            //    }
            //}
            return true;

        }

        public List<AudioFile> GetLibrary()
        {
            return this.Library;
        }

        public List<string> GetGenders()
        {
            return this.Bdd.GetGenders();
        }

        public bool ImportFilesToLibrary(string[] filenames, AudioType type)
        {
            AudioFile file;
            bool state = true;
            foreach(string filename in filenames)
            {
                try
                {
                    TagLib.File tagFile = TagLib.File.Create(filename);
                    if (type == AudioType.Music)
                        file = new Music(filename,
                            tagFile.Tag.Title,
                            tagFile.Tag.FirstPerformer,
                            tagFile.Tag.Album,
                            (int)tagFile.Tag.Year,
                            tagFile.Tag.Copyright,
                            tagFile.Properties.Duration,
                            tagFile.Tag.FirstGenre);
                    else
                        file = new Ad(filename,
                            tagFile.Tag.Title,
                            tagFile.Tag.FirstPerformer,
                            tagFile.Tag.Album,
                            (int)tagFile.Tag.Year,
                            tagFile.Tag.Copyright,
                            tagFile.Properties.Duration,
                            tagFile.Tag.FirstGenre);

                    int id = this.Bdd.AddAudioFile(file);
                    if (id != Bdd.ERROR)
                    {
                        file.Id = id;
                        this.Library.Add(file);
                        this.UpdateObservers();
                    }
                    state = true;
                }
                catch
                {

                }
            }
            return state;
        }

        public bool DeleteAudioFile(int id, string audioFilename)
        {
            foreach(KeyValuePair<int,Webradio> webradio in this.Webradios)
            {
                foreach(Playlist playlist in webradio.Value.Playlists)
                {
                    foreach(string filename in playlist.AudioFileList)
                    {
                        if(filename == audioFilename)
                        {
                            playlist.AudioFileList.Remove(filename);                        
                        }
                    }
                }
            }
            foreach (AudioFile file in this.Library)
            {
                if (file.Id == id)
                {
                    this.Library.Remove(file);
                    break;
                }
            }
            return this.Bdd.DeleteAudioFile(id);
        }

        public bool CreatePlaylist(string name, string webradioName, int webradioId, AudioType type)
        {
            Webradio selectedWebradio = this.Webradios[webradioId];
            Playlist newPlaylist;
            string filename = DEFAULT_WEBRADIOS_FOLDER + webradioName + "/" + DEFAULT_PLAYLISTS_FOLDER + name + ".lst";
            if (type == AudioType.Music)
                newPlaylist = new PlaylistMusic(name, filename);
            else
                newPlaylist = new PlaylistAd(name, filename);
            int id = this.Bdd.CreatePlaylist(newPlaylist,webradioId);
            if (id == Bdd.ERROR)
                return false;
            else
            {
                try
                {
                    newPlaylist.Id = id;
                    newPlaylist.GenerateConfigFile();
                    selectedWebradio.Playlists.Add(newPlaylist);
                    this.UpdateObservers();
                    return true;
                }
                catch
                { 
                    return false;
                }
                
            }
            
        }

        public bool DeletePlaylist(Playlist playlist, int idWebradio)
        {
            if (this.Bdd.DeletePlaylist(playlist.Id))
            {
                this.Webradios[idWebradio].Playlists.Remove(playlist);
                System.IO.File.Delete(playlist.Filename);
                this.UpdateObservers();
                return true;
            }
            else
                return false;
                
        }

        public bool AddToPlaylist(Playlist playlist, Dictionary<int,string> audioFiles)
        {
            bool state = true;
            foreach (KeyValuePair<int, string> audioFile in audioFiles)
            {
                if (this.Bdd.AddToPlaylist(audioFile.Key, playlist.Id))
                {
                    playlist.AudioFileList.Add(audioFile.Value);
                    state = true;
                }
                else
                {
                    state = false;
                    break;
                }
                    
            }
            playlist.GenerateConfigFile();
            return state;
            
        }

        public bool RemoveFromPlaylist(Dictionary<int,string> audioFiles, Playlist playlist)
        {
            bool state = true;
            foreach (KeyValuePair<int, string> audioFile in audioFiles)
            {
                if (this.Bdd.RemoveFromPlaylist(audioFile.Key, playlist.Id))
                {
                    playlist.AudioFileList.Remove(audioFile.Value);
                    state = true;
                }
                else
                {
                    state = false;
                    break;
                }

            }
            playlist.GenerateConfigFile();
            return state;
        }
        public List<AudioFile> GetPlaylistContent(Playlist playlist)
        {
            List<AudioFile> audioFiles = new List<AudioFile>();
            foreach(string filename in playlist.AudioFileList)
            {
                foreach(AudioFile af in this.Library)
                {
                    if (af.Filename == filename)
                        audioFiles.Add(af);
                }
            }
            return audioFiles;
        }

        public bool GeneratePlaylist(string name, TimeSpan duration, AudioType type, string gender, int webradioId, string webradioName)
        {
            Playlist newPlaylist;
            string filename = DEFAULT_WEBRADIOS_FOLDER + webradioName + "/" + DEFAULT_PLAYLISTS_FOLDER + name + ".lst";
            if (type == AudioType.Music)
                newPlaylist = new PlaylistMusic(name, filename);
            else
                newPlaylist = new PlaylistAd(name, filename);
            TimeSpan tmpDuration = new TimeSpan();
            Random random = new Random();
            AudioFile audioFile;
            int retries = 0;
            List<int> audioFilesId = new List<int>();
            while(tmpDuration <= duration)
            {
                audioFile = this.Library[random.Next(0, this.Library.Count - 1)];
                if(audioFile.Type == type)
                {
                    if (retries > MAX_TRY_GENERATE)
                        break;
                    if ((tmpDuration + audioFile.Duration) > duration)
                    {
                        retries++;
                        continue;
                    }
                    else
                        retries = 0;
                    
                    if((audioFile.Type == AudioType.Ad) || (audioFile.Type == AudioType.Music && audioFile.Gender == gender))
                    {
                        tmpDuration += audioFile.Duration;
                        newPlaylist.AudioFileList.Add(audioFile.Filename);
                        audioFilesId.Add(audioFile.Id);
                    }
                }
            }

            //Impossible to create a playlist
            if (newPlaylist.AudioFileList.Count == 0)
                return false;

            //Add to database
            int idPlaylist = this.Bdd.AddGeneratedPlaylist(newPlaylist, audioFilesId, webradioId);
            if(idPlaylist == Bdd.ERROR)
                return false;
            newPlaylist.Id = idPlaylist;
            //Add to model
            this.Webradios[webradioId].Playlists.Add(newPlaylist);
            newPlaylist.GenerateConfigFile();
            this.UpdateObservers();
            return true;
        }

        public bool CreateEvent(CalendarEvent newEvent, int webradioId)
        {
            if (this.Bdd.EventExist(newEvent, this.Webradios[webradioId].Calendar.Id))
                return false;

            int id = this.Bdd.AddEvent(newEvent, this.Webradios[webradioId].Calendar.Id, newEvent.Playlist.Id);
            newEvent.Id = id;
            this.Webradios[webradioId].Calendar.Events.Add(newEvent);
            this.Webradios[webradioId].Calendar.GenerateConfigFile();
            this.UpdateObservers();
            return true;
        }

        public bool UpdateEvent(CalendarEvent aEvent, int webradioId)
        {
            if (this.Bdd.UpdateEvent(aEvent))
            {
                foreach (CalendarEvent ce in this.Webradios[webradioId].Calendar.Events)
                {
                    CalendarEvent tmp = ce;
                    if (ce.Id == aEvent.Id)
                    {
                        tmp.StartTime = aEvent.StartTime;
                        tmp.Duration = aEvent.Duration;
                        break;
                    }
                }
                this.Webradios[webradioId].Calendar.GenerateConfigFile();
                this.UpdateObservers();
                return true;
            }
            else
                return false;
        }

        public bool DeleteEvent(CalendarEvent aEvent, int webradioId)
        {
            if (this.Bdd.DeleteEvent(aEvent))
            {
                this.Webradios[webradioId].Calendar.Events.Remove(aEvent);
                this.Webradios[webradioId].Calendar.GenerateConfigFile();
                this.UpdateObservers();
                return true;
            }
            else
                return false;
        }

        public bool CreateTranscoder(string name, StreamType st, int sampleRate, int bitrate, string url, IPAddress ip, int port, string password, int webradioId)
        {
            string filename = DEFAULT_WEBRADIOS_FOLDER + this.Webradios[webradioId].Name + "/" + DEFAULT_TRANSCODERS_FOLDER;
            WebradioTranscoder transcoder;
            if(st == StreamType.AACPlus)
                transcoder = new TranscoderAacPlus(name,
                bitrate,
                sampleRate,
                ip,
                port,
                url,
                password,
                filename,
                filename);
            else
               transcoder = new TranscoderMp3(name,
                bitrate,
                sampleRate,
                ip,
                port,
                url,
                password,
                filename,
                filename);

            transcoder.CalendarFile = DEFAULT_WEBRADIOS_FOLDER + this.Webradios[webradioId].Name + "/" + DEFAULT_CALENDAR_FILENAME;
            int id = this.Bdd.AddTranscoder(transcoder, webradioId);
            if (id == Bdd.ERROR)
                return false;
            transcoder.Id = id;
            transcoder.ConfigFilename = filename  + id.ToString() + ".config";
            transcoder.LogFilename = filename + id.ToString() + ".log";
            this.Webradios[webradioId].Transcoders.Add(transcoder);
            transcoder.GenerateConfigFile(this.Webradios[webradioId].Playlists);
            this.UpdateObservers();
            return true;
        }

        public bool DeleteTranscoder(WebradioTranscoder transcoder, int webradioId)
        {
            if (this.Bdd.DeleteTranscoder(transcoder.Id))
            {
                System.IO.File.Delete(transcoder.ConfigFilename);
                if (System.IO.File.Exists(transcoder.LogFilename))
                    System.IO.File.Delete(transcoder.LogFilename);
                this.Webradios[webradioId].Transcoders.Remove(transcoder);
                this.UpdateObservers();
                return true;
            }
            else
                return false;
        }

        public bool UpdateTranscoder(WebradioTranscoder transcoder, int webradioId)
        {
            try
            {
                bool wasRunning = false;
                if (transcoder.IsRunning())
                {
                    wasRunning = true;
                    transcoder.Process.Kill();
                }

                this.Bdd.UpdateTranscoder(transcoder);
                transcoder.GenerateConfigFile(this.Webradios[webradioId].Playlists);
                if(wasRunning)
                    transcoder.Start();
                this.UpdateObservers();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool StartTranscoder(WebradioTranscoder transcoder, int webradioId)
        {
            try
            {
                transcoder.Start();
                return true;
            }
            catch
            {
                return false;
            }
            
        }

        public bool StopTranscoder(WebradioTranscoder transcoder, int webradioId)
        {
            try
            {
                transcoder.Stop();
                this.Webradios[webradioId].Calendar.GenerateConfigFile();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool StopAllTranscoders(int webradioId)
        {
            try
            {
                foreach(WebradioTranscoder transcoder in this.Webradios[webradioId].Transcoders)
                {
                    transcoder.Stop();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool StopAllTranscoders()
        {
            try
            {
                foreach (KeyValuePair<int,Webradio> webradio in this.Webradios)
                {
                    foreach (WebradioTranscoder transcoder in webradio.Value.Transcoders)
                    {
                        transcoder.Stop();
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
