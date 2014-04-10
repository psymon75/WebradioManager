﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace WebradioManager
{
    public class WMModel
    {
        //Defaults constants
        public const string DEFAULT_WEBRADIOS_FOLDER = "webradios/";
        const string DEFAULT_LOGFILENAME = "log.txt";
        const string DEFAULT_CONFIGFILENAME = "config.config";
        const string DEFAULT_PASSWORD = "1234";
        
        //SERVER CONSTANTS
        const string DEFAULT_SERVER_FOLDER = "server/";
        const int DEFAULT_SERVER_PORT = 8000;
        //CALENDAR CONSTANTS
        const string DEFAULT_CALENDAR_FILENAME = "calendar.xml";
        //PLAYLISTS CONSTANTS
        const string DEFAULT_PLAYLISTS_FOLDER = "playlists/";
        //TRANSCODERS CONSTANTS
        

        private List<Webradio> _webradios;
        private List<IController> _observers;
        private Bdd _bdd;
        private List<AudioFile> _library;

        #region Properties
        public Bdd Bdd
        {
            get { return _bdd; }
            set { _bdd = value; }
        }

        public List<IController> Observers
        {
            get { return _observers; }
            set { _observers = value; }
        }

        public List<Webradio> Webradios
        {
            get { return _webradios; }
            set { _webradios = value; }
        }

        public List<AudioFile> Library
        {
            get { return _library; }
            set { _library = value; }
        }
        #endregion

        public WMModel()
        {
            this.Webradios = new List<Webradio>();
            this.Observers = new List<IController>();
            this.Bdd = new Bdd();
            this.Library = new List<AudioFile>();
        }

        public void AddObserver(IController observer)
        {
            this.Observers.Add(observer);
        }

        public void RemoveObserver(IController observer)
        {
            this.Observers.Remove(observer);
        }

        public void LoadLibrary()
        {
            this.Library = this.Bdd.LoadLibrary();
        }

        public void LoadWebradios()
        {
            this.Webradios = this.Bdd.LoadWebradios();
        }

        public List<Webradio> GetWebradios()
        {
            //Get only webradios with its name and id and without useless stuffs for SelectionView
            List<Webradio> list = new List<Webradio>();
            foreach(Webradio wr in this.Webradios)
            {
                list.Add(new Webradio(wr.Name, wr.Id));
            }
            return list;
        }

        public bool CreateWebradio(string name)
        {
            string webradioFilename = DEFAULT_WEBRADIOS_FOLDER + name + "/";
            Webradio wr = new Webradio(name);
            WebradioServer server = new WebradioServer(DEFAULT_SERVER_PORT,
                webradioFilename + DEFAULT_SERVER_FOLDER + DEFAULT_LOGFILENAME,
                webradioFilename + DEFAULT_SERVER_FOLDER + DEFAULT_CONFIGFILENAME, DEFAULT_PASSWORD, DEFAULT_PASSWORD);
            wr.Server = server;
            wr.Playlists = new List<Playlist>();
            wr.Calendar = new WebradioCalendar(webradioFilename + DEFAULT_CALENDAR_FILENAME);
            wr.Transcoders = new List<WebradioTranscoder>();
            wr.Id = this.Bdd.AddWebradio(wr);
            this.Webradios.Add(wr);
            //Directory and file creation
            Directory.CreateDirectory(webradioFilename);
            Directory.CreateDirectory(webradioFilename + DEFAULT_SERVER_FOLDER);
            Directory.CreateDirectory(webradioFilename + DEFAULT_PLAYLISTS_FOLDER);
            Thread.Sleep(100);
            wr.GenerateConfigFiles();
            return true;
        }

        public bool DeleteWebradio(int id)
        {
            return true;
        }

    }
}
