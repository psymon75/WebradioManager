using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebradioManager
{
    public class CalendarEvent
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private DateTime _startTime;

        public DateTime StartTime
        {
            get { return _startTime; }
            set { _startTime = value; }
        }
        private DateTime _duration;

        public DateTime Duration
        {
            get { return _duration; }
            set { _duration = value; }
        }
        private bool _repeat;

        public bool Repeat
        {
            get { return _repeat; }
            set { _repeat = value; }
        }
        private bool _shuffle;

        public bool Shuffle
        {
            get { return _shuffle; }
            set { _shuffle = value; }
        }
        private bool _loopatend;

        public bool Loopatend
        {
            get { return _loopatend; }
            set { _loopatend = value; }
        }
    }
}
