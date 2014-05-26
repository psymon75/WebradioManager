/**
/// \file Bdd.cs
///
/// \brief Implements the bdd class.
**/

using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Net;

namespace WebradioManager
{
    /**
    /// \class Bdd
    ///
    /// \brief A bdd connection.
    ///
    /// \author Simon Menetrey
    /// \date 26.05.2014
    **/

    public class Bdd
    {
        #region Const
        /// \brief The error code.
        public const int ERROR = -1;
        #endregion

        #region Fields
        /// \brief The bdd controls.
        private BddControls _controls;
        #endregion

        #region Properties

        /**
        /// \property public BddControls Controls
        ///
        /// \brief Gets or sets the bdd controls.
        ///
        /// \return The controls.
        **/

        public BddControls Controls
        {
            get { return _controls; }
            set { _controls = value; }
        }
        #endregion

        #region Methods

        /**
        /// \fn public Bdd()
        ///
        /// \brief Default constructor.
        ///
        /// \author Simon Menetrey
        /// \date 26.05.2014
        **/

        public Bdd()
        {
            this.Controls = new BddControls();
        }

        /**
        /// \fn public Dictionary<int,Webradio> LoadWebradios()
        ///
        /// \brief Loads the webradios from db. All webradio's elements are loaded too.
        ///
        /// \author Simon Menetrey
        /// \date 26.05.2014
        ///
        /// \return The webradios list.
        **/

        public Dictionary<int,Webradio> LoadWebradios()
        {
            Dictionary<int, Webradio> webradios = new Dictionary<int, Webradio>();
            SQLiteDataReader reader = this.Controls.ExecuteDataReader("SELECT * FROM twebradio");
            while(reader.Read())
            {
                webradios.Add( int.Parse(reader["id"].ToString()), new Webradio(reader["name"].ToString(), int.Parse(reader["id"].ToString())));
            }
            reader.Close();
            
            foreach(KeyValuePair<int,Webradio> pair in webradios)
            {
                Webradio wr = pair.Value;
                //Server
                int id = wr.Id;
                reader = this.Controls.ExecuteDataReader("SELECT * FROM tserver WHERE webradioid = " + id.ToString());
                reader.Read();
                wr.Server = new WebradioServer(int.Parse(reader["port"].ToString()),
                    reader["logfilename"].ToString(),
                    reader["configfilename"].ToString(),
                    reader["password"].ToString(),
                    reader["adminpassword"].ToString(),
                    int.Parse(reader["maxlistener"].ToString()));
                reader.Close();
                //----

                //Calendar
                reader = this.Controls.ExecuteDataReader("SELECT id, filename FROM tcalendar WHERE webradioid = " + id.ToString());
                reader.Read();
                wr.Calendar = new WebradioCalendar(int.Parse(reader["id"].ToString()), reader["filename"].ToString());
                reader.Close();
                reader = this.Controls.ExecuteDataReader("SELECT ce.id AS EventId, ce.playlistid, ce.starttime, ce.duration, ce.name AS EventName, ce.repeat, ce.priority, ce.shuffle, ce.loopatend, p.name  AS PlaylistName, p.filename AS PlaylistFilename, at.name AS AudiotypeName FROM tcalendarevent ce, tplaylist p, taudiotype at WHERE ce.calendarid = " + wr.Calendar.Id + " AND ce.playlistid = p.id AND p.typeid = at.id");
                while(reader.Read())
                {
                    string[] time = reader["starttime"].ToString().Split(':');
                    TimeSpan start = new TimeSpan(int.Parse(time[0]),int.Parse(time[1]),int.Parse(time[2]));
                    time = reader["duration"].ToString().Split(':');
                    TimeSpan duration = new TimeSpan(int.Parse(time[0]),int.Parse(time[1]),int.Parse(time[2]));
                    Playlist playlist;
                    if (reader["AudiotypeName"].ToString() == AudioType.Music.ToString())
                        playlist = new PlaylistMusic(reader["PlaylistName"].ToString(), reader["PlaylistFilename"].ToString());
                    else
                        playlist = new PlaylistAd(reader["PlaylistName"].ToString(), reader["PlaylistFilename"].ToString());
                    wr.Calendar.Events.Add(new CalendarEvent(int.Parse(reader["EventId"].ToString()), reader["EventName"].ToString(),
                        start,
                        duration,
                        int.Parse(reader["repeat"].ToString()),
                        int.Parse(reader["priority"].ToString()),
                        Convert.ToBoolean(reader["shuffle"].ToString()),
                        Convert.ToBoolean(reader["loopatend"].ToString()),
                        playlist));
                }
                reader.Close();
                //---

                //Playlists
                reader = this.Controls.ExecuteDataReader("SELECT p.id, p.name AS PlaylistName, p.filename, t.name AS AudioType FROM tplaylist p, taudiotype t WHERE p.typeid = t.id AND webradioid = " + id.ToString());
                while(reader.Read())
                {
                    Playlist p = null;
                    if(reader["AudioType"].ToString() == AudioType.Ad.ToString())
                        p = new PlaylistAd(int.Parse(reader["id"].ToString()), reader["PlaylistName"].ToString(), reader["filename"].ToString());
                    else if(reader["AudioType"].ToString() == AudioType.Music.ToString())
                        p = new PlaylistMusic(int.Parse(reader["id"].ToString()), reader["PlaylistName"].ToString(), reader["filename"].ToString());
                    wr.Playlists.Add(p);
                }
                reader.Close();
                foreach(Playlist playlist in wr.Playlists)
                {
                    reader = this.Controls.ExecuteDataReader("SELECT m.filename FROM tmusic m, tplaylist_has_music pm WHERE pm.playlistid = " + playlist.Id + " AND m.id = pm.musicid");
                    while(reader.Read())
                    {
                        playlist.AudioFileList.Add(reader["filename"].ToString());
                    }
                }
                reader.Close();
                //Transcoders
                reader = this.Controls.ExecuteDataReader("SELECT c.filename AS CalendarFilename, tr.id, tr.name AS TransName, tr.bitrate, tr.samplerate, tr.url, tr.ip, tr.port, tr.adminport, tr.password, tr.configfilename, tr.logfilename, st.name AS StreamName FROM tcalendar c, ttranscoder tr, tstreamtype st WHERE tr.webradioid = " + id.ToString() + " AND tr.streamtypeid = st.id AND c.webradioid = " + id.ToString());
                while(reader.Read())
                {
                    WebradioTranscoder trans = null;
                    if(reader["StreamName"].ToString() == StreamType.MP3.ToString())
                        trans = new TranscoderMp3(int.Parse(reader["id"].ToString()), 
                            reader["TransName"].ToString(), 
                            int.Parse(reader["bitrate"].ToString()),
                            int.Parse(reader["samplerate"].ToString()),
                            IPAddress.Parse(reader["ip"].ToString()),
                            int.Parse(reader["port"].ToString()),
                            int.Parse(reader["adminport"].ToString()),
                            reader["url"].ToString(),
                            reader["password"].ToString(),
                            reader["configfilename"].ToString(),
                            reader["logfilename"].ToString());
                    else
                        trans = new TranscoderAacPlus(int.Parse(reader["id"].ToString()),
                            reader["TransName"].ToString(),
                            int.Parse(reader["bitrate"].ToString()),
                            int.Parse(reader["samplerate"].ToString()),
                            IPAddress.Parse(reader["ip"].ToString()),
                            int.Parse(reader["port"].ToString()),
                            int.Parse(reader["adminport"].ToString()),
                            reader["url"].ToString(),
                            reader["password"].ToString(),
                            reader["configfilename"].ToString(),
                            reader["logfilename"].ToString());
                    trans.CalendarFile = reader["CalendarFilename"].ToString();
                    wr.Transcoders.Add(trans);
                }
                reader.Close();
                //---
                
            }

            return webradios;
        }

