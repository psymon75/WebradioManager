using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using TagLib;

namespace WebradioManager
{

    public class WMModel
    {
        //Defaults constants
        public const string DEFAULT_WEBRADIOS_FOLDER = "webradios/";
        public const string DEFAULT_SHOUTCAST_FOLDER = "shoutcast/";
        const string DEFAULT_LOGFILENAME = "log.txt";
        const string DEFAULT_CONFIGFILENAME = "config.config";
        const string DEFAULT_PASSWORD = "1234";
        const int MAX_NAME_LENGTH = 255;

        //SERVER CONSTANTS
        const string DEFAULT_SERVER_FOLDER = "server/";
        const int DEFAULT_SERVER_PORT = 8000;
        const int DEFAULT_MAX_LISTENER = 32;
        const string DEFAULT_SERVER_PASSWORD = "1234";
        const string DEFAULT_ADMIN_SERVER_PASSWORD = "admin";
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
        private System.Windows.Forms.Timer _processWatcher;
        private List<WebradioTranscoder> _activeTranscoders;
        private List<WebradioServer> _activeServers;


        #region Properties

        public List<WebradioTranscoder> ActiveTranscoders
        {
            get { return _activeTranscoders; }
            set { _activeTranscoders = value; }
        }
        public System.Windows.Forms.Timer ProcessWatcher
        {
            get { return _processWatcher; }
            set { _processWatcher = value; }
        }
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

        public Dictionary<int, Webradio> Webradios
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
        public List<WebradioServer> ActiveServers
        {
            get { return _activeServers; }
            set { _activeServers = value; }
        }
        public WMModel()
        {
            this.Webradios = new Dictionary<int, Webradio>();
            this.Observers = new List<IController>();
            this.Bdd = new Bdd();
            this.Library = new List<AudioFile>();
            this.ActiveTranscoders = new List<WebradioTranscoder>();
            this.ActiveServers = new List<WebradioServer>();
            this.ProcessWatcher = new System.Windows.Forms.Timer();
            this.ProcessWatcher.Tick += ProcessWatcher_Tick;
            this.ProcessWatcher.Interval = 1000;
            this.ProcessWatcher.Start();
        }

        private string GetCurrentTrackFromXML(string xml)
        {
            if (xml != "")
            {
                string currentTrack = "";
                XmlDocument document = new XmlDocument();
                document.LoadXml(xml);
                XmlNodeList nodes = document.GetElementsByTagName("activesource");
                foreach (XmlNode node in nodes[0].ChildNodes)
                {
                    if (node.Name == "currenttrack")
                    {
                        currentTrack = node.InnerText;
                        break;
                    }
                }
                return currentTrack;
            }
            else
                return xml;
        }

        void ProcessWatcher_Tick(object sender, EventArgs e)
        {
            bool needUpdate = false;
            for (int i = 0; i < this.ActiveTranscoders.Count; i++)
            {
                if (!this.ActiveTranscoders[i].IsRunning())
                {
                    this.ActiveTranscoders.RemoveAt(i);
                    needUpdate = true;
                    i--;
                }
                else
                {
                    string currentTrack = this.GetCurrentTrackFromXML(this.ActiveTranscoders[i].GetStatus());
                    if(currentTrack != this.ActiveTranscoders[i].CurrentTrack)
                    {
                        this.ActiveTranscoders[i].CurrentTrack = currentTrack;
                        needUpdate = true;
                        if(currentTrack.Trim() != "")
                            this.Bdd.AddToHistory(this.ActiveTranscoders[i].Id, DateTime.Now, currentTrack);                         
                    }
                }
            }
            for (int i = 0; i < this.ActiveServers.Count; i++)
            {
                if (!this.ActiveServers[i].IsRunning())
                {
                    this.ActiveServers.RemoveAt(i);
                    needUpdate = true;
                    i--;
                }
            }
            if (needUpdate)
                this.UpdateObservers();
        }

