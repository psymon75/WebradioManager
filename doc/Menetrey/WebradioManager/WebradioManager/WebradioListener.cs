/**
// \file WebradioListener.cs
//
// \brief Implements the webradio listener class.
**/


namespace WebradioManager
{
    /**
    // \class WebradioListener
    //
    // \brief A webradio listener.
    //
    // \author Simon Menetrey
    // \date 26.05.2014
    **/

    public class WebradioListener
    {
        #region Fields
        // \brief The hostname.
        private string _hostname;
        // \brief The useragent.
        private string _useragent;
        // \brief The connection time.
        private uint _connectionTime;
        // \brief The UID.
        private int _uid;
        #endregion

        #region Properties

        /**
        // \property public int Uid
        //
        // \brief Gets or sets the UID.
        //
        // \return The UID.
        **/

        public int Uid
        {
            get { return _uid; }
            set { _uid = value; }
        }

        /**
        // \property public uint ConnectionTime
        //
        // \brief Gets or sets the connection time.
        //
        // \return The connection time.
        **/

        public uint ConnectionTime
        {
            get { return _connectionTime; }
            set { _connectionTime = value; }
        }

        /**
        // \property public string Useragent
        //
        // \brief Gets or sets the useragent.
        //
        // \return The useragent.
        **/

        public string Useragent
        {
            get { return _useragent; }
            set { _useragent = value; }
        }

        /**
        // \property public string Hostname
        //
        // \brief Gets or sets the hostname.
        //
        // \return The hostname.
        **/

        public string Hostname
        {
            get { return _hostname; }
            set { _hostname = value; }
        }

        #endregion

        #region Methods

        /**
        // \fn public WebradioListener(string hostname, string useragent, uint connectiontime, int uid)
        //
        // \brief Constructor.
        //
        // \author Simon Menetrey
        // \date 26.05.2014
        //
        // \param hostname       The hostname.
        // \param useragent      The useragent.
        // \param connectiontime The connection time.
        // \param uid            The UID.
        **/

        public WebradioListener(string hostname, string useragent, uint connectiontime, int uid)
        {
            this.Hostname = hostname;
            this.Useragent = useragent;
            this.ConnectionTime = connectiontime;
            this.Uid = uid;
        }
        #endregion
    }
}
