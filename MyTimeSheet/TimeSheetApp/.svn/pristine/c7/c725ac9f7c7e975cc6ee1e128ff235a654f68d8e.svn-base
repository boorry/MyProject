using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using MyDataCustomer.data;
using TimeSheetApp.Model;
using TimeSheetApp.data;
using TimeSheetApp.Utils;
using TimeSheetApp.View;
using MessageBox = System.Windows.MessageBox;

namespace TimeSheetApp.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class AddNewProjectViewModel : ViewModelBase, IDataErrorInfo
    {

        private readonly IProjectService _service;
        public RelayCommand AddedSaveChange { get; set; }
        public RelayCommand GotoClientList { get; set; }
        public RelayCommand AddTaskCommand { get; set; }
        public RelayCommand RemovMyTaskCommand { get; set; }
        private CustumerView _clientWind;
        public RelayCommand AddNewTaskProject { get; set; }
        public RelayCommand ReturnTolistProject { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the AddNewProjectViewModel class.
        /// </summary>
        public AddNewProjectViewModel()
        {
           
            _service = new ProjectService();
            AddedSaveChange = new RelayCommand(ProjectAddedSave);
            _creationDate = DateTime.Now;
            GotoClientList = new RelayCommand(VieAllClientList);
            this.StartDateProject = DateTime.Now.AddHours(1);
            CreatorProject = Environment.UserName;
            AddTaskList = _service.ListTacheToAdd();
            AddNewTaskProject = new RelayCommand(AddTaskInToListTaskProject);
            RemovMyTaskCommand = new RelayCommand(RemoveTaskInToListTaskProject);
            ListTacheProject = new List<Task>();
            ReturnTolistProject = new RelayCommand(BackToHomeProject);
            
        }

        private DateTime _myTime;

        public DateTime MyTime
        {
            get { return _myTime; }
            set
            {
                _myTime = value;
                RaisePropertyChanged(() => MyTime);
            }
        }

        // Empty field test

        public bool EmptyFieldTest()
        {
            if ((NewProjectName != null) || (DescriptionProject != null) || (AddCustomerName != null) ||
                (EstimateDuration != null))
            {
                return true;
            }
            return false;
        }
        
        //Back to list project
        public void BackToHomeProject()
        {
            if (EmptyFieldTest())
            {
                if (MaterialMessageBox.ShowWithCancel("Des données ont été modifiées et non sauvégardées." + " Voulez-vous continuer ?") == MessageBoxResult.OK)
                {
                    //ViewModelLocator.Main.CurrentView = ViewModelLocator.ProjetView;
                    ViewModelLocator.Main.ProjetOngletActuel = MainViewModel.ProjetOnglet.Projet;
                    ViewModelLocator.Main.ShowProjetList();
                    SimpleIoc.Default.Unregister<AddNewProjectViewModel>();
                    SimpleIoc.Default.Register<AddNewProjectViewModel>();
                }
                else
                {
                    ViewModelLocator.Main.ProjetOngletActuel = MainViewModel.ProjetOnglet.Projet;
                    ViewModelLocator.Main.ShowProjetList();
                    //ViewModelLocator.Main.CurrentView = ViewModelLocator.ProjetView;
                }
            }
            else
            {
                //ViewModelLocator.Main.CurrentView = ViewModelLocator.ProjetView;
                ViewModelLocator.Main.ProjetOngletActuel = MainViewModel.ProjetOnglet.Projet;
                ViewModelLocator.Main.ShowProjetList();
            }

        }

        // Add Task Command
        public void AddTaskInToListTaskProject()
        {
            if (AddTaskProject == null)
            {
                MaterialMessageBox.ShowWarning("Veuillez sélectionner la tâche à ajouter !");
            }
            else
            {
                ListTacheProject.Add(AddTaskProject);

                List<data.Task> variable = new List<data.Task>();
                variable = ListTacheProject;
                ListTacheProject = null;
                ListTacheProject = variable;
                AddTaskList.Remove(AddTaskProject);
                List<data.Task> remove = new List<Task>();
                remove = AddTaskList;
                AddTaskList = null;
                AddTaskList = remove;
            }
        }

        //Remoove Task Command
        public void RemoveTaskInToListTaskProject()
        {
            
            if (RemoveMyTask == null)
            {
                MaterialMessageBox.ShowWarning("Veuillez sélectionner la tâche à enlever !");
            }
            else
            {
                ListTacheProject.Remove(RemoveMyTask);
                List<data.Task> variable = new List<data.Task>();
                variable = ListTacheProject;
                ListTacheProject = null;
                ListTacheProject = variable;
            }
        }


        //List Task
        private List<data.Task> _addTaskList;

        public List<data.Task> AddTaskList
        {
            get { return _addTaskList; }
            set
            {
                _addTaskList = value;
                RaisePropertyChanged(() => AddTaskList);
            }
        }
        
        // task selected to add
        private Task _addTaskProject;
        public Task AddTaskProject
        {
            get { return _addTaskProject; }
            set
            {
                _addTaskProject = value;
                RaisePropertyChanged(() => AddTaskProject);
            }
        }

        // Task in Project 
        private List<data.Task> _listTacheProject;
        public List<data.Task> ListTacheProject
        {
            get { return _listTacheProject; }
            set
            {
                _listTacheProject = value;
                RaisePropertyChanged(() => ListTacheProject);
            }
        }

        

        // select task in project
        private Task _removeMyTask;

        public Task RemoveMyTask
        {
            get { return _removeMyTask; }
            set
            {
                _removeMyTask = value;
                RaisePropertyChanged(() => RemoveMyTask);
            }
        }

        private VCustomers _geCustomer;
        public void CustomerNameGet()
        {
            GeCustomer = ViewModelLocator.CustomerView.ClientSelected;
            AddCustomerName = GeCustomer.Customername.ToString();
            //MessageBox.Show(_projectGet.CustomerName.ToString());
        }
        public void VieAllClientList()
        {
            _clientWind = new CustumerView();
            _clientWind.ShowDialog();
        }
        public void CloseClientMyWindow()
        {
            _clientWind.Close();
        }

        // My string input

        private string _newProjectName;
        public string NewProjectName
        {
            get { return _newProjectName; }
            set
            {
                _newProjectName = value;
                RaisePropertyChanged(() => NewProjectName);
            }
        }

        // My Function Test
        // ProjectName
        public bool ProjectNameTest()
        {
            if((NewProjectName == null) || (NewProjectName == ""))
            {
                return true;
            }
            
            return false;
        }

        // Description Project
        public bool DescriptionTest()
        {
            if ((DescriptionProject == null) || (DescriptionProject == ""))
            {
                return true;
            }

            return false;
        }

        // Saved Add
        public void ProjectAddedSave()
        {
            ProjectService addTaskService = new ProjectService();
            if (ProjectNameTest())
            {
                MaterialMessageBox.ShowError("Le champ nom de projet est vide !");
            }
            else if (DescriptionTest())
            {
                MaterialMessageBox.ShowError("Le champ description de projet est vide");
            }
            else if (StartDateProject == null)
            {
                MaterialMessageBox.ShowError("Le champ debut de projet est vide");
            }
            else if (EstimateDuration == null)
            {
                MaterialMessageBox.ShowError("Le champ durée estimée est vide");
            }
            else if(addTaskService.ProjectExist(NewProjectName) != null)
            {
                MaterialMessageBox.ShowWarning("Le nom de projet que vous avez entré existe déja, " +
                                               " veuillez modifier le nom avant d'enregistrer");
            }

            else
            {
               addTaskService.NewProjectAdd(NewProjectName, DescriptionProject, AddCustomerName, StartDateProject,
                    EstimateDuration, Environment.UserName, DateTime.Now);
                foreach (var myTak in ListTacheProject)
                {
                    addTaskService.AddTaskToListToDo(addTaskService.MaxProjectId(), myTak.TaskID);
                }
                ViewModelLocator.Main.CurrentView = ViewModelLocator.ProjetView;
                DetailProjetViewModel.AutoClosingMessageBox.Show("Le projet " + NewProjectName + " est bien enrégistré!", "Confirmatin", 2000);
                ViewModelLocator.ProjetView.ProjetContentList = _service.ListProjectList();
                SimpleIoc.Default.Unregister<AddNewProjectViewModel>();
                SimpleIoc.Default.Register<AddNewProjectViewModel>();
                
            }
        }
        

        private DateTime? _startDateProject;
        public DateTime? StartDateProject
        {
            get { return _startDateProject; }
            set
            {
                if (this._startDateProject != value)
                {
                    _startDateProject = value;
                    RaisePropertyChanged(() => this.StartDateProject);
                    RaisePropertyChanged("StartDateProject");
                }
                    //_startDateProject = value;
                    //RaisePropertyChanged(() => StartDateProject);
            }
        }
        private string ValidateCheckInDate()
        {
            if (!this.StartDateProject.HasValue)
            {
                return "Le champ debut de projet ne devrait pas être vide.";
            }
            
            return null;
        }
        string IDataErrorInfo.Error => ValidateCheckInDate();
        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case "StartDateProject": return this.ValidateCheckInDate();
                }
                return null;
            }
            
        }

        private string _addCustomerName;
        public string AddCustomerName
        {
            get { return _addCustomerName; }
            set
            {
                _addCustomerName = value;
                RaisePropertyChanged(() => AddCustomerName);
            }
        }
       

        private string _descriptionProject;
        public string DescriptionProject
        {
            get { return _descriptionProject; }
            set
            {
                _descriptionProject = value;
                RaisePropertyChanged(() => DescriptionProject);
            }
        }

        private float? _estimateDuration;
        public float? EstimateDuration
        {
            get { return _estimateDuration; }
            set
            {
                _estimateDuration = value;
                RaisePropertyChanged(() => EstimateDuration);
                
            }
        }

        private string _creatorProject;
        public string CreatorProject
        {
            get { return _creatorProject; }
            set
            {
                _creatorProject = value;
                RaisePropertyChanged(() => CreatorProject);
            }
        }

        private DateTime _creationDate;
        public DateTime CreationDate
        {
            get { return _creationDate; }
            set
            {
                _creationDate = value;
                RaisePropertyChanged(() => CreationDate);
            }
        }

        private string _modificator;
        public string Modificator
        {
            get { return _modificator; }
            set
            {
                _modificator = value;
                RaisePropertyChanged(() => Modificator);
            }
        }
        public VCustomers GeCustomer
        {
            get
            {return _geCustomer;
            }

            set
            {
                _geCustomer = value;
                RaisePropertyChanged(() => GeCustomer);
            }
        }

        public void RefreshTask()
        {
            AddTaskList = _service.ListTacheToAdd();
        }

        public void RefreshSave()
        {
            ViewModelLocator.Main.CurrentView = ViewModelLocator.DetailProjetView;
        }

    }
}