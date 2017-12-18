using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BespokeFusion;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using TimeSheetApp.data;
using TimeSheetApp.Model;
using TimeSheetApp.View;

/*Tsiry 
 * dérnier modif : 08-12-2017
 */

namespace TimeSheetApp.ViewModel
{
    //Cette classe est lié à la vue "UserTimeView", elle sérvira à faire le traitement des actions de l'utilisateur sur cette vue
    // et aussi d'interagir avec la base
    //elle charge les différents "TaskTime" déja enregistés dans la base avec la possibiliter d'affciher les informations 
    //quand on sélectionne un et la possibilitée de modifier les dates et heurs de début et de fin
    public class UserTimeViewModel : ViewModelBase
    {
        #region attributs
        private IService _service;//qui est en charge d'interragire avec la base
        private List<VTaskTime> _lstVTaskTime;//la liste qui sera afficher dans la dataGrid
        private string _nbResult;//nobre de résulta
        private VTaskTime _selection;//l'élement sélectionné
        private UserTimeHistoryView _winUserTimeHistory;//fenetre qui conservera l'hystorique des modifcation
        private TaskUserTime _taskUserTime;//le "TaskUserTime" lier à la vue sélectionnée
        //pour l'afficha dans les "materialDesign:TimePicker" et "DatePicker" 
        private DateTime? _startHeure;
        private DateTime? _endHeure;
        private bool _isDateFinExiste;
        private bool _isUnSelectionnE;
        private int _indiceSelection;

        private VProjectTaskUser _vProjectTaskUserSelectinE;// la "VProjectTaskUserSelectinE" envoyer par "TimeSheetViewModel" affin de liste seulemnt les TaskUserTime qui lui sont associés

        private enum CodeDErreur//pour les code d'érreur si il y a des érreur lors de l'enregistrement
        {
            DateFinPlusPetitQueDateDebut,
            DateFinDepasse,
            DateDebutDepasse,
            DateDebutAvantDateFinPrecedent,
            DateFinApresDateDebutSuivant,
            PasDerreur
        }

        private CodeDErreur _codeDErreur;


        #region Commandes
        //les commandes sont liées à la vue par le "Binding" et en suite liées à differents méthodes pour faire les traitements
        public ICommand RetourAvecVerificationCommand { get; set; }
        public ICommand SauverCommand { get; set; }
        public ICommand AfficherHistoryCommand { get; set; }
        public ICommand ActualiserCommand { get; set; }

        #endregion
        #endregion

        #region Propriétes
        //les Propriétes sont les données qui sont affichées par la vue via le "Binding"
        public List<VTaskTime> LstVTaskTime
        {
            get { return _lstVTaskTime; }
            set
            {
                _lstVTaskTime = value;
                RaisePropertyChanged(() => LstVTaskTime);
                NbResult = LstVTaskTime.Count.ToString() + " résulta(s)";//on charge le nombre de resultas
            }
        }

        public string NbResult
        {
            get { return _nbResult; }
            set
            {
                _nbResult = value;
                RaisePropertyChanged(() => NbResult);
            }
        }

        public VTaskTime Selection
        {
            get { return _selection; }
            set
            {
                _selection = value;
                RaisePropertyChanged(() => Selection);
                if (Selection != null)
                {
                    TaskUserTime = _service.TaskUserTimeCharger(Selection);//si la sélection existe, on charge le "TaskUserTime" affin d'afficher les dates et heurs qui lui sont associées
                    IsUnSelectionnE = true;
                    _indiceSelection = LstVTaskTime.IndexOf(Selection);
                }
            }
        }

        public bool IsUnSelectionnE
        {
            get { return _isUnSelectionnE; }
            set
            {
                _isUnSelectionnE = value;
                RaisePropertyChanged(() => IsUnSelectionnE);
            }
        }

        public TaskUserTime TaskUserTime
        {
            get { return _taskUserTime; }
            set
            {
                _taskUserTime = value;
                RaisePropertyChanged(() => TaskUserTime);


                //quand on a un "TaskUserTime":
                // on extrait les dates de debut et de fin de "TaskUserTime.startDate", et "TaskUserTime.EndDate"
                //vue que ces dérnier sont on "DateTime" on les chagent en string

                if (TaskUserTime.startDate != null)
                {
                    StartHeure = (DateTime)TaskUserTime.startDate;
                    // StartHeure = dd.ToString("HH:mm:ss");
                }
                else
                {
                    StartHeure = null;
                }


                if (TaskUserTime.EndDate != null)
                {
                    EndHeure = (DateTime)TaskUserTime.EndDate;
                    // EndHeure = dt.ToString("HH:mm:ss");
                    IsDateFinExiste = true;
                }
                else
                {
                    //  EndHeure = "";
                    IsDateFinExiste = false;
                }
            }
        }