        /**
        /// \fn public List<AudioFile> LoadLibrary()
        ///
        /// \brief Loads the library from db.
        ///
        /// \author Simon Menetrey
        /// \date 26.05.2014
        ///
        /// \return The library list.
        **/

        public List<AudioFile> LoadLibrary()
        {
            List<AudioFile> audios = new List<AudioFile>();
            //Music
            SQLiteDataReader reader = this.Controls.ExecuteDataReader("SELECT m.id, m.filename, m.title, m.artist, m.album, m.year, m.label, m.duration, t.name AS AudioType, g.name AS GenderName FROM tmusic m, taudiotype t, tgender g WHERE m.typeid = t.id AND m.genderid = g.id");
            while (reader.Read())
            {
                string[] time = reader["duration"].ToString().Split(':');
                TimeSpan duration = new TimeSpan(int.Parse(time[0]), int.Parse(time[1]), int.Parse(time[2]));
                AudioFile af = null;
                if (reader["AudioType"].ToString() == AudioType.Ad.ToString())
                    af = new Ad(int.Parse(reader["id"].ToString()),
                        reader["filename"].ToString(),
                        reader["title"].ToString(),
                        reader["artist"].ToString(),
                        reader["album"].ToString(),
                        int.Parse(reader["year"].ToString()),
                        reader["label"].ToString(),
                        duration,
                        reader["GenderName"].ToString());
                else if (reader["AudioType"].ToString() == AudioType.Music.ToString())
                    af = new Music(int.Parse(reader["id"].ToString()),
                        reader["filename"].ToString(),
                        reader["title"].ToString(),
                        reader["artist"].ToString(),
                        reader["album"].ToString(),
                        int.Parse(reader["year"].ToString()),
                        reader["label"].ToString(),
                        duration,
                        reader["GenderName"].ToString());

                audios.Add(af);
            }
            reader.Close();
            
            return audios;
        }

