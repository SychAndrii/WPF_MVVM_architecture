using MVVM.ViewModels.Base;
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
    }
}
