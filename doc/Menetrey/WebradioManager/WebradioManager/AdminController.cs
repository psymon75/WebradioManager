/**
// \file AdminController.cs
//
// \brief Implements the admin controller class.
**/

using System;
using System.Collections.Generic;
using System.Net;

namespace WebradioManager
{
    /**
    // \class AdminController
    //
    // \brief A controller for handling admin view.
    //
    // \author Simon Menetrey
    // \date 23.05.2014
    **/

    public class AdminController : IController
    {
        #region Fields
        // \brief The model.
        private WMModel _model;
        // \brief The view.
        private AdminView _view;
        #endregion

        #region Properties

        /**
        // \property public AdminView View
        //
        // \brief Gets or sets the view.
        //
        // \return The view.
        **/

        public AdminView View
        {
            get { return _view; }
            set { _view = value; }
        }

        /**
        // \property public WMModel Model
        //
        // \brief Gets or sets the model.
        //
        // \return The model.
        **/

        public WMModel Model
        {
            get { return _model; }
            set { _model = value; }
        }
        #endregion

        #region Methods

        /**
        // \fn public AdminController(int id, WMModel model)
        //
        // \brief Constructor.
        //
        // \author Simon Menetrey
        // \date 23.05.2014
        //
        // \param id    The webradio identifier.
        // \param model The model.
        **/

        public AdminController(int id, WMModel model)
        {
            this.View = new AdminView(id,this);
            this.Model = model;
            this.UpdateView();
            this.View.Show();
        }

        /**
        // \fn public void UpdateView()
        //
        // \brief Updates the view.
        //
        // \author Simon Menetrey
        // \date 23.05.2014
        **/

        public void UpdateView()
        {
            this.View.UpdateView();
        }

        /**
        // \fn public Webradio GetWebradio(int id)
        //
        // \brief Gets a webradio.
        //
        // \author Simon Menetrey
        // \date 23.05.2014
        //
        // \param id The webradio identifier.
        //
        // \return The webradio.
        **/

        public Webradio GetWebradio(int id)
        {
            return this.Model.GetWebradio(id);
        }

        /**
        // \fn public List<AudioFile> GetLibrary()
        //
        // \brief Gets the library.
        //
        // \author Simon Menetrey
        // \date 23.05.2014
        //
        // \return The library.
        **/

        public List<AudioFile> GetLibrary()
        {
            return this.Model.GetLibrary();
        }

        /**
        // \fn public List<string> GetGenders()
        //
        // \brief Gets the genders.
        //
        // \author Simon Menetrey
        // \date 23.05.2014
        //
        // \return The genders.
        **/

        public List<string> GetGenders()
        {
            return this.Model.GetGenders();
        }

        /**
        // \fn public void CheckFolders(int webradioId)
        //
        // \brief Check folders.
        //
        // \author Simon Menetrey
        // \date 23.05.2014
        //
        // \param webradioId Identifier of the webradio.
        **/

        public void CheckFolders(int webradioId)
        {
            this.Model.CheckFolders(webradioId);
        }

        /**
        // \fn public void FormClose()
        //
        // \brief Form close. Remove observer.
        //
        // \author Simon Menetrey
        // \date 23.05.2014
        **/

        public void FormClose()
        {
            this.Model.RemoveObserver(this);
        }

        /**
        // \fn public bool ImportFilesToLibrary(string[] filenames, AudioType type)
        //
        // \brief Import files to library.
        //
        // \author Simon Menetrey
        // \date 23.05.2014
        //
        // \param filenames The filenames.
        // \param type      The type.
        //
        // \return true if it succeeds, false if it fails.
        **/

        public bool ImportFilesToLibrary(string[] filenames, AudioType type)
        {
            return this.Model.ImportFilesToLibrary(filenames, type);
        }

        /**
        // \fn public bool DeleteAudioFile(int id,string filename)
        //
        // \brief Deletes the audio file.
        //
        // \author Simon Menetrey
        // \date 23.05.2014
        //
        // \param id       The identifier.
        // \param filename Filename of the file.
        //
        // \return true if it succeeds, false if it fails.
        **/

        public bool DeleteAudioFile(int id,string filename)
        {
            return this.Model.DeleteAudioFile(id,filename);
        }