        /**
        /// \fn public int AddWebradio(Webradio webradio)
        ///
        /// \brief Adds a webradio to db. Create server and calendar entries for this new webradio.
        ///
        /// \author Simon Menetrey
        /// \date 26.05.2014
        ///
        /// \param webradio The webradio.
        ///
        /// \return Id of created webradio. or ERROR.
        **/

        public int AddWebradio(Webradio webradio)
        {
            //Webradio name must be unique !
            if (this.WebradioExist(webradio.Name))
                return ERROR;
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("name", webradio.Name);
            try
            {
                //Webradio
                this.Controls.Insert("twebradio", data);
                SQLiteDataReader reader = this.Controls.ExecuteDataReader("SELECT id FROM twebradio WHERE name = '" + webradio.Name + "'");
                reader.Read();
                int id = int.Parse(reader["id"].ToString());
                reader.Close();
                data.Clear();
                //Server creation
                data.Add("webradioid", id.ToString());
                data.Add("port", webradio.Server.Port.ToString());
                data.Add("logfilename", webradio.Server.LogFilename);
                data.Add("configfilename", webradio.Server.ConfigFilename);
                data.Add("password", webradio.Server.Password);
                data.Add("adminpassword", webradio.Server.AdminPassword);
                data.Add("maxlistener", webradio.Server.MaxListener.ToString());
                this.Controls.Insert("tserver", data);
                data.Clear();
                //----
                //Calendar creation
                data.Add("filename", webradio.Calendar.Filename);
                data.Add("webradioid", id.ToString());
                this.Controls.Insert("tcalendar", data);
                data.Clear();
                reader = this.Controls.ExecuteDataReader("SELECT id FROM tcalendar WHERE webradioid = " + id.ToString());
                reader.Read();
                webradio.Calendar.Id = int.Parse(reader["id"].ToString());
                reader.Close();
                //----
                return id;
            }
            catch
            {
                return ERROR;
            }
        }

        /**
        /// \fn public bool WebradioExist(string name)
        ///
        /// \brief Webradio exists in the db.
        ///
        /// \author Simon Menetrey
        /// \date 26.05.2014
        ///
        /// \param name The webradio's name.
        ///
        /// \return true if it exists, false if it not exists.
        **/

        public bool WebradioExist(string name)
        {
            SQLiteDataReader reader = this.Controls.ExecuteDataReader("SELECT COUNT(*) AS Count FROM twebradio WHERE name = '"+ name +"'");
            reader.Read();
            if (int.Parse(reader["Count"].ToString()) == 0)
            {
                reader.Close();
                return false;
            }
            else
            {
                reader.Close();
                return true;
            }
                
            
        }

        /**
        /// \fn public bool DeleteWebradio(int id)
        ///
        /// \brief Deletes the webradio described by ID.
        ///
        /// \author Simon Menetrey
        /// \date 26.05.2014
        ///
        /// \param id The identifier.
        ///
        /// \return true if it succeeds, false if it fails.
        **/

        public bool DeleteWebradio(int id)
        {
            try
            {
                this.Controls.Delete("twebradio", "id = " + id.ToString());
                return true;
            }
            catch
            {
                return false;
            }
        }

        /**
        /// \fn public List<string> GetGenders()
        ///
        /// \brief Gets genders list.
        ///
        /// \author Simon Menetrey
        /// \date 26.05.2014
        ///
        /// \return The genders list.
        **/

        public List<string> GetGenders()
        {
            List<string> genders = new List<string>();
            SQLiteDataReader reader = this.Controls.ExecuteDataReader("SELECT * FROM tgender");
            while(reader.Read())
            {
                genders.Add(reader["name"].ToString());
            }
            reader.Close();
            return genders;
        }

        /**
        /// \fn public int GetGenderId(string gender)
        ///
        /// \brief Gets gender identifier.
        ///
        /// \author Simon Menetrey
        /// \date 26.05.2014
        ///
        /// \param gender The gender's name.
        ///
        /// \return The gender identifier.
        **/

        public int GetGenderId(string gender)
        {
            SQLiteDataReader reader = this.Controls.ExecuteDataReader("SELECT id FROM tgender WHERE name = '"+gender+"'");
            reader.Read();
            int id;
            if (reader.HasRows)
                id = int.Parse(reader["id"].ToString());
            else
                id = ERROR;
            reader.Close();
            return id;
        }

