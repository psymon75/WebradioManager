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

        public Webradio(string name)
        {
            throw new System.NotImplementedException();
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
    }
}
