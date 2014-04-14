﻿using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WebradioManager
{
    public class Bdd
    {
        const int ERROR = -1;

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
                    reader["adminpassword"].ToString());
                reader.Close();
                //----

                //Calendar
                reader = this.Controls.ExecuteDataReader("SELECT id, filename FROM tcalendar WHERE webradioid = " + id.ToString());
                reader.Read();
                wr.Calendar = new WebradioCalendar(int.Parse(reader["id"].ToString()), reader["filename"].ToString());
                reader.Close();
                reader = this.Controls.ExecuteDataReader("SELECT ce.starttime, ce.duration, ce.name AS EventName, ce.repeat, ce.priority, ce.shuffle, ce.loopatend, p.name AS PlaylistName FROM tcalendarevent ce, tplaylist p WHERE ce.calendarid = " + wr.Calendar.Id + " AND ce.playlistid = p.id");
                while(reader.Read())
                {
                    string[] time = reader["starttime"].ToString().Split(':');
                    TimeSpan start = new TimeSpan(int.Parse(time[0]),int.Parse(time[1]),int.Parse(time[2]));
                    time = reader["duration"].ToString().Split(':');
                    TimeSpan duration = new TimeSpan(int.Parse(time[0]),int.Parse(time[1]),int.Parse(time[2]));
                                       
                    wr.Calendar.Events.Add(new CalendarEvent(reader["EventName"].ToString(),
                        start,
                        duration,
                        int.Parse(reader["repeat"].ToString()),
                        int.Parse(reader["priority"].ToString()),
                        Convert.ToBoolean(reader["shuffle"].ToString()),
                        Convert.ToBoolean(reader["loopatend"].ToString()),
                        reader["PlaylistName"].ToString()));
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


        
    }
}
