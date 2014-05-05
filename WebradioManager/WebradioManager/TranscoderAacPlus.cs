using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace WebradioManager
{
    public class TranscoderAacPlus : WebradioTranscoder
    {
        public TranscoderAacPlus(int id, string name, int bitrate, int sampleRate, IPAddress ip, int port, string url, string password, string configFilename, string logFilename)
            :base(id,name,bitrate,sampleRate,ip,port,url,password,configFilename,logFilename,StreamType.AACPlus)
        {
            
        }

        public TranscoderAacPlus(string name, int bitrate, int sampleRate, IPAddress ip, int port, string url, string password, string configFilename, string logFilename)
            : base(name, bitrate, sampleRate, ip, port, url, password, configFilename, logFilename, StreamType.AACPlus)
        {

        }
    }
}
