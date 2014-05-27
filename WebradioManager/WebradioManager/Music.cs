/**
// \file Music.cs
//
// \brief Implements the music class.
**/

using System;

namespace WebradioManager
{
    /**
    // \class Music
    //
    // \brief A music.
    //
    // \author Simon Menetrey
    // \date 26.05.2014
    **/

    public class Music : AudioFile
    {
        #region Methods
        /**
        // \fn public Music(int id, string filename, string title, string artist, string album, int year, string label, TimeSpan duration, string gender): base(id,filename,title,artist,album,year,label,duration,gender,AudioType.Music)
        //
        // \brief Constructor.
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        //
        // \param id       The identifier.
        // \param filename Filename of the audiofile.
        // \param title    The title.
        // \param artist   The artist.
        // \param album    The album.
        // \param year     The year.
        // \param label    The label.
        // \param duration The duration.
        // \param gender   The gender.
        **/

        public Music(int id, string filename, string title, string artist, string album, int year, string label, TimeSpan duration, string gender):
            base(id,filename,title,artist,album,year,label,duration,gender,AudioType.Music)
        {

        }

        /**
        // \fn public Music(string filename, string title, string artist, string album, int year, string label, TimeSpan duration, string gender) : base(filename, title, artist, album, year, label, duration, gender, AudioType.Music)
        //
        // \brief Constructor.
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        //
        // \param filename Filename of the audiofile.
        // \param title    The title.
        // \param artist   The artist.
        // \param album    The album.
        // \param year     The year.
        // \param label    The label.
        // \param duration The duration.
        // \param gender   The gender.
        **/

        public Music(string filename, string title, string artist, string album, int year, string label, TimeSpan duration, string gender) :
            base(filename, title, artist, album, year, label, duration, gender, AudioType.Music)
        {

        }
        #endregion
    }
}
