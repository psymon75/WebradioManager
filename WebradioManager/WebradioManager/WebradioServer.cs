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
    public class WebradioServer
    {
        #region Fields
        const string SC_SERVER_FILENAME = "\\shoutcast\\sc_serv.exe";
        public const string DEFAULT_ADMIN_LOGIN = "admin";

        private int _port;
        private string _logFilename;
        private string _configFilename;
        private string _password;
        private string _adminPassword;
        private Process _process;
        private int _maxListener;
        private WebradioServerStats _stats;

        #endregion

        #region Properties
        internal WebradioServerStats Stats
        {
            get { return _stats; }
            set { _stats = value; }
        }
        public string WebInterfaceUrl
        {
            get
            {
                return "http://" + this.LocalIPAddress() + ":" + this.Port;
            }
        }

        public string WebAdminUrl
        {
            get
            {
                return "http://" + this.LocalIPAddress() + ":" + this.Port + "/admin.cgi";
            }
        }
        public int MaxListener
        {
            get { return _maxListener; }
            set { _maxListener = value; }
        }
        public Process Process
        {
            get { return _process; }
            set { _process = value; }
        }
        public string LogFilename
        {
            get { return _logFilename; }
            set { _logFilename = value; }
        }

        public string ConfigFilename
        {
            get { return _configFilename; }
            set { _configFilename = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public string AdminPassword
        {
            get { return _adminPassword; }
            set { _adminPassword = value; }
        }

        public int Port
        {
            get { return _port; }
            set { _port = value; }
        }

        #endregion

        public WebradioServer(int port, string logfilename, string configfilename, string password, string adminPassword, int maxlistener)
        {
            this.Port = port;
            this.LogFilename = logfilename;
            this.ConfigFilename = configfilename;
            this.Password = password;
            this.AdminPassword = adminPassword;
            this.MaxListener = maxlistener;
            this.Stats = new WebradioServerStats();
        }

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

        private string LocalIPAddress()
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
    }
}
