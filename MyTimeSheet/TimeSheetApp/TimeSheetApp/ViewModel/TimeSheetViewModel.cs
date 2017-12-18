using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
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
 * dérnier modif : 11-12-2017
 */

namespace TimeSheetApp.ViewModel
{
    //Cette classe est lié à la vue "TimeSheetView", elle sérvira à faire le traitement des actions de l'utilisateur sur cette vue
    // et aussi d'interagir avec la base
    //elle charge les différents "TimeSheet", avec la possibiliter de les filtrer, de faire les different actions comme:
    //le lancement, la mise en pause et l'arret de ces dérniers mais permet aussi de supprimer un timeSheet, d'en ajouter ou d'afficher les détailles de ce dérnier
    public class TimeSheetViewModel : ViewModelBase
    {
        #region Attribus
        private IService _service;// le sérvice sérvira à toutes les interractions avec la base de données

        private List<VProjectTaskUser> _lstContenu;//la liste qui seras affiché dans la dataGrid
        private string _nbResult;
        private string _filtre;//sérvira de filtre: elle est liée avec la propriété "Filtre" qui est lui meme lier à la téxte boxe de la vue, pour pérmetre de filtrer les résultats

        private TimeSheetAjoutView _winAjout;//"_winAjout" permetra l'ajout d'un "TimeSheet"
        private UserTimeView _winTaskUserTime;//"_winTaskUserTime" pour la correction des heurs
        private VProjectTaskUser _selection;//l'élement sélectionnée dans la dataGrid
        
        //les "is" sérviront à de filtre lor de l'affichage
        private bool _isUniquementMesProjet;
        private bool _isUniquementTimeSheetCloturEs;
        #endregion
        #region commandes 
        //les commandes sont liées à la vue par le "Binding" et en suite liées à differents méthodes pour faire les traitements
        public ICommand AfficherDetailCommand { get; set; }

        public ICommand AjouerUnTimeSheetCommand { get; set; }
        public ICommand DetacherUnTimeSheetCommand { get; set; }
        public ICommand GererTaskUserTimeCommand { get; set; }
        public ICommand ActuialiserCommand { get; set; }

        public ICommand FiltrerCommand { get; set; }//cette commande est lier au zone de texte, des que le texte chanche, le filtre des résultats est fait
        public ICommand FiltrerParIntervenantCommand { get; set; }

        public ICommand CancelFiltreCommand { get; set; }
        public ICommand PlayOuPauseCommand { get; set; }
        public ICommand StoperCommand { get; set; }

