using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace WebradioManager
{
    public class WebradioServer
    {
        #region Fields
        const string SC_SERVER_FILENAME = "shoutcast/sc_serv.exe";

        private int _port;
        private string _logFilename;
        private string _configFilename;
        private string _password;
        private string _adminPassword;
        private Process _process;
        #endregion

        #region Properties
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

        public WebradioServer(int port, string logfilename, string configfilename, string password, string adminPassword)
        {
            this.Port = port;
            this.LogFilename = logfilename;
            this.ConfigFilename = configfilename;
            this.Password = password;
            this.AdminPassword = adminPassword;
        }

        public void Start()
        {

        }

        public void Stop()
        { 
        
        }
    }
}
