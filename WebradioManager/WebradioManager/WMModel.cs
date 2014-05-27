/**
// \file WMModel.cs
//
// \brief Implements the wm model class.
**/

using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using System.Xml;

namespace WebradioManager
{
    /**
    // \class WMModel
    //
    // \brief A data Model for the WebradioManager project.
    //
    // \author Simon Menetrey
    // \date 26.05.2014
    **/

    public class WMModel
    {
        #region Const
        //Default
        // \brief Defaults webradio's folder.
        public const string DEFAULT_WEBRADIOS_FOLDER = "webradios/";
        // \brief The default shoutcast folder.
        public const string DEFAULT_SHOUTCAST_FOLDER = "shoutcast/";
        // \brief The default logfilename.
        const string DEFAULT_LOGFILENAME = "log.txt";
        // \brief The default configfilename.
        const string DEFAULT_CONFIGFILENAME = "config.config";
        // \brief The default password.
        const string DEFAULT_PASSWORD = "1234";
        // \brief The maximum name length.
        const int MAX_NAME_LENGTH = 255;

        //Server
        // \brief Default server folder
        const string DEFAULT_SERVER_FOLDER = "server/";
        // \brief The default server port.
        const int DEFAULT_SERVER_PORT = 8000;
        // \brief The default maximum listener.
        const int DEFAULT_MAX_LISTENER = 32;
        // \brief The default server password.
        const string DEFAULT_SERVER_PASSWORD = "1234";

        //Calendar
        // \brief Default calendar's filename
        public const string DEFAULT_CALENDAR_FILENAME = "calendar.xml";

        //Playlist
        // \brief Default playlist folder
        const string DEFAULT_PLAYLISTS_FOLDER = "playlists/";
        // \brief The maximum try generate.
        const int MAX_TRY_GENERATE = 10;

        //Transcoder
        // \brief Default transcoders folder
        const string DEFAULT_TRANSCODERS_FOLDER = "transcoders/";
        #endregion

        #region Fields
        // \brief The webradios list (id,webradio object).
        private Dictionary<int, Webradio> _webradios;
        // \brief The observers list.
        private List<IController> _observers;
        // \brief The bdd.
        private Bdd _bdd;
        // \brief The library.
        private List<AudioFile> _library;
        // \brief The process watcher.
        private System.Windows.Forms.Timer _processWatcher;
        // \brief The active transcoders list.
        private List<WebradioTranscoder> _activeTranscoders;
        // \brief The active servers list.
        private List<WebradioServer> _activeServers;
        #endregion

        #region Properties

        /**
        // \property public List<WebradioServer> ActiveServers
        //
        // \brief Gets or sets the active servers list.
        //
        // \return The active servers.
        **/

        public List<WebradioServer> ActiveServers
        {
            get { return _activeServers; }
            set { _activeServers = value; }
        }

        /**
        // \property public List<WebradioTranscoder> ActiveTranscoders
        //
        // \brief Gets or sets the active transcoders list.
        //
        // \return The active transcoders.
        **/

        public List<WebradioTranscoder> ActiveTranscoders
        {
            get { return _activeTranscoders; }
            set { _activeTranscoders = value; }
        }

        /**
        // \property public System.Windows.Forms.Timer ProcessWatcher
        //
        // \brief Gets or sets the process watcher.
        //
        // \return The process watcher.
        **/

        public System.Windows.Forms.Timer ProcessWatcher
        {
            get { return _processWatcher; }
            set { _processWatcher = value; }
        }

        /**
        // \property public Bdd Bdd
        //
        // \brief Gets or sets the bdd.
        //
        // \return The bdd.
        **/

        public Bdd Bdd
        {
            get { return _bdd; }
            set { _bdd = value; }
        }

        /**
        // \property public List<IController> Observers
        //
        // \brief Gets or sets the observers.
        //
        // \return The observers.
        **/

        public List<IController> Observers
        {
            get { return _observers; }
            set { _observers = value; }
        }

        /**
        // \property public Dictionary<int, Webradio> Webradios
        //
        // \brief Gets or sets the webradios.
        //
        // \return The webradios.
        **/

        public Dictionary<int, Webradio> Webradios
        {
            get { return _webradios; }
            set { _webradios = value; }
        }

        /**
        // \property public List<AudioFile> Library
        //
        // \brief Gets or sets the library.
        //
        // \return The library.
        **/

