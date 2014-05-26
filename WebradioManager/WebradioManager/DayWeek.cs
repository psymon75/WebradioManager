/**
/// \file DayWeek.cs
///
/// \brief Implements the day week struct.
**/

namespace WebradioManager
{
    /**
    /// \struct DayWeek
    ///
    /// \brief A week with boolean values for each day. Uses for store which day is selected for an CalendarEvent.
    ///
    /// \author Simon Menetrey
    /// \date 26.05.2014
    **/

    public struct DayWeek
    {
        #region Const
        /// \brief Number of days.
        const int DAYS_COUNT = 7;
        #endregion

        #region Fields
        /// \brief true to monday.
        private bool _monday;
        /// \brief true to tuesday.
        private bool _tuesday;
        /// \brief true to wednesday.
        private bool _wednesday;
        /// \brief true to thursday.
        private bool _thursday;
        /// \brief true to friday.
        private bool _friday;
        /// \brief true to saturday.
        private bool _saturday;
        /// \brief true to sunday.
        private bool _sunday;
        #endregion

        #region Properties

        /**
        /// \property public bool Monday
        ///
        /// \brief Gets or sets a value indicating whether the monday.
        ///
        /// \return true if monday, false if not.
        **/

        public bool Monday
        {
            get { return _monday; }
            set { _monday = value; }
        }

        /**
        /// \property public bool Tuesday
        ///
        /// \brief Gets or sets a value indicating whether the tuesday.
        ///
        /// \return true if tuesday, false if not.
        **/

        public bool Tuesday
        {
            get { return _tuesday; }
            set { _tuesday = value; }
        }

        /**
        /// \property public bool Wednesday
        ///
        /// \brief Gets or sets a value indicating whether the wednesday.
        ///
        /// \return true if wednesday, false if not.
        **/

        public bool Wednesday
        {
            get { return _wednesday; }
            set { _wednesday = value; }
        }

        /**
        /// \property public bool Thursday
        ///
        /// \brief Gets or sets a value indicating whether the thursday.
        ///
        /// \return true if thursday, false if not.
        **/

        public bool Thursday
        {
            get { return _thursday; }
            set { _thursday = value; }
        }

        /**
        /// \property public bool Friday
        ///
        /// \brief Gets or sets a value indicating whether the friday.
        ///
        /// \return true if friday, false if not.
        **/

        public bool Friday
        {
            get { return _friday; }
            set { _friday = value; }
        }

        /**
        /// \property public bool Saturday
        ///
        /// \brief Gets or sets a value indicating whether the saturday.
        ///
        /// \return true if saturday, false if not.
        **/

        public bool Saturday
        {
            get { return _saturday; }
            set { _saturday = value; }
        }

        /**
        /// \property public bool Sunday
        ///
        /// \brief Gets or sets a value indicating whether the sunday.
        ///
        /// \return true if sunday, false if not.
        **/

        public bool Sunday
        {
            get { return _sunday; }
            set { _sunday = value; }
        }
        #endregion

        #region Methods

        /**
        /// \fn public bool[] ToArray()
        ///
        /// \brief Convert the week into an array representation.
        ///
        /// \author Simon Menetrey
        /// \date 26.05.2014
        ///
        /// \return An array that represents the day values of the week.
        **/

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
        #endregion
    }
}