        public void AddObserver(IController observer)
        {
            this.Observers.Add(observer);
        }

        public void RemoveObserver(IController observer)
        {
            this.Observers.Remove(observer);
        }

        private void UpdateObservers(int webradioId)
        {
            foreach (IController controller in this.Observers)
            {
                if (controller is AdminController)
                {
                    if ((controller as AdminController).View.IdWebradio == webradioId)
                        controller.UpdateView();
                }
            }
        }

        private void UpdateObservers()
        {
            foreach (IController controller in this.Observers)
            {
                controller.UpdateView();
            }
        }

        public void LoadLibrary()
        {
            this.Library = this.Bdd.LoadLibrary();
        }

        public void CheckFolders(int webradioId)
        {
            if (!Directory.Exists(DEFAULT_WEBRADIOS_FOLDER + this.Webradios[webradioId].Name))
                Directory.CreateDirectory(DEFAULT_WEBRADIOS_FOLDER + this.Webradios[webradioId].Name);
        }

        public void LoadWebradios()
        {
            if (!Directory.Exists(DEFAULT_WEBRADIOS_FOLDER))
                Directory.CreateDirectory(DEFAULT_WEBRADIOS_FOLDER);
            if (!Directory.Exists(DEFAULT_SHOUTCAST_FOLDER))
                Directory.CreateDirectory(DEFAULT_SHOUTCAST_FOLDER);
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
            foreach (KeyValuePair<int, Webradio> wr in this.Webradios)
            {
                list.Add(new Webradio(wr.Value.Name, wr.Value.Id));
            }
            return list;
        }