        /**
        // \fn public bool CreatePlaylist(string name, string webradioName, int webradioId, AudioType type)
        //
        // \brief Creates a playlist.
        //
        // \author Simon Menetrey
        // \date 23.05.2014
        //
        // \param name         The playlis's name.
        // \param webradioName Name of the webradio.
        // \param webradioId   Identifier of the webradio.
        // \param type         The type.
        //
        // \return true if it succeeds, false if it fails.
        **/

        public bool CreatePlaylist(string name, string webradioName, int webradioId, AudioType type)
        {
            Playlist newPlaylist;
            return this.Model.CreatePlaylist(name,webradioName,webradioId,type, out newPlaylist);
        }

        /**
        // \fn public bool DeletePlaylist(Playlist playlist, int webradioId)
        //
        // \brief Deletes the playlist.
        //
        // \author Simon Menetrey
        // \date 23.05.2014
        //
        // \param playlist   The playlist.
        // \param webradioId Identifier of the webradio.
        //
        // \return true if it succeeds, false if it fails.
        **/

        public bool DeletePlaylist(Playlist playlist, int webradioId)
        {
            return this.Model.DeletePlaylist(playlist, webradioId);
        }

        /**
        // \fn public bool AddToPlaylist(Playlist playlist, Dictionary<int, string> audioFiles)
        //
        // \brief Adds to the playlist.
        //
        // \author Simon Menetrey
        // \date 23.05.2014
        //
        // \param playlist   The playlist.
        // \param audioFiles The audio files.
        //
        // \return true if it succeeds, false if it fails.
        **/

        public bool AddToPlaylist(Playlist playlist, Dictionary<int, string> audioFiles)
        {
            if (playlist != null)
                return this.Model.AddToPlaylist(playlist, audioFiles);
            else
                return false;
        }

        /**
        // \fn public bool RemoveFromPlaylist(Playlist playlist, Dictionary<int,string> audioFiles)
        //
        // \brief Removes from playlist.
        //
        // \author Simon Menetrey
        // \date 23.05.2014
        //
        // \param playlist   The playlist.
        // \param audioFiles The audio files.
        //
        // \return true if it succeeds, false if it fails.
        **/

        public bool RemoveFromPlaylist(Playlist playlist, Dictionary<int,string> audioFiles)
        {
            return this.Model.RemoveFromPlaylist(audioFiles, playlist);
        }

        /**
        // \fn public List<AudioFile> GetPlaylistContent(Playlist playlist)
        //
        // \brief Gets playlist content.
        //
        // \author Simon Menetrey
        // \date 23.05.2014
        //
        // \param playlist The playlist.
        //
        // \return The playlist content.
        **/

        public List<AudioFile> GetPlaylistContent(Playlist playlist)
        {
            return this.Model.GetPlaylistContent(playlist);
        }

        /**
        // \fn public bool GeneratePlaylist(string name, TimeSpan duration, AudioType type, string gender, int webradioId, string webradioName)
        //
        // \brief Generates a playlist.
        //
        // \author Simon Menetrey
        // \date 23.05.2014
        //
        // \param name         The name.
        // \param duration     The duration.
        // \param type         The type.
        // \param gender       The gender.
        // \param webradioId   Identifier of the webradio.
        // \param webradioName Name of the webradio.
        //
        // \return true if it succeeds, false if it fails.
        **/

        public bool GeneratePlaylist(string name, TimeSpan duration, AudioType type, string gender, int webradioId, string webradioName)
        {
            return this.Model.GeneratePlaylist(name, duration, type, gender, webradioId, webradioName);
        }

        /**
        // \fn public bool CreateEvent(CalendarEvent newEvent, int webradioId)
        //
        // \brief Creates an event.
        //
        // \author Simon Menetrey
        // \date 23.05.2014
        //
        // \param newEvent   The new event.
        // \param webradioId Identifier of the webradio.
        //
        // \return true if it succeeds, false if it fails.
        **/

        public bool CreateEvent(CalendarEvent newEvent, int webradioId)
        {
            return this.Model.CreateEvent(newEvent, webradioId);
        }