        public bool IsDateFinExiste
        {
            get { return _isDateFinExiste; }
            set
            {
                _isDateFinExiste = value;
                RaisePropertyChanged(() => IsDateFinExiste);
            }
        }

        public DateTime? StartHeure
        {
            get { return _startHeure; }
            set
            {
                _startHeure = value;
                RaisePropertyChanged(() => StartHeure);
            }
        }


        public DateTime? EndHeure
        {
            get { return _endHeure; }
            set
            {
                _endHeure = value;
                RaisePropertyChanged(() => EndHeure);
            }
        }



        #endregion

        #region Méthodes

        public void LectureDuMessageEtInitialisation(VProjectTaskUser vProjectTaskUserSelectinE)//cette méthode traite le message envoyer par "TimeSheetViewModel"  
        //avec la VProjectTaskUserSelectinE comme marametre et fait l'initialisation 
        {
            _vProjectTaskUserSelectinE = vProjectTaskUserSelectinE;
            LstVTaskTime = _service.VTaskTimeChargerLstDuProjectTaskUser(_vProjectTaskUserSelectinE);
        }

        public void LectureDuMessage(string message)//cette methode rechoit le message de "TimeHistoryView" demande de la férmer
        {
            if (message.Equals("fermerUserTimeHistoryView"))
                FermerUserTimeHistoryView();
        }

        public void FermerUserTimeHistoryView()
        {
            _winUserTimeHistory?.Close();
        }

        public void RetourAvecVerification()//cette methode pérmet une vérification si il y a eu des modifications avant de férmer la fenetre
        {
            if (Selection != null)
            {
                //on verifie si il y a eu des modification
                if (TaskUserTime.startDate != Selection.startDate || TaskUserTime.EndDate != Selection.EndDate)
                {
                    if (
                        MaterialMessageBox.ShowWithCancel(
                            "il y a eu des (une) modification(s), voulez vous vraiment quiter sans enregistrer les modification?") ==
                        MessageBoxResult.OK)
                    {
                        Retour();
                    }
                }
                else
                {
                    Retour();
                }
            }
            else
            {
                Retour();
            }

        }


        public void Retour()//retour à le fenetre principales
        {
            //pour s'assurer de la netoyage, on deregistre et enregistre la ViewModel
            SimpleIoc.Default.Unregister<UserTimeViewModel>();
            SimpleIoc.Default.Register<UserTimeViewModel>();

            Messenger.Default.Send("fermerUserTimeView");

        }

