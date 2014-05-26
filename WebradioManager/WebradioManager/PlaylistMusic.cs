/**
/// \file PlaylistMusic.cs
///
/// \brief Implements the playlist music class.
**/

namespace WebradioManager
{
    /**
    /// \class PlaylistMusic
    ///
    /// \brief A playlist music.
    ///
    /// \author Simon Menetrey
    /// \date 26.05.2014
    **/

    public class PlaylistMusic : Playlist
    {
        #region Methods
        /**
        /// \fn public PlaylistMusic(int id, string name, string filename) : base(id, name, filename, AudioType.Music)
        ///
        /// \brief Constructor.
        ///
        /// \author Simon Menetrey
        /// \date 26.05.2014
        ///
        /// \param id       The identifier.
        /// \param name     The name.
        /// \param filename Filename of the file.
        **/

        public PlaylistMusic(int id, string name, string filename)
            : base(id, name, filename, AudioType.Music)
        {

        }

        /**
        /// \fn public PlaylistMusic(string name, string filename) : base(name, filename, AudioType.Music)
        ///
        /// \brief Constructor.
        ///
        /// \author Simon Menetrey
        /// \date 26.05.2014
        ///
        /// \param name     The name.
        /// \param filename Filename of the file.
        **/

        public PlaylistMusic(string name, string filename)
            : base(name, filename, AudioType.Music)
        {

        }
        #endregion
    }
}