        /**
        // \fn public bool UpdateEvent(CalendarEvent aEvent, int webradioId)
        //
        // \brief Updates the event.
        //
        // \author Simon Menetrey
        // \date 23.05.2014
        //
        // \param aEvent     The event.
        // \param webradioId Identifier of the webradio.
        //
        // \return true if it succeeds, false if it fails.
        **/

        public bool UpdateEvent(CalendarEvent aEvent, int webradioId)
        {
            return this.Model.UpdateEvent(aEvent,webradioId);
        }

        /**
        // \fn public bool DeleteEvent(CalendarEvent aEvent, int webradioId)
        //
        // \brief Deletes the event.
        //
        // \author Simon Menetrey
        // \date 23.05.2014
        //
        // \param aEvent     The event.
        // \param webradioId Identifier of the webradio.
        //
        // \return true if it succeeds, false if it fails.
        **/

        public bool DeleteEvent(CalendarEvent aEvent, int webradioId)
        {
            return this.Model.DeleteEvent(aEvent, webradioId);
        }

        /**
        // \fn public bool CreateTranscoder(string name, StreamType st, int sampleRate, int bitrate, string url, IPAddress ip, int port, int adminport, string password, int webradioId)
        //
        // \brief Creates a transcoder.
        //
        // \author Simon Menetrey
        // \date 23.05.2014
        //
        // \param name       The name.
        // \param st         The streamtype.
        // \param sampleRate The sample rate.
        // \param bitrate    The bitrate.
        // \param url        URL of the stream.
        // \param ip         The IP.
        // \param port       The port.
        // \param adminport  The adminport.
        // \param password   The password.
        // \param webradioId Identifier of the webradio.
        //
        // \return true if it succeeds, false if it fails.
        **/

        public bool CreateTranscoder(string name, StreamType st, int sampleRate, int bitrate, string url, IPAddress ip, int port, int adminport, string password, int webradioId)
        {
            return this.Model.CreateTranscoder(name, st, sampleRate, bitrate, url, ip, port, adminport, password, webradioId);
        }

        /**
        // \fn public bool DeleteTranscoder(WebradioTranscoder transcoder, int webradioId)
        //
        // \brief Deletes the transcoder.
        //
        // \author Simon Menetrey
        // \date 23.05.2014
        //
        // \param transcoder The transcoder.
        // \param webradioId Identifier of the webradio.
        //
        // \return true if it succeeds, false if it fails.
        **/

        public bool DeleteTranscoder(WebradioTranscoder transcoder, int webradioId)
        {
            return this.Model.DeleteTranscoder(transcoder, webradioId);
        }

        /**
        // \fn public bool UpdateTranscoder(WebradioTranscoder transcoder, bool debug, int webradioId)
        //
        // \brief Updates the transcoder.
        //
        // \author Simon Menetrey
        // \date 23.05.2014
        //
        // \param transcoder The transcoder.
        // \param debug      Debug or not.
        // \param webradioId Identifier of the webradio.
        //
        // \return true if it succeeds, false if it fails.
        **/

        public bool UpdateTranscoder(WebradioTranscoder transcoder, bool debug, int webradioId)
        {
            return this.Model.UpdateTranscoder(transcoder, debug, webradioId);
        }

        /**
        // \fn public bool StartTranscoder(WebradioTranscoder transcoder,bool debug, int webradioId)
        //
        // \brief Starts a transcoder.
        //
        // \author Simon Menetrey
        // \date 23.05.2014
        //
        // \param transcoder The transcoder.
        // \param debug      Debug or not.
        // \param webradioId Identifier of the webradio.
        //
        // \return true if it succeeds, false if it fails.
        **/

        public bool StartTranscoder(WebradioTranscoder transcoder,bool debug, int webradioId)
        {
            return this.Model.StartTranscoder(transcoder, debug, webradioId);
        }

        /**
        // \fn public bool StopTranscoder(WebradioTranscoder transcoder, int webradioId)
        //
        // \brief Stops a transcoder.
        //
        // \author Simon Menetrey
        // \date 23.05.2014
        //
        // \param transcoder The transcoder.
        // \param webradioId Identifier of the webradio.
        //
        // \return true if it succeeds, false if it fails.
        **/

        public bool StopTranscoder(WebradioTranscoder transcoder, int webradioId)
        {
            return this.Model.StopTranscoder(transcoder,webradioId);
        }

