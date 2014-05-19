using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebradioManager
{
    public class WebradioListener
    {
        private string _hostname;
        private string _useragent;
        private uint _connectionTime;
        private int _uid;

        #region Properties
        public int Uid
        {
            get { return _uid; }
            set { _uid = value; }
        }

        public uint ConnectionTime
        {
            get { return _connectionTime; }
            set { _connectionTime = value; }
        }

        public string Useragent
        {
            get { return _useragent; }
            set { _useragent = value; }
        }

        public string Hostname
        {
            get { return _hostname; }
            set { _hostname = value; }
        }

        #endregion

        public WebradioListener(string hostname, string useragent, uint connectiontime, int uid)
        {
            this.Hostname = hostname;
            this.Useragent = useragent;
            this.ConnectionTime = connectiontime;
            this.Uid = uid;
        }
    }
}
