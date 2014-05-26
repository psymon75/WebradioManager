/**
/// \file EventAppointment.cs
///
/// \brief Implements the event appointment class.
**/

using Calendar;

namespace WebradioManager
{
    /**
    /// \class EventAppointment
    ///
    /// \brief An event appointment. Add 2 properties to the original Appointment class (from Calendar library).
    ///
    /// \author Simon Menetrey
    /// \date 26.05.2014
    **/

    public class EventAppointment : Appointment
    {
        #region Fields
        /// \brief The playlist.
        private Playlist _playlist;
        /// \brief The event object.
        private CalendarEvent _eventObject;
        #endregion

        #region Properties
        /**
        /// \property public CalendarEvent EventObject
        ///
        /// \brief Gets or sets the event object.
        ///
        /// \return The event object.
        **/

        public CalendarEvent EventObject
        {
            get { return _eventObject; }
            set { _eventObject = value; }
        }

        /**
        /// \property public Playlist Playlist
        ///
        /// \brief Gets or sets the playlist.
        ///
        /// \return The playlist.
        **/

        public Playlist Playlist
        {
            get { return _playlist; }
            set { _playlist = value; }
        }
        #endregion

        #region Methods
        /**
        /// \fn public EventAppointment():base()
        ///
        /// \brief Default constructor.
        ///
        /// \author Simon Menetrey
        /// \date 26.05.2014
        **/

        public EventAppointment():base()
        {
            //NO CODE

        }
        #endregion
    }
}
