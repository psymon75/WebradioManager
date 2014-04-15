using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebradioManager
{
    public struct DayWeek
    {
        const int DAYS_COUNT = 7;

        private bool _monday;

        public bool Monday
        {
            get { return _monday; }
            set { _monday = value; }
        }
        private bool _tuesday;

        public bool Tuesday
        {
            get { return _tuesday; }
            set { _tuesday = value; }
        }
        private bool _wednesday;

        public bool Wednesday
        {
            get { return _wednesday; }
            set { _wednesday = value; }
        }
        private bool _thursday;

        public bool Thursday
        {
            get { return _thursday; }
            set { _thursday = value; }
        }
        private bool _friday;

        public bool Friday
        {
            get { return _friday; }
            set { _friday = value; }
        }
        private bool _saturday;

        public bool Saturday
        {
            get { return _saturday; }
            set { _saturday = value; }
        }
        private bool _sunday;

        public bool Sunday
        {
            get { return _sunday; }
            set { _sunday = value; }
        }

        public bool[] ToArray()
        {
            bool[] array = new bool[DAYS_COUNT];
            array[0] = this.Monday;
            array[1] = this.Tuesday;
            array[2] = this.Wednesday;
            array[3] = this.Thursday;
            array[4] = this.Friday;
            array[5] = this.Saturday;
            array[6] = this.Sunday;
            return array;
        }
    }
}
