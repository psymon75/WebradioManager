/**
// \file AudioFile.cs
//
// \brief Implements the audio file class.
**/

using System;

namespace WebradioManager
{
    /**
    // \class AudioFile
    //
    // \brief An audio file. Abstract class.
    //
    // \author Simon Menetrey
    // \date 26.05.2014
    **/

    public abstract class AudioFile
    {
        #region Const
        // \brief Number of elements (for an audiofile).
        const int NUMBER_OF_ELEMENTS = 9;
        // \brief The default identifier.
        const int DEFAULT_ID = 0;
        #endregion

        #region Fields
        // \brief The identifier.
        private int _id;
        // \brief Filename of the audiofile.
        private string _filename;
        // \brief The title.
        private string _title;
        // \brief The artist.
        private string _artist;
        // \brief The album.
        private string _album;
        // \brief The year.
        private int _year;
        // \brief The label.
        private string _label;
        // \brief The duration.
        private TimeSpan _duration;
        // \brief The gender.
        private string _gender;
        // \brief The type.
        private AudioType _type;
        #endregion

        #region Properties

        /**
        // \property public int Id
        //
        // \brief Gets or sets the identifier.
        //
        // \return The identifier.
        **/

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        /**
        // \property public string Filename
        //
        // \brief Gets or sets the filename of the audiofile.
        //
        // \return The filename.
        **/

        public string Filename
        {
            get { return _filename; }
            set { _filename = value; }
        }

        /**
        // \property public string Title
        //
        // \brief Gets or sets the title.
        //
        // \return The title.
        **/

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        /**
        // \property public string Artist
        //
        // \brief Gets or sets the artist.
        //
        // \return The artist.
        **/

        public string Artist
        {
            get { return _artist; }
            set { _artist = value; }
        }

        /**
        // \property public string Album
        //
        // \brief Gets or sets the album.
        //
        // \return The album.
        **/

        public string Album
        {
            get { return _album; }
            set { _album = value; }
        }

        /**
        // \property public int Year
        //
        // \brief Gets or sets the year.
        //
        // \return The year.
        **/

        public int Year
        {
            get { return _year; }
            set { _year = value; }
        }

        /**
        // \property public string Label
        //
        // \brief Gets or sets the label.
        //
        // \return The label.
        **/

        public string Label
        {
            get { return _label; }
            set { _label = value; }
        }

        /**
        // \property public TimeSpan Duration
        //
        // \brief Gets or sets the duration.
        //
        // \return The duration.
        **/

        public TimeSpan Duration
        {
            get { return _duration; }
            set { _duration = value; }
        }

        /**
        // \property public string Gender
        //
        // \brief Gets or sets the gender.
        //
        // \return The gender.
        **/

        public string Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        /**
        // \property public AudioType Type
        //
        // \brief Gets or sets the type.
        //
        // \return The type.
        **/

        public AudioType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        #endregion

        #region Methods

        /**
        // \fn public AudioFile(int id, string filename, string title, string artist, string album, int year, string label, TimeSpan duration, string gender, AudioType audiotype)
        //
        // \brief Constructor.
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        //
        // \param id        The identifier.
        // \param filename  Filename of the audiofile.
        // \param title     The title.
        // \param artist    The artist.
        // \param album     The album.
        // \param year      The year.
        // \param label     The label.
        // \param duration  The duration.
        // \param gender    The gender.
        // \param audiotype The audiotype.
        **/

        public AudioFile(int id, string filename, string title, string artist, string album, int year, string label, TimeSpan duration, string gender, AudioType audiotype)
        {
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

        /**
        // \fn public AudioFile(string filename, string title, string artist, string album, int year, string label, TimeSpan duration, string gender, AudioType audiotype) :this(DEFAULT_ID,filename, title, artist, album, year, label, duration, gender, audiotype)
        //
        // \brief Constructor.
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        //
        // \param filename  Filename of the audiofile.
        // \param title     The title.
        // \param artist    The artist.
        // \param album     The album.
        // \param year      The year.
        // \param label     The label.
        // \param duration  The duration.
        // \param gender    The gender.
        // \param audiotype The audiotype.
        **/

        public AudioFile(string filename, string title, string artist, string album, int year, string label, TimeSpan duration, string gender, AudioType audiotype)
            :this(DEFAULT_ID,filename, title, artist, album, year, label, duration, gender, audiotype)
        {
            //NO CODE
        }

        /**
        // \fn public string[] GetInfosArray()
        //
        // \brief Gets infos in an array.
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        //
        // \return An array of string.
        **/

        public string[] GetInfosArray()
        {
            string[] infos = new string[NUMBER_OF_ELEMENTS];

            infos[0] = this.Id.ToString();
            infos[1] = this.Title;
            infos[2] = this.Artist;
            infos[3] = this.Album;
            infos[4] = this.Year.ToString();
            infos[5] = this.Label;
            infos[6] = this.Duration.ToString(@"\:mm\:ss");
            infos[7] = this.Gender;
            infos[8] = this.Filename;

            return infos;
        }
        #endregion
    }
}
