/**
/// \file TranscoderAacPlus.cs
///
/// \brief Implements the transcoder aac plus class.
**/

using System.Net;

namespace WebradioManager
{
    /**
    /// \class TranscoderAacPlus
    ///
    /// \brief A transcoder aac plus.
    ///
    /// \author Simon Menetrey
    /// \date 26.05.2014
    **/

    public class TranscoderAacPlus : WebradioTranscoder
    {
        #region Methods
        /**
        /// \fn public TranscoderAacPlus(int id, string name, int bitrate, int sampleRate, IPAddress ip, int port, int adminport, string url, string password, string configFilename, string logFilename) :base(id,name,bitrate,sampleRate,ip,port,adminport, url,password,configFilename,logFilename,StreamType.AACPlus)
        ///
        /// \brief Constructor.
        ///
        /// \author Simon Menetrey
        /// \date 26.05.2014
        ///
        /// \param id             The identifier.
        /// \param name           The name.
        /// \param bitrate        The bitrate.
        /// \param sampleRate     The sample rate.
        /// \param ip             The IP.
        /// \param port           The port.
        /// \param adminport      The administration port.
        /// \param url            URL of the stream.
        /// \param password       The password.
        /// \param configFilename Filename of the configuration file.
        /// \param logFilename    Filename of the log file.
        **/

        public TranscoderAacPlus(int id, string name, int bitrate, int sampleRate, IPAddress ip, int port, int adminport, string url, string password, string configFilename, string logFilename)
            :base(id,name,bitrate,sampleRate,ip,port,adminport, url,password,configFilename,logFilename,StreamType.AACPlus)
        {
            
        }

        /**
        /// \fn public TranscoderAacPlus(string name, int bitrate, int sampleRate, IPAddress ip, int port, int adminport, string url, string password, string configFilename, string logFilename) : base(name, bitrate, sampleRate, ip, port, adminport, url, password, configFilename, logFilename, StreamType.AACPlus)
        ///
        /// \brief Constructor.
        ///
        /// \author Simon Menetrey
        /// \date 26.05.2014
        ///
        /// \param name           The name.
        /// \param bitrate        The bitrate.
        /// \param sampleRate     The sample rate.
        /// \param ip             The IP.
        /// \param port           The port.
        /// \param adminport      The administration port.
        /// \param url            URL of the stream.
        /// \param password       The password.
        /// \param configFilename Filename of the configuration file.
        /// \param logFilename    Filename of the log file.
        **/

        public TranscoderAacPlus(string name, int bitrate, int sampleRate, IPAddress ip, int port, int adminport, string url, string password, string configFilename, string logFilename)
            : base(name, bitrate, sampleRate, ip, port, adminport, url, password, configFilename, logFilename, StreamType.AACPlus)
        {

        }
        #endregion
    }
}
