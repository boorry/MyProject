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
using TimeSheetApp.Model;
using Task = TimeSheetApp.data.Task;
/*Tsiry 
 * dérnier modif : 11-12-2017
 */
namespace TimeSheetApp.ViewModel
{
    //Cette classe est lié à la vue "TacheView", elle sérvira à faire le traitement des actions de l'utilisateur sur cette vue
    // et aussi d'interagire avec la base
    //elle permet d'ajouter une tache 

    public class TacheAjoutViewModel : ViewModelBase
    {

        #region Attributs
        private readonly IService _service;// le sérvice sérvira à toutes les interractions avec la base de données
        private Task _selection;//la tache à ajouter
        #endregion

        #region Commandes
        //les commandes sont liées à la vue par le "Binding" et en suite liées à differents méthodes pour faire les traitements
        public ICommand SauverCommand { get; set; }
        public ICommand RetourAvecAvertisementCommand { get; set; }
        #endregion

        #region Propriétes
        public Task Selection
        {
            get { return _selection; }
            set
            {
                _selection = value;
                RaisePropertyChanged(() => Selection);
            }
        }
        #endregion

        #region Méthodes

        public void Sauver()
        {
          
                if (Selection.TaskName.Equals(""))
                {
                    Utils.MaterialMessageBox.ShowWarning("Le nom de la tache ne peut pas être vide !!");

                }
                else if (Selection.TaskName[0] == ' ')
                {
                    Utils.MaterialMessageBox.ShowWarning("Le nom de la tache ne peut pas commencer par un éspace !!");
                }
                else if (_service.TaskNomExisteDeja(Selection.TaskName))
                {
                    Utils.MaterialMessageBox.ShowWarning("Le nom de la tache existe déja dans la liste !!");
                }
                else
                {
                    if (!_service.TaskAjouter((Selection))) return;
                    Utils.MaterialMessageBox.Show("Ajout de la tache \"" + Selection.TaskName + "\" bien éffectué");
                    Retour();
                }
           
            
           
               
        }
        public void RetourAvecAvertisement()
        {
           
            if (IsNomModif())//On verifie si le nom de la tache n'est pas vide
            {
                if (
                    MaterialMessageBox.ShowWithCancel(
                        "vous n'avez pas encore enregistrer, voulez vous vraiment quiter la page?") ==
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
            return !Selection.TaskName.Equals("");
        }


        public void Retour()
        {
            //pour s'assurer de la netoyage, on deregistre et enregistre la ViewModel

            ViewModelLocator.TacheViewModelVm.Actuialiser();
            ViewModelLocator.Main.TacheOngletActuel = MainViewModel.TacheOnglet.Tache;
            ViewModelLocator.Main.AllerSurTache();
        }
        #endregion
        public TacheAjoutViewModel()
        {
            _service=new Service();
            SauverCommand = new RelayCommand(Sauver);
            RetourAvecAvertisementCommand = new RelayCommand(RetourAvecAvertisement);


            Selection = new Task
            {
                TaskName = "",
                CreationDate = DateTime.Now,
                CreatedBy = Environment.UserName
            };
        }
    }
}
