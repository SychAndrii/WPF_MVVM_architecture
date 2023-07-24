using MVVM.Infrastructure.Commands;
using MVVM.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MVVM.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        #region Properties

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

        #endregion

        #region Comamnds

        #region CloseApplicaitonCommand

        public ICommand CloseApplicationCommand { get; }

        private void OnCloseApplicationCommand(object param)
        {
            Application.Current.Shutdown();
        }

        private bool CanCloseApplicationCommand(object param) => true;

        #endregion

        #endregion

        #region Constructors

        public MainWindowViewModel()
        {
            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommand, CanCloseApplicationCommand);
        }

        #endregion
    }
}
