using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using TimeSheetApp.data;

namespace TimeSheetApp.ViewModel
{
    public class MainViewModel : ViewModelBase
    {

        #region Attributs

        private ViewModelBase _currentView;
        private string _utilisateur;
        private double _minWidth;
        private double _minHeight;

        #region Enum
        public enum TimeSheetOnglet//pour la mémorisation des ongles de timeSheet
        {
            TimeSheet,
            TimeSheetDetail

        }
        public enum TacheOnglet//pour la mémorisation des ongles de tache
        {
            Tache,
            TacheDetail,
            TacheAjout
        }

        public enum ProjetOnglet//pour la mémorisation des ongles de projet
        {
            Projet,
            ProjetDetail,
            ProjetAjout
        }


        #endregion




        #endregion

        #region Commandes

        public ICommand AllerSurTimeSheetCommande { get; set; } //définition de la commande
        public ICommand AllerSurTacheCommande { get; set; }
        public ICommand SortirCommande { get; set; }


        public ICommand GoToProjet { get; set; }

        public ICommand WindowClosing
        {
            get
            {
                return new RelayCommand<CancelEventArgs>(
                    (args) =>
                    {
                    if(Utils.MaterialMessageBox.ShowWithCancel("Vouez vous vraiment quitter l'application ?") != MessageBoxResult.OK)
                        { 
                            args.Cancel = true;
                        }
                    });
            }
        }

        #endregion Commandes

        #region Propriétés

        public TimeSheetOnglet TimeSheetOngletActuel { get; set; }
        public TacheOnglet TacheOngletActuel { get; set; }

        public ProjetOnglet ProjetOngletActuel { get; set; }

       

