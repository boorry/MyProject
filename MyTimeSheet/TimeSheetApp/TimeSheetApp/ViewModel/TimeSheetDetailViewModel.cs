using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using BespokeFusion;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.VisualBasic;
using TimeSheetApp.data;
using TimeSheetApp.Model;
using TimeSheetApp.Utils;
using TimeSheetApp.View;
using Task = TimeSheetApp.data.Task;
/*Tsiry 
 * dérnier modif : 08-12-2017
 */
namespace TimeSheetApp.ViewModel
{
    //Cette classe est lié à la vue "TimeSheetDetailView", elle sérvira à faire le traitement des actions de l'utilisateur sur cette vue
    // et aussi d'interagire avec la base
    //elle charge les différents informations sur le "TimeSheet", avac la possibiliter
    //de le lancement, de ma pettre en pause ou de l'arret

    public class TimeSheetDetailViewModel : ViewModelBase
    {
        #region Attribut
        private IService _service;// le sérvice sérvira à toutes les interractions avec la base de données

        private VProjectTaskUser _element;//"_element" est l'élement Selectionnée evoyer par "TimeSheetViewModel"
        private Project _contenuPrj;//"_contenuPrj" le projet lié à l' élement"
        //les information sur le projet
        private string _nomProjet;
        private string _description;
        private string _client;
        private string _durrEeEstimE;
        private string _durrEeTotal;
        private string _dateDebutPrj;

        private Task _contenuTache;//"_contenuTache" la tache liée à l'élement
        //les infos sur la tache
        private string _nomTache;
        private string _etatTache;
        private string _dateDebutTache;
        private string _dateFinTache;
        private string _durrEEffEctiveTache;

        #endregion

        #region Commandes
        //les commandes sont liées à la vue par le "Binding" et en suite liées à differents méthodes pour faire les traitements
        public ICommand RetourCommand { get; set; }
        public ICommand LancerOuPauserTacheCommand { get; set; }
        public ICommand ActualiserCommand { get; set; }


        public ICommand StopCommand { get; set; }

        #endregion


        #region Proprietés
        //les Propriétes sont les données qui sont affichées par la vue via le "Binding"
        public string EtatTache
        {
            get { return _etatTache; }
            set
            {
                _etatTache = value;
                RaisePropertyChanged(() => EtatTache);
            }
        }