        /**
        // \fn public bool StopAllTranscoders(int webradioId)
        //
        // \brief Stops all transcoders.
        //
        // \author Simon Menetrey
        // \date 23.05.2014
        //
        // \param webradioId Identifier of the webradio.
        //
        // \return true if it succeeds, false if it fails.
        **/

        public bool StopAllTranscoders(int webradioId)
        {
            return this.Model.StopAllProcess(webradioId);
        }

        /**
        // \fn public void GenerateAllConfigs(int webradioId)
        //
        // \brief Generates all configs.
        //
        // \author Simon Menetrey
        // \date 23.05.2014
        //
        // \param webradioId Identifier of the webradio.
        **/

        public void GenerateAllConfigs(int webradioId)
        {
            this.Model.GenerateConfigFiles(webradioId);
        }

        /**
        // \fn public bool UpdateServer(bool debug, int port, string password, string adminPassword, int maxListener, int webradioId)
        //
        // \brief Updates the server.
        //
        // \author Simon Menetrey
        // \date 23.05.2014
        //
        // \param debug         Debug or not.
        // \param port          The port.
        // \param password      The password.
        // \param adminPassword The admin password.
        // \param maxListener   The maximum listener.
        // \param webradioId    Identifier of the webradio.
        //
        // \return true if it succeeds, false if it fails.
        **/

        public bool UpdateServer(bool debug, int port, string password, string adminPassword, int maxListener, int webradioId)
        {
            return this.Model.UpdateServer(debug, port, password, adminPassword, maxListener, webradioId);
        }

        /**
        // \fn public bool StartServer(int webradioId, bool debug)
        //
        // \brief Starts a server.
        //
        // \author Simon Menetrey
        // \date 23.05.2014
        //
        // \param webradioId Identifier of the webradio.
        // \param debug      Debug or not.
        //
        // \return true if it succeeds, false if it fails.
        **/

        public bool StartServer(int webradioId, bool debug)
        {
            return this.Model.StartServer(webradioId, debug);
        }

        /**
        // \fn public bool StopServer(int webradioId)
        //
        // \brief Stops a server.
        //
        // \author Simon Menetrey
        // \date 23.05.2014
        //
        // \param webradioId Identifier of the webradio.
        //
        // \return true if it succeeds, false if it fails.
        **/

        public bool StopServer(int webradioId)
        {
            return this.Model.StopServer(webradioId);
        }

        /**
        // \fn public void ShowServerWebInterface(int webradioId)
        //
        // \brief Shows the server web interface.
        //
        // \author Simon Menetrey
        // \date 23.05.2014
        //
        // \param webradioId Identifier of the webradio.
        **/

        public void ShowServerWebInterface(int webradioId)
        {
            this.Model.ShowServerWebInterface(webradioId);
        }

        /**
        // \fn public void ShowServerWebAdmin(int webradioId)
        //
        // \brief Shows the server web admin.
        //
        // \author Simon Menetrey
        // \date 23.05.2014
        //
        // \param webradioId Identifier of the webradio.
        **/

        public void ShowServerWebAdmin(int webradioId)
        {
            this.Model.ShowServerWebAdmin(webradioId);
        }

        /**
        // \fn public bool TranscoderNextTrack(WebradioTranscoder transcoder)
        //
        // \brief Transcoder next track.
        //
        // \author Simon Menetrey
        // \date 23.05.2014
        //
        // \param transcoder The transcoder.
        //
        // \return true if it succeeds, false if it fails.
        **/

        public bool TranscoderNextTrack(WebradioTranscoder transcoder)
        {
            return this.Model.TranscoderNextTrack(transcoder);
        }

        /**
        // \fn public bool ClearHistory(int transcoderId)
        //
        // \brief Clears the transcoder's history.
        //
        // \author Simon Menetrey
        // \date 23.05.2014
        //
        // \param transcoderId Identifier for the transcoder.
        //
        // \return true if it succeeds, false if it fails.
        **/

        public bool ClearHistory(int transcoderId)
        {
            return this.Model.ClearHistory(transcoderId);
        }

