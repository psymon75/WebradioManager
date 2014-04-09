﻿using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace WebradioManager
{
    public class Bdd
    {
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

        public List<Webradio> LoadWebradios()
        {
            List<Webradio> webradios = new List<Webradio>();
            SQLiteDataReader reader = this.Controls.ExecuteDataReader("SELECT * FROM twebradio");
            while(reader.Read())
            {
                webradios.Add(new Webradio(reader["name"].ToString(), int.Parse(reader["id"].ToString())));
            }
            reader.Close();
            
            foreach(Webradio wr in webradios)
            {
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
                reader = this.Controls.ExecuteDataReader("SELECT * FROM tcalendarevent WHERE calendarid = " + wr.Calendar.Id);
                while(reader.Read())
                {
                    string[] time = reader["starttime"].ToString().Split(':');
                    TimeSpan start = new TimeSpan(int.Parse(time[0]),int.Parse(time[1]),int.Parse(time[2]));
                    time = reader["duration"].ToString().Split(':');
                    TimeSpan duration = new TimeSpan(int.Parse(time[0]),int.Parse(time[1]),int.Parse(time[2]));
                                       
                    wr.Calendar.Events.Add(new CalendarEvent(reader["name"].ToString(),
                        start,
                        duration,
                        int.Parse(reader["repeat"].ToString()),
                        int.Parse(reader["priority"].ToString()),
                        Convert.ToBoolean(reader["shuffle"].ToString()),
                        Convert.ToBoolean(reader["loopatend"].ToString()),
                        int.Parse(reader["playlistid"].ToString())));
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

                
            }

            return webradios;
        }

        public List<AudioFile> LoadLibrary()
        {
            List<AudioFile> audios = new List<AudioFile>();
            //Music
            SQLiteDataReader reader = this.Controls.ExecuteDataReader("SELECT m.filename, m.title, m.artist, m.album, m.year, m.label, m.duration, t.name AS AudioType, g.name AS GenderName FROM tmusic m, taudiotype t, tgender g WHERE m.typeid = t.id AND m.genderid = g.id");
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
            //Playlist for music
            foreach(AudioFile af in audios)
            {
                List<int> idsPlaylist = new List<int>();
                reader = this.Controls.ExecuteDataReader("SELECT playlistid FROM tplaylist_has_music WHERE musicid = " + af.Id.ToString());
                while(reader.Read())
                {
                    idsPlaylist.Add(int.Parse(reader["playlistid"].ToString()));
                }
                reader.Close();
                foreach(int playlistId in idsPlaylist)
                {
                    reader = this.Controls.ExecuteDataReader("SELECT p.id, p.name, p.filename, t.name AS AudioType FROM tplaylist p, taudiotype t WHERE p.id = " + playlistId.ToString() + " AND p.typeid = t.id");
                    while(reader.Read())
                    {
                        if(reader["AudioType"].ToString() == AudioType.Ad.ToString())
                        af.Playlists.Add(new PlaylistAd(int.Parse(reader["id"].ToString()),
                            reader["name"].ToString(),
                            reader["filename"].ToString()));
                        else if(reader["AudioType"].ToString() == AudioType.Music.ToString())
                            af.Playlists.Add(new PlaylistMusic(int.Parse(reader["id"].ToString()),
                            reader["name"].ToString(),
                            reader["filename"].ToString()));
                    }
                    reader.Close();
                }
            }
            //---
            return audios;
        }

        public bool AddWebradio(Webradio webradio)
        {
            //Webradio name must be unique !
            if (this.WebradioExist(webradio.Name))
                return false;
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("name", webradio.Name);
            try
            {
                //Webradio
                this.Controls.Insert("twebradio", data);
                SQLiteDataReader reader = this.Controls.ExecuteDataReader("SELECT id FROM webradio WHERE name = '" + webradio.Name + "'");
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

                return true;
            }
            catch
            {
                return false;
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
            throw new System.NotImplementedException();
        }

        public bool DuplicateWebradio(int id)
        {
            throw new System.NotImplementedException();
        }


        
    }
}
