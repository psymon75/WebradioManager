using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebradioManager
{
    public abstract class AudioFile
    {
        const int NUMBER_OF_ELEMENTS = 8;
        const int DEFAULT_ID = 0;

        private List<Playlist> _playlists;
        private int _id;
        private string _filename;
        private string _title;
        private string _artist;
        private string _album;
        private int _year;
        private string _label;
        private TimeSpan _duration;
        private string _gender;
        private AudioType _type;

        #region Properties
       

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
        

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        

        public string Artist
        {
            get { return _artist; }
            set { _artist = value; }
        }
        

        public string Album
        {
            get { return _album; }
            set { _album = value; }
        }
        

        public int Year
        {
            get { return _year; }
            set { _year = value; }
        }
        

        public string Label
        {
            get { return _label; }
            set { _label = value; }
        }
        

        public TimeSpan Duration
        {
            get { return _duration; }
            set { _duration = value; }
        }
        

        public string Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }
        

        public AudioType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public List<Playlist> Playlists
        {
            get { return _playlists; }
            set { _playlists = value; }
        }
        #endregion

        public AudioFile(int id, string filename, string title, string artist, string album, int year, string label, TimeSpan duration, string gender, AudioType audiotype)
        {
            this.Playlists = new List<Playlist>();
            this.Id = id;
            this.Filename = filename;
            this.Title = title;
            this.Artist = artist;
            this.Album = album;
            this.Year = year;
            this.Label = label;
            this.Duration = duration;
            this.Gender = gender;
            this.Type = audiotype;
        }
        
        public AudioFile(string filename, string title, string artist, string album, int year, string label, TimeSpan duration, string gender, AudioType audiotype)
            :this(DEFAULT_ID,filename, title, artist, album, year, label, duration, gender, audiotype)
        {
            //NO CODE
        }
        public string[] GetInfosArray()
        {
            string[] infos = new string[NUMBER_OF_ELEMENTS];

            infos[0] = this.Id.ToString();
            infos[1] = this.Title;
            infos[2] = this.Artist;
            infos[3] = this.Album;
            infos[4] = this.Year.ToString();
            infos[5] = this.Label;
            infos[6] = this.Duration.ToString(@"hh\:mm\:ss");
            infos[7] = this.Gender;

            return infos;
        }
    }
}