        /**
        /// \fn public int AddGender(string gender)
        ///
        /// \brief Adds a gender.
        ///
        /// \author Simon Menetrey
        /// \date 26.05.2014
        ///
        /// \param gender The gender's name.
        ///
        /// \return The new gender's id.
        **/

        public int AddGender(string gender)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("name", gender);
            this.Controls.Insert("tgender", data);

            SQLiteDataReader reader = this.Controls.ExecuteDataReader("SELECT id FROM tgender WHERE name = '"+ gender +"'");
            reader.Read();
            int id = int.Parse(reader["id"].ToString());
            reader.Close();
            return id;
        }

        /**
        /// \fn public int AddAudioFile(AudioFile file)
        ///
        /// \brief Adds an audio file.
        ///
        /// \author Simon Menetrey
        /// \date 26.05.2014
        ///
        /// \param file The audiofile.
        ///
        /// \return The new audio file's id.
        **/

        public int AddAudioFile(AudioFile file)
        {
            if(this.AudioFileExist(file.Filename))
                return ERROR;

            int genderId = this.GetGenderId(file.Gender);
            //If return error, gender doesn't exist in DB, so add it
            if (genderId == ERROR)
                //Get the new id
                genderId = AddGender(file.Gender);

            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("filename", file.Filename.Replace('\'', ' '));
            data.Add("title", file.Title);
            data.Add("artist", file.Artist);
            data.Add("album", file.Album);
            data.Add("year", file.Year.ToString());
            data.Add("label", file.Label);
            data.Add("duration", file.Duration.ToString(@"hh\:mm\:ss"));
            data.Add("genderid", genderId.ToString());
            data.Add("typeid", ((int)file.Type).ToString());
            this.Controls.Insert("tmusic", data);

            //Get the new id
            SQLiteDataReader reader = this.Controls.ExecuteDataReader("SELECT id FROM tmusic WHERE filename = '" + file.Filename.Replace('\'', ' ') + "'");
            reader.Read();
            int id = int.Parse(reader["id"].ToString());
            reader.Close();
            return id;
        }

        /**
        /// \fn public bool UpdateAudioFile(AudioFile file)
        ///
        /// \brief Updates the audio file's values
        ///
        /// \author Simon Menetrey
        /// \date 26.05.2014
        ///
        /// \param file The audio file.
        ///
        /// \return true if it succeeds, false if it fails.
        **/