        /**
        // \fn public bool GenerateHistory(int webradioId, string transcoderName, int transcoderId, string outputFilename)
        //
        // \brief Generates a history.
        //
        // \author Simon Menetrey
        // \date 23.05.2014
        //
        // \param webradioId     Identifier of the webradio.
        // \param transcoderName Name of the transcoder.
        // \param transcoderId   Identifier of the transcoder.
        // \param outputFilename Filename of the output file.
        //
        // \return true if it succeeds, false if it fails.
        **/

        public bool GenerateHistory(int webradioId, string transcoderName, int transcoderId, string outputFilename)
        {
            return this.Model.GenerateHistory(webradioId, transcoderName, transcoderId, outputFilename);
        }

        /**
        // \fn public bool ModifyWebradioName(string name, int webradioId)
        //
        // \brief Modify webradio's name.
        //
        // \author Simon Menetrey
        // \date 23.05.2014
        //
        // \param name       The name.
        // \param webradioId Identifier of the webradio.
        //
        // \return true if it succeeds, false if it fails.
        **/

        public bool ModifyWebradioName(string name, int webradioId)
        {
            return this.Model.ModifyWebradioName(name, webradioId);
        }

        /**
        // \fn public AudioFile GetAudioFileByFilename(string filename)
        //
        // \brief Gets audio file by filename.
        //
        // \author Simon Menetrey
        // \date 23.05.2014
        //
        // \param filename Filename of the file.
        //
        // \return The audio file by filename.
        **/

        public AudioFile GetAudioFileByFilename(string filename)
        {
            return this.Model.GetAudioFileByFilename(filename);
        }

        /**
        // \fn public bool UpdateAudioFile(AudioFile file)
        //
        // \brief Updates the audio file described by file.
        //
        // \author Simon Menetrey
        // \date 23.05.2014
        //
        // \param file The file.
        //
        // \return true if it succeeds, false if it fails.
        **/

        public bool UpdateAudioFile(AudioFile file)
        {
            return this.Model.UpdateAudioFile(file);
        }

        /**
        // \fn public bool TranscoderCapture(bool active, string device, WebradioTranscoder transcoder,int webradioId)
        //
        // \brief Transcoder capture mode set.
        //
        // \author Simon Menetrey
        // \date 23.05.2014
        //
        // \param active     true to active.
        // \param device     The device's name.
        // \param transcoder The transcoder.
        // \param webradioId Identifier of the webradio.
        //
        // \return true if it succeeds, false if it fails.
        **/

        public bool TranscoderCapture(bool active, string device, WebradioTranscoder transcoder,int webradioId)
        {
            return this.Model.TranscoderCapture(active, device, transcoder, webradioId);
        }

        /**
        // \fn public List<WebradioListener> GetServerListeners(int webradioId)
        //
        // \brief Get server's listeners.
        //
        // \author Simon Menetrey
        // \date 23.05.2014
        //
        // \param webradioId Identifier of the webradio.
        //
        // \return A List&lt;WebradioListener&gt;
        **/

        public List<WebradioListener> GetServerListeners(int webradioId)
        {
            return this.Model.UpdateServerListeners(webradioId);
        }

        /**
        // \fn public bool UpdateServerStats(int webradioId)
        //
        // \brief Updates the server statistics.
        //
        // \author Simon Menetrey
        // \date 23.05.2014
        //
        // \param webradioId Identifier of the webradio.
        //
        // \return true if it succeeds, false if it fails.
        **/

        public bool UpdateServerStats(int webradioId)
        {
            return this.Model.UpdateServerStats(webradioId);
        }

        /**
        // \fn public bool CheckLibrary()
        //
        // \brief Check library integrity.
        //
        // \author Simon Menetrey
        // \date 23.05.2014
        //
        // \return true if it succeeds, false if it fails.
        **/

        public bool CheckLibrary()
        {
            return this.Model.CheckLibrary();
        }

        /**
        // \fn public int GetSimilarViewCount(int webradioId)
        //
        // \brief Gets similar view count.
        //
        // \author Simon Menetrey
        // \date 23.05.2014
        //
        // \param webradioId Identifier of the webradio.
        //
        // \return The similar view count.
        **/

        public int GetSimilarViewCount(int webradioId)
        {
            return this.Model.GetSimiliarViewCount(webradioId);
        }

        #endregion


    }
}
