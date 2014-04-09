using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebradioManager
{
    public class Webradio
    {
        private List<Playlist> _playlists;
        private WebradioCalendar _calendar;
        private string _name;
        private WebradioServer _server;
        private int _id;

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

        public Webradio(string name, int id)
        {
            this.Name = name;
            this.Id = id;
            this.Playlists = new List<Playlist>();
        }

        public Webradio(string name)
        {
            this.Playlists = new List<Playlist>();
            this.Name = name;
        }
    }
}
