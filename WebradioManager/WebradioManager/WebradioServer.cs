using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace WebradioManager
{
    public class WebradioServer
    {
        #region Fields
        const string SC_SERVER_FILENAME = "\\shoutcast\\sc_serv.exe";

        private int _port;
        private string _logFilename;
        private string _configFilename;
        private string _password;
        private string _adminPassword;
        private Process _process;
        private int _maxListener;

        #endregion

        #region Properties
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
    }
}