        public ViewModelBase CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                RaisePropertyChanged(() => CurrentView);
                
            }
        }

        //Color Project

        private string _myBackGroundChange;
        public string MyBackGroundProject
        {
            get { return _myBackGroundChange; }
            set
            {
                _myBackGroundChange = value;
                RaisePropertyChanged(() => MyBackGroundProject);
            }
        }

        //Color TimeSheet

        private string _backgroundTimeSheet;

        public string BackGroundTimeSheet
        {
            get { return _backgroundTimeSheet; }
            set
            {
                _backgroundTimeSheet = value;
                RaisePropertyChanged(() => BackGroundTimeSheet);
            }
        }

        //Color Task

        private string _backGroundTask;

        public string BackGroundTask
        {
            get {return _backGroundTask; }
            set
            {
                _backGroundTask = value;
                RaisePropertyChanged(() => BackGroundTask);
            }
        }

        //Default Color
        private string _myBackGround;
        public string MyBackGround
        {
            get { return _myBackGround; }
            set
            {
                _myBackGround = value;
                RaisePropertyChanged(() => MyBackGround);
            }
        }


        public string Utilisateur
        {
            get { return _utilisateur; }
            set
            {
                _utilisateur = value;
                RaisePropertyChanged(() => Utilisateur);
            }
        }

        public double MinWidth
        {
            get { return _minWidth; }
            set
            {
                _minWidth = value;
                RaisePropertyChanged(() => MinWidth);
            }
        }

        public double MinHeight
        {
            get { return _minHeight; }
            set
            {
                _minHeight = value;
                RaisePropertyChanged(() => MinHeight);
            }
        }
        #endregion Propriétés

        #region Méthodes

       

        public void AllerSurTimeSheet()
        {
            if (TimeSheetOngletActuel == TimeSheetOnglet.TimeSheet)
            {
                CurrentView = ViewModelLocator.TimeSheetVeiwModelVm;
                ViewModelLocator.TimeSheetVeiwModelVm.Actualiser();
            }
            else if(TimeSheetOngletActuel == TimeSheetOnglet.TimeSheetDetail)
            {
                ViewModelLocator.TimeSheetVeiwModelVm.AfficherDetail();
            }
          
            BackGroundTimeSheet = MyBackGround;
            MyBackGroundProject = "Gainsboro";
            BackGroundTask = "Gainsboro";
        }

        public void AllerSurTache()
        {
            switch (TacheOngletActuel)
            {
                case TacheOnglet.Tache:
                    CurrentView = ViewModelLocator.TacheViewModelVm;
                    ViewModelLocator.TacheViewModelVm.Actuialiser();
                    break;
                case TacheOnglet.TacheDetail:
                    ViewModelLocator.TacheViewModelVm.AfficherDetail();
                    break;
                case TacheOnglet.TacheAjout:
                    ViewModelLocator.TacheViewModelVm.Ajouter();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            BackGroundTask = MyBackGround;
            MyBackGroundProject = "Gainsboro";
            BackGroundTimeSheet = "Gainsboro";
        }

        public void ShowProjetList()
        {
           /* SimpleIoc.Default.Unregister<ProjetViewModel>();
            SimpleIoc.Default.Register<ProjetViewModel>();*/
            if (ProjetOngletActuel == ProjetOnglet.Projet)
            {
                CurrentView = ViewModelLocator.ProjetView;
                ViewModelLocator.DetailProjetView.RefreshTaskList();
            }
            else if (ProjetOngletActuel == ProjetOnglet.ProjetDetail)
            {
                //MessageBox.Show(ViewModelLocator.ProjetView.SelectProject.ToString());
                ViewModelLocator.ProjetView.ProjectDetail();


            }
            else if (ProjetOngletActuel == ProjetOnglet.ProjetAjout)
            {
                ViewModelLocator.ProjetView.ExecuteAddNewProject();
            }
            

            MyBackGroundProject = MyBackGround;
            BackGroundTask = "Gainsboro";
            BackGroundTimeSheet = "Gainsboro";
            

        }

        public void Sortir()
        {
           
            if (ViewModelLocator.TacheAjoutViewModelVm.IsNomModif())
            {
                if (
                    Utils.MaterialMessageBox.ShowWithCancel(
                        "Il y a eu modification dans \"Ajout tache\", voulez vous vraiment quiter l'application sans sauvegarder la modification?") ==
                    MessageBoxResult.OK)
                {
                    if (Application.Current.MainWindow != null) Application.Current.MainWindow.Close();

                }
                else
                {
                    TacheOngletActuel=TacheOnglet.TacheAjout;
                    AllerSurTache();
                }
            }

            else if(ViewModelLocator.TacheDetailViewModelVm.IsNomModif())
            {
                if (
                    Utils.MaterialMessageBox.ShowWithCancel(
                        "Il y a eudans \"Detail tache\", voulez vous vraiment quiter l'application sans sauvegarder la modification?") ==
                    MessageBoxResult.OK)
                {
                    if (Application.Current.MainWindow != null) Application.Current.MainWindow.Close();

                }
                else
                {
                    TacheOngletActuel = TacheOnglet.TacheDetail;
                    AllerSurTache();
                }
            }
            else if (ViewModelLocator.DetailProjetView.MyFieldChanged())
            {
                if (
                    Utils.MaterialMessageBox.ShowWithCancel(
                        "Il y a eu modification dans \"Detail projet\", voulez vous vraiment quiter l'application sans sauvegarder la modification?") ==
                    MessageBoxResult.OK)
                {
                    if (Application.Current.MainWindow != null) Application.Current.MainWindow.Close();

                }
                else
                {
                  ProjetOngletActuel=ProjetOnglet.ProjetDetail;
                    ShowProjetList();
                }
            }
            else if (ViewModelLocator.AddNewProjectView.EmptyFieldTest())
            {
                if (
                    Utils.MaterialMessageBox.ShowWithCancel(
                        "Il y a eu modification dans \"Ajout projet\", voulez vous vraiment quiter l'application sans sauvegarder la modification?") ==
                    MessageBoxResult.OK)
                {
                    if (Application.Current.MainWindow != null) Application.Current.MainWindow.Close();

                }
                else
                {
                    ProjetOngletActuel = ProjetOnglet.ProjetAjout;
                    ShowProjetList();
                }
            }
            else
            {
                if (Application.Current.MainWindow != null) Application.Current.MainWindow.Close();
            }

        }

        #endregion Méthodes

        public MainViewModel()
        {
            CurrentView = (ViewModelBase) ViewModelLocator.TimeSheetVeiwModelVm;
            AllerSurTimeSheetCommande = new RelayCommand(AllerSurTimeSheet);
            AllerSurTacheCommande = new RelayCommand(AllerSurTache);
            SortirCommande = new RelayCommand(Sortir);
            GoToProjet = new RelayCommand(ShowProjetList);
            Utilisateur = "Bienvenu " + Environment.UserName;
            MinWidth = System.Windows.SystemParameters.PrimaryScreenWidth - 100;
            MinHeight = System.Windows.SystemParameters.PrimaryScreenHeight - 100;
            MyBackGround = "#318CE7";
            BackGroundTimeSheet = MyBackGround;
            MyBackGroundProject = "Gainsboro";
            BackGroundTask = "Gainsboro";
            TimeSheetOngletActuel = TimeSheetOnglet.TimeSheet;
            TacheOngletActuel = TacheOnglet.Tache;
            ProjetOngletActuel=ProjetOnglet.Projet;
        }
    }
}