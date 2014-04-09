using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebradioManager
{
    public class PlaylistMusic : Playlist
    {
        public PlaylistMusic(int id, string name, string filename)
            : base(id, name, filename, AudioType.Music)
        {

        }
    }
}
