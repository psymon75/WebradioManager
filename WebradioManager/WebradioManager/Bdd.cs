using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WebradioManager
{
    public class Bdd
    {
        public const int ERROR = -1;

        private BddControls _controls;

        public BddControls Controls
        {
            get { return _controls; }
            set { _controls = value; }
        }

        public Bdd()
        {
            this.Controls = new BddControls();
        }

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
                reader = this.Controls.ExecuteDataReader("SELECT tr.id, tr.name AS TransName, tr.bitrate, tr.samplerate, tr.url, tr.ip, tr.port, tr.password, tr.configfilename, tr.logfilename, st.name AS StreamName FROM ttranscoder tr, tstreamtype st WHERE webradioid = " + id.ToString() + " AND tr.streamtypeid = st.id");
                while(reader.Read())
                {
                    WebradioTranscoder trans = null;
                    if(reader["StreamName"].ToString() == StreamType.MP3.ToString())
                        trans = new TranscoderMp3(int.Parse(reader["id"].ToString()), 
                            reader["TransName"].ToString(), 
                            int.Parse(reader["bitrate"].ToString()),
                            int.Parse(reader["samplerate"].ToString()),
                            reader["ip"].ToString(),
                            int.Parse(reader["port"].ToString()),
                            reader["url"].ToString(),
                            reader["password"].ToString(),
                            reader["configfilename"].ToString(),
                            reader["logfilename"].ToString());
                    else if(reader["StreamName"].ToString() == StreamType.AACPlus.ToString())
                        trans = new TranscoderAacPlus(int.Parse(reader["id"].ToString()),
                            reader["TransName"].ToString(),
                            int.Parse(reader["bitrate"].ToString()),
                            int.Parse(reader["samplerate"].ToString()),
                            reader["ip"].ToString(),
                            int.Parse(reader["port"].ToString()),
                            reader["url"].ToString(),
                            reader["password"].ToString(),
                            reader["configfilename"].ToString(),
                            reader["logfilename"].ToString());
                    wr.Transcoders.Add(trans);
                }
                reader.Close();
                //---
                
            }

            return webradios;
        }

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
            //---
            ////Playlist for music
            //foreach(AudioFile af in audios)
            //{
            //    List<int> idsPlaylist = new List<int>();
            //    reader = this.Controls.ExecuteDataReader("SELECT playlistid FROM tplaylist_has_music WHERE musicid = " + af.Id.ToString());
            //    while(reader.Read())
            //    {
            //        idsPlaylist.Add(int.Parse(reader["playlistid"].ToString()));
            //    }
            //    reader.Close();
            //    foreach(int playlistId in idsPlaylist)
            //    {
            //        reader = this.Controls.ExecuteDataReader("SELECT p.id, p.name, p.filename, t.name AS AudioType FROM tplaylist p, taudiotype t WHERE p.id = " + playlistId.ToString() + " AND p.typeid = t.id");
            //        while(reader.Read())
            //        {
            //            if(reader["AudioType"].ToString() == AudioType.Ad.ToString())
            //            af.Playlists.Add(new PlaylistAd(int.Parse(reader["id"].ToString()),
            //                reader["name"].ToString(),
            //                reader["filename"].ToString()));
            //            else if(reader["AudioType"].ToString() == AudioType.Music.ToString())
            //                af.Playlists.Add(new PlaylistMusic(int.Parse(reader["id"].ToString()),
            //                reader["name"].ToString(),
            //                reader["filename"].ToString()));
            //        }
            //        reader.Close();
            //    }
            //}
            //---
            return audios;
        }

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
                //----
                return id;
            }
            catch
            {
                return ERROR;
            }
        }

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

        public bool DuplicateWebradio(int id)
        {
            throw new System.NotImplementedException();
        }

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

        public int CreatePlaylist(Playlist playlist, int webradioid)
        {
            if(this.PlaylistExist(playlist,webradioid))
                return ERROR;

            Dictionary<string,string> data = new Dictionary<string,string>();
            data.Add("name", playlist.Name);
            data.Add("filename", playlist.Filename);
            data.Add("webradioid", webradioid.ToString());
            data.Add("typeid", ((int)playlist.Type).ToString());
            this.Controls.Insert("tplaylist", data);

            SQLiteDataReader reader = this.Controls.ExecuteDataReader("SELECT id FROM tplaylist WHERE name = '" + playlist.Name + "' AND webradioid = " + webradioid.ToString() + " AND typeid = " + ((int)playlist.Type).ToString());
            reader.Read();
            int id = int.Parse(reader["id"].ToString());
            reader.Close();
            return id;
        }

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

        private bool PlaylistExist(Playlist playlist, int webradioid)
        {
            SQLiteDataReader reader = this.Controls.ExecuteDataReader("SELECT COUNT(*) AS Count FROM tplaylist WHERE name = '"+playlist.Name+"' AND webradioid = "+webradioid.ToString()+" AND typeid = " + ((int)playlist.Type).ToString());
            reader.Read();
            bool result = Convert.ToBoolean(int.Parse(reader["Count"].ToString()));
            reader.Close();
            return result;
        }

        public int AddGeneratedPlaylist(Playlist playlist, List<int> audioFilesId, int webradioId)
        {
            int idPlaylist = this.CreatePlaylist(playlist, webradioId);
            if (idPlaylist == ERROR)
                return idPlaylist;
            foreach(int audioFileId in audioFilesId)
                this.AddToPlaylist(audioFileId, idPlaylist);
            return idPlaylist;

        }

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

        public bool EventExist(CalendarEvent aEvent, int calendarId)
        {
            SQLiteDataReader reader = this.Controls.ExecuteDataReader("SELECT COUNT(*) AS Count FROM tcalendarevent WHERE name = '" + aEvent.Name + "' AND calendarid = " + calendarId.ToString());
            reader.Read();
            bool result = (reader["Count"].ToString() == "0")?false:true;
            reader.Close();
            return result;
        }

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
    }
}
