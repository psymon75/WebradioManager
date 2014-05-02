using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebradioManager
{
    public enum DayValue
    {
        Monday = 2,
        Tuesday = 4,
        Wednesday = 8,
        Thursday = 16,
        Friday = 32,
        Saturday = 64,
        Sunday = 1,
    }
    public class CalendarEvent
    {        
        const int MONDAY_MASK = 2;
        const int TUESDAY_MASK = 4;
        const int WEDNESDAY_MASK = 8;
        const int THURSDAY_MASK = 16;
        const int FRIDAY_MASK = 32;
        const int SATURDAY_MASK = 64;
        const int SUNDAY_MASK = 1;

        #region Fields
        private string _name;
        private TimeSpan _startTime;
        private TimeSpan _duration;
        private int _repeat;
        private bool _shuffle;
        private bool _loopatend;
        private int _priority;
        private Playlist _playlist;
        private int _id;

        #endregion

        #region Properties
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public Playlist Playlist
        {
            get { return _playlist; }
            set { _playlist = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        

        public TimeSpan StartTime
        {
            get { return _startTime; }
            set { _startTime = value; }
        }
        

        public TimeSpan Duration
        {
            get { return _duration; }
            set { _duration = value; }
        }
        

        public int Repeat
        {
            get { return _repeat; }
            set { _repeat = value; }
        }
        

        public bool Shuffle
        {
            get { return _shuffle; }
            set { _shuffle = value; }
        }
        

        public bool Loopatend
        {
            get { return _loopatend; }
            set { _loopatend = value; }
        }

        public int Priority
        {
            get { return _priority; }
            set { _priority = value; }
        }
        #endregion

        public CalendarEvent(string name, TimeSpan starttime, TimeSpan duration, int repeat, int priority, bool shuffle, bool loopatend, Playlist playlist)
            :this(0,name,starttime,duration,repeat,priority,shuffle,loopatend,playlist)
        {
            //NO CODE
        }

        public CalendarEvent(int id, string name, TimeSpan starttime, TimeSpan duration, int repeat, int priority, bool shuffle, bool loopatend, Playlist playlist)
        {
            this.Id = id;
            this.Name = name;
            this.StartTime = starttime;
            this.Duration = duration;
            this.Repeat = repeat;
            this.Priority = priority;
            this.Shuffle = shuffle;
            this.Loopatend = loopatend;
            this.Playlist = playlist;
        }

        public DayWeek GetSelectedDays()
        {
            DayWeek dow = new DayWeek();
            dow.Monday = Convert.ToBoolean(this.Repeat & MONDAY_MASK);
            dow.Tuesday = Convert.ToBoolean(this.Repeat & TUESDAY_MASK);
            dow.Wednesday = Convert.ToBoolean(this.Repeat & WEDNESDAY_MASK);
            dow.Thursday = Convert.ToBoolean(this.Repeat & THURSDAY_MASK);
            dow.Friday = Convert.ToBoolean(this.Repeat & FRIDAY_MASK);
            dow.Saturday = Convert.ToBoolean(this.Repeat & SATURDAY_MASK);
            dow.Sunday = Convert.ToBoolean(this.Repeat & SUNDAY_MASK);
            return dow;
        }

        

        
    }
}
