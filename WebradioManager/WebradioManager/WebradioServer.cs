/**
/// \file webradioserver.cs
///
/// \brief Implements the webradioserver class.
**/

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace WebradioManager
{
    /**
    /// \class WebradioServer
    ///
    /// \brief A shoutcast webradio server.
    ///
    /// \author Simon Menetrey
    /// \date 21.05.2014
    **/

    public class WebradioServer
    {
        #region Fields
        /// \brief Filename of the server file.
        const string SC_SERVER_FILENAME = "\\shoutcast\\sc_serv.exe";
        /// \brief The default admin login.
        public const string DEFAULT_ADMIN_LOGIN = "admin";

        /// \brief The port.
        private int _port;
        /// \brief Filename of the log file.
        private string _logFilename;
        /// \brief Filename of the configuration file.
        private string _configFilename;
        /// \brief The password.
        private string _password;
        /// \brief The admin password.
        private string _adminPassword;
        /// \brief The process.
        private Process _process;
        /// \brief The number of maximum listener.
        private int _maxListener;
        /// \brief The statistics.
        private WebradioServerStats _stats;

        #endregion

        #region Properties

        /**
        /// \property internal WebradioServerStats Stats
        ///
        /// \brief Gets or sets the statistics.
        ///
        /// \return The statistics.
        **/

        internal WebradioServerStats Stats
        {
            get { return _stats; }
            set { _stats = value; }
        }

        /**
        /// \property public string WebInterfaceUrl
        ///
        /// \brief Gets URL of the web interface.
        ///
        /// \return The web interface URL.
        **/

        public string WebInterfaceUrl
        {
            get
            {
                return "http://" + this.GetLocalIPAddress() + ":" + this.Port;
            }
        }

        /**
        /// \property public string WebAdminUrl
        ///
        /// \brief Gets URL of the web admin.
        ///
        /// \return The web admin URL.
        **/

        public string WebAdminUrl
        {
            get
            {
                return "http://" + this.GetLocalIPAddress() + ":" + this.Port + "/admin.cgi";
            }
        }

        /**
        /// \property public int MaxListener
        ///
        /// \brief Gets or sets the number of maximum listener.
        ///
        /// \return The maximum listener.
        **/

        public int MaxListener
        {
            get { return _maxListener; }
            set { _maxListener = value; }
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
        /// \property public string AdminPassword
        ///
        /// \brief Gets or sets the admin password.
        ///
        /// \return The admin password.
        **/

        public string AdminPassword
        {
            get { return _adminPassword; }
            set { _adminPassword = value; }
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

        #endregion

        #region Methods
        /**
        /// \fn public WebradioServer(int port, string logfilename, string configfilename, string password, string adminPassword, int maxlistener)
        ///
        /// \brief Constructor.
        ///
        /// \author Simon Menetrey
        /// \date 21.05.2014
        ///
        /// \param port           The port.
        /// \param logfilename    The filename of the log file.
        /// \param configfilename The filename of the configuration file.
        /// \param password       The password.
        /// \param adminPassword  The admin password.
        /// \param maxlistener    The number of max listener.
        **/

        public WebradioServer(int port, string logFilename, string configFilename, string password, string adminPassword, int maxListener)
        {
            this.Port = port;
            this.LogFilename = logFilename;
            this.ConfigFilename = configFilename;
            this.Password = password;
            this.AdminPassword = adminPassword;
            this.MaxListener = maxListener;
            this.Stats = new WebradioServerStats();
        }

        /**
        /// \fn public void GenerateConfigFile()
        ///
        /// \brief Generates the configuration file.
        ///
        /// \author Simon Menetrey
        /// \date 21.05.2014
        **/

        public void GenerateConfigFile()
        {
            if (File.Exists(this.ConfigFilename))
                File.Delete(this.ConfigFilename);
            string output = "";
            output += "logfile=" + Directory.GetCurrentDirectory() + "\\" + this.LogFilename.Replace('/', '\\') + "\n";
            output += "portbase=" + this.Port.ToString() + "\n";
            output += "password=" + this.Password + "\n";
            output += "adminpassword=" + this.AdminPassword + "\n";
            output += "publicserver=always" + "\n";
            output += "maxuser=" + this.MaxListener.ToString() + "\n";
            //Don't kick idle source
            output += "autodumpsourcetime=0\n";
            File.WriteAllText(this.ConfigFilename, output);
        }

        /**
        /// \fn public bool IsRunning()
        ///
        /// \brief Query if the process is running.
        ///
        /// \author Simon Menetrey
        /// \date 21.05.2014
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
        /// \brief Starts the process.
        ///
        /// \author Simon Menetrey
        /// \date 21.05.2014
        ///
        /// \param debug True to debug mode.
        ///
        /// \return true if it succeeds, false if it fails.
        **/

        public bool Start(bool debug)
        {
            ProcessStartInfo StartInfo = new ProcessStartInfo(Directory.GetCurrentDirectory() + SC_SERVER_FILENAME)
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
        /// \brief Stops the process.
        ///
        /// \author Simon Menetrey
        /// \date 21.05.2014
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
                    return true;
                }
                catch
                {
                    return false;
                }       
            }
            return true;
        }

        /**
        /// \fn private string LocalIPAddress()
        ///
        /// \brief Get local IP address.
        ///
        /// \author Simon Menetrey
        /// \date 21.05.2014
        ///
        /// \return The local IP address as string.
        **/

        private string GetLocalIPAddress()
        {
            IPHostEntry host;
            string localIP = "";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIP = ip.ToString();
                    break;
                }
            }
            return localIP;
        }

        /**
        /// \fn public bool UpdateStats()
        ///
        /// \brief Updates the statistics.
        ///
        /// \author Simon Menetrey
        /// \date 21.05.2014
        ///
        /// \return true if it succeeds, false if it fails.
        **/

        public bool UpdateStats()
        {
            try
            {
                WebClient wc = new WebClient();
                wc.Credentials = new NetworkCredential(DEFAULT_ADMIN_LOGIN, this.AdminPassword);
                string response = wc.DownloadString("http://127.0.0.1:" + this.Port + "/admin.cgi?mode=viewxml&page=1&sid=1");
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(response);
                XmlNodeList nodes = doc.SelectNodes("/SHOUTCASTSERVER");
                foreach(XmlNode xn in nodes)
                {
                    this.Stats.CurrentListeners = int.Parse(xn["CURRENTLISTENERS"].InnerText);
                    this.Stats.PeakListeners = int.Parse(xn["PEAKLISTENERS"].InnerText);
                    this.Stats.UniqueListeners = int.Parse(xn["UNIQUELISTENERS"].InnerText);
                    this.Stats.AverageTime = TimeSpan.FromSeconds(double.Parse(xn["AVERAGETIME"].InnerText));
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /**
        /// \fn public List<WebradioListener> GetListeners()
        ///
        /// \brief Gets the list of listeners.
        ///
        /// \author Simon Menetrey
        /// \date 21.05.2014
        ///
        /// \return The list of listeners.
        **/

        public List<WebradioListener> GetListeners()
        {
            List<WebradioListener> list = new List<WebradioListener>();
            WebClient wc = new WebClient();
            wc.Credentials = new NetworkCredential(DEFAULT_ADMIN_LOGIN, this.AdminPassword);
            string response = wc.DownloadString("http://127.0.0.1:" + this.Port + "/admin.cgi?mode=viewxml&page=3&sid=1");

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(response);
            XmlNodeList nodes = doc.SelectNodes("/SHOUTCASTSERVER/LISTENERS/LISTENER");
            if (nodes.Count > 0)
            {
                foreach (XmlNode xn in nodes)
                {
                    WebradioListener listener = new WebradioListener(xn["HOSTNAME"].InnerText, xn["USERAGENT"].InnerText, uint.Parse(xn["CONNECTTIME"].InnerText), int.Parse(xn["UID"].InnerText));
                    list.Add(listener);
                }
            }
            return list;
        }
        #endregion
    }
}
