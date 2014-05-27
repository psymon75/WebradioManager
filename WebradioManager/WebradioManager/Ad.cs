/**
// \file ad.cs
//
// \brief Implements the ad class.
**/

using System;

namespace WebradioManager
{
    /**
    // \class Ad
    //
    // \brief An ad audio file.
    //
    // \author Simon Menetrey
    // \date 23.05.2014
    **/

    public class Ad : AudioFile
    {
        #region Methods
        /**
        // \fn public Ad(int id, string filename, string title, string artist, string album, int year, string label, TimeSpan duration, string gender): base(id,filename,title,artist,album,year,label,duration,gender,AudioType.Ad)
        //
        // \brief Constructor.
        //
        // \author Simon Menetrey
        // \date 23.05.2014
        //
        // \param id       The identifier.
        // \param filename Filename of the audio file.
        // \param title    The title.
        // \param artist   The artist.
        // \param album    The album.
        // \param year     The year.
        // \param label    The label.
        // \param duration The duration.
        // \param gender   The gender.
        **/

        public Ad(int id, string filename, string title, string artist, string album, int year, string label, TimeSpan duration, string gender):
            base(id,filename,title,artist,album,year,label,duration,gender,AudioType.Ad)
        {

        }

        /**
        // \fn public Ad(string filename, string title, string artist, string album, int year, string label, TimeSpan duration, string gender) : base(filename, title, artist, album, year, label, duration, gender, AudioType.Ad)
        //
        // \brief Constructor.
        //
        // \author Simon Menetrey
        // \date 23.05.2014
        //
        // \param filename Filename of the audio file.
        // \param title    The title.
        // \param artist   The artist.
        // \param album    The album.
        // \param year     The year.
        // \param label    The label.
        // \param duration The duration.
        // \param gender   The gender.
        **/

        public Ad(string filename, string title, string artist, string album, int year, string label, TimeSpan duration, string gender) :
            base(filename, title, artist, album, year, label, duration, gender, AudioType.Ad)
        {

        }
        #endregion
    }
}
