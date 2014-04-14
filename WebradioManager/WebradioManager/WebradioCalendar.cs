using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

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
            if (File.Exists(this.Filename))
                File.Delete(this.Filename);
            XmlDocument document = new XmlDocument();
            XmlElement root = document.CreateElement("eventlist");
            foreach(CalendarEvent ev in this.Events)
            {
                XmlElement eventelement = document.CreateElement("event");
                eventelement.SetAttribute("type", "playlist");
                XmlElement playlist = document.CreateElement("playlist");
                playlist.SetAttribute("loopatend", (ev.Loopatend)?"1":"0");
                playlist.SetAttribute("shuffle", (ev.Shuffle) ? "1" : "0");
                playlist.SetAttribute("priority", ev.Priority.ToString());
                playlist.InnerText = ev.Playlist;
                eventelement.AppendChild(playlist);

                XmlElement calendar = document.CreateElement("calendar");
                calendar.SetAttribute("starttime", ev.StartTime.ToString("hh:mm:ss"));
                calendar.SetAttribute("duration", ev.Duration.ToString("hh:mm:ss"));
                calendar.SetAttribute("repeat", ev.Repeat.ToString());
                eventelement.AppendChild(calendar);
                root.AppendChild(eventelement);
            }
            
            document.AppendChild(root);
            document.Save(this.Filename);
        }
    }
}
