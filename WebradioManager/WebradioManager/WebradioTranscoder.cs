﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace WebradioManager
{
    public abstract class WebradioTranscoder
    {
        const int DEFAULT_ID = 0;
        const string SC_TRANS_FILENAME = "\\shoutcast\\sc_trans.exe";
        public const string DEFAULT_CONFIG_EXTENSION = ".config";
        public const string DEFAULT_LOG_EXTENSION = ".log";
        const int DEFAULT_ADMIN_PORT = 9000;
        const string DEFAULT_ADMIN = "admin";
        const string DEFAULT_ADMIN_PASSWORD = "admin";

        private int _id;
        private int _birate;
        private int _sampleRate;
        private string _name;
        private string _url;
        private IPAddress _ip;
        private int _port;
        private string _password;
        private string _configFilename;
        private string _logFilename;
        private string _calendarFile;
        private StreamType _streamType;
        private Process _process;
        private static int[] _avaliableBitrates = { 96000, 128000, 256000 };
        private static int[] _avaliableSampleRates = { 44100 };


        #region Properties
        public string CalendarFile
        {
            get { return _calendarFile; }
            set { _calendarFile = value; }
        }
        public Process Process
        {
            get { return _process; }
            set { _process = value; }
        }
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

        public IPAddress Ip
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

        public WebradioTranscoder(string name, int bitrate, int sampleRate, IPAddress ip, int port, string url, string password, string configFilename, string logFilename, StreamType st)
            : this(DEFAULT_ID, name, bitrate, sampleRate, ip, port, url, password, configFilename, logFilename, st)
        {
            //NO CODE
        }
        public WebradioTranscoder(int id, string name, int bitrate, int sampleRate, IPAddress ip, int port, string url, string password, string configFilename, string logFilename, StreamType st)
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
            this.Process = new Process();
            this.Process.EnableRaisingEvents = true;
            this.Process.Exited += Process_Exited;
            
        }

        void Process_Exited(object sender, EventArgs e)
        {
            MessageBox.Show("bad");
        }





        public void GenerateConfigFile(List<Playlist> playlists)
        {
            if (File.Exists(this.ConfigFilename))
                File.Delete(this.ConfigFilename);
            string output = "";
            output += "logfile=" + Directory.GetCurrentDirectory() + "\\" + this.LogFilename.Replace('/', '\\') + "\n";
            output += "encoder_1=" + ((this.StreamType == WebradioManager.StreamType.AACPlus) ? "aacp" : "mp3") + "\n";
            output += "bitrate_1=" + this.Birate + "\n";
            output += "adminport=" + DEFAULT_ADMIN_PORT + "\n";
            output += "adminuser=" + DEFAULT_ADMIN + "\n";
            output += "adminpassword" + DEFAULT_ADMIN_PASSWORD + "\n";

            output += "outprotocol_1=3\n";
            output += "serverip_1=" + this.Ip + "\n";
            output += "serverport_1=" + this.Port + "\n";
            output += "password_1=" + this.Password + "\n";
            output += "streamid_1=1\n";

            output += "streamtitle=" + this.Name + "\n";
            output += "streamurl=" + this.Url + "\n";
            output += "genre=Misc\n";

            output += "calendarfile=" + Directory.GetCurrentDirectory() + "\\" + this.CalendarFile.Replace('/', '\\') + "\n";
            int index = 0;
            foreach (Playlist playlist in playlists)
            {
                index++;
                output += "playlistfilename_" + index.ToString() + "=" + playlist.Name + "\n";
                output += "playlistfilepath_" + index.ToString() + "=" + Directory.GetCurrentDirectory() + "\\" + playlist.Filename.Replace("/", "\\") + "\n";
            }

            File.WriteAllText(this.ConfigFilename, output);
        }

        public bool IsRunning()
        {
            bool result = false;
            try
            {
                foreach (Process prc in Process.GetProcesses())
                {
                    if (prc.ProcessName.Contains(this.Process.ProcessName))
                    {
                        result = true;
                    }
                }
                return result;
            }
            catch
            {
                return false;
            }

        }

        public bool Start()
        {

            ProcessStartInfo StartInfo = new ProcessStartInfo(Directory.GetCurrentDirectory() + SC_TRANS_FILENAME)
              {
                  CreateNoWindow = true,
                  WindowStyle = ProcessWindowStyle.Minimized,
                  Arguments = Directory.GetCurrentDirectory() + "\\" + this.ConfigFilename.Replace('/', '\\')
              };
            if (this.IsRunning())
                this.Process.Kill();
            try
            {
                this.Process = Process.Start(StartInfo);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool Stop()
        {
            try
            {
                if (this.IsRunning())
                    this.Process.Kill();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public override string ToString()
        {
            return this.Name;
        }
    }
}
