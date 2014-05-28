/**
// \file PlaylistAd.cs
//
// \brief Implements the playlist ad class.
**/

namespace WebradioManager
{
    /**
    // \class PlaylistAd
    //
    // \brief A playlist ad.
    //
    // \author Simon Menetrey
    // \date 26.05.2014
    **/

    public class PlaylistAd : Playlist
    {
        #region Methods
        /**
        // \fn public PlaylistAd(int id, string name, string filename):base(id,name,filename,AudioType.Ad)
        //
        // \brief Constructor.
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        //
        // \param id       The identifier.
        // \param name     The name.
        // \param filename Filename of the file.
        **/

        public PlaylistAd(int id, string name, string filename):base(id,name,filename,AudioType.Ad)
        {

        }

        /**
        // \fn public PlaylistAd(string name, string filename) : base(name, filename, AudioType.Ad)
        //
        // \brief Constructor.
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        //
        // \param name     The name.
        // \param filename Filename of the file.
        **/

        public PlaylistAd(string name, string filename)
            : base(name, filename, AudioType.Ad)
        {

        }
        #endregion
    }
}
