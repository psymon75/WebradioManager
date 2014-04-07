using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebradioManager
{
    public class Webradio
    {
        private List<Playlist> _playlists;
        private Calendar _calendar;
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public Calendar Calendar
        {
            get { return _calendar; }
            set { _calendar = value; }
        }

        public List<Playlist> Playlists
        {
            get { return _playlists; }
            set { _playlists = value; }
        }
    }
}
