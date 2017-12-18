using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using BespokeFusion;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using TimeSheetApp.data;
using TimeSheetApp.Model;
using TimeSheetApp.Utils;
using Task = TimeSheetApp.data.Task;
/*Tsiry 
 * dérnier modif : 08-12-2017
 */

namespace TimeSheetApp.ViewModel
{
    //Cette classe est lié à la vue "TacheView", elle sérvira à faire le traitement des actions de l'utilisateur sur cette vue
    // et aussi d'interagire avec la base
    //elle affiche les informations sur une tache, mais pérmetera aussi de modifier le non de la tache
    public class TacheDetailViewModel : ViewModelBase
    {

        #region Attributs
        private readonly IService _service;// le sérvice sérvira à toutes les interractions avec la base de données
        private Task _selection;//la tache sélctionnée

        private string _dateDeModification;
        private bool _isActive;

        #endregion

        #region Commandes
        //les commandes sont liées à la vue par le "Binding" et en suite liées à differents méthodes pour faire les traitements

        public ICommand SauverCommand { get; set; }

        public ICommand RetourAvecAvertissementCommand { get; set; }
        public ICommand EffacerCommand { get; set; }
        public ICommand ActualiserCommand { get; set; }
        public ICommand CheckActiveCommand { get; set; }



        #endregion

        #region Propriétes
        //les Propriétes sont les données qui sont affichées par la vue via le "Binding"
        public Task Selection
        {
            get { return _selection; }
            set
            {
                _selection = value;
                RaisePropertyChanged(() => Selection);

            }
        }

        public string DateDeModification
        {
            get { return _dateDeModification; }
            set
            {
                _dateDeModification = value;
                RaisePropertyChanged(() => DateDeModification);

            }
        }

        public bool IsActive
        {
            get { return _isActive; }
            set
            {
                _isActive = value;
                RaisePropertyChanged(() => IsActive);

            }
        }

        private string _toolTipTache;

        public string ToolTipTache
        {
            get { return _toolTipTache; }
            set
            {
                _toolTipTache = value;
                RaisePropertyChanged(() => ToolTipTache);
            }
        }

        #endregion


        #region Méthodes
       
        public void LectureDuMessageEtInitialisation(Task selection)//lit le message du "TacheViewModel" avec un "Task" comme parametre
        {

            Selection = selection;
            DateDeModification = Selection.ModificationDate.ToString();
            if (Selection.Active != null) IsActive = (bool)Selection.Active;
        }


        public void Sauver()
        {
            Task tacheAvant = _service.TaskCharger(Selection.TaskID);//on charge la tache d'avant
            if (!tacheAvant.TaskName.Equals(Selection.TaskName))//si il y a eu modification
            {
                if (Selection.TaskName.Equals(""))
                {
                    Utils.MaterialMessageBox.ShowWarning("Le champ tâche ne doit pas être vide !!");

                }
                else if (Selection.TaskName[0] == ' ')
                {
                    Utils.MaterialMessageBox.ShowWarning("Le nom d'une tâche ne doit pas commencer par une espace !!");
                }
                else if (_service.TaskNomExisteDeja(Selection.TaskName))
                {
                    Utils.MaterialMessageBox.ShowWarning("Le nom de tâche existe déja dans la liste !!");
                }
                else
                {

                    Selection.ModifiedBy = Environment.UserName;
                    Selection.ModificationDate = DateTime.Now;
                    Selection.Active = IsActive;
                    DateDeModification = Selection.ModificationDate.ToString();
                    if (_service.TaskModifier((Selection)))
                    {
                        Utils.MaterialMessageBox.Show("Modification de la tâche " + Selection.TaskName + " bien éffectué");
                        Retour();
                    }
                }
            }
        }

        public void Effacer()//supprime la tache
        {
            if (Outils.VerificationSiAppacrientAlUtilisateurCourant(Selection))//vérification du doit
            {
                //verification si la tache n'est lier à aucun ProjectTaskUser
                if (_service.ProjectTaskUserTacheEstDedans(Selection) || _service.ProjectTaskTacheEstDedans(Selection))
                    Utils.MaterialMessageBox.ShowError(" Cette action ne peut pas être effectuée car la tâche est encore dans TimeSheet ou liée à un projet ");
                else
                {
                    //AVERISEMENT
                    if (Utils.MaterialMessageBox.ShowWithCancel("voulez vous vraiment supprimer cette tâche ?") ==
                        MessageBoxResult.OK) //Avertissement
                    {

                        if (_service.TaskSupprimer((Selection)))
                            Utils.MaterialMessageBox.Show("Suppression de la tâche " + Selection.TaskName + " effectuer avec succes");
                        Retour();
                    }
                }
            }
            else
            {
                Utils.MaterialMessageBox.ShowError("Vous ne pouvez pas supprimer une tâche que vous n'avez pas crée ");

            }

        }

        public void RetourAvecAvertissement()
        {
            if (IsNomModif())//On vérifie si il y a eu des modifications 
            {
                if (
                    Utils.MaterialMessageBox.ShowWithCancel(
                        "Il y a eu des (une) modification(s), voulez vous vraiment quitter sans enregistrer les modifications ?") ==
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

        public bool IsNomModif()
        {
            if (Selection != null)
            {
                var tacheActuel = _service.TaskCharger(Selection);
                return tacheActuel.TaskName != Selection.TaskName;
            }
            else
            {
                return false;
            }
           
        }

        public void CheckActive()
        {
            if (Outils.VerificationEtChangementEtatTache(Selection))
                IsActive = true;
            Actualiser();
        }

        public void Retour()
        {
            //pour s'assurer de la netoyage, on deregistre et enregistre la ViewModel

            ViewModelLocator.TacheViewModelVm.Actuialiser();
            ViewModelLocator.Main.TacheOngletActuel = MainViewModel.TacheOnglet.Tache;
            ViewModelLocator.Main.AllerSurTache();
        }

        public void Actualiser()
        {
            DateDeModification = Selection.ModificationDate.ToString();
            if (Selection.Active != null) IsActive = (bool)Selection.Active;
        }

        #endregion

        public TacheDetailViewModel()
        {
            _service = new Service();
            Messenger.Default.Register<Task>(this, LectureDuMessageEtInitialisation); //on s'abbonne au systeme de mesagerie
            SauverCommand = new RelayCommand(Sauver);
            RetourAvecAvertissementCommand = new RelayCommand(RetourAvecAvertissement);
            EffacerCommand = new RelayCommand(Effacer);
            ActualiserCommand = new RelayCommand(Actualiser);
            CheckActiveCommand = new RelayCommand(CheckActive);
        }
    }
}
