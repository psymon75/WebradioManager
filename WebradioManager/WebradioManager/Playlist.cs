using System;
using System.Collections.Generic;
using System.IO;
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
        private List<string> _audioFileList;


        #region Properties
        public List<string> AudioFileList
        {
            get { return _audioFileList; }
            set { _audioFileList = value; }
        }
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
            this.AudioFileList = new List<string>();
        }

        public void GenerateConfigFile()
        {
            string output = "";
            foreach(string filename in this.AudioFileList)
            {
                output += (filename + "\n"); 
            }
            File.WriteAllText(this.Filename, output);
        }

        public override string ToString()
        {
            return this.Name;
        }

    }
}
