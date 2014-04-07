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
        private string _filename;

        public Playlist(string name, string filename)
        {
            throw new System.NotImplementedException();
        }

        public string Filename
        {
            get { return _filename; }
            set { _filename = value; }
        }

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
