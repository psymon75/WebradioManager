using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebradioManager
{
    public abstract class Playlist
    {
        private string _name;
        private int _id;
        private string _filename;
        private AudioType _type;

        #region Properties

        public AudioType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
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
        #endregion

        public Playlist(int id, string name, string filename, AudioType type)
        {
            this.Id = id;
            this.Name = name;
            this.Filename = filename;
            this.Type = type;
        }


    }
}
