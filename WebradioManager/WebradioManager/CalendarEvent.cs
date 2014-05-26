/**
/// \file CalendarEvent.cs
///
/// \brief Implements the calendar event class.
**/

using System;

namespace WebradioManager
{
    /**
    /// \enum DayValue
    ///
    /// \brief Values that represent DayValue for calendar event. http://wiki.winamp.com/wiki/SHOUTcast_Calendar_Event_XML_File_Specification#Calendar_Tag
    **/

    public enum DayValue
    {
        ///< An enum constant representing the monday option
        Monday = 2,
        ///< An enum constant representing the tuesday option
        Tuesday = 4,
        ///< An enum constant representing the wednesday option
        Wednesday = 8,
        ///< An enum constant representing the thursday option
        Thursday = 16,
        ///< An enum constant representing the friday option
        Friday = 32,
        ///< An enum constant representing the saturday option
        Saturday = 64,
        ///< An enum constant representing the sunday option
        Sunday = 1,
    }

    /**
    /// \class CalendarEvent
    ///
    /// \brief A calendar event.
    ///
    /// \author Simon Menetrey
    /// \date 26.05.2014
    **/

    public class CalendarEvent
    {
        #region Const
        /// \brief The monday mask.
        const int MONDAY_MASK = 2;
        /// \brief The tuesday mask.
        const int TUESDAY_MASK = 4;
        /// \brief The wednesday mask.
        const int WEDNESDAY_MASK = 8;
        /// \brief The thursday mask.
        const int THURSDAY_MASK = 16;
        /// \brief The friday mask.
        const int FRIDAY_MASK = 32;
        /// \brief The saturday mask.
        const int SATURDAY_MASK = 64;
        /// \brief The sunday mask.
        const int SUNDAY_MASK = 1;
        #endregion

        #region Fields
        /// \brief The name.
        private string _name;
        /// \brief The start time.
        private TimeSpan _startTime;
        /// \brief The duration.
        private TimeSpan _duration;
        /// \brief The repeat.
        private int _repeat;
        /// \brief true to shuffle.
        private bool _shuffle;
        /// \brief true to loopatend.
        private bool _loopatend;
        /// \brief The priority number.
        private int _priority;
        /// \brief The playlist.
        private Playlist _playlist;
        /// \brief The identifier.
        private int _id;

        #endregion

        #region Properties

        /**
        /// \property public int Id
        ///
        /// \brief Gets or sets the identifier.
        ///
        /// \return The identifier.
        **/

        public int Id
        {
            get { return _id; }
            set { _id = value; }
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

        /**
        /// \property public string Name
        ///
        /// \brief Gets or sets the name.
        ///
        /// \return The name.
        **/

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /**
        /// \property public TimeSpan StartTime
        ///
        /// \brief Gets or sets the start time.
        ///
        /// \return The start time.
        **/

        public TimeSpan StartTime
        {
            get { return _startTime; }
            set { _startTime = value; }
        }

        /**
        /// \property public TimeSpan Duration
        ///
        /// \brief Gets or sets the duration.
        ///
        /// \return The duration.
        **/

        public TimeSpan Duration
        {
            get { return _duration; }
            set { _duration = value; }
        }

        /**
        /// \property public int Repeat
        ///
        /// \brief Gets or sets the repeat's value.
        ///
        /// \return The repeat.
        **/

        public int Repeat
        {
            get { return _repeat; }
            set { _repeat = value; }
        }

        /**
        /// \property public bool Shuffle
        ///
        /// \brief Gets or sets a value indicating whether the shuffle.
        ///
        /// \return true if shuffle, false if not.
        **/

        public bool Shuffle
        {
            get { return _shuffle; }
            set { _shuffle = value; }
        }

        /**
        /// \property public bool Loopatend
        ///
        /// \brief Gets or sets a value indicating whether the loopatend.
        ///
        /// \return true if loopatend, false if not.
        **/

        public bool Loopatend
        {
            get { return _loopatend; }
            set { _loopatend = value; }
        }

        /**
        /// \property public int Priority
        ///
        /// \brief Gets or sets the priority.
        ///
        /// \return The priority.
        **/

        public int Priority
        {
            get { return _priority; }
            set { _priority = value; }
        }
        #endregion

        #region Methods
        /**
        /// \fn public CalendarEvent(string name, TimeSpan starttime, TimeSpan duration, int repeat, int priority, bool shuffle, bool loopatend, Playlist playlist) :this(0,name,starttime,duration,repeat,priority,shuffle,loopatend,playlist)
        ///
        /// \brief Constructor.
        ///
        /// \author Simon Menetrey
        /// \date 26.05.2014
        ///
        /// \param name      The name.
        /// \param starttime The starttime.
        /// \param duration  The duration.
        /// \param repeat    The repeat.
        /// \param priority  The priority.
        /// \param shuffle   true to shuffle.
        /// \param loopatend true to loopatend.
        /// \param playlist  The playlist.
        **/

        public CalendarEvent(string name, TimeSpan starttime, TimeSpan duration, int repeat, int priority, bool shuffle, bool loopatend, Playlist playlist)
            :this(0,name,starttime,duration,repeat,priority,shuffle,loopatend,playlist)
        {
            //NO CODE
        }

        /**
        /// \fn public CalendarEvent(int id, string name, TimeSpan starttime, TimeSpan duration, int repeat, int priority, bool shuffle, bool loopatend, Playlist playlist)
        ///
        /// \brief Constructor.
        ///
        /// \author Simon Menetrey
        /// \date 26.05.2014
        ///
        /// \param id        The identifier.
        /// \param name      The name.
        /// \param starttime The starttime.
        /// \param duration  The duration.
        /// \param repeat    The repeat.
        /// \param priority  The priority.
        /// \param shuffle   true to shuffle.
        /// \param loopatend true to loopatend.
        /// \param playlist  The playlist.
        **/

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

        /**
        /// \fn public DayWeek GetSelectedDays()
        ///
        /// \brief Gets selected days from repest value.
        ///        http://wiki.winamp.com/wiki/SHOUTcast_Calendar_Event_XML_File_Specification#Calendar_Tag
        ///
        /// \author Simon Menetrey
        /// \date 26.05.2014
        ///
        /// \return The selected days in DayWeek structure.
        **/

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
        #endregion
    }
}
