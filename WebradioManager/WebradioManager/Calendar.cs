using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebradioManager
{
    public class WebradioCalendar
    {
        private List<CalendarEvent> _events;
        private string _filename;

        public string Filename
        {
            get { return _filename; }
            set { _filename = value; }
        }

        public List<CalendarEvent> Events
        {
            get { return _events; }
            set { _events = value; }
        }
    }
}
