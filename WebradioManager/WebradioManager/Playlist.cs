/**
// \file Playlist.cs
//
// \brief Implements the playlist class.
**/

using System.Collections.Generic;
using System.IO;

namespace WebradioManager
{
    /**
    // \class Playlist
    //
    // \brief A playlist. Abstract class.
    //
    // \author Simon Menetrey
    // \date 26.05.2014
    **/

    public abstract class Playlist
    {
        #region Const
        // \brief The default identifier.
        const int DEFAULT_ID = 0;
        #endregion

        #region Fields
        // \brief The name.
        private string _name;
        // \brief The identifier.
        private int _id;
        // \brief Filename of the file.
        private string _filename;
        // \brief The type.
        private AudioType _type;
        // \brief List of audio files's filename.
        private List<string> _audioFileList;
        #endregion

        #region Properties

        /**
        // \property public List<string> AudioFileList
        //
        // \brief Gets or sets a list of audio files's filename.
        //
        // \return A List of audio files.
        **/

        public List<string> AudioFileList
        {
            get { return _audioFileList; }
            set { _audioFileList = value; }
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
        // \brief Gets or sets the filename of the file.
        //
        // \return The filename.
        **/

        public string Filename
        {
            get { return _filename; }
            set { _filename = value; }
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
        #endregion

        #region Methods

        /**
        // \fn public Playlist(string name, string filename, AudioType type):this(DEFAULT_ID,name,filename,type)
        //
        // \brief Constructor.
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        //
        // \param name     The name.
        // \param filename Filename of the file.
        // \param type     The type.
        **/

        public Playlist(string name, string filename, AudioType type):this(DEFAULT_ID,name,filename,type)
        {
            //NO CODE
        }

        /**
        // \fn public Playlist(int id, string name, string filename, AudioType type)
        //
        // \brief Constructor.
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        //
        // \param id       The identifier.
        // \param name     The name.
        // \param filename Filename of the file.
        // \param type     The type.
        **/

        public Playlist(int id, string name, string filename, AudioType type)
        {
            this.Id = id;
            this.Name = name;
            this.Filename = filename;
            this.Type = type;
            this.AudioFileList = new List<string>();
        }

        /**
        // \fn public void GenerateConfigFile()
        //
        // \brief Generates a configuration file.
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        **/

        public void GenerateConfigFile()
        {
            string output = "";
            if (File.Exists(this.Filename))
                File.Delete(this.Filename);
            foreach(string filename in this.AudioFileList)
            {
                output += (filename + "\n"); 
            }
            File.WriteAllText(this.Filename, output);
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
            return this.Name;
        }
        #endregion

    }
}