        #endregion
        #region Propriétes
        //les Propriétes sont les données qui sont affichées par la vue via le "Binding"
        public List<VProjectTaskUser> LstContenu
        {
            get { return _lstContenu; }
            set
            {
                _lstContenu = value;
                RaisePropertyChanged(() => LstContenu);
                NbResult = LstContenu.Count.ToString() + " resultat(s)";// on change le nonbre de résultat quand la liste change
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


        public bool IsUniquementMesProjet
        {
            get { return _isUniquementMesProjet; }
            set
            {
                _isUniquementMesProjet = value;
                RaisePropertyChanged(() => IsUniquementMesProjet);
                Filtrer();//à chaque check, on fait le filtre
            }
        }

        public bool IsUniquementTimeSheetCloturEs
        {
            get { return _isUniquementTimeSheetCloturEs; }
            set
            {
                _isUniquementTimeSheetCloturEs = value;
                RaisePropertyChanged(() => IsUniquementTimeSheetCloturEs);
                Filtrer();//à chaque check, on fait le filtre
            }
        }

       

        public VProjectTaskUser Selection
        {
            get { return _selection; }
            set
            {
                _selection = value;
                RaisePropertyChanged(() => Selection);


            }
        }

        public string Filtre
        {
            get { return _filtre; }
            set
            {
                _filtre = value;
                RaisePropertyChanged(() => Filtre);
            }
        }
        #endregion


        #region Méthodes
        public void AfficherDetail()
        {
           
                if (Selection == null)//verifie si un élement est séléctioné
                {

                    Utils.MaterialMessageBox.ShowWarning("Sélectionner un champ!!!");
                }
                else
                {
                    
                        ViewModelLocator.Main.CurrentView = ViewModelLocator.TimeSheetDetailVeiwModelVm;
                        ViewModelLocator.Main.TimeSheetOngletActuel = MainViewModel.TimeSheetOnglet.TimeSheetDetail;
                        Messenger.Default.Send(Selection);
                   
                }
            
        }

        private void AjouerUnTimeSheet()
        {
            _winAjout = null;
            _winAjout = new TimeSheetAjoutView();
            ViewModelLocator.TimeSheetAjoutViewModelVm.Initialiser();
            _winAjout.ShowDialog();
            
        }

        private void DetacherUnTimeSheet()
        {
            
                
                if (Selection == null)//verifie si un élement est séléctioné
                    Utils.MaterialMessageBox.ShowWarning("Sélectionner un champ!!");
                else
                {
                    if (Utils.Outils.VerificationSiAppacrientAlUtilisateurCourant(Selection))//vérification du droit
                    {
                        if (Selection.MapTaskStateName.Equals("Engagé")) //seul les tache qui sont términées ou engagées peuvent etres détaches
                    {
                        if (Utils.MaterialMessageBox.ShowWithCancel("Vouler vous réelement détacher ce TimeSheet") !=
                            MessageBoxResult.OK) return;
                        //Détachement
                        var projectTaskUser = _service.ProjectTaskUserChargerUn(Selection.ProjectTaskUserID);//on charge le "ProjectTaskUser"
                        if (!_service.ProjectTaskUserSupprimer((projectTaskUser))) return;
                        Utils.MaterialMessageBox.Show("Détachement du TimeSheet :  \"" + Selection.ProjectName + "\"  \"" + Selection.TaskName + "\" bien éffectué");
                        Actualiser();
                    }
                        else
                        {
                            Utils.MaterialMessageBox.ShowWarning("Vous ne pouver pas détacher un TimeSheet qui est términé, en cours ou en pause");
                        }
                    }
                else
                {
                    Utils.MaterialMessageBox.ShowWarning("Vous ne pouver pas supprimer un TimeSheet qui ne vous appartien pas");
                }
            } 
        }

        private void GererTaskUserTime()// pour la corréction du temps
        {
           
                if (Selection == null)//il faut qu'un élement soit sélectioné
                {
                    Utils.MaterialMessageBox.ShowWarning("Sélectionner un champs!!");
                }
                else
                {
                    if (Utils.Outils.VerificationSiAppacrientAlUtilisateurCourant(Selection))//verification du droit
                    {
                        _winTaskUserTime = null;//pour éviter tout érreur, on point vers null
                        _winTaskUserTime = new UserTimeView();
                        Messenger.Default.Send(Selection);//en envoi la sélection actuel
                        _winTaskUserTime.ShowDialog();//on affiche la fenetre
                    }
                    else
                    {
                        Utils.MaterialMessageBox.ShowWarning("Cette tache ne vous appartien pas !! ");
                    }
                }
        }

        public void Filtrer()//filtrage par téxte, appelé quand on édite la zone de texte de filtrage
        {
            LstContenu = _service.VProjectTaskUserChargerLst(Filtre, IsUniquementMesProjet, IsUniquementTimeSheetCloturEs);
        }

        public void FiltrerParIntervenant()//Cette methode filtre sur le champs "Intervenant" et est appeller quand on clique sur le bouton de filtre sur les intervenants: 
            //C'est à dire que le texte dans la zone de filtre (Filtre) sérvira de filtre sur les intervenant
        {
            IsUniquementMesProjet = false;//si filtre par intervenant, on doit pouvoir afficher tout les intervenants avant de les  filtrer
            LstContenu = _service.VProjectTaskUserChargerLstParIntervenant(Filtre, IsUniquementMesProjet, IsUniquementTimeSheetCloturEs);
        }

        public void CancelFiltre()
        {
            Filtre = "";
        }

        //Pour les férmetures, les fenetres à férmers envoient des méssages à l'user control et ce dérnier est charger de 
        //les férmer vue que c'est ce dérnier qui les ont créer 
        public void LectureDuMessage(string message)
        {
            if (message.Equals("fermerUserTimeView"))
                FermerUserTimeView();
            if (message.Equals("fermerTimeSheetAjoutView"))
                FermerAjout();

        }
        public void FermerUserTimeView()
        {

            _winTaskUserTime?.Close();
            Actualiser();

        }
        public void FermerAjout()
        {
            _winAjout?.Close();
        }


        //pour les action sur les "TimeSheet"
        //Ici "Outils" est une classe qui contiendra les méthodes qui seront utiliser dans toute l'application
        public void PlayOuPause()
        {
           if(Utils.Outils.VerificationSiAppacrientAlUtilisateurCourant(Selection))//vérification du doit
            {
                if (Selection.MapTaskStateName.Equals("Engagé"))
                {
                    Outils.LancerUnEngagE(Selection);
                }

                else if (Selection.MapTaskStateName.Equals("En pause"))
                {
                    Outils.LancerUnEnPause(Selection);
                }
                else if (Selection.MapTaskStateName.Equals("Terminé"))
                {
                    Outils.LancerUnTerminE(Selection);
                }
                else if (Selection.MapTaskStateName.Equals("En cours") || Selection.MapTaskStateName.Equals("En Cours"))
                {
                    Outils.MettreEnPause(Selection);

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
            
            if (Utils.Outils.VerificationSiAppacrientAlUtilisateurCourant(Selection))//vérification du doit
            {
                Outils.Stoper(Selection);
                Actualiser();
            }
            else
            {
                Utils.MaterialMessageBox.ShowWarning("Cette tache ne vous appartien pas !!");
            }
        }

        public void Actualiser()
        {
            //on met à null le service pour s'assurer que l'actualisation entre la base et l'application se fait bien
            _service = null;
            _service=new Service();
             LstContenu = _service.VProjectTaskUserChargerLst(Filtre,IsUniquementMesProjet,IsUniquementTimeSheetCloturEs);
        }

        #endregion

        public TimeSheetViewModel()
        {
            _service = new Service();
            
            _isUniquementMesProjet = true;
            _isUniquementTimeSheetCloturEs = false;
            LstContenu = _service.VProjectTaskUserChargerLst("", IsUniquementMesProjet,IsUniquementTimeSheetCloturEs);

            //convert format date

          /*  MessageBox.Show(DateTime.ParseExact("11/26/2017 2:44:01 PM", "MM/dd/yyyy h:mm:ss tt",
                CultureInfo.InvariantCulture).ToString("MM/dd/yyyy hh:mm:ss"));*/


            AfficherDetailCommand = new RelayCommand(AfficherDetail);
            AjouerUnTimeSheetCommand = new RelayCommand(AjouerUnTimeSheet);
            DetacherUnTimeSheetCommand = new RelayCommand(DetacherUnTimeSheet);
            GererTaskUserTimeCommand =new RelayCommand(GererTaskUserTime);
            ActuialiserCommand = new RelayCommand(Actualiser);
            FiltrerCommand = new RelayCommand(Filtrer);
            FiltrerParIntervenantCommand = new RelayCommand(FiltrerParIntervenant);
            CancelFiltreCommand = new RelayCommand(CancelFiltre);
            PlayOuPauseCommand = new RelayCommand(PlayOuPause);
            StoperCommand = new RelayCommand(Stoper);

            
            Messenger.Default.Register<string>(this, LectureDuMessage);// pour lire les méssages des autres fenétres

        }
    }
}
