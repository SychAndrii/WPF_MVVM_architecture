using MVVM.Infrastructure.Commands;
using MVVM.Models;
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

        #region DataPoints

        private IEnumerable<DataPoint> _TestDataPoints;

        public IEnumerable<DataPoint> TestDataPoints
        {
            get
            {
                return _TestDataPoints;
            }
            set
            {
                Set(ref _TestDataPoints, value);
            }
        }

        #endregion

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

            var dataPoints = new List<DataPoint>((int)(360 / 0.1));
            for (double i = 0; i <= 360; i += .1)
            {
                const double TO_RAD = Math.PI / 180;
                var y = Math.Sin(i * TO_RAD);
                dataPoints.Add(new DataPoint() { XValue = i, YValue = y });
            }

            TestDataPoints = dataPoints;
        }

        #endregion
    }
}
