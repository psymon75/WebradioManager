/**
// \file Webradio.cs
//
// \brief Implements the webradio class.
**/

using System.Collections.Generic;

namespace WebradioManager
{
    /**
    // \class Webradio
    //
    // \brief A webradio.
    //
    // \author Simon Menetrey
    // \date 26.05.2014
    **/

    public class Webradio
    {
        #region Const
        // \brief The default identifier.
        const int DEFAULT_ID = 0;
        #endregion

        #region Fields
        // \brief The playlists list.
        private List<Playlist> _playlists;
        // \brief The calendar.
        private WebradioCalendar _calendar;
        // \brief The name.
        private string _name;
        // \brief The server.
        private WebradioServer _server;
        // \brief The identifier.
        private int _id;
        // \brief The transcoders list.
        private List<WebradioTranscoder> _transcoders;
        #endregion

        #region Properties

        /**
        // \property public List<WebradioTranscoder> Transcoders
        //
        // \brief Gets or sets the transcoders list.
        //
        // \return The transcoders.
        **/

        public List<WebradioTranscoder> Transcoders
        {
            get { return _transcoders; }
            set { _transcoders = value; }
        }

        /**
        // \property public WebradioServer Server
        //
        // \brief Gets or sets the server.
        //
        // \return The server.
        **/

        public WebradioServer Server
        {
            get { return _server; }
            set { _server = value; }
        } 

        /**
        // \property public string Name
        //
        // \brief Gets or sets the name.
        //
        // \return The name.
        **/

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /**
        // \property public WebradioCalendar Calendar
        //
        // \brief Gets or sets the calendar.
        //
        // \return The calendar.
        **/

        public WebradioCalendar Calendar
        {
            get { return _calendar; }
            set { _calendar = value; }
        }

        /**
        // \property public List<Playlist> Playlists
        //
        // \brief Gets or sets the playlists list.
        //
        // \return The playlists.
        **/

        public List<Playlist> Playlists
        {
            get { return _playlists; }
            set { _playlists = value; }
        }

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
        #endregion

        #region Methods

        /**
        // \fn public Webradio(string name, int id)
        //
        // \brief Constructor.
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        //
        // \param name The name.
        // \param id   The identifier.
        **/

        public Webradio(string name, int id)
        {
            this.Name = name;
            this.Id = id;
            this.Playlists = new List<Playlist>();
            this.Transcoders = new List<WebradioTranscoder>();
        }

        /**
        // \fn public Webradio(string name):this(name,DEFAULT_ID)
        //
        // \brief Constructor.
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        //
        // \param name The name.
        **/

        public Webradio(string name):this(name,DEFAULT_ID)
        {
            //NO CODE
        }

        /**
        // \fn public void GenerateConfigFiles()
        //
        // \brief Generates a configuration files.
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        **/

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
                transcoder.GenerateConfigFile(this.Playlists);
            }
        }

        /**
        // \fn public override string ToString()
        //
        // \brief Convert this object into a string representation.
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        //
        // \return Chaîne qui représente l'objet actif.
        //
        // ### summary Retourne une chaîne qui représente l'objet actif.
        **/

        public override string ToString()
        {
            return this.Name + " | ID = " + this.Id.ToString();
        }
        #endregion
    }
}
