using MVVM.Infrastructure.Commands;
using MVVM.Models;
using MVVM.Models.Decanat;
using MVVM.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

namespace MVVM.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        #region Properties

        #region SelectedObject
        private Object _SelectedObject;
        public Object SelectedObject
        {
            get
            {
                return _SelectedObject;
            }
            set
            {
                Set(ref _SelectedObject, value, nameof(SelectedObject));
            }
        }
        #endregion

        #region Objects
        public Object[] Objects { get; set; }
        #endregion

        #region SelectedGroup

        private Group _SelectedGroup = null;
        public Group SelectedGroup
        {
            get
            {
                return _SelectedGroup;
            }
            set
            {
                Set(ref _SelectedGroup, value);
            }
        }

        #endregion

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

        #region Groups
        public ObservableCollection<Group> Groups { get; set; }
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

        #region AddGroupCommand
        public ICommand AddGroupCommand { get; }

        public bool CanExecuteAddGroupCommand(object obj) => true;

        public void ExecuteAddGroupCommand(object obj)
        {
            Group g = new Group()
            {
                Name = $"Group {Groups.Count + 1}",
                Students = new ObservableCollection<Student>()
            };
            Groups.Add(g);
        }
        #endregion

        #region RemoveGroupCommand
        public ICommand RemoveGroupCommand { get; }

        public bool CanExecuteRemoveGroupCommand(object obj)
        {
            return obj is Group g && Groups.Contains(g);
        }

        public void ExecuteRemoveGroupCommand(object obj)
        {
            if(obj is Group g)
                Groups.Remove(g);
        }
        #endregion

        #endregion

        #region Constructors

        public MainWindowViewModel()
        {
            AddGroupCommand = new LambdaCommand(ExecuteAddGroupCommand, CanExecuteAddGroupCommand);
            RemoveGroupCommand = new LambdaCommand(ExecuteRemoveGroupCommand, CanExecuteRemoveGroupCommand);

            var dataPoints = new List<DataPoint>((int)(360 / 0.1));
            for (double i = 0; i <= 360; i += .1)
            {
                const double TO_RAD = Math.PI / 180;
                var y = Math.Sin(i * TO_RAD);
                dataPoints.Add(new DataPoint() { XValue = i, YValue = y });
            }

            TestDataPoints = dataPoints;

            int studentIdx = 1;

            var students = Enumerable
                .Range(1, 10)
                .Select(I => new Student
                {
                    Name = $"Name {studentIdx}",
                    Surname = $"Surname {studentIdx}",
                    Patronymic = $"Patronymic {studentIdx++}",
                    Birthday = DateTime.Now,
                    Rating = 4.0
                });

            var groups = Enumerable
                .Range(1, 20)
                .Select(i => new Group
                {
                    Name = $"Group {i++}",
                    Students = new ObservableCollection<Student>(students)
                });

            Groups = new ObservableCollection<Group>(groups);

            var dataList = new List<Object>();
            dataList.Add(42);
            dataList.Add("String");
            dataList.Add(Groups[0]);
            dataList.Add(Groups[0].Students.ElementAt(0));

            Objects = dataList.ToArray();
        }

        #endregion
    }
}
