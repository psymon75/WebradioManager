/**
// \file WebradioCalendar.cs
//
// \brief Implements the webradio calendar class.
**/

using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace WebradioManager
{
    /**
    // \class WebradioCalendar
    //
    // \brief A webradio calendar.
    //
    // \author Simon Menetrey
    // \date 26.05.2014
    **/

    public class WebradioCalendar
    {
        #region Fields
        // \brief The events.
        private List<CalendarEvent> _events;
        // \brief Filename of the calendar's file.
        private string _filename;
        // \brief The identifier.
        private int _id;
        #endregion

        #region Properties

        /**
        // \property public int Id
        //
        // \brief Gets or sets the identifier.
        //
        // \return The identifier.
        **/

        public int Id
        {
          get { return _id; }
          set { _id = value; }
        }

        /**
        // \property public string Filename
        //
        // \brief Gets or sets the filename of the calendar's file.
        //
        // \return The filename.
        **/

        public string Filename
        {
            get { return _filename; }
            set { _filename = value; }
        }

        /**
        // \property public List<CalendarEvent> Events
        //
        // \brief Gets or sets the events.
        //
        // \return The events.
        **/

        public List<CalendarEvent> Events
        {
            get { return _events; }
            set { _events = value; }
        }
        #endregion

        #region Methods

        /**
        // \fn public WebradioCalendar(int id, string filename)
        //
        // \brief Constructor.
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        //
        // \param id       The identifier.
        // \param filename Filename of the file.
        **/

        public WebradioCalendar(int id, string filename)
        {
            this.Id = id;
            this.Filename = filename;
            this.Events = new List<CalendarEvent>();
        }

        /**
        // \fn public WebradioCalendar(string filename)
        //
        // \brief Constructor.
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        //
        // \param filename Filename of the file.
        **/

        public WebradioCalendar(string filename)
        {
            this.Filename = filename;
            this.Events = new List<CalendarEvent>();
        }

        /**
        // \fn public void GenerateConfigFile()
        //
        // \brief Generates a configuration file.
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        **/

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
                playlist.InnerText = ev.Playlist.Name;
                eventelement.AppendChild(playlist);

                XmlElement calendar = document.CreateElement("calendar");
                calendar.SetAttribute("starttime", ev.StartTime.ToString(@"hh\:mm\:ss"));
                calendar.SetAttribute("duration", ev.Duration.ToString(@"hh\:mm\:ss"));
                calendar.SetAttribute("repeat", ev.Repeat.ToString());
                eventelement.AppendChild(calendar);
                root.AppendChild(eventelement);
            }
            
            document.AppendChild(root);
            document.Save(this.Filename);
        }
        #endregion
    }
}