        public bool UpdateAudioFile(AudioFile file)
        {
            try
            {
                int genderId = this.GetGenderId(file.Gender);
                //If return error, gender doesn't exist in DB, so add it
                if (genderId == ERROR)
                    //Get the new id
                    genderId = AddGender(file.Gender);
                Dictionary<string, string> data = new Dictionary<string, string>();
                data.Add("title", file.Title);
                data.Add("artist", file.Artist);
                data.Add("album", file.Album);
                data.Add("year", file.Year.ToString());
                data.Add("label", file.Label);
                data.Add("genderid", genderId.ToString());
                data.Add("typeid", ((int)file.Type).ToString());
                this.Controls.Update("tmusic", data, "id = " + file.Id);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /**
        /// \fn public bool AudioFileExist(string filename)
        ///
        /// \brief Audio file exists.
        ///
        /// \author Simon Menetrey
        /// \date 26.05.2014
        ///
        /// \param filename Filename of the audio file.
        ///
        /// \return true if it exists, false if it doesn't exist.
        **/

        public bool AudioFileExist(string filename)
        {
            SQLiteDataReader reader = this.Controls.ExecuteDataReader("SELECT COUNT(*) AS Count FROM tmusic WHERE filename = '" + filename.Replace('\'', ' ') + "'");
            reader.Read();
            if (reader["Count"].ToString() == "0")
            {
                reader.Close();
                return false;
            }
            else
            {
                reader.Close();
                return true;
            }

        }

        /**
        /// \fn public bool DeleteAudioFile(int id)
        ///
        /// \brief Deletes the audio file described by ID.
        ///
        /// \author Simon Menetrey
        /// \date 26.05.2014
        ///
        /// \param id The identifier.
        ///
        /// \return true if it succeeds, false if it fails.
        **/

        public bool DeleteAudioFile(int id)
        {
            try
            {
                this.Controls.Delete("tmusic", "id = " + id.ToString());
                //this.Controls.Delete("tplaylist_has_music", "idmusic = " + id.ToString());
                return true;
            }
            catch
            {
                return false;
            }
        }

        /**
        /// \fn public int CreatePlaylist(Playlist playlist, int webradioid)
        ///
        /// \brief Creates a playlist.
        ///
        /// \author Simon Menetrey
        /// \date 26.05.2014
        ///
        /// \param playlist   The playlist.
        /// \param webradioid The webradio's id.
        ///
        /// \return The new playlist's id or error code.
        **/

        public int CreatePlaylist(Playlist playlist, int webradioId)
        {
            if(this.PlaylistExist(playlist,webradioId))
                return ERROR;

            Dictionary<string,string> data = new Dictionary<string,string>();
            data.Add("name", playlist.Name);
            data.Add("filename", playlist.Filename);
            data.Add("webradioid", webradioId.ToString());
            data.Add("typeid", ((int)playlist.Type).ToString());
            this.Controls.Insert("tplaylist", data);

            SQLiteDataReader reader = this.Controls.ExecuteDataReader("SELECT id FROM tplaylist WHERE name = '" + playlist.Name + "' AND webradioid = " + webradioId.ToString() + " AND typeid = " + ((int)playlist.Type).ToString());
            reader.Read();
            int id = int.Parse(reader["id"].ToString());
            reader.Close();
            return id;
        }

        /**
        /// \fn public bool DeletePlaylist(int id)
        ///
        /// \brief Deletes the playlist described by ID.
        ///
        /// \author Simon Menetrey
        /// \date 26.05.2014
        ///
        /// \param id The identifier.
        ///
        /// \return true if it succeeds, false if it fails.
        **/

        public bool DeletePlaylist(int id)
        {
            try
            {
                this.Controls.Delete("tplaylist", "id = " + id.ToString());
                return true;
            }
            catch
            {
                return false;
            }
        }

        /**
        /// \fn public bool AddToPlaylist(int idAudioFile, int idPlaylist)
        ///
        /// \brief Adds an audio file to a playlist.
        ///
        /// \author Simon Menetrey
        /// \date 26.05.2014
        ///
        /// \param idAudioFile The identifier audio file.
        /// \param idPlaylist  The identifier playlist.
        ///
        /// \return true if it succeeds, false if it fails.
        **/

        public bool AddToPlaylist(int idAudioFile, int idPlaylist)
        {
            try
            {
                Dictionary<string,string> data = new Dictionary<string,string>();
                data.Add("playlistid", idPlaylist.ToString());
                data.Add("musicid", idAudioFile.ToString());
                this.Controls.Insert("tplaylist_has_music", data);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /**
        /// \fn public bool RemoveFromPlaylist(int idAudioFile, int idPlaylist)
        ///
        /// \brief Removes an audio file from a playlist.
        ///
        /// \author Simon Menetrey
        /// \date 26.05.2014
        ///
        /// \param idAudioFile The identifier audio file.
        /// \param idPlaylist  The identifier playlist.
        ///
        /// \return true if it succeeds, false if it fails.
        **/

        public bool RemoveFromPlaylist(int idAudioFile, int idPlaylist)
        {
            try
            {
                this.Controls.Delete("tplaylist_has_music", "musicid = " + idAudioFile.ToString() + " AND playlistid = " + idPlaylist.ToString());
                return true;
            }
            catch
            {
                return false;
            }
        }

        /**
        /// \fn private bool PlaylistExist(Playlist playlist, int webradioid)
        ///
        /// \brief Playlist exists in the db.
        ///
        /// \author Simon Menetrey
        /// \date 26.05.2014
        ///
        /// \param playlist   The playlist.
        /// \param webradioid The webradio's id.
        ///
        /// \return true if it exists, false if it doesn't exist.
        **/

        private bool PlaylistExist(Playlist playlist, int webradioId)
        {
            SQLiteDataReader reader = this.Controls.ExecuteDataReader("SELECT COUNT(*) AS Count FROM tplaylist WHERE name = '"+playlist.Name+"' AND webradioid = "+webradioId.ToString()+" AND typeid = " + ((int)playlist.Type).ToString());
            reader.Read();
            bool result = Convert.ToBoolean(int.Parse(reader["Count"].ToString()));
            reader.Close();
            return result;
        }

        /**
        /// \fn public int AddGeneratedPlaylist(Playlist playlist, List<int> audioFilesId, int webradioId)
        ///
        /// \brief Adds a generated playlist.
        ///
        /// \author Simon Menetrey
        /// \date 26.05.2014
        ///
        /// \param playlist     The playlist.
        /// \param audioFilesId Identifier for the audio files.
        /// \param webradioId   Identifier for the webradio.
        ///
        /// \return AThe new generated playlist's id.
        **/

        public int AddGeneratedPlaylist(Playlist playlist, List<int> audioFilesId, int webradioId)
        {
            int idPlaylist = this.CreatePlaylist(playlist, webradioId);
            if (idPlaylist == ERROR)
                return idPlaylist;
            foreach(int audioFileId in audioFilesId)
                this.AddToPlaylist(audioFileId, idPlaylist);
            return idPlaylist;

        }

        /**
        /// \fn public int AddEvent(CalendarEvent newEvent, int calendarId, int playlistId)
        ///
        /// \brief Adds an event to a calendar.
        ///
        /// \author Simon Menetrey
        /// \date 26.05.2014
        ///
        /// \param newEvent   The new event.
        /// \param calendarId Identifier for the calendar.
        /// \param playlistId Identifier for the playlist.
        ///
        /// \return The new event's id.
        **/

        public int AddEvent(CalendarEvent newEvent, int calendarId, int playlistId)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("name", newEvent.Name);
            data.Add("starttime", newEvent.StartTime.ToString());
            data.Add("duration", newEvent.Duration.ToString());
            data.Add("repeat", newEvent.Repeat.ToString());
            data.Add("priority", newEvent.Priority.ToString());
            data.Add("shuffle", (newEvent.Shuffle) ? "TRUE" : "FALSE");
            data.Add("loopatend", "TRUE");
            data.Add("calendarid", calendarId.ToString());
            data.Add("playlistid", playlistId.ToString());

            this.Controls.Insert("tcalendarevent", data);

            SQLiteDataReader reader = this.Controls.ExecuteDataReader("SELECT id FROM tcalendarevent WHERE name = '"+ newEvent.Name +"' AND calendarid = " + calendarId.ToString());
            reader.Read();
            int id = int.Parse(reader["id"].ToString());
            reader.Close();
            return id;
        }

        /**
        /// \fn public bool EventExist(CalendarEvent aEvent, int calendarId)
        ///
        /// \brief Event exists in the db.
        ///
        /// \author Simon Menetrey
        /// \date 26.05.2014
        ///
        /// \param aEvent     The event.
        /// \param calendarId Identifier for the calendar.
        ///
        /// \return true if it exists, false if it doesn't exists.
        **/

        public bool EventExist(CalendarEvent aEvent, int calendarId)
        {
            SQLiteDataReader reader = this.Controls.ExecuteDataReader("SELECT COUNT(*) AS Count FROM tcalendarevent WHERE name = '" + aEvent.Name + "' AND calendarid = " + calendarId.ToString());
            reader.Read();
            bool result = (reader["Count"].ToString() == "0")?false:true;
            reader.Close();
            return result;
        }

        /**
        /// \fn public bool UpdateEvent(CalendarEvent aEvent)
        ///
        /// \brief Updates the event's value.
        ///
        /// \author Simon Menetrey
        /// \date 26.05.2014
        ///
        /// \param aEvent The event.
        ///
        /// \return true if it succeeds, false if it fails.
        **/

        public bool UpdateEvent(CalendarEvent aEvent)
        {
            Dictionary<string,string> data = new Dictionary<string,string>();
            //Only change starttime and duration for the moment
            data.Add("starttime", aEvent.StartTime.ToString());
            data.Add("duration", aEvent.Duration.ToString());
            data.Add("repeat", aEvent.Repeat.ToString());
            try
            {
                this.Controls.Update("tcalendarevent", data, "id = " + aEvent.Id);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /**
        /// \fn public bool DeleteEvent(CalendarEvent aEvent)
        ///
        /// \brief Deletes the event described by aEvent.
        ///
        /// \author Simon Menetrey
        /// \date 26.05.2014
        ///
        /// \param aEvent The event.
        ///
        /// \return true if it succeeds, false if it fails.
        **/

        public bool DeleteEvent(CalendarEvent aEvent)
        {
            try
            {
                this.Controls.Delete("tcalendarevent", "id = " + aEvent.Id.ToString());
                return true;
            }
            catch
            {
                return false;
            }
        }

        /**
        /// \fn public bool TranscoderExist(string name, int webradioId)
        ///
        /// \brief Transcoder exists.
        ///
        /// \author Simon Menetrey
        /// \date 26.05.2014
        ///
        /// \param name       The name.
        /// \param webradioId Identifier for the webradio.
        ///
        /// \return true if it exists, false if it doesn't exist.
        **/

        public bool TranscoderExist(string name, int webradioId)
        {
            SQLiteDataReader reader = this.Controls.ExecuteDataReader("SELECT COUNT(*) AS Count FROM ttranscoder WHERE webradioid = " + webradioId.ToString() + " AND name = '"+ name +"'");
            reader.Read();
            if (reader["Count"].ToString() == "0")
            {
                reader.Close();
                return false;
            }
            else
            {
                reader.Close();
                return true;
            }
        }

        /**
        /// \fn public int AddTranscoder(WebradioTranscoder transcoder, int webradioId)
        ///
        /// \brief Adds a transcoder to a webradio.
        ///
        /// \author Simon Menetrey
        /// \date 26.05.2014
        ///
        /// \param transcoder The transcoder.
        /// \param webradioId Identifier for the webradio.
        ///
        /// \return The new transcoder's id.
        **/

        public int AddTranscoder(WebradioTranscoder transcoder, int webradioId)
        {
            if (this.TranscoderExist(transcoder.Name, webradioId))
                return ERROR;
            try
            {
                Dictionary<string, string> data = new Dictionary<string, string>();
                data.Add("webradioid", webradioId.ToString());
                data.Add("streamtypeid", ((int)transcoder.StreamType).ToString());
                data.Add("bitrate", transcoder.Birate.ToString());
                data.Add("samplerate", transcoder.SampleRate.ToString());
                data.Add("name", transcoder.Name);
                data.Add("url", transcoder.Url);
                data.Add("port", transcoder.Port.ToString());
                data.Add("adminport", transcoder.AdminPort.ToString());
                data.Add("ip", transcoder.Ip.ToString());
                data.Add("password", transcoder.Password);
                data.Add("configfilename", transcoder.ConfigFilename);
                data.Add("logfilename", transcoder.LogFilename);
                this.Controls.Insert("ttranscoder", data);

                SQLiteDataReader reader = this.Controls.ExecuteDataReader("SELECT id FROM ttranscoder WHERE webradioid = " + webradioId.ToString() + " AND name = '" + transcoder.Name + "'");
                reader.Read();
                int id = int.Parse(reader["id"].ToString());
                reader.Close();
                data.Clear();
                data.Add("configfilename", transcoder.ConfigFilename + id.ToString() + ".config");
                data.Add("logfilename", transcoder.LogFilename + "/" + id.ToString() + ".log");
                this.Controls.Update("ttranscoder", data, "webradioid = " + webradioId.ToString() + " AND name = '" + transcoder.Name + "'");
                return id;
            }
            catch
            {
                return ERROR;
            }
            
        }

        /**
        /// \fn public bool DeleteTranscoder(int transcoderId)
        ///
        /// \brief Deletes the transcoder described by transcoder's id.
        ///
        /// \author Simon Menetrey
        /// \date 26.05.2014
        ///
        /// \param transcoderId Identifier for the transcoder.
        ///
        /// \return true if it succeeds, false if it fails.
        **/

        public bool DeleteTranscoder(int transcoderId)
        {
            try
            {
                this.Controls.Delete("ttranscoder", "id = " + transcoderId.ToString());
                return true;
            }
            catch
            {
                return false;
            }
        }

        /**
        /// \fn public bool UpdateTranscoder(WebradioTranscoder transcoder)
        ///
        /// \brief Updates the transcoder with transcoder param's values.
        ///
        /// \author Simon Menetrey
        /// \date 26.05.2014
        ///
        /// \param transcoder The transcoder.
        ///
        /// \return true if it succeeds, false if it fails.
        **/

        public bool UpdateTranscoder(WebradioTranscoder transcoder)
        {
            try
            {
                Dictionary<string, string> data = new Dictionary<string, string>();
                data.Add("streamtypeid", ((int)transcoder.StreamType).ToString());
                data.Add("bitrate", transcoder.Birate.ToString());
                data.Add("samplerate", transcoder.SampleRate.ToString());
                data.Add("name", transcoder.Name);
                data.Add("url", transcoder.Url);
                data.Add("port", transcoder.Port.ToString());
                data.Add("adminport", transcoder.AdminPort.ToString());
                data.Add("ip", transcoder.Ip.ToString());
                data.Add("password", transcoder.Password);

                this.Controls.Update("ttranscoder", data, "id = " + transcoder.Id.ToString());
                return true;
            }
            catch
            {
                return false;
            }
        }

        /**
        /// \fn public bool UpdateServer(int port, string password, string adminPassword, int maxListener, int webradioId)
        ///
        /// \brief Updates the server configuration.
        ///
        /// \author Simon Menetrey
        /// \date 26.05.2014
        ///
        /// \param port          The port.
        /// \param password      The password.
        /// \param adminPassword The admin password.
        /// \param maxListener   The number of maximum listener.
        /// \param webradioId    Identifier for the webradio.
        ///
        /// \return true if it succeeds, false if it fails.
        **/

        public bool UpdateServer(int port, string password, string adminPassword, int maxListener, int webradioId)
        {
            try
            {
                Dictionary<string,string> data = new Dictionary<string,string>();
                data.Add("port", port.ToString());
                data.Add("password", password);
                data.Add("adminpassword", adminPassword);
                data.Add("maxlistener", maxListener.ToString());
                this.Controls.Update("tserver", data, "webradioid = " + webradioId.ToString());
                return true;
            }
            catch
            {
                return false;
            }
        }

        /**
        /// \fn public bool AddToHistory(int transcoderId, DateTime date, string filename)
        ///
        /// \brief Adds audiofile's filename to the transcoder's history.
        ///
        /// \author Simon Menetrey
        /// \date 26.05.2014
        ///
        /// \param transcoderId Identifier for the transcoder.
        /// \param date         The date Date/Time.
        /// \param filename     Filename of the audiofile.
        ///
        /// \return true if it succeeds, false if it fails.
        **/

        public bool AddToHistory(int transcoderId, DateTime date, string filename)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("date", date.ToString());
            data.Add("filename", filename);
            data.Add("transcoderid", transcoderId.ToString());

            if (this.Controls.Insert("thistory", data))
                return true;
            else
                return false;

        }

        /**
        /// \fn public Dictionary<string,string> GetHistory(int transcoderId)
        ///
        /// \brief Gets a transcoder's history.
        ///
        /// \author Simon Menetrey
        /// \date 26.05.2014
        ///
        /// \param transcoderId Identifier for the transcoder.
        ///
        /// \return The history (date,filename).
        **/

        public Dictionary<string,string> GetHistory(int transcoderId)
        {
            Dictionary<string,string> filenames = new Dictionary<string,string>();
            SQLiteDataReader reader = this.Controls.ExecuteDataReader("SELECT date, filename FROM thistory WHERE transcoderid = " + transcoderId.ToString());
            while(reader.Read())
            {
                filenames.Add(reader["date"].ToString(), reader["filename"].ToString());
            }
            reader.Close();
            return filenames;
        }

        /**
        /// \fn public bool ClearHistory(int transcoderId)
        ///
        /// \brief Clears the transcoder's history.
        ///
        /// \author Simon Menetrey
        /// \date 26.05.2014
        ///
        /// \param transcoderId Identifier for the transcoder.
        ///
        /// \return true if it succeeds, false if it fails.
        **/

        public bool ClearHistory(int transcoderId)
        {
            try
            {
                this.Controls.Delete("thistory", "transcoderid = " + transcoderId.ToString());
                return true;
            }
            catch
            {
                return false;
            }
        }

        /**
        /// \fn public bool ModifyWebradioName(string name,int webradioId)
        ///
        /// \brief Modify webradio's name.
        ///
        /// \author Simon Menetrey
        /// \date 26.05.2014
        ///
        /// \param name       The name.
        /// \param webradioId Identifier for the webradio.
        ///
        /// \return true if it succeeds, false if it fails or already exist.
        **/

        public bool ModifyWebradioName(string name,int webradioId)
        {
            if (this.WebradioExist(name))
                return false;
            try
            {
                Dictionary<string,string> data = new Dictionary<string,string>();
                data.Add("name", name);
                this.Controls.Update("twebradio", data, "id = " + webradioId);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /**
        /// \fn public bool UpdateFilenames(string oldName, string newName, Webradio webradio)
        ///
        /// \brief Updates the filenames with new webradio's name.
        ///
        /// \author Simon Menetrey
        /// \date 26.05.2014
        ///
        /// \param oldName  Webradio's old name.
        /// \param newName  Webradio's new name.
        /// \param webradio The webradio.
        ///
        /// \return true if it succeeds, false if it fails.
        **/

        public bool UpdateFilenames(string oldName, string newName, Webradio webradio)
        {
            try
            {
                Dictionary<string, string> data = new Dictionary<string, string>();
                foreach (WebradioTranscoder transcoder in webradio.Transcoders)
                {
                    data.Clear();
                    data.Add("configfilename", transcoder.ConfigFilename.Replace(oldName, newName));
                    data.Add("logfilename", transcoder.LogFilename.Replace(oldName, newName));
                    this.Controls.Update("ttranscoder", data, "webradioid = " + webradio.Id);
                }
                data.Clear();
                data.Add("configfilename", webradio.Server.ConfigFilename.Replace(oldName, newName));
                data.Add("logfilename", webradio.Server.LogFilename.Replace(oldName, newName));
                this.Controls.Update("tserver", data, "webradioid = " + webradio.Id);
                foreach (Playlist playlist in webradio.Playlists)
                {
                    data.Clear();
                    data.Add("filename", playlist.Filename.Replace(oldName, newName));
                    this.Controls.Update("tplaylist", data, "webradioid = " + webradio.Id);
                }
                data.Clear();
                data.Add("filename", webradio.Calendar.Filename.Replace(oldName, newName));
                this.Controls.Update("tcalendar", data, "webradioid = " + webradio.Id);
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
