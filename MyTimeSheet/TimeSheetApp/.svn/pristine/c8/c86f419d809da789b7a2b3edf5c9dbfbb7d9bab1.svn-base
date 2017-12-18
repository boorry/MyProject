using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using MyDataCustomer.data;
using TimeSheetApp.Model;
using TimeSheetApp.data;
using TimeSheetApp.Utils;
using TimeSheetApp.View;

namespace TimeSheetApp.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class ProjetViewModel : ViewModelBase
    {
        private IProjectService _service;
        public RelayCommand FilterProject { get; set; }
        public ICommand DisplayProjectDetail { get; set; }
        public ICommand DisplayAddNewProject { get; set; }
        public ICommand CancelMySearche { get; set;}
        

        /// <summary>
        /// Initializes a new instance of the ProjetViewModel class.
        /// </summary>
        public ProjetViewModel()
        {
            _service = new ProjectService();
            ProjetContentList = _service.ListProjectList();
            FilterProject = new RelayCommand(ExecuteFiltre);
            DisplayProjectDetail = new RelayCommand(ProjectDetail);
            DisplayAddNewProject = new RelayCommand(ExecuteAddNewProject);
            CancelMySearche = new RelayCommand(CancelFiltre);
            
        }

        //Libele

        private string _libelle;

        public string Libelle
        {
            get { return _libelle; }
            set
            {
                _libelle = value;
                RaisePropertyChanged(() => Libelle);
            }
        }

        public void ExecuteAddNewProject()
        {
            ViewModelLocator.Main.CurrentView = ViewModelLocator.AddNewProjectView;
            ViewModelLocator.AddNewProjectView.RefreshTask();
            ViewModelLocator.Main.ProjetOngletActuel = MainViewModel.ProjetOnglet.ProjetAjout;
        }
        

        public void ProjectDetail ()
        {
            if (SelectProject == null)
                MaterialMessageBox.ShowWarning("Veuillez sélectionner d'abord dans la liste");
            else
            {
                
                Messenger.Default.Send(SelectProject);
                //ViewModelLocator.DetailProjetView.CopyProjectDetail();
                /*SimpleIoc.Default.Unregister<ProjetViewModel>();
                 SimpleIoc.Default.Register<ProjetViewModel>();*/
                ViewModelLocator.Main.CurrentView = ViewModelLocator.DetailProjetView;
                ViewModelLocator.Main.ProjetOngletActuel = MainViewModel.ProjetOnglet.ProjetDetail;
            }

        }

        public void RefreshDetailProject()
        {
            ViewModelLocator.Main.CurrentView = ViewModelLocator.DetailProjetView;
        }

        private List<Project> _projetContentList;
        public List<Project> ProjetContentList
        {
            get { return _projetContentList; }
            set
            {
                _projetContentList = value;
                RaisePropertyChanged(() => ProjetContentList);
                ProjectNumber = ProjetContentList.Count;
                Libelle = ProjectNumber > 1 ? " résultats" : " résultat";
            }
        }

        //count display result
        private int _projectNumber;

        public int ProjectNumber
        {
            get { return _projectNumber; }
            set
            {
                _projectNumber = value;
                RaisePropertyChanged(() => ProjectNumber);
            }
        }

        private void ExecuteFiltre()
        {
            ProjetContentList = _service.SearchProjects(ProjectFilter);
        }

        private string _projectFilter;
        public string ProjectFilter
        {
            get
            {
                return _projectFilter;
            }
            set
            {
                if (value != _projectFilter)
                {

                    _projectFilter = value;
                    RaisePropertyChanged(() => ProjectFilter);
                }
            }
        }

        // Cancel Filtre search

        private void CancelFiltre()
        {
            ProjectFilter = "";
            ProjetContentList = _service.ListProjectList();
        }

        //SelectProject

        private Project _selectProject;
        public Project SelectProject
        {
            get { return _selectProject; }
            set
            {
                _selectProject = value;
                RaisePropertyChanged(() => SelectProject);
                ViewModelLocator.DetailProjetView.CopyProjectDetail();
            }
            
        }

        //BacKground color selected
        private string _myTestColor;

        public string MyTestColor
        {
            get { return _myTestColor; ; }
            set
            {
                _myTestColor = value;
                RaisePropertyChanged(() => MyTestColor);
            }
        }

        //Refresh Project
        public ICommand RefreSheProjectList => new RelayCommand(() =>
        {
            if (ProjectFilter != null)
            {
                ProjetContentList = _service.SearchProjects(ProjectFilter);
            }
            else
            {
                ProjetContentList = _service.ListProjectList();
            }
            
        });

        // Refresh Data Base

        public void MyDataBaseTorRefresh()
        {
            _service = null;
            _service = new ProjectService();
        }
    }
}