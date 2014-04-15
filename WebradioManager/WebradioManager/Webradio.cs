using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebradioManager
{
    public class Webradio : ICloneable
    {
        private List<Playlist> _playlists;
        private WebradioCalendar _calendar;
        private string _name;
        private WebradioServer _server;
        private int _id;
        private List<WebradioTranscoder> _transcoders;

        #region Properties
        public List<WebradioTranscoder> Transcoders
        {
            get { return _transcoders; }
            set { _transcoders = value; }
        }

        public WebradioServer Server
        {
            get { return _server; }
            set { _server = value; }
        } 

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public WebradioCalendar Calendar
        {
            get { return _calendar; }
            set { _calendar = value; }
        }

        public List<Playlist> Playlists
        {
            get { return _playlists; }
            set { _playlists = value; }
        }


        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        #endregion

        public Webradio(string name, int id)
        {
            this.Name = name;
            this.Id = id;
            this.Playlists = new List<Playlist>();
            this.Transcoders = new List<WebradioTranscoder>();
        }

        public Webradio(string name)
        {
            this.Playlists = new List<Playlist>();
            this.Transcoders = new List<WebradioTranscoder>();
            this.Name = name;
        }

        public void GenerateConfigFiles()
        {
            foreach (Playlist playlist in this.Playlists)
            {
                playlist.GenerateConfigFile();
            }
            this.Calendar.GenerateConfigFile();
            this.Server.GenerateConfigFile();
            foreach (WebradioTranscoder transcoder in this.Transcoders)
            {
                transcoder.GenerateConfigFile();
            }
        }

        public object Clone()
        {
            //TODO
            return new Webradio("lol");
        }

        public override string ToString()
        {
            return this.Name + " | ID = " + this.Id.ToString();
        }
    }
}