        public bool CreateWebradio(string name)
        {
            if (this.IsValidPath(name))
            {
                string webradioFilename = DEFAULT_WEBRADIOS_FOLDER + name + "/";
                Webradio wr = new Webradio(name);
                WebradioServer server = new WebradioServer(DEFAULT_SERVER_PORT,
                    webradioFilename + DEFAULT_SERVER_FOLDER + DEFAULT_LOGFILENAME,
                    webradioFilename + DEFAULT_SERVER_FOLDER + DEFAULT_CONFIGFILENAME, DEFAULT_SERVER_PASSWORD, DEFAULT_ADMIN_SERVER_PASSWORD, DEFAULT_MAX_LISTENER);
                wr.Server = server;
                wr.Playlists = new List<Playlist>();
                wr.Calendar = new WebradioCalendar(webradioFilename + DEFAULT_CALENDAR_FILENAME);
                wr.Transcoders = new List<WebradioTranscoder>();
                try
                {
                    wr.Id = this.Bdd.AddWebradio(wr);
                    this.Webradios.Add(wr.Id, wr);
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
            else
                return false;
        }

        public bool DeleteWebradio(int id)
        {
            bool output = false;
            output = this.Bdd.DeleteWebradio(id);
            Directory.Delete(DEFAULT_WEBRADIOS_FOLDER + this.Webradios[id].Name,true);
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
            foreach (string filename in filenames)
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
            foreach (KeyValuePair<int, Webradio> webradio in this.Webradios)
            {
                foreach (Playlist playlist in webradio.Value.Playlists)
                {
                    for(int i = 0; i < playlist.AudioFileList.Count;i++)
                    {
                        if (playlist.AudioFileList[i] == audioFilename)
                        {
                            playlist.AudioFileList.Remove(playlist.AudioFileList[i]);
                            i--;
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

        public bool UpdateAudioFile(AudioFile file)
        {
            if (this.Bdd.UpdateAudioFile(file))
            {
                try
                {
                    TagLib.File tagFile = TagLib.File.Create(file.Filename);
                    tagFile.Tag.Title = file.Title;
                    tagFile.Tag.Performers = new string[] { file.Artist };
                    tagFile.Tag.Album = file.Album;
                    tagFile.Tag.Year = (uint)file.Year;
                    tagFile.Tag.Copyright = file.Label;
                    tagFile.Tag.Genres = new string[] { file.Gender };
                    tagFile.Save();

                    foreach(AudioFile af in this.Library)
                    {
                        if(af.Id == file.Id)
                        {
                            af.Title = file.Title;
                            af.Artist = file.Artist;
                            af.Album = file.Album;
                            af.Year = file.Year;
                            af.Label = file.Label;
                            af.Gender = file.Gender;
                            break;
                        }
                    }
                    this.UpdateObservers();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
                return false;
        }

        private bool IsValidFilename(string testName)
        {
            char[] invalidFileChars = Path.GetInvalidFileNameChars();
            if (testName.IndexOfAny(invalidFileChars) == -1)
                return true;
            else
                return false;
        }

        private bool IsValidPath(string testName)
        {
            char[] invalidFileChars = Path.GetInvalidPathChars();
            if (testName.IndexOfAny(invalidFileChars) == -1)
                return true;
            else
                return false;
        }

        public bool CreatePlaylist(string name, string webradioName, int webradioId, AudioType type)
        {
            Webradio selectedWebradio = this.Webradios[webradioId];
            Playlist newPlaylist;
            if (this.IsValidFilename(name))
            {
                string filename = DEFAULT_WEBRADIOS_FOLDER + webradioName + "/" + DEFAULT_PLAYLISTS_FOLDER + name + ".lst";
                if (type == AudioType.Music)
                    newPlaylist = new PlaylistMusic(name, filename);
                else
                    newPlaylist = new PlaylistAd(name, filename);
                int id = this.Bdd.CreatePlaylist(newPlaylist, webradioId);
                if (id == Bdd.ERROR)
                    return false;
                else
                {
                    try
                    {
                        newPlaylist.Id = id;
                        newPlaylist.GenerateConfigFile();
                        selectedWebradio.Playlists.Add(newPlaylist);
                        this.UpdateObservers(webradioId);
                        return true;
                    }
                    catch
                    {
                        return false;
                    }

                }
            }
            else
            {
                return false;
            }

        }

        public bool DeletePlaylist(Playlist playlist, int webradioId)
        {
            if (this.Bdd.DeletePlaylist(playlist.Id))
            {
                this.Webradios[webradioId].Playlists.Remove(playlist);
                System.IO.File.Delete(playlist.Filename);
                this.UpdateObservers(webradioId);
                return true;
            }
            else
                return false;

        }

        public bool AddToPlaylist(Playlist playlist, Dictionary<int, string> audioFiles)
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

        public bool RemoveFromPlaylist(Dictionary<int, string> audioFiles, Playlist playlist)
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
            foreach (string filename in playlist.AudioFileList)
            {
                foreach (AudioFile af in this.Library)
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
            while (tmpDuration <= duration)
            {
                audioFile = this.Library[random.Next(0, this.Library.Count - 1)];
                if (audioFile.Type == type)
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

                    if ((audioFile.Type == AudioType.Ad) || (audioFile.Type == AudioType.Music && audioFile.Gender == gender))
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
            if (idPlaylist == Bdd.ERROR)
                return false;
            newPlaylist.Id = idPlaylist;
            //Add to model
            this.Webradios[webradioId].Playlists.Add(newPlaylist);
            newPlaylist.GenerateConfigFile();
            this.UpdateObservers(webradioId);
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
            this.UpdateObservers(webradioId);
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
                this.UpdateObservers(webradioId);
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
                this.UpdateObservers(webradioId);
                return true;
            }
            else
                return false;
        }

        public bool CreateTranscoder(string name, StreamType st, int sampleRate, int bitrate, string url, IPAddress ip, int port, int adminport, string password, int webradioId)
        {
            string filename = DEFAULT_WEBRADIOS_FOLDER + this.Webradios[webradioId].Name + "/" + DEFAULT_TRANSCODERS_FOLDER;
            WebradioTranscoder transcoder;
            if (st == StreamType.AACPlus)
                transcoder = new TranscoderAacPlus(name,
                bitrate,
                sampleRate,
                ip,
                port,
                adminport,
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
                 adminport,
                 url,
                 password,
                 filename,
                 filename);

            transcoder.CalendarFile = DEFAULT_WEBRADIOS_FOLDER + this.Webradios[webradioId].Name + "/" + DEFAULT_CALENDAR_FILENAME;
            int id = this.Bdd.AddTranscoder(transcoder, webradioId);
            if (id == Bdd.ERROR)
                return false;
            transcoder.Id = id;
            transcoder.ConfigFilename = filename + id.ToString() + ".config";
            transcoder.LogFilename = filename + id.ToString() + ".log";
            this.Webradios[webradioId].Transcoders.Add(transcoder);
            transcoder.GenerateConfigFile(this.Webradios[webradioId].Playlists);
            this.Webradios[webradioId].GenerateConfigFiles();
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
                this.UpdateObservers(webradioId);
                return true;
            }
            else
                return false;
        }

        public bool UpdateTranscoder(WebradioTranscoder transcoder, bool debug, int webradioId)
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
                if (wasRunning)
                    transcoder.Start(debug);
                this.UpdateObservers(webradioId);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool StartTranscoder(WebradioTranscoder transcoder, bool debug, int webradioId)
        {
            try
            {
                if (transcoder.Start(debug))
                {
                    this.ActiveTranscoders.Add(transcoder);
                    UpdateObservers(webradioId);
                    return true;
                }
                else
                    return false;

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
                if (transcoder.Stop())
                {
                    this.ActiveTranscoders.Remove(transcoder);
                    this.Webradios[webradioId].Calendar.GenerateConfigFile();
                    this.UpdateObservers(webradioId);
                    return true;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public bool StopAllProcess(int webradioId)
        {
            try
            {
                foreach (WebradioTranscoder transcoder in this.Webradios[webradioId].Transcoders)
                {
                    transcoder.Stop();
                }
                this.Webradios[webradioId].Server.Stop();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool StopAllProcess()
        {
            try
            {
                foreach (KeyValuePair<int, Webradio> webradio in this.Webradios)
                {
                    foreach (WebradioTranscoder transcoder in webradio.Value.Transcoders)
                    {
                        transcoder.Stop();
                    }
                    webradio.Value.Server.Stop();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void GenerateConfigFiles(int webradioId)
        {
            this.Webradios[webradioId].GenerateConfigFiles();
        }

        public bool UpdateServer(bool debug, int port, string password, string adminPassword, int maxListener, int webradioId)
        {
            try
            {
                WebradioServer server = this.Webradios[webradioId].Server;
                bool wasRunning = false;
                if (server.IsRunning())
                {
                    wasRunning = true;
                    server.Process.Kill();
                }

                if (!this.Bdd.UpdateServer(port, password, adminPassword, maxListener, webradioId))
                    return false;

                server.AdminPassword = adminPassword;
                server.Password = password;
                server.Port = port;
                server.MaxListener = maxListener;
                server.GenerateConfigFile();
                if (wasRunning)
                    server.Start(debug);


                this.UpdateObservers(webradioId);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool StartServer(int webradioId, bool debug)
        {
            if (this.Webradios[webradioId].Server.Start(debug))
            {
                this.ActiveServers.Add(this.Webradios[webradioId].Server);
                this.UpdateObservers(webradioId);
                return true;
            }
            else
                return false;
        }

        public bool StopServer(int webradioId)
        {
            if (this.Webradios[webradioId].Server.Stop())
            {
                this.ActiveServers.Remove(this.Webradios[webradioId].Server);
                this.UpdateObservers(webradioId);
                return true;
            }
            else
                return false;
        }

        public void ShowServerWebInterface(int webradioId)
        {
            Process.Start(this.Webradios[webradioId].Server.WebInterfaceUrl);
        }

        public void ShowServerWebAdmin(int webradioId)
        {
            Process.Start(this.Webradios[webradioId].Server.WebAdminUrl);
        }

        public bool TranscoderNextTrack(WebradioTranscoder transcoder)
        {
            try
            {
                transcoder.NextTrack();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool ClearHistory(int transcoderId)
        {
            return this.Bdd.ClearHistory(transcoderId);
        }

        public bool GenerateHistory(int webradioId, string transcoderName, int transcoderId, string outputFilename)
        {
            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, new FileStream(outputFilename, FileMode.Create));
            document.Open();
            iTextSharp.text.Font fontTitle = FontFactory.GetFont(FontFactory.HELVETICA,20,iTextSharp.text.Font.NORMAL);
            iTextSharp.text.Font fontText = FontFactory.GetFont(FontFactory.HELVETICA, 12, iTextSharp.text.Font.NORMAL);
            iTextSharp.text.Font fontTextError = FontFactory.GetFont(FontFactory.HELVETICA, 12,BaseColor.RED);
            document.Add(new Paragraph(new Chunk("Webradio's name : " + this.Webradios[webradioId].Name, fontTitle)));
            document.Add(new Paragraph(new Chunk("Transcoder's name : " + transcoderName + "\n\n", fontTitle)));
            foreach(KeyValuePair<string,string> filename in this.Bdd.GetHistory(transcoderId))
            {
                string line = "";
                AudioFile file = this.GetAudioFileByFilename(filename.Value);
                if(file != null)
                {
                    line += "Title : " + file.Title + "\n";
                    line += "Artist : " + file.Artist + "\n";
                    line += "Album : " + file.Album + "\n";
                    line += "Date : " + filename.Key + "\n\n";
                    document.Add(new Paragraph(new Chunk(line, fontText)));
                }
                else
                {
                    document.Add(new Paragraph(new Chunk("File not found", fontTextError)));
                }
            }
            
            document.Close();
            return true;
        }

        public AudioFile GetAudioFileByFilename(string filename)
        {
            AudioFile result = null;
            foreach(AudioFile file in this.Library)
            {
                if(file.Filename == filename)
                {
                    result = file;
                    break;
                }
            }
            return result;
        }

        public bool ModifyWebradioName(string newName, int webradioId)
        {
            Webradio selectedWebradio = this.Webradios[webradioId];
            this.StopAllProcess(webradioId);
            string oldName = selectedWebradio.Name;
            if (this.Bdd.ModifyWebradioName(newName, webradioId) && this.Bdd.UpdateFilenames(selectedWebradio.Name,newName,selectedWebradio))
            {
                foreach (WebradioTranscoder transcoder in selectedWebradio.Transcoders)
                {
                    transcoder.ConfigFilename = transcoder.ConfigFilename.Replace(oldName, newName);
                    transcoder.LogFilename = transcoder.LogFilename.Replace(oldName, newName);

                }
                selectedWebradio.Server.ConfigFilename = selectedWebradio.Server.ConfigFilename.Replace(oldName, newName);
                selectedWebradio.Server.LogFilename =  selectedWebradio.Server.LogFilename.Replace(oldName, newName);
                foreach (Playlist playlist in selectedWebradio.Playlists)
                {
                     playlist.Filename = playlist.Filename.Replace(oldName, newName);
                }
                selectedWebradio.Calendar.Filename = selectedWebradio.Calendar.Filename.Replace(oldName, newName);

                Directory.Move(DEFAULT_WEBRADIOS_FOLDER + this.Webradios[webradioId].Name, DEFAULT_WEBRADIOS_FOLDER + newName);
                selectedWebradio.Name = newName;
                selectedWebradio.GenerateConfigFiles();
                this.UpdateObservers(webradioId);
                return true;
            }
            else
                return false;
        }

        public bool TranscoderCapture(bool active, string device, WebradioTranscoder transcoder, int webradioId)
        {
            try
            {
                transcoder.SetCaptureMode(active, device);
                this.UpdateObservers(webradioId);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