        public string NomProjet
        {
            get { return _nomProjet; }
            set
            {
                _nomProjet = value;
                RaisePropertyChanged(() => NomProjet);
            }
        }
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                RaisePropertyChanged(() => Description);
            }
        }
        public string Client
        {
            get { return _client; }
            set
            {
                _client = value;
                RaisePropertyChanged(() => Client);
            }
        }
        public string DurrEeEstimE
        {
            get { return _durrEeEstimE; }
            set
            {
                _durrEeEstimE = value;
                RaisePropertyChanged(() => DurrEeEstimE);
            }
        }
        public string DurrEeTotal
        {
            get { return _durrEeTotal; }
            set
            {
                _durrEeTotal = value;
                RaisePropertyChanged(() => DurrEeTotal);
            }
        }

        public string DateDebutPrj
        {
            get { return _dateDebutPrj; }
            set
            {
                _dateDebutPrj = value;
                RaisePropertyChanged(() => DateDebutPrj);
            }
        }




        public Project ContenuPrj
        {
            get { return _contenuPrj; }
            set
            {
                _contenuPrj = value;
                RaisePropertyChanged(() => ContenuPrj);
            }
        }
        public Task ContenuTache
        {
            get { return _contenuTache; }
            set
            {
                _contenuTache = value;
                RaisePropertyChanged(() => ContenuTache);
            }
        }

        public string NomTache
        {
            get { return _nomTache; }
            set
            {
                _nomTache = value;
                RaisePropertyChanged(() => NomTache);
            }
        }


        public string DateDebutTache
        {
            get { return _dateDebutTache; }
            set
            {
                _dateDebutTache = value;
                RaisePropertyChanged(() => DateDebutTache);
            }
        }

        public string DateFinTache
        {
            get { return _dateFinTache; }
            set
            {
                _dateFinTache = value;
                RaisePropertyChanged(() => DateFinTache);
            }
        }
        public string DurrEEffEctiveTache
        {
            get { return _durrEEffEctiveTache; }
            set
            {
                _durrEEffEctiveTache = value;
                RaisePropertyChanged(() => DurrEEffEctiveTache);
            }
        }
        #endregion Proprietés
        #region Méthodes
        public void Retour()
        {
            //pour s'assurer de la netoyage, on deregistre et enregistre la ViewModel
           /* SimpleIoc.Default.Unregister<TimeSheetDetailViewModel>();
            SimpleIoc.Default.Register<TimeSheetDetailViewModel>();*/
            ViewModelLocator.TimeSheetVeiwModelVm.Actualiser();
            ViewModelLocator.Main.TimeSheetOngletActuel = MainViewModel.TimeSheetOnglet.TimeSheet;
            ViewModelLocator.Main.AllerSurTimeSheet();
        }

        public void Initialiser()// cette méthode est appleler apres la récaption du message de "TimeSheetViewModel"
            //qui contiendra l'élément sélectionné 
        {
            //chargelent de tout les informations
            ContenuPrj = _service.ChargerUnProjet(_element);
            NomProjet = _contenuPrj.ProjectName?.ToString();
            Description = _contenuPrj.Description?.ToString();
            Client = _contenuPrj.CustomerName?.ToString();
          
            
            DurrEeEstimE = _contenuPrj.EstimateDurationProject?.ToString();
            DurrEeTotal = _contenuPrj.DurationProject?.ToString();
            DateDebutPrj = _contenuPrj.StartDate?.ToString();

            ContenuTache = _service.TaskCharger(_element.TaskID);
            NomTache = _contenuTache.TaskName?.ToString();


            EtatTache = _service.MapTaskStateLireEtatAPartirDUnProjectTaskUser(_element);
            DateDebutTache = _element.StartTask?.ToString();
            DateFinTache = _element.EndTask?.ToString();
            DurrEEffEctiveTache = _element.ExecutionTime?.ToString();
        }

        public void Actualiser()
        {
            //on met à null le service pour s'assurer que l'actualisation entre la base et l'application se fait bien
            _service = null;
            _service = new Service();
            //on charger l'element depui la base et on initialise pour s'assurer le la cohérence des donnée affichées
            _element = _service.VProjectTaskUserChargerUn(_element.ProjectTaskUserID);
            Initialiser();
        }

        //pour les actions liées au "TimeSheet" actuel
        //Ici "Outils" est une classe qui contiendra les méthodes qui seront utiliser dans toute l'application
        private void LancerOuPauserTache()
        {
            if (Utils.Outils.VerificationSiAppacrientAlUtilisateurCourant(_element)) //vérification du doit
            {
                if (EtatTache.Equals("En cours") || EtatTache.Equals("En Cours"))
                {
                    Outils.MettreEnPause(_element);
                }
                else if (EtatTache.Equals("En pause"))
                {
                    Outils.LancerUnEnPause(_element);

                }
                else if (EtatTache.Equals("Engagé"))
                {
                    Outils.LancerUnEngagE(_element);


                }
                else if (EtatTache.Equals("Terminé"))
                {
                    Outils.LancerUnTerminE(_element);
                }
                Actualiser();
            }
            else
            {
                Utils.MaterialMessageBox.ShowWarning("Cette tache ne vous appartien pas !!");
            }
        }
        public void Stoper()
        {
            Outils.Stoper(_element);
            Actualiser();
        }

        public void LectureDuMessageEtInitialisation(VProjectTaskUser selection)//cette méthode  qand  on choisie d'afficher les détails d'un "TimeSheet"
            //il est liée au systeme de méssagerie qui reçoi de "TimeSheetViewModel" l'élement sélectionné
        { 
            _element = selection;
            Initialiser();
        }
        #endregion Méthode
        public TimeSheetDetailViewModel()
        {

            _service = new Service();
            RetourCommand = new RelayCommand(Retour);
            LancerOuPauserTacheCommand = new RelayCommand(LancerOuPauserTache);//avec parametre
            StopCommand = new RelayCommand(Stoper);
            ActualiserCommand = new RelayCommand(Actualiser);

           Messenger.Default.Register<VProjectTaskUser>(this, LectureDuMessageEtInitialisation); //on s'abbonne au systeme de mesagerie

        }


    }

}