        public void SauverAjouter()//cette methode modifi le "TaskUserTime" actuel, et ajoute l'encie dans le table "TaskUserTimeHistory" 
        {

            if (Selection != null)
            {
                //il faut extraire les heures de "TaskUserTime.startDate" et "TaskUserTime.EndDate"


                var dd = new DateTime();
                dd = new DateTime();
                if (TaskUserTime.startDate != null)
                {
                    dd = (DateTime)TaskUserTime.startDate;
                }
                var startDate = dd.ToString("MM/dd/yyyy");
                string srtDateDebut = startDate + " " + StartHeure?.ToString("T");
                //on atrribut la nouvelle "TaskUserTime.startDate"
                TaskUserTime.startDate = DateTime.ParseExact(srtDateDebut, "MM/dd/yyyy HH:mm:ss",
                    CultureInfo.InvariantCulture);

                if (EndHeure != null)//si la date de fin existe
                {
                    dd = new DateTime();
                    if (TaskUserTime.EndDate != null)
                    {
                        dd = (DateTime)TaskUserTime.EndDate;
                    }
                    var endDate = dd.ToString("MM/dd/yyyy");
                    var srtDateFin = endDate + " " + EndHeure?.ToString("T");//on réconstitue la date de fin
                                                                             //on attribut le nouveau date de fin
                    TaskUserTime.EndDate = DateTime.ParseExact(srtDateFin, "MM/dd/yyyy HH:mm:ss",
                        CultureInfo.InvariantCulture);
                }



                //VERIFICATION SI IL Y A EU MODIF
                if (Selection.EndDate != TaskUserTime.EndDate ||
                    Selection.startDate != TaskUserTime.startDate)
                {
                    //VERIFICATION DE LA COHERENCE DES DATES
                    if (TaskUserTime.EndDate != null)
                    {
                        if (TaskUserTime.EndDate <= TaskUserTime.startDate) // && TaskUserTime.EndDate <= DateTime.Now)
                        {
                            _codeDErreur = CodeDErreur.DateFinPlusPetitQueDateDebut;
                        }
                        else if (TaskUserTime.EndDate > DateTime.Now)
                        {
                            _codeDErreur = CodeDErreur.DateFinDepasse;
                        }
                        else if (TaskUserTime.startDate > DateTime.Now)
                        {
                            _codeDErreur = CodeDErreur.DateDebutDepasse;
                        }
                        else
                        {
                            _codeDErreur = CodeDErreur.PasDerreur;
                        }
                        if (_indiceSelection > 0)
                        {

                            //MessageBox.Show(TaskUserTime.startDate + " et  " + LstVTaskTime[_indiceSelection - 1].EndDate);
                            if (TaskUserTime.startDate < LstVTaskTime[_indiceSelection - 1].EndDate)
                                _codeDErreur = CodeDErreur.DateDebutAvantDateFinPrecedent;
                            // MessageBox.Show("date debut avant date fin precedent");



                        }
                        if (_indiceSelection < LstVTaskTime.Count - 1)
                        {
                            //MessageBox.Show(TaskUserTime.EndDate + " et  " + LstVTaskTime[_indiceSelection + 1].startDate);
                            if (TaskUserTime.EndDate > LstVTaskTime[_indiceSelection + 1].startDate)
                                _codeDErreur = CodeDErreur.DateFinApresDateDebutSuivant;
                            //MessageBox.Show("date fin apres date debut suivant");
                        }
                    }
                    else
                    {
                        _codeDErreur = TaskUserTime.startDate > DateTime.Now ? CodeDErreur.DateDebutDepasse : CodeDErreur.PasDerreur;
                    }


                    switch (_codeDErreur)
                    {
                        case CodeDErreur.DateFinDepasse:
                            Utils.MaterialMessageBox.ShowError("Erreur: La date de fin depasse la date actuéle");
                            Actualiser();
                            break;
                        case CodeDErreur.DateDebutDepasse:
                            Utils.MaterialMessageBox.ShowError("Erreur: La date de début depasse la date actuéle");
                            Actualiser();
                            break;
                        case CodeDErreur.DateFinPlusPetitQueDateDebut:
                            Utils.MaterialMessageBox.ShowError("Erreur: la date de debut est appres à la date de fin");
                            Actualiser();
                            break;
                        case CodeDErreur.DateDebutAvantDateFinPrecedent:
                            Utils.MaterialMessageBox.ShowError("Erreur: la date de debut est avant la date de fin du précedent");
                            Actualiser();
                            break;
                        case CodeDErreur.DateFinApresDateDebutSuivant:
                            Utils.MaterialMessageBox.ShowError("Erreur: la date de fin est apres la date de debut du suivant");
                            Actualiser();
                            break;
                        case CodeDErreur.PasDerreur:
                            //AJOUT
                            TaskUserTime taskUserTimeEncien = _service.TaskUserTimeCharger(Selection);
                            _service.TaskUserTimeHistoryAjouterUnTaskUserTime(taskUserTimeEncien);

                            //MODIF
                            if (_service.TaskUserTimeModifier(TaskUserTime))
                                Utils.MaterialMessageBox.Show("Modification bien éffectuer");
                            //IL FAUT CALCULER L'EXECUTIONTIME DU "PROJECTTASK" 
                            Utils.Outils.ModificationDeExecutionTimeEtRecaluleDesTemps(TaskUserTime);

                            Actualiser();
                            break;

                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
                else
                {
                    Actualiser();
                }
            }
            else
            {
                Utils.MaterialMessageBox.ShowError("Sélection un champs !!");
            }
        }

        public void Actualiser()
        {
            _service = null;
            _service = new Service();
            LstVTaskTime = _service.VTaskTimeChargerLstDuProjectTaskUser(_vProjectTaskUserSelectinE);

            //IL FAUT AUSSI VIDER LES CHAMPS POUR LES MODIFICATIONS
            //pour cela, on point TaskUserTime vers un nouveau qui est totalement vide
            TaskUserTime = new TaskUserTime();
            Selection = LstVTaskTime[_indiceSelection];
            _codeDErreur = CodeDErreur.PasDerreur;
            IsUnSelectionnE = true;
        }

        public void AfficherHistory() //cette méthode affiche l'hystorique de modification de l'élément actuelement sélectionné
        {
            if (Selection != null)
            {
                _winUserTimeHistory = null;
                _winUserTimeHistory = new UserTimeHistoryView();
                Messenger.Default.Send(Selection); //on envoie la sélection actuel à "UserTimeHistory"
                _winUserTimeHistory.ShowDialog();
            }
            else
            {
                Utils.MaterialMessageBox.ShowWarning("Sélectionner un champs !!");
            }
        }

        #endregion

        public UserTimeViewModel()
        {
            _service = new Service();


            RetourAvecVerificationCommand = new RelayCommand(RetourAvecVerification);
            SauverCommand = new RelayCommand(SauverAjouter);
            AfficherHistoryCommand = new RelayCommand(AfficherHistory);
            ActualiserCommand = new RelayCommand(Actualiser);


            Messenger.Default.Register<VProjectTaskUser>(this, LectureDuMessageEtInitialisation); //pour la lecture du "ProjectTaskUser" envoyer
            Messenger.Default.Register<string>(this, LectureDuMessage); //pour la fermeture de History

            _codeDErreur = CodeDErreur.PasDerreur;
        }
    }
}