        public List<AudioFile> Library
        {
            get { return _library; }
            set { _library = value; }
        }
        #endregion

        #region Methods

        /**
        // \fn public WMModel()
        //
        // \brief Default constructor.
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        **/

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

        /**
        // \fn private string GetCurrentTrackFromXML(string xml)
        //
        // \brief Gets current track from XML.
        //        http://wiki.winamp.com/wiki/SHOUTcast_Transcoder_AJAX_api_Specification#GetStatus
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        //
        // \param xml The XML.
        //
        // \return The current track's filename.
        **/

        private string GetCurrentTrackFromXML(string xml)
        {
            if (!string.IsNullOrEmpty(xml))
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

        /**
        // \fn void ProcessWatcher_Tick(object sender, EventArgs e)
        //
        // \brief Event handler. Called by ProcessWatcher for tick events.
        //        Check all active process and get current track for each active transcoder
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        //
        // \param sender Source of the event.
        // \param e      Event information.
        **/

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
                    if (currentTrack != this.ActiveTranscoders[i].CurrentTrack)
                    {
                        this.ActiveTranscoders[i].CurrentTrack = currentTrack;
                        needUpdate = true;
                        if (!string.IsNullOrEmpty(currentTrack.Trim()))
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

        /**
        // \fn public void AddObserver(IController observer)
        //
        // \brief Adds an observer.
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        //
        // \param observer The observer.
        **/

        public void AddObserver(IController observer)
        {
            this.Observers.Add(observer);
        }

        /**
        // \fn public void RemoveObserver(IController observer)
        //
        // \brief Removes the observer described by observer.
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        //
        // \param observer The observer.
        **/

        public void RemoveObserver(IController observer)
        {
            this.Observers.Remove(observer);
        }

        /**
        // \fn public int GetSimiliarViewCount(int webradioId)
        //
        // \brief Gets similiar view count.
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        //
        // \param webradioId Identifier for the webradio.
        //
        // \return The similiar view count.
        **/

        public int GetSimiliarViewCount(int webradioId)
        {
            int ret = 0;
            foreach (IController controler in this.Observers)
            {
                if (controler is AdminController)
                {
                    if ((controler as AdminController).View.IdWebradio == webradioId)
                        ret++;
                }
            }
            return ret;
        }

        /**
        // \fn private void UpdateObservers(int webradioId)
        //
        // \brief Updates the observers described by webradioId.
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        //
        // \param webradioId Identifier for the webradio.
        **/

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

        /**
        // \fn private void UpdateObservers()
        //
        // \brief Updates the observers.
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        **/

        private void UpdateObservers()
        {
            foreach (IController controller in this.Observers)
            {
                controller.UpdateView();
            }
        }

        /**
        // \fn public void LoadLibrary()
        //
        // \brief Loads the library.
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        **/

        public void LoadLibrary()
        {
            this.Library = this.Bdd.LoadLibrary();
        }

        /**
        // \fn public void CheckFolders(int webradioId)
        //
        // \brief Check folders.
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        //
        // \param webradioId Identifier for the webradio.
        **/

        public void CheckFolders(int webradioId)
        {
            if (!Directory.Exists(DEFAULT_WEBRADIOS_FOLDER + this.Webradios[webradioId].Name))
                Directory.CreateDirectory(DEFAULT_WEBRADIOS_FOLDER + this.Webradios[webradioId].Name);
        }

        /**
        // \fn public void LoadWebradios()
        //
        // \brief Loads the webradios.
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        **/

        public void LoadWebradios()
        {
            if (!Directory.Exists(DEFAULT_WEBRADIOS_FOLDER))
                Directory.CreateDirectory(DEFAULT_WEBRADIOS_FOLDER);
            if (!Directory.Exists(DEFAULT_SHOUTCAST_FOLDER))
                Directory.CreateDirectory(DEFAULT_SHOUTCAST_FOLDER);
            this.Webradios = this.Bdd.LoadWebradios();
        }

        /**
        // \fn public Webradio GetWebradio(int id)
        //
        // \brief Gets a webradio.
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        //
        // \param id The identifier.
        //
        // \return The webradio.
        **/

        public Webradio GetWebradio(int id)
        {
            return this.Webradios[id];
        }

        /**
        // \fn public Webradio GetWebradioByName(string name)
        //
        // \brief Gets webradio by name.
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        //
        // \param name The name.
        //
        // \return The webradio by name.
        **/

        public Webradio GetWebradioByName(string name)
        {
            Webradio ret = null;
            foreach (KeyValuePair<int, Webradio> webradio in this.Webradios)
            {
                if (webradio.Value.Name == name)
                {
                    ret = webradio.Value;
                    break;
                }
            }
            return ret;
        }

        /**
        // \fn public List<Webradio> GetWebradios()
        //
        // \brief Gets the webradios list.
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        //
        // \return The webradios list.
        **/

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

        /**
        // \fn public bool CreateWebradio(string name)
        //
        // \brief Creates a webradio.
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        //
        // \param name The name.
        //
        // \return true if it succeeds, false if it fails.
        **/

        public bool CreateWebradio(string name)
        {
            if (this.IsValidPath(name))
            {
                string webradioFilename = DEFAULT_WEBRADIOS_FOLDER + name + "/";
                Webradio wr = new Webradio(name);
                WebradioServer server = new WebradioServer(DEFAULT_SERVER_PORT,
                    webradioFilename + DEFAULT_SERVER_FOLDER + DEFAULT_LOGFILENAME,
                    webradioFilename + DEFAULT_SERVER_FOLDER + DEFAULT_CONFIGFILENAME, DEFAULT_SERVER_PASSWORD, WebradioServer.DEFAULT_ADMIN_LOGIN, DEFAULT_MAX_LISTENER);
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

        /**
        // \fn public bool DeleteWebradio(int id)
        //
        // \brief Deletes the webradio described by ID.
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        //
        // \param id The identifier.
        //
        // \return true if it succeeds, false if it fails.
        **/

        public bool DeleteWebradio(int id)
        {
            bool output = false;
            output = this.Bdd.DeleteWebradio(id);
            Directory.Delete(DEFAULT_WEBRADIOS_FOLDER + this.Webradios[id].Name, true);
            //Delete webradio from model
            try
            {
                for (int i = 0; i < this.Observers.Count; i++)
                {
                    AdminController ac = null;
                    if (this.Observers[i] is AdminController)
                    {
                        ac = this.Observers[i] as AdminController;
                        if (ac.View.IdWebradio == id)
                        {
                            ac.View.Close();
                            this.RemoveObserver(ac);
                            i--;
                        }
                    }
                }
                this.Webradios.Remove(id);
                output = true;
            }
            catch
            {
                output = false;
            }

            return output;
        }

        /**
        // \fn private Playlist GetPlaylistByName(string name, int webradioId)
        //
        // \brief Gets playlist by name.
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        //
        // \param name       The name.
        // \param webradioId Identifier for the webradio.
        //
        // \return The playlist by name.
        **/

        private Playlist GetPlaylistByName(string name, int webradioId)
        {
            Playlist playlist = null;
            foreach (Playlist p in this.Webradios[webradioId].Playlists)
            {
                if (p.Name == name)
                {
                    playlist = p;
                    break;
                }
            }
            return playlist;
        }

        /**
        // \fn public bool DuplicateWebradio(int id)
        //
        // \brief Duplicate webradio.
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        //
        // \param id The identifier.
        //
        // \return true if it succeeds, false if it fails.
        **/

        public bool DuplicateWebradio(int id)
        {
            Webradio webradio = this.Webradios[id];
            string name = "Copy of " + webradio.Name;
            if (this.IsValidPath(name))
            {
                try
                {
                    this.CreateWebradio(name);
                    Webradio newWebradio = this.GetWebradioByName(name);
                    //SERVER CONFIGURATION - Put server config to the clone
                    this.UpdateServer(true, webradio.Server.Port, webradio.Server.Password, webradio.Server.AdminPassword, webradio.Server.MaxListener, newWebradio.Id);
                    //PLAYLIST CONFIGURATION
                    foreach (Playlist playlist in webradio.Playlists)
                    {
                        Playlist newPlaylist;
                        if (this.CreatePlaylist(playlist.Name, newWebradio.Name, newWebradio.Id, playlist.Type, out newPlaylist))
                        {
                            newPlaylist.AudioFileList = new List<string>(playlist.AudioFileList);
                        }
                    }
                    //CALENDAR CONFIGURATION
                    foreach (CalendarEvent ev in webradio.Calendar.Events)
                    {
                        Playlist newPlaylistEvent = this.GetPlaylistByName(ev.Playlist.Name, newWebradio.Id);
                        if (newPlaylistEvent != null)
                        {
                            CalendarEvent newEvent = new CalendarEvent(ev.Name, ev.StartTime, ev.Duration, ev.Repeat, ev.Priority, ev.Shuffle, ev.Loopatend, newPlaylistEvent);
                            this.CreateEvent(newEvent, newWebradio.Id);
                        }
                    }
                    //TRANSCODER CONFIGURATION
                    foreach (WebradioTranscoder transcoder in webradio.Transcoders)
                    {
                        this.CreateTranscoder(transcoder.Name, transcoder.StreamType, transcoder.SampleRate, transcoder.Birate, transcoder.Url, transcoder.Ip, transcoder.Port, transcoder.AdminPort, transcoder.Password, newWebradio.Id);
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

        /**
        // \fn public List<AudioFile> GetLibrary()
        //
        // \brief Gets the library.
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        //
        // \return The library.
        **/

        public List<AudioFile> GetLibrary()
        {
            return this.Library;
        }

        /**
        // \fn public List<string> GetGenders()
        //
        // \brief Gets the genders list.
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        //
        // \return The genders list.
        **/

        public List<string> GetGenders()
        {
            return this.Bdd.GetGenders();
        }

        /**
        // \fn public bool ImportFilesToLibrary(string[] filenames, AudioType type)
        //
        // \brief Import files to library.
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        //
        // \param filenames The filenames array.
        // \param type      The type.
        //
        // \return true if it succeeds, false if it fails.
        **/

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

        /**
        // \fn public bool DeleteAudioFile(int id, string audioFilename)
        //
        // \brief Deletes the audio file.
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        //
        // \param id            The identifier.
        // \param audioFilename Filename of the audio file.
        //
        // \return true if it succeeds, false if it fails.
        **/

        public bool DeleteAudioFile(int id, string audioFilename)
        {
            foreach (KeyValuePair<int, Webradio> webradio in this.Webradios)
            {
                foreach (Playlist playlist in webradio.Value.Playlists)
                {
                    for (int i = 0; i < playlist.AudioFileList.Count; i++)
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

        /**
        // \fn public bool UpdateAudioFile(AudioFile file)
        //
        // \brief Updates the audio file with param one's value.
        //        Retag file.
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        //
        // \param file The file.
        //
        // \return true if it succeeds, false if it fails.
        **/

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

                    foreach (AudioFile af in this.Library)
                    {
                        if (af.Id == file.Id)
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

        /**
        // \fn private bool IsValidFilename(string testName)
        //
        // \brief Query if 'testName' is a valid filename.
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        //
        // \param testName Name of the test.
        //
        // \return true if valid filename, false if not.
        **/

        private bool IsValidFilename(string testName)
        {
            char[] invalidFileChars = Path.GetInvalidFileNameChars();
            if (testName.IndexOfAny(invalidFileChars) == -1)
                return true;
            else
                return false;
        }

        /**
        // \fn private bool IsValidPath(string testName)
        //
        // \brief Query if 'testName' is a valid path.
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        //
        // \param testName Name of the test.
        //
        // \return true if valid path, false if not.
        **/

        private bool IsValidPath(string testName)
        {
            char[] invalidFileChars = Path.GetInvalidPathChars();
            if (testName.IndexOfAny(invalidFileChars) == -1)
                return true;
            else
                return false;
        }

        /**
        // \fn public bool CreatePlaylist(string name, string webradioName, int webradioId, AudioType type, out Playlist newPlaylist)
        //
        // \brief Creates a playlist.
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        //
        // \param name              The name.
        // \param webradioName      Name of the webradio.
        // \param webradioId        Identifier for the webradio.
        // \param type              The type.
        // \param [out] newPlaylist The new playlist.
        //
        // \return true if it succeeds, false if it fails.
        **/

        public bool CreatePlaylist(string name, string webradioName, int webradioId, AudioType type, out Playlist newPlaylist)
        {
            Webradio selectedWebradio = this.Webradios[webradioId];
            int id = Bdd.ERROR;
            newPlaylist = null;
            if (this.IsValidFilename(name))
            {
                string filename = DEFAULT_WEBRADIOS_FOLDER + webradioName + "/" + DEFAULT_PLAYLISTS_FOLDER + name + ".lst";
                if (type == AudioType.Music)
                    newPlaylist = new PlaylistMusic(name, filename);
                else
                    newPlaylist = new PlaylistAd(name, filename);
                id = this.Bdd.CreatePlaylist(newPlaylist, webradioId);
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

        /**
        // \fn public bool DeletePlaylist(Playlist playlist, int webradioId)
        //
        // \brief Deletes the playlist.
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        //
        // \param playlist   The playlist.
        // \param webradioId Identifier for the webradio.
        //
        // \return true if it succeeds, false if it fails.
        **/

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

        /**
        // \fn public bool AddToPlaylist(Playlist playlist, Dictionary<int, string> audioFiles)
        //
        // \brief Adds to the playlist.
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        //
        // \param playlist   The playlist.
        // \param audioFiles The audio files.
        //
        // \return true if it succeeds, false if it fails.
        **/

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

        /**
        // \fn public bool RemoveFromPlaylist(Dictionary<int, string> audioFiles, Playlist playlist)
        //
        // \brief Removes from playlist.
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        //
        // \param audioFiles The audio files.
        // \param playlist   The playlist.
        //
        // \return true if it succeeds, false if it fails.
        **/

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

        /**
        // \fn public List<AudioFile> GetPlaylistContent(Playlist playlist)
        //
        // \brief Gets playlist content.
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        //
        // \param playlist The playlist.
        //
        // \return The playlist content (AudioFile list).
        **/

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

        /**
        // \fn public bool GeneratePlaylist(string name, TimeSpan duration, AudioType type, string gender, int webradioId, string webradioName)
        //
        // \brief Generates a playlist.
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        //
        // \param name         The name.
        // \param duration     The duration.
        // \param type         The type.
        // \param gender       The gender.
        // \param webradioId   Identifier for the webradio.
        // \param webradioName Name of the webradio.
        //
        // \return true if it succeeds, false if it fails.
        **/

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

        /**
        // \fn public bool CreateEvent(CalendarEvent newEvent, int webradioId)
        //
        // \brief Creates an event.
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        //
        // \param newEvent   The new event.
        // \param webradioId Identifier for the webradio.
        //
        // \return true if it succeeds, false if it fails.
        **/

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

        /**
        // \fn public bool UpdateEvent(CalendarEvent aEvent, int webradioId)
        //
        // \brief Updates the event with param one's values.
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        //
        // \param aEvent     The event.
        // \param webradioId Identifier for the webradio.
        //
        // \return true if it succeeds, false if it fails.
        **/

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

        /**
        // \fn public bool DeleteEvent(CalendarEvent aEvent, int webradioId)
        //
        // \brief Deletes the event.
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        //
        // \param aEvent     The event.
        // \param webradioId Identifier for the webradio.
        //
        // \return true if it succeeds, false if it fails.
        **/

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

        /**
        // \fn public bool CreateTranscoder(string name, StreamType st, int sampleRate, int bitrate, string url, IPAddress ip, int port, int adminport, string password, int webradioId)
        //
        // \brief Creates a transcoder.
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        //
        // \param name       The name.
        // \param st         The st.
        // \param sampleRate The sample rate.
        // \param bitrate    The bitrate.
        // \param url        URL of the document.
        // \param ip         The IP.
        // \param port       The port.
        // \param adminport  The administration port.
        // \param password   The password.
        // \param webradioId Identifier for the webradio.
        //
        // \return true if it succeeds, false if it fails.
        **/

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

        /**
        // \fn public bool DeleteTranscoder(WebradioTranscoder transcoder, int webradioId)
        //
        // \brief Deletes the transcoder.
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        //
        // \param transcoder The transcoder.
        // \param webradioId Identifier for the webradio.
        //
        // \return true if it succeeds, false if it fails.
        **/

        public bool DeleteTranscoder(WebradioTranscoder transcoder, int webradioId)
        {
            if (transcoder.IsRunning())
                transcoder.Stop();

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

        /**
        // \fn public bool UpdateTranscoder(WebradioTranscoder transcoder, bool debug, int webradioId)
        //
        // \brief Updates the transcoder.
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        //
        // \param transcoder The transcoder.
        // \param debug      true to debug.
        // \param webradioId Identifier for the webradio.
        //
        // \return true if it succeeds, false if it fails.
        **/

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

        /**
        // \fn public bool StartTranscoder(WebradioTranscoder transcoder, bool debug, int webradioId)
        //
        // \brief Starts a transcoder.
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        //
        // \param transcoder The transcoder.
        // \param debug      true to debug.
        // \param webradioId Identifier for the webradio.
        //
        // \return true if it succeeds, false if it fails.
        **/

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

        /**
        // \fn public bool StopTranscoder(WebradioTranscoder transcoder, int webradioId)
        //
        // \brief Stops a transcoder.
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        //
        // \param transcoder The transcoder.
        // \param webradioId Identifier for the webradio.
        //
        // \return true if it succeeds, false if it fails.
        **/

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

        /**
        // \fn public bool StopAllProcess(int webradioId)
        //
        // \brief Stops all process of a webradio.
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        //
        // \param webradioId Identifier for the webradio.
        //
        // \return true if it succeeds, false if it fails.
        **/

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

        /**
        // \fn public bool StopAllProcess()
        //
        // \brief Stops all process of the program.
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        //
        // \return true if it succeeds, false if it fails.
        **/

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

        /**
        // \fn public void GenerateConfigFiles(int webradioId)
        //
        // \brief Generates a configuration files.
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        //
        // \param webradioId Identifier for the webradio.
        **/

        public void GenerateConfigFiles(int webradioId)
        {
            this.Webradios[webradioId].GenerateConfigFiles();
        }

        /**
        // \fn public bool UpdateServer(bool debug, int port, string password, string adminPassword, int maxListener, int webradioId)
        //
        // \brief Updates the server.
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        //
        // \param debug         true to debug.
        // \param port          The port.
        // \param password      The password.
        // \param adminPassword The admin password.
        // \param maxListener   The maximum listener.
        // \param webradioId    Identifier for the webradio.
        //
        // \return true if it succeeds, false if it fails.
        **/

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

        /**
        // \fn public bool StartServer(int webradioId, bool debug)
        //
        // \brief Starts a server.
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        //
        // \param webradioId Identifier for the webradio.
        // \param debug      true to debug.
        //
        // \return true if it succeeds, false if it fails.
        **/

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

        /**
        // \fn public bool StopServer(int webradioId)
        //
        // \brief Stops a server.
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        //
        // \param webradioId Identifier for the webradio.
        //
        // \return true if it succeeds, false if it fails.
        **/

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

        /**
        // \fn public void ShowServerWebInterface(int webradioId)
        //
        // \brief Shows the server web interface.
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        //
        // \param webradioId Identifier for the webradio.
        **/

        public void ShowServerWebInterface(int webradioId)
        {
            Process.Start(this.Webradios[webradioId].Server.WebInterfaceUrl);
        }

        /**
        // \fn public void ShowServerWebAdmin(int webradioId)
        //
        // \brief Shows the server web admin.
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        //
        // \param webradioId Identifier for the webradio.
        **/

        public void ShowServerWebAdmin(int webradioId)
        {
            Process.Start(this.Webradios[webradioId].Server.WebAdminUrl);
        }

        /**
        // \fn public bool TranscoderNextTrack(WebradioTranscoder transcoder)
        //
        // \brief Transcoder goes next track.
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        //
        // \param transcoder The transcoder.
        //
        // \return true if it succeeds, false if it fails.
        **/

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

        /**
        // \fn public bool ClearHistory(int transcoderId)
        //
        // \brief Clears the transcoder's history described by transcoderId.
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        //
        // \param transcoderId Identifier for the transcoder.
        //
        // \return true if it succeeds, false if it fails.
        **/

        public bool ClearHistory(int transcoderId)
        {
            return this.Bdd.ClearHistory(transcoderId);
        }

        /**
        // \fn public bool GenerateHistory(int webradioId, string transcoderName, int transcoderId, string outputFilename)
        //
        // \brief Generates a transcoder's history.
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        //
        // \param webradioId     Identifier for the webradio.
        // \param transcoderName Name of the transcoder.
        // \param transcoderId   Identifier for the transcoder.
        // \param outputFilename Filename of the output file.
        //
        // \return true if it succeeds, false if it fails.
        **/

        public bool GenerateHistory(int webradioId, string transcoderName, int transcoderId, string outputFilename)
        {
            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, new FileStream(outputFilename, FileMode.Create));
            document.Open();
            iTextSharp.text.Font fontTitle = FontFactory.GetFont(FontFactory.HELVETICA, 20, iTextSharp.text.Font.NORMAL);
            iTextSharp.text.Font fontText = FontFactory.GetFont(FontFactory.HELVETICA, 12, iTextSharp.text.Font.NORMAL);
            iTextSharp.text.Font fontTextError = FontFactory.GetFont(FontFactory.HELVETICA, 12, BaseColor.RED);
            document.Add(new Paragraph(new Chunk("Webradio's name : " + this.Webradios[webradioId].Name, fontTitle)));
            document.Add(new Paragraph(new Chunk("Transcoder's name : " + transcoderName + "\n\n", fontTitle)));
            foreach (KeyValuePair<string, string> filename in this.Bdd.GetHistory(transcoderId))
            {
                string line = "";
                AudioFile file = this.GetAudioFileByFilename(filename.Value);
                if (file != null)
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

        /**
        // \fn public AudioFile GetAudioFileByFilename(string filename)
        //
        // \brief Gets audio file by filename.
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        //
        // \param filename Filename of the file.
        //
        // \return The audio file by filename.
        **/

        public AudioFile GetAudioFileByFilename(string filename)
        {
            AudioFile result = null;
            foreach (AudioFile file in this.Library)
            {
                if (file.Filename == filename)
                {
                    result = file;
                    break;
                }
            }
            return result;
        }

        /**
        // \fn public bool ModifyWebradioName(string newName, int webradioId)
        //
        // \brief Modify webradio name.
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        //
        // \param newName    Name of the new webradio.
        // \param webradioId Identifier for the webradio.
        //
        // \return true if it succeeds, false if it fails.
        **/

        public bool ModifyWebradioName(string newName, int webradioId)
        {
            Webradio selectedWebradio = this.Webradios[webradioId];
            this.StopAllProcess(webradioId);
            string oldName = selectedWebradio.Name;
            if (this.Bdd.ModifyWebradioName(newName, webradioId) && this.Bdd.UpdateFilenames(selectedWebradio.Name, newName, selectedWebradio))
            {
                foreach (WebradioTranscoder transcoder in selectedWebradio.Transcoders)
                {
                    transcoder.ConfigFilename = transcoder.ConfigFilename.Replace(oldName, newName);
                    transcoder.LogFilename = transcoder.LogFilename.Replace(oldName, newName);

                }
                selectedWebradio.Server.ConfigFilename = selectedWebradio.Server.ConfigFilename.Replace(oldName, newName);
                selectedWebradio.Server.LogFilename = selectedWebradio.Server.LogFilename.Replace(oldName, newName);
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

        /**
        // \fn public bool TranscoderCapture(bool active, string device, WebradioTranscoder transcoder, int webradioId)
        //
        // \brief Transcoder capture set.
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        //
        // \param active     true to active.
        // \param device     The device.
        // \param transcoder The transcoder.
        // \param webradioId Identifier for the webradio.
        //
        // \return true if it succeeds, false if it fails.
        **/

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

        /**
        // \fn public List<WebradioListener> UpdateServerListeners(int webradioId)
        //
        // \brief Updates the webradio's server listeners.
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        //
        // \param webradioId Identifier for the webradio.
        //
        // \return A List&lt;WebradioListener&gt;
        **/

        public List<WebradioListener> UpdateServerListeners(int webradioId)
        {
            return this.Webradios[webradioId].Server.GetListeners();
        }

        /**
        // \fn public bool UpdateServerStats(int webradioId)
        //
        // \brief Updates the webradio's server statistics.
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        //
        // \param webradioId Identifier for the webradio.
        //
        // \return true if it succeeds, false if it fails.
        **/

        public bool UpdateServerStats(int webradioId)
        {
            WebradioServer server = this.Webradios[webradioId].Server;
            server.UpdateStats();
            this.UpdateObservers(webradioId);
            return true;
        }

        /**
        // \fn public bool CheckLibrary()
        //
        // \brief Check if audio files from library exists on the disc.
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        //
        // \return true if it succeeds, false if it fails.
        **/

        public bool CheckLibrary()
        {
            try
            {
                for (int i = 0; i < this.Library.Count; i++)
                {
                    AudioFile file = this.Library[i];
                    if (!System.IO.File.Exists(file.Filename))
                    {
                        this.Bdd.DeleteAudioFile(file.Id);
                        this.Library.Remove(file);
                        i--;
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
        #endregion

    }
}
