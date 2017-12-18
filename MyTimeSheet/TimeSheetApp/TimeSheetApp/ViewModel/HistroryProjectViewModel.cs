using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Ioc;
using MaterialDesignThemes.Wpf;
using TimeSheetApp.Model;
using TimeSheetApp.data;
using TimeSheetApp.View;
using RelayCommand = GalaSoft.MvvmLight.Command.RelayCommand;

namespace TimeSheetApp.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class HistroryProjectViewModel : ViewModelBase
    {
        public ICommand PreviewToDetail { get; set; }
        private readonly IProjectService _service;

        /// <summary>
        /// Initializes a new instance of the HistroryProjectViewModel class.
        /// </summary>
        public HistroryProjectViewModel()
        {
            _service = new ProjectService();
            ProjectNameHistory = ViewModelLocator.DetailProjetView.NameProject;
           
            PreviewToDetail = new RelayCommand(GotoPreviewToDetail);
            //TestMyHistories = _service.TestDisplyHistory();
            
            TestViewMyHistories = _service.ListProjectHistory(ViewModelLocator.DetailProjetView.ContentProject.ProjectID);

        }

        private List<VProjectHistory> _testViewHistories;

        public List<VProjectHistory> TestViewMyHistories
        {
            get { return _testViewHistories; }
            set
            {
                _testViewHistories = value;
                RaisePropertyChanged(() => TestViewMyHistories);
                CountHistory = TestViewMyHistories.Count;
                Resultas = CountHistory > 1 ? "resultas" : "resultat";
            }
        } 

        private void GotoPreviewToDetail()
        {
            SimpleIoc.Default.Unregister<HistroryProjectViewModel>();
            SimpleIoc.Default.Register<HistroryProjectViewModel>();
            ViewModelLocator.DetailProjetView.CloseHistoricWindow();
            //TestViewMyHistories = _service.ListProjectHistory(ViewModelLocator.DetailProjetView.ContentProject.ProjectID);
        }
        

        private string _projectNameHistory;

        public string ProjectNameHistory
        {
            get { return _projectNameHistory; }
            set
            {
                _projectNameHistory = value;
                RaisePropertyChanged(() => ProjectNameHistory);
            }
        }

        //Count History

        private string _resultats;

        public string Resultas
        {
            get { return _resultats; }
            set
            {
                _resultats = value;
                RaisePropertyChanged(() => Resultas);
            }
        }

        private int _countHistory;

        public int CountHistory
        {
            get { return _countHistory; }
            set
            {
                _countHistory = value;
                RaisePropertyChanged(() => CountHistory);
            }
        }

    }
}