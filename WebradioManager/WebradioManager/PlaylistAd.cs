using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebradioManager
{
    public class PlaylistAd : Playlist
    {
        public PlaylistAd(int id, string name, string filename):base(id,name,filename,AudioType.Ad)
        {

        }
    }
}
