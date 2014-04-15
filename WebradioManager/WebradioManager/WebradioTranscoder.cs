using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WebradioManager
{
    public abstract class WebradioTranscoder
    {
        private int _id;
        private int _birate;
        private int _sampleRate;
        private string _name;
        private string _url;
        private string _ip;
        private int _port;
        private string _password;
        private string _configFilename;
        private string _logFilename;
        private StreamType _streamType;
        private static int[] _avaliableBitrates = { 96000, 128000, 256000 };
        private static int[] _avaliableSampleRates = { 44100 };


        #region Properties
        public static int[] AvaliableSampleRates
        {
            get { return WebradioTranscoder._avaliableSampleRates; }
            set { WebradioTranscoder._avaliableSampleRates = value; }
        }
        public static int[] AvaliableBitrates
        {
            get { return WebradioTranscoder._avaliableBitrates; }
            set { WebradioTranscoder._avaliableBitrates = value; }
        }
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public int Birate
        {
            get { return _birate; }
            set { _birate = value; }
        }

        public int SampleRate
        {
            get { return _sampleRate; }
            set { _sampleRate = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }

        public string Ip
        {
            get { return _ip; }
            set { _ip = value; }
        }
        

        public int Port
        {
            get { return _port; }
            set { _port = value; }
        }
        

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        

        public string ConfigFilename
        {
            get { return _configFilename; }
            set { _configFilename = value; }
        }
        

        public string LogFilename
        {
            get { return _logFilename; }
            set { _logFilename = value; }
        }
        

        public StreamType StreamType
        {
            get { return _streamType; }
            set { _streamType = value; }
        }
        #endregion

        public WebradioTranscoder(int id, string name, int bitrate, int sampleRate, string ip, int port, string url, string password, string configFilename, string logFilename, StreamType st)
        {
            this.Id = id;
            this.Name = name;
            this.Birate = bitrate;
            this.SampleRate = sampleRate;
            this.Ip = ip;
            this.Port = port;
            this.Url = url;
            this.Password = password;
            this.LogFilename = logFilename;
            this.ConfigFilename = configFilename;
            this.StreamType = st;
        }

        public void GenerateConfigFile()
        {
            if (File.Exists(this.ConfigFilename))
                File.Delete(this.ConfigFilename);
            string output = "";
            output += "logfile=" + this.LogFilename.Replace('/', '\\') + "\n";
            output += "encoder_1=" + ((this.StreamType == WebradioManager.StreamType.AACPlus) ? "aacp" : "mp3") + "\n";
            output += "butrate_1=" + this.Birate + "\n";

            output += "outprotocol_1=3\n";
            output += "serverip_1=" + this.Ip + "\n";
            output += "serverport_1="+ this.Port +"\n";
            output += "password_1=" + this.Password +"\n";
            output += "streamid_1=1\n";

            output += "streamtitle=" + this.Name + "\n";
            output += "streamurl=" + this.Url + "\n";
            output += "genre=Misc\n";
            File.WriteAllText(this.ConfigFilename,output);
        }

        public override string ToString()
        {
            return this.Name;
        } 
    }
}
