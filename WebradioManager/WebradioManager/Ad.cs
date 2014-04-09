﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebradioManager
{
    public class Ad : AudioFile
    {
        public Ad(int id, string filename, string title, string artist, string album, int year, string label, TimeSpan duration, string gender):
            base(id,filename,title,artist,album,year,label,duration,gender,AudioType.Ad)
        {

        }
    }
}
