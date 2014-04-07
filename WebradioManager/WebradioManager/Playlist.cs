using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebradioManager
{
    public class Playlist
    {
        private List<Music> _musics;
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public List<Music> Musics
        {
            get { return _musics; }
            set { _musics = value; }
        }
    }
}
