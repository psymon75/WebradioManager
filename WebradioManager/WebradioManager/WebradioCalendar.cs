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
        private int _id;

        public int Id
        {
          get { return _id; }
          set { _id = value; }
        }

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

        public WebradioCalendar(int id, string filename)
        {
            this.Id = id;
            this.Filename = filename;
            this.Events = new List<CalendarEvent>();
        }

        public WebradioCalendar(string filename)
        {
            this.Filename = filename;
            this.Events = new List<CalendarEvent>();
        }
        
        public void GenerateConfigFile()
        {

        }
    }
}
