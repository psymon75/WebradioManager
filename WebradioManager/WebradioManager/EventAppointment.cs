using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calendar;

namespace WebradioManager
{
    public class EventAppointment : Appointment
    {
        private Playlist _playlist;
        private CalendarEvent _eventObject;

        public CalendarEvent EventObject
        {
            get { return _eventObject; }
            set { _eventObject = value; }
        }

        public Playlist Playlist
        {
            get { return _playlist; }
            set { _playlist = value; }
        }

        public EventAppointment():base()
        {
            //NO CODE
            
        }
    }
}
