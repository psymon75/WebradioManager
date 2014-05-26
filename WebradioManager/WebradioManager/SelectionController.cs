/**
/// \file SelectionController.cs
///
/// \brief Implements the selection controller class.
**/

using System.Collections.Generic;

namespace WebradioManager
{
    /**
    /// \class SelectionController
    ///
    /// \brief A controller for SelectionView.
    ///
    /// \author Simon Menetrey
    /// \date 26.05.2014
    **/

    public class SelectionController : IController
    {
        #region Fields
        /// \brief The view.
        private SelectionView _view;
        /// \brief The model.
        private WMModel _model;
        #endregion

        #region Properties

        /**
        /// \property public WMModel Model
        ///
        /// \brief Gets or sets the model.
        ///
        /// \return The model.
        **/

        public WMModel Model
        {
            get { return _model; }
            set { _model = value; }
        }

        /**
        /// \property public SelectionView View
        ///
        /// \brief Gets or sets the view.
        ///
        /// \return The view.
        **/

        public SelectionView View
        {
            get { return _view; }
            set { _view = value; }
        }
        #endregion

        #region Methods

        /**
        /// \fn public SelectionController(SelectionView view)
        ///
        /// \brief Constructor.
        ///
        /// \author Simon Menetrey
        /// \date 26.05.2014
        ///
        /// \param view The view.
        **/

        public SelectionController(SelectionView view)
        {
            this.View = view;
            this.Model = new WMModel();
            this.Model.AddObserver(this);
        }

        /**
        /// \fn public void LoadLibrary()
        ///
        /// \brief Loads the library.
        ///
        /// \author Simon Menetrey
        /// \date 26.05.2014
        **/

        public void LoadLibrary()
        {
            this.Model.LoadLibrary();
        }

        /**
        /// \fn public void LoadWebradios()
        ///
        /// \brief Loads the webradios.
        ///
        /// \author Simon Menetrey
        /// \date 26.05.2014
        **/

        public void LoadWebradios()
        {
            this.Model.LoadWebradios();
        }

        /**
        /// \fn public void UpdateView()
        ///
        /// \brief Updates the view.
        ///
        /// \author Simon Menetrey
        /// \date 26.05.2014
        **/

        public void UpdateView()
        {
            this.View.UpdateView();
        }

        /**
        /// \fn public List<Webradio> GetWebradios()
        ///
        /// \brief Gets the webradios list.
        ///
        /// \author Simon Menetrey
        /// \date 26.05.2014
        ///
        /// \return The webradios list.
        **/

        public List<Webradio> GetWebradios()
        {
            return this.Model.GetWebradios();
        }

        /**
        /// \fn public bool CreateWebradio(string name)
        ///
        /// \brief Creates a webradio.
        ///
        /// \author Simon Menetrey
        /// \date 26.05.2014
        ///
        /// \param name The webradio's name.
        ///
        /// \return true if it succeeds, false if it fails.
        **/

        public bool CreateWebradio(string name)
        {
            return this.Model.CreateWebradio(name);
        }

        /**
        /// \fn public bool DeleteWebradio(int id)
        ///
        /// \brief Deletes the webradio described by ID.
        ///
        /// \author Simon Menetrey
        /// \date 26.05.2014
        ///
        /// \param id The identifier.
        ///
        /// \return true if it succeeds, false if it fails.
        **/

        public bool DeleteWebradio(int id)
        {
            return this.Model.DeleteWebradio(id);
        }

        /**
        /// \fn public bool DuplicateWebradio(int id)
        ///
        /// \brief Duplicate webradio described by id.
        ///
        /// \author Simon Menetrey
        /// \date 26.05.2014
        ///
        /// \param id The identifier.
        ///
        /// \return true if it succeeds, false if it fails.
        **/

        public bool DuplicateWebradio(int id)
        {
            return this.Model.DuplicateWebradio(id);
        }

        /**
        /// \fn public void OpenWebradio(int id)
        ///
        /// \brief Opens a webradio described by id in an AdminView.
        ///
        /// \author Simon Menetrey
        /// \date 26.05.2014
        ///
        /// \param id The identifier.
        **/

        public void OpenWebradio(int id)
        {

            AdminController admincontroller = new AdminController(id, this.Model);
            this.Model.AddObserver(admincontroller);
        }

        /**
        /// \fn public bool StopAllProcess()
        ///
        /// \brief Stops all process.
        ///
        /// \author Simon Menetrey
        /// \date 26.05.2014
        ///
        /// \return true if it succeeds, false if it fails.
        **/

        public bool StopAllProcess()
        {
            return this.Model.StopAllProcess();
        }
        #endregion

    }
}
