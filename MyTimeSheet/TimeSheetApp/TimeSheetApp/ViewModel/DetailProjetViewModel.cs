using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Eventing.Reader;
using System.Reflection;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Helpers;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using MaterialDesignThemes.Wpf;
using MyDataCustomer.data;
using TimeSheetApp.Model;
using TimeSheetApp.data;
using TimeSheetApp.Utils;
using TimeSheetApp.View;
using static System.Windows.MessageBox;

namespace TimeSheetApp.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class DetailProjetViewModel : ViewModelBase
    {
        private HistoriqueProjetView _hitoricWindow;
        private ResearchClientView _clientWindow;
        
        private readonly IProjectService _service;
        public Project ContentProject;

        public RelayCommand ViewHistoryProject { get; set; }
        public RelayCommand ViewClientList { get; set; }
        public RelayCommand DetailSaveChange { get; set; }
        public RelayCommand AddTaskCommand { get; set; }
        public RelayCommand RemovTaskCommand { get; set; }
        public RelayCommand DeleteProject { get; set; }
        

        /// <summary>
        /// Initializes a new instance of the DetailProjetViewModel class.
        /// </summary>
        public DetailProjetViewModel()
        {
            _service = new ProjectService();
            CopyProjectDetail();
            ListTacheMinus = _service.ListTaskWhenProject(NameProject);
            TaskList = _service.ListTacheToAdd();
            ViewHistoryProject = new RelayCommand(CopyHistory);
            ViewClientList = new RelayCommand(GotoClientList);
            DetailSaveChange = new RelayCommand(ExecuteSaveDetail);
            AddTaskCommand = new RelayCommand(AddTaskInToListTask);
            RemovTaskCommand = new RelayCommand(RemovTaskSelected);
            DeleteProject = new RelayCommand(ExecuteDeleteProjectSelected);

            Messenger.Default.Register<Project>(this, MemoriseSelect);
        }

        public void RefreshTaskList()
        {
            TaskList = _service.ListTacheToAdd();
        }

        // List Task

        private List<data.Task> _taskList;

        public List<data.Task> TaskList
        {
            get { return _taskList; }
            set
            {
                _taskList = value;
                RaisePropertyChanged(() => TaskList);
            }
        } 
        
        //AddTaskToMinus

        private Task _addTaskToMinus;
        public Task AddTaskToMinus
        {
            get { return _addTaskToMinus; }
            set
            {
                _addTaskToMinus = value;
                RaisePropertyChanged(() => AddTaskToMinus);
            }
        }
        public void AddTaskInToListTask()
        {
            ProjectService addTaskService = new ProjectService();
            if (AddTaskToMinus == null)
            {
                MaterialMessageBox.ShowWarning("Veuillez sélectionner la tâche à ajouter !");
            }
            else if (addTaskService.TaskExist(AddTaskToMinus.TaskID, ContentProject.ProjectID) != null)
            {

                MaterialMessageBox.ShowWarning("La tâche " + AddTaskToMinus.TaskName + " est déja attachée au projet " +
                                               ContentProject.ProjectName);
            }
            else
            {

                addTaskService.AddTaskToListToDo(ContentProject.ProjectID, AddTaskToMinus.TaskID);
                AutoClosingMessageBox.Show(AddTaskToMinus.TaskName + " ajoutée", "Confirmation", 2000);
                TaskList.Remove(AddTaskToMinus);
                List<data.Task> remove = new List<Task>();
                remove = TaskList;
                TaskList = null;
                TaskList = remove;
                ListTacheMinus = _service.ListTaskWhenProject(NameProject);
            }
        
        }
        
        //TakaOff TAsk
        private VProjectTask _remooveTask;

        public VProjectTask RemoovTask
        {
            get { return _remooveTask; }
            set
            {
                _remooveTask = value;
                RaisePropertyChanged(() => RemoovTask);
                //MessageBox.Show(RemoovTask.TaskName.ToString());
            }
        }

        public void RemovTaskSelected()
        {
            if (CountTask == 0)
            {
                 MaterialMessageBox.ShowWarning("La liste est vide, " + " ajoutez d'abord");
            }
            else
            {
               if (RemoovTask == null)
               {
                  MaterialMessageBox.ShowWarning("Veuillez sélectionner la tâche à retirer !");
               }

               else
               {
                    Service service = new Service();
                    ListTacheMinus.Remove(RemoovTask);
                    ProjectService sss = new ProjectService();
                    AutoClosingMessageBox.Show(RemoovTask.TaskName + " retirée", "Confirmation", 2000);
                    sss.RemoovTaskToList(ContentProject.ProjectID, RemoovTask.TaskID);
                    ListTacheMinus = _service.ListTaskWhenProject(NameProject);
               }
              }
           
        }

        // Get CustomerSelected

        private VCustomers _clientGet;
        public void ClientNameGet()
        {
           _clientGet = ViewModelLocator.ResearchClientVm.ClientSelected;
           CustomerName = _clientGet.Customername;
            
        }

        public void ChangeMyCustomer()
        {
            CustomerName = "";
            CustomerName = ViewModelLocator.ResearchClientVm.ClientSelected.Customername;
        }

        // TEst Field Changed

        public bool MyFieldChanged()
        {
            if(ContentProject != null)
            if (!ContentProject.EstimateDurationProject.Equals(EstimateDuration) || (ContentProject.StartDate != StartDateProject) || (ContentProject.ProjectName != NameProject) ||
                (ContentProject.CustomerName != CustomerName) || (ContentProject.Description != DescriptionProject))
            {
                return true;
            }
            return false;
        }

        // dfqsfdsfs

        public bool IfHaveChenge()
        {
            ProjectService test = new ProjectService();
            
                var projetOld = test.IfMyProject(ContentProject);

            MessageBox.Show(projetOld.ProjectName+  " et " + ContentProject.ProjectName);
            if (projetOld.ProjectName.Equals(ContentProject.ProjectName))
                {
                    
                        return false;
                }
                 else
                {
                    MessageBox.Show("Different " + projetOld.ProjectName.ToString());
                    return true;
                }

        }

        //DetailSaveChange

        public void ExecuteSaveDetail()
        {
            ProjectService servir = new ProjectService();

            if (!ContentProject.EstimateDurationProject.Equals(EstimateDuration))
            {
                if (MaterialMessageBox.ShowWithCancel("Voulez-vous sauvegarder le changement ?") == MessageBoxResult.OK)
                {
                    MaterialMessageBox.Show(servir.AddProjectHistories(ContentProject.ProjectID, ContentProject.EstimateDurationProject, EstimateDuration, DateTime.Now, Environment.UserName) ? "Mise à jour du projet : "+ContentProject.ProjectName+" réussi !" : "Save Not done");
                    Modificator = Environment.UserName;
                    ModifyDate = DateTime.Now;
                    ContentProject.ModificationDate = ModifyDate;
                    ContentProject.ModifiedBy = Modificator;
                    ContentProject.EstimateDurationProject = EstimateDuration;
                    servir.UpdateProject(ContentProject);
                    ViewModelLocator.AddNewProjectView.RefreshSave();
                }
                
            }
            else if (!NameProject.Equals(ContentProject.ProjectName))
            {

                if (servir.ProjecNameDetailExist(NameProject))
                {
                    MaterialMessageBox.ShowWarning("Le nom de projet que vous avez entré existe déja, " +
                                               " veuillez modifier le nom avant d'enregistrer");
                }
                else if (MyFieldChanged())
                {
                    if (MaterialMessageBox.ShowWithCancel("Voulez-vous sauvegarder le(s) changement(s) ?") == MessageBoxResult.OK)
                    {
                        ContentProject.ProjectName = NameProject;
                        ContentProject.Description = DescriptionProject.Trim();
                        ContentProject.CustomerName = CustomerName;
                        ContentProject.StartDate = StartDateProject;
                        Modificator = Environment.UserName;
                        ModifyDate = DateTime.Now;
                        ContentProject.ModificationDate = ModifyDate;
                        ContentProject.ModifiedBy = Modificator;
                        servir.ChangeCustomer(ContentProject);
                        MaterialMessageBox.Show("Mise à jour du projet :  " + ContentProject.ProjectName + " réussi !");
                        ViewModelLocator.AddNewProjectView.RefreshSave();
                    }

                }
            }
            
            else
            {
                MaterialMessageBox.ShowWarning("Aucune modification n'a été faite !");
            }
            
        }
        
        public void GotoClientList()
        {
            _clientWindow = new ResearchClientView();
            _clientWindow.ShowDialog();
        }
        public void CloseClientWindow()
        {
            _clientWindow.Close();
            _clientWindow = null;
        }
        public void TestFermeture()
        {
            HistoriqueProjetView tt = new HistoriqueProjetView();
            tt.Close();
            //var clientVm = ViewModelLocator.ResearchClientVm;
        }
        //tache
        private List<VProjectTask> _listTacheMinus;
        public List<VProjectTask> ListTacheMinus
        {
            get { return _listTacheMinus; }
            set
            {
                _listTacheMinus = value;
                RaisePropertyChanged(() => ListTacheMinus);
                CountTask = ListTacheMinus.Count;
                IsTasks = CountTask > 1 ? "des tâches" : "une tâche";

            }
        }

        private string _isTasks;

        public string IsTasks
        {
            get { return _isTasks; }
            set
            {
                _isTasks = value;
                RaisePropertyChanged(() => IsTasks);
            }
        }

        //Count Task relied project selected
        private int _countTask;
        public int CountTask
        {
            get { return _countTask; }
            set
            {
                _countTask = value;
                RaisePropertyChanged(() => CountTask);
            }
        }
        public void CopyHistory()
        {
           //_hitoricWindow = null;
             _hitoricWindow = new HistoriqueProjetView();
             _hitoricWindow.ShowDialog();
        }
        public void CloseHistoricWindow()
        {
            _hitoricWindow.Close();
            _hitoricWindow = null;
        }
        public ICommand BackToHomeProject => new RelayCommand(() =>
        {
            try
            {
                if (MyFieldChanged())
                {
                    if (MaterialMessageBox.ShowWithCancel("Des modifications ont été faites, voulez-vous continuer ?") == MessageBoxResult.OK)
                    {
                        ViewModelLocator.Main.ProjetOngletActuel = MainViewModel.ProjetOnglet.Projet;
                        ViewModelLocator.ProjetView.ProjetContentList = _service.ListProjectList();
                        /*SimpleIoc.Default.Unregister<DetailProjetViewModel>();
                        SimpleIoc.Default.Register<DetailProjetViewModel>();*/
                        ViewModelLocator.Main.ShowProjetList();
                    }
                }
                else
                {
                    ViewModelLocator.Main.ProjetOngletActuel = MainViewModel.ProjetOnglet.Projet;
                    ViewModelLocator.ProjetView.ProjetContentList = _service.ListProjectList();
                    /*SimpleIoc.Default.Unregister<DetailProjetViewModel>();
                    SimpleIoc.Default.Register<DetailProjetViewModel>();*/
                    ViewModelLocator.Main.ShowProjetList();
                }
            }
            catch (Exception)
            {

                //MessageBox.Show(e.ToString());
                return;
            }
           
        });
        public void CopyProjectDetail()
        {
            try
            {
                ContentProject = ViewModelLocator.ProjetView.SelectProject;
                NameProject = ContentProject.ProjectName;
                DescriptionProject = ContentProject.Description.Trim();
                EstimateDuration = ContentProject.EstimateDurationProject;
                TotalDuration = ContentProject.DurationProject;
                CreatorProject = ContentProject.CreatedBy;
                CreationDate = ContentProject.CreationDate.Date;
                Modificator = ContentProject.ModifiedBy;
                ModifyDate = ContentProject.ModificationDate;
                CustomerName = ContentProject.CustomerName;
                StartDateProject = ContentProject.StartDate;
                EndDateProject = ContentProject.EndDate;
                ListTacheMinus = _service.ListTaskWhenProject(NameProject);
            }
            catch (Exception )
            {
                //MessageBox.Show(e.ToString());
                return;
            }
            

        }

        private DateTime? _endDateProject;
        public DateTime? EndDateProject
        {
            get { return _endDateProject; }
            set
            {
                _endDateProject = value;
                RaisePropertyChanged(() => EndDateProject);
            }
        }

        private DateTime? _startDateProject;
        public DateTime? StartDateProject
        {
            get { return _startDateProject; }
            set
            {
                _startDateProject = value;
                RaisePropertyChanged(() => StartDateProject);
            }
        }

        private string _customerName;
        public string CustomerName
        {
            get { return _customerName; }
            set
            {
                _customerName = value;
                RaisePropertyChanged(() => CustomerName);
            }
        }

        private string _nameProject;
        public string NameProject
        {
            get { return _nameProject; }
            set
            {
                _nameProject = value;
                RaisePropertyChanged(() => NameProject);
               
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
        private float? _totalDuration;
        public float? TotalDuration
        {
            get { return _totalDuration; }
            set
            {
                _totalDuration = value;
                RaisePropertyChanged(() => TotalDuration);
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

        private DateTime? _modifyDate;

        public DateTime? ModifyDate
        {
            get { return _modifyDate; }
            set
            {
                _modifyDate = value;
                RaisePropertyChanged(() => ModifyDate);
            }
        }

        //Delete Project
        public void ExecuteDeleteProjectSelected()
        {
           
            Service service=new Service();
            if ((service.ProjectTaskUserProjetEstDedans(ContentProject)))
            {
                MaterialMessageBox.ShowError("Le Projet " + ContentProject.ProjectName + " est utilisé dans le TimeSheet, vous ne pouvez pas le supprimer");
            }
            else
            {
                if (MaterialMessageBox.ShowWithCancel("Etes-vous sûr de supprimer le projet " + ContentProject.ProjectName + " ?") == MessageBoxResult.OK)
                {
                    
                    ProjectService myService = new ProjectService();
                    myService.DeleteTaskUserProject(ContentProject.ProjectID);
                    myService.DeleteHistoryProject(ContentProject.ProjectID);
                    myService.DeleteTaskProject(ContentProject.ProjectID);
                    ViewModelLocator.Main.CurrentView = ViewModelLocator.ProjetView;
                    
                    if (myService.DeleteProjectInDetail(ContentProject.ProjectID))
                    {
                        AutoClosingMessageBox.Show("Projet " + ContentProject.ProjectName + " supprimé", "Confirmation", 2000);
                    }
                    else
                    {
                        MaterialMessageBox.ShowWarning("Command not Done !");
                    }
                    ViewModelLocator.ProjetView.ProjetContentList = _service.ListProjectList();

                }
            }

        }

        public class AutoClosingMessageBox
        {
            readonly System.Threading.Timer _timeoutTimer;
            readonly string _caption;
            AutoClosingMessageBox(string text, string caption, int timeout)
            {
                _caption = caption;
                _timeoutTimer = new System.Threading.Timer(OnTimerElapsed,
                    null, timeout, System.Threading.Timeout.Infinite);
                using (_timeoutTimer)
                    MessageBox.Show(text, caption);
            }
            public static void Show(string text, string caption, int timeout)
            {
                new AutoClosingMessageBox(text, caption, timeout);
            }
            void OnTimerElapsed(object state)
            {
                IntPtr mbWnd = FindWindow("#32770", _caption); // lpClassName is #32770 for MessageBox
                if (mbWnd != IntPtr.Zero)
                    SendMessage(mbWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
                _timeoutTimer.Dispose();
            }
            const int WM_CLOSE = 0x0010;
            [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
            static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
            [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
            static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
        }

        public void MemoriseSelect(Project mySelectede)//lit le message du "TacheViewModel" avec un "Task" comme parametre
        {
            ContentProject = mySelectede;
            //CopyProjectDetail();
        }

    }
}