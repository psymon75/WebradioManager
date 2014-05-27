/**
// \file WebradioServerStats.cs
//
// \brief Implements the webradio server statistics class.
**/

using System;

namespace WebradioManager
{
    /**
    // \class WebradioServerStats
    //
    // \brief A webradio server statistics.
    //
    // \author Simon Menetrey
    // \date 26.05.2014
    **/

    public class WebradioServerStats
    {
        #region Fields
        // \brief The current listeners count.
        private int _currentListeners;
        // \brief The unique listeners count.
        private int _uniqueListeners;
        // \brief The peak listeners count.
        private int _peakListeners;
        // \brief The average time listening.
        private TimeSpan _averageTime;
        #endregion

        #region Properties

        /**
        // \property public TimeSpan AverageTime
        //
        // \brief Gets or sets the average time listening.
        //
        // \return The average time.
        **/

        public TimeSpan AverageTime
        {
            get { return _averageTime; }
            set { _averageTime = value; }
        }

        /**
        // \property public int PeakListeners
        //
        // \brief Gets or sets the peak listeners count.
        //
        // \return The peak listeners.
        **/

        public int PeakListeners
        {
            get { return _peakListeners; }
            set { _peakListeners = value; }
        }

        /**
        // \property public int UniqueListeners
        //
        // \brief Gets or sets the unique listeners count.
        //
        // \return The unique listeners.
        **/

        public int UniqueListeners
        {
            get { return _uniqueListeners; }
            set { _uniqueListeners = value; }
        }

        /**
        // \property public int CurrentListeners
        //
        // \brief Gets or sets the current listeners count.
        //
        // \return The current listeners.
        **/

        public int CurrentListeners
        {
            get { return _currentListeners; }
            set { _currentListeners = value; }
        }
        #endregion

        #region Methods

        /**
        // \fn public WebradioServerStats()
        //
        // \brief Default constructor.
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        **/

        public WebradioServerStats()
        {
            this.CurrentListeners = 0;
            this.UniqueListeners = 0;
            this.PeakListeners = 0;
            this.AverageTime = new TimeSpan(0,0,0);
        }
        #endregion
    }
}
