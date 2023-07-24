﻿using MVVM.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        #region WindowTitle
        private string _WindowTitle = "Default Title";

        /// <summary>
        /// Title of main window.
        /// </summary>
        public string WindowTitle
        {
            get { return _WindowTitle; }
            set
            {
                Set(ref _WindowTitle, value, "WindowTitle");
            }
        }
        #endregion

        #region AppStatus
        private string _appStatus = "Ready!";
        /// <summary>
        /// Status of your application at the bottom of the main window.
        /// </summary>
        public string AppStatus
        {
            get
            {
                return _appStatus;
            }
            set
            {
                Set(ref _appStatus, value, "AppStatus");
            }
        }
        #endregion
    }
}
