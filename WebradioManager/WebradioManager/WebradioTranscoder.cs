/**
/// \file WebradioTranscoder.cs
///
/// \brief Implements the webradio transcoder class.
**/

using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace WebradioManager
{
    /**
    /// \class WebradioTranscoder
    ///
    /// \brief A webradio transcoder.
    ///
    /// \author Simon Menetrey
    /// \date 26.05.2014
    **/

    public abstract class WebradioTranscoder
    {
        #region Const
        /// \brief The default identifier.
        const int DEFAULT_ID = 0;
        /// \brief Filename of the transcoder executable file.
        const string SC_TRANS_FILENAME = "\\shoutcast\\sc_trans.exe";
        /// \brief The default configuration extension.
        public const string DEFAULT_CONFIG_EXTENSION = ".config";
        /// \brief The default log extension.
        public const string DEFAULT_LOG_EXTENSION = ".log";
        /// \brief The default admin port.
        const int DEFAULT_ADMIN_PORT = 9000;
        /// \brief The default admin login.
        public const string DEFAULT_ADMIN = "admin";
        /// \brief The default admin password.
        public const string DEFAULT_ADMIN_PASSWORD = "admin";
        /// \brief http://wiki.winamp.com/wiki/SHOUTcast_DNAS_Transcoder_2#Network_Options.
        const int PROTOCOL_VALUE = 3;
        #endregion

        #region Fields
        /// \brief The identifier.
        private int _id;
        /// \brief The birate.
        private int _birate;
        /// \brief The sample rate.
        private int _sampleRate;
        /// \brief The name.
        private string _name;
        /// \brief _URL of the document.
        private string _url;
        /// \brief The IP.
        private IPAddress _ip;
        /// \brief The port.
        private int _port;
        /// \brief The admin port.
        private int _adminPort;
        /// \brief The password.
        private string _password;
        /// \brief Filename of the configuration file.
        private string _configFilename;
        /// \brief Filename of the log file.
        private string _logFilename;
        /// \brief The calendar file.
        private string _calendarFile;
        /// \brief The current track's filename.
        private string _currentTrack;
        /// \brief true to live capture.
        private bool _capture;
        /// \brief Type of the stream.
        private StreamType _streamType;
        /// \brief The process.
        private Process _process;
        /// \brief The avaliable bitrates.
        private static int[] _avaliableBitrates = { 64000, 96000, 128000, 256000, 320000 };
        /// \brief The avaliable sample rates.
        private static int[] _avaliableSampleRates = { 44100 };
        #endregion


        #region Properties

        /**
        /// \property public bool Capture
        ///
        /// \brief Gets or sets a value indicating whether the capture.
        ///
        /// \return true if capture, false if not.
        **/

        public bool Capture
        {
            get { return _capture; }
            set { _capture = value; }
        }

        /**
        /// \property public string CurrentTrack
        ///
        /// \brief Gets or sets the current track's filename.
        ///
        /// \return The current track.
        **/

        public string CurrentTrack
        {
            get { return _currentTrack; }
            set { _currentTrack = value; }
        }

        /**
        /// \property public int AdminPort
        ///
        /// \brief Gets or sets the admin port.
        ///
        /// \return The admin port.
        **/

        public int AdminPort
        {
            get { return _adminPort; }
            set { _adminPort = value; }
        }

        /**
        /// \property public string CalendarFile
        ///
        /// \brief Gets or sets the calendar file.
        ///
        /// \return The calendar file.
        **/

        public string CalendarFile
        {
            get { return _calendarFile; }
            set { _calendarFile = value; }
        }

        /**
        /// \property public Process Process
        ///
        /// \brief Gets or sets the process.
        ///
        /// \return The process.
        **/

        public Process Process
        {
            get { return _process; }
            set { _process = value; }
        }

        /**
        /// \property public static int[] AvaliableSampleRates
        ///
        /// \brief Gets or sets the avaliable sample rates.
        ///
        /// \return The avaliable sample rates.
        **/

        public static int[] AvaliableSampleRates
        {
            get { return WebradioTranscoder._avaliableSampleRates; }
            set { WebradioTranscoder._avaliableSampleRates = value; }
        }

        /**
        /// \property public static int[] AvaliableBitrates
        ///
        /// \brief Gets or sets the avaliable bitrates.
        ///
        /// \return The avaliable bitrates.
        **/

        public static int[] AvaliableBitrates
        {
            get { return WebradioTranscoder._avaliableBitrates; }
            set { WebradioTranscoder._avaliableBitrates = value; }
        }

        /**
        /// \property public int Id
        ///
        /// \brief Gets or sets the identifier.
        ///
        /// \return The identifier.
        **/

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        /**
        /// \property public int Birate
        ///
        /// \brief Gets or sets the birate.
        ///
        /// \return The birate.
        **/

        public int Birate
        {
            get { return _birate; }
            set { _birate = value; }
        }

        /**
        /// \property public int SampleRate
        ///
        /// \brief Gets or sets the sample rate.
        ///
        /// \return The sample rate.
        **/

        public int SampleRate
        {
            get { return _sampleRate; }
            set { _sampleRate = value; }
        }

        /**
        /// \property public string Name
        ///
        /// \brief Gets or sets the name.
        ///
        /// \return The name.
        **/

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /**
        /// \property public string Url
        ///
        /// \brief Gets or sets URL of the document.
        ///
        /// \return The URL.
        **/

        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }

        /**
        /// \property public IPAddress Ip
        ///
        /// \brief Gets or sets the IP.
        ///
        /// \return The IP.
        **/

        public IPAddress Ip
        {
            get { return _ip; }
            set { _ip = value; }
        }

        /**
        /// \property public int Port
        ///
        /// \brief Gets or sets the port.
        ///
        /// \return The port.
        **/

        public int Port
        {
            get { return _port; }
            set { _port = value; }
        }

        /**
        /// \property public string Password
        ///
        /// \brief Gets or sets the password.
        ///
        /// \return The password.
        **/

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        /**
        /// \property public string ConfigFilename
        ///
        /// \brief Gets or sets the filename of the configuration file.
        ///
        /// \return The filename of the configuration file.
        **/

        public string ConfigFilename
        {
            get { return _configFilename; }
            set { _configFilename = value; }
        }

        /**
        /// \property public string LogFilename
        ///
        /// \brief Gets or sets the filename of the log file.
        ///
        /// \return The filename of the log file.
        **/

        public string LogFilename
        {
            get { return _logFilename; }
            set { _logFilename = value; }
        }

        /**
        /// \property public StreamType StreamType
        ///
        /// \brief Gets or sets the type of the stream.
        ///
        /// \return The type of the stream.
        **/

        public StreamType StreamType
        {
            get { return _streamType; }
            set { _streamType = value; }
        }
        #endregion

        #region Methods

        /**
        /// \fn public WebradioTranscoder(string name, int bitrate, int sampleRate, IPAddress ip, int port, int adminport, string url, string password, string configFilename, string logFilename, StreamType st) : this(DEFAULT_ID, name, bitrate, sampleRate, ip, port, adminport, url, password, configFilename, logFilename, st)
        ///
        /// \brief Constructor.
        ///
        /// \author Simon Menetrey
        /// \date 26.05.2014
        ///
        /// \param name           The name.
        /// \param bitrate        The bitrate.
        /// \param sampleRate     The sample rate.
        /// \param ip             The IP.
        /// \param port           The port.
        /// \param adminport      The adminport.
        /// \param url            URL of the document.
        /// \param password       The password.
        /// \param configFilename Filename of the configuration file.
        /// \param logFilename    Filename of the log file.
        /// \param st             The st.
        **/

        public WebradioTranscoder(string name, int bitrate, int sampleRate, IPAddress ip, int port, int adminport, string url, string password, string configFilename, string logFilename, StreamType st)
            : this(DEFAULT_ID, name, bitrate, sampleRate, ip, port, adminport, url, password, configFilename, logFilename, st)
        {
            //NO CODE
        }

        /**
        /// \fn public WebradioTranscoder(int id, string name, int bitrate, int sampleRate, IPAddress ip, int port, int adminport, string url, string password, string configFilename, string logFilename, StreamType st)
        ///
        /// \brief Constructor.
        ///
        /// \author Simon Menetrey
        /// \date 26.05.2014
        ///
        /// \param id             The identifier.
        /// \param name           The name.
        /// \param bitrate        The bitrate.
        /// \param sampleRate     The sample rate.
        /// \param ip             The IP.
        /// \param port           The port.
        /// \param adminport      The adminport.
        /// \param url            URL of the document.
        /// \param password       The password.
        /// \param configFilename Filename of the configuration file.
        /// \param logFilename    Filename of the log file.
        /// \param st             The st.
        **/

        public WebradioTranscoder(int id, string name, int bitrate, int sampleRate, IPAddress ip, int port, int adminport, string url, string password, string configFilename, string logFilename, StreamType st)
        {
            this.Id = id;
            this.Name = name;
            this.Birate = bitrate;
            this.SampleRate = sampleRate;
            this.Ip = ip;
            this.Port = port;
            this.AdminPort = adminport;
            this.Url = url;
            this.Password = password;
            this.LogFilename = logFilename;
            this.ConfigFilename = configFilename;
            this.StreamType = st;
            this.Capture = false;
            this.Process = new Process();
            this.CurrentTrack = "";
        }

        /**
        /// \fn public void GenerateConfigFile(List<Playlist> playlists)
        ///
        /// \brief Generates a configuration file.
        ///
        /// \author Simon Menetrey
        /// \date 26.05.2014
        ///
        /// \param playlists The playlists.
        **/

        public void GenerateConfigFile(List<Playlist> playlists)
        {
            if (File.Exists(this.ConfigFilename))
                File.Delete(this.ConfigFilename);
            string output = "";
            output += "logfile=" + Directory.GetCurrentDirectory() + "\\" + this.LogFilename.Replace('/', '\\') + "\n";
            output += "encoder_1=" + ((this.StreamType == WebradioManager.StreamType.AACPlus) ? "aacp" : "mp3") + "\n";
            output += "bitrate_1=" + (this.Birate * 1000) + "\n";
            output += "adminport=" + this.AdminPort + "\n";
            output += "adminuser=" + DEFAULT_ADMIN + "\n";
            output += "adminpassword=" + DEFAULT_ADMIN_PASSWORD + "\n";
            output += "capturedebug=1\n";

            output += "outprotocol_1=" + PROTOCOL_VALUE + "\n";
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

        /**
        /// \fn public bool IsRunning()
        ///
        /// \brief Query if this transcoder's process is running.
        ///
        /// \author Simon Menetrey
        /// \date 26.05.2014
        ///
        /// \return true if running, false if not.
        **/

        public bool IsRunning()
        {
            bool result = false;
            try
            {
                foreach (Process prc in Process.GetProcesses())
                {
                    if (prc.Id == this.Process.Id)
                    {
                        result = true;
                    }
                }
                if(this.Process.HasExited || !this.Process.Responding)
                    result = false;
                return result;
            }
            catch
            {
                return false;
            }

        }

        /**
        /// \fn public bool Start(bool debug)
        ///
        /// \brief Starts the transcoder's process.
        ///
        /// \author Simon Menetrey
        /// \date 26.05.2014
        ///
        /// \param debug true to debug.
        ///
        /// \return true if it succeeds, false if it fails.
        **/

        public bool Start(bool debug)
        {

            ProcessStartInfo StartInfo = new ProcessStartInfo(Directory.GetCurrentDirectory() + SC_TRANS_FILENAME)
              {
                  CreateNoWindow = true,
                  WindowStyle = (debug)?ProcessWindowStyle.Minimized:ProcessWindowStyle.Hidden,
                  Arguments = "\"" + Directory.GetCurrentDirectory() + "\\" + this.ConfigFilename.Replace('/', '\\') + "\""
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

        /**
        /// \fn public bool Stop()
        ///
        /// \brief Stops the transcoder's process.
        ///
        /// \author Simon Menetrey
        /// \date 26.05.2014
        ///
        /// \return true if it succeeds, false if it fails.
        **/

        public bool Stop()
        {

            if (this.IsRunning() && this.Process.Responding)
            {
                try
                {
                    this.Process.Kill();
                }
                catch
                {
                    return false;
                }
            }
            return true;

        }

        /**
        /// \fn public string GetStatus()
        ///
        /// \brief Gets the transcoder's status.
        ///        http://wiki.winamp.com/wiki/SHOUTcast_Transcoder_AJAX_api_Specification#GetStatus
        ///
        /// \author Simon Menetrey
        /// \date 26.05.2014
        ///
        /// \return The status (XML).
        **/

        public string GetStatus()
        {
            WebClient wb = new WebClient();
            var data = new NameValueCollection();
            data["op"] = "getstatus";
            data["seq"] = "45";
            wb.Credentials = new NetworkCredential(DEFAULT_ADMIN, DEFAULT_ADMIN_PASSWORD);
            try
            {
                var response = wb.UploadValues("http://127.0.0.1:" + this.AdminPort + "/api", "POST", data);
                return System.Text.Encoding.UTF8.GetString(response);
            }
            catch
            {
                return string.Empty;
            }
        }

        /**
        /// \fn public void SetCaptureMode(bool active, string device)
        ///
        /// \brief Sets capture mode.
        ///
        /// \author Simon Menetrey
        /// \date 26.05.2014
        ///
        /// \param active true to active.
        /// \param device The device name.
        **/

        public void SetCaptureMode(bool active, string device)
        {
            this.Capture = active;

            WebClient wb = new WebClient();
            var data = new NameValueCollection();
            data["op"] = "setoptions";
            data["seq"] = "45";
            data["capturedevice"] = "Contrôleur audio haute définition";
            wb.Credentials = new NetworkCredential(DEFAULT_ADMIN, DEFAULT_ADMIN_PASSWORD);
            wb.UploadValues("http://127.0.0.1:" + this.AdminPort + "/api", "POST", data);

            data = new NameValueCollection();
            data["op"] = "capture";
            data["seq"] = "45";
            data["state"] = (active)?"on":"off";
            wb.Credentials = new NetworkCredential(WebradioTranscoder.DEFAULT_ADMIN, WebradioTranscoder.DEFAULT_ADMIN_PASSWORD);
            wb.UploadValues("http://127.0.0.1:" + this.AdminPort + "/api", "POST", data);
        }

        /**
        /// \fn public void NextTrack()
        ///
        /// \brief Go to next track.
        ///
        /// \author Simon Menetrey
        /// \date 26.05.2014
        **/

        public void NextTrack()
        {
            WebClient wb = new WebClient();
            var data = new NameValueCollection();
            data["op"] = "nexttrack";
            data["seq"] = "45";
            wb.Credentials = new NetworkCredential(WebradioTranscoder.DEFAULT_ADMIN, WebradioTranscoder.DEFAULT_ADMIN_PASSWORD);
            wb.UploadValues("http://127.0.0.1:" + this.AdminPort + "/api", "POST", data);
        }

        /**
        /// \fn public override string ToString()
        ///
        /// \brief Convert this object into a string representation.
        ///
        /// \author Simon Menetrey
        /// \date 26.05.2014
        ///
        /// \return Chaîne qui représente l'objet actif.
        ///
        /// ### summary Retourne une chaîne qui représente l'objet actif.
        **/

        public override string ToString()
        {
            return this.Name;
        }

        #endregion
    }
}
