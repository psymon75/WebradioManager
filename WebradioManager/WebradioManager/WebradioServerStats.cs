using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebradioManager
{
    public class WebradioServerStats
    {
        private int _currentListeners;
        private int _uniqueListeners;
        private int _peakListeners;
        private TimeSpan _averageTime;

        #region Properties
        public TimeSpan AverageTime
        {
            get { return _averageTime; }
            set { _averageTime = value; }
        }

        public int PeakListeners
        {
            get { return _peakListeners; }
            set { _peakListeners = value; }
        }

        public int UniqueListeners
        {
            get { return _uniqueListeners; }
            set { _uniqueListeners = value; }
        }

        public int CurrentListeners
        {
            get { return _currentListeners; }
            set { _currentListeners = value; }
        }
        #endregion

        public WebradioServerStats()
        {
            this.CurrentListeners = 0;
            this.UniqueListeners = 0;
            this.PeakListeners = 0;
            this.AverageTime = new TimeSpan(0,0,0);
        }
    }
}
