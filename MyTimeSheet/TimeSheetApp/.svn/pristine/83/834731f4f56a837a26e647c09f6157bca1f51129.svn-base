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
using TimeSheetApp.data;
using TimeSheetApp.Model;
using Task = System.Threading.Tasks.Task;

/*Tsiry 
 * dérnier modif : 08-12-2017
 */

namespace TimeSheetApp.ViewModel
{
    //Cette classe est lié à la vue "TimeSheetAjoutView", elle sérvira à faire le traitement des actions de l'utilisateur sur cette vue
    // et aussi d'interagire avec la base
    //elle charge les différents "ProjectTask" avec les possibilités de filtrer par nom des projet, et affiche des "ProjectTask" qui ne sont pas encore prises
    public class TimeSheetAjoutViewModel : ViewModelBase
    {
        #region  Attribut
        private readonly IService _service;// le sérvice sérvira à toutes les interractions avec la base de données
        private List<VProjectTask> _lstPrjTache;//la liste des "VProjectTask" qui seront affiches dans la dataGrid
        private string _nbResult;//nombre de résultat
        private List<Project> _lstProjet;// liste de tout les projets, sérvira de filtre quand l'utilisateur en choisira un
        private VProjectTask _selection;//l'élement sélectionné
        private Project _selectionComboBoxProjet;//le porjet sélectionné
        #endregion

        #region Commandes
        //les commandes sont liées à la vue par le "Binding" et en suite liées à differents méthodes pour faire les traitements
        public ICommand RetourCommand { get; set; }
        public ICommand SauverCommand { get; set; }

        public ICommand ActualiserCommand { get; set; }


        #endregion

        #region Protriétés
        //les Propriétes sont les données qui sont affichées par la vue via le "Binding"
        public List<VProjectTask> LstPrjTache
        {
            get { return _lstPrjTache; }
            set
            {
                _lstPrjTache = value;
                RaisePropertyChanged(() => LstPrjTache);
                NbResult = LstPrjTache.Count.ToString() + " resultat(s)";//on met à jour le nombre de résultat si la liste change
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

        public List<Project> LstProjet
        {
            get { return _lstProjet; }
            set
            {
                _lstProjet = value;
                RaisePropertyChanged(() => LstProjet);
            }
        }

        public Project SelectionComboBoxProjet
        {
            get { return _selectionComboBoxProjet; }
            set
            {
                _selectionComboBoxProjet = value;
                RaisePropertyChanged(() => SelectionComboBoxProjet);

                LstPrjTache = _service.VProjectTaskChargerLst(SelectionComboBoxProjet.ProjectName);

            }
        }

        public VProjectTask Selection
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

        public void Retour()
        {
            //pour s'assurer de la netoyage, on deregistre et enregistre la ViewModel
            SimpleIoc.Default.Unregister<TimeSheetAjoutViewModel>();
            SimpleIoc.Default.Register<TimeSheetAjoutViewModel>();
            Messenger.Default.Send("fermerTimeSheetAjoutView");//en envoi un message à "TimeSheet" qui férmera la fenetre
        }
        private void Ajouter()//pour l'ajout d'un "TimeSheet"
        {

            if (Selection == null)//on s'assure qu'il élement est sélectionné
            {
                Utils.MaterialMessageBox.ShowWarning("Selectionner un champs!!");
            }
            else
            {
                if (_service.ProjectTaskUserEstDedans(Selection))
                    Utils.MaterialMessageBox.ShowWarning("L'élement existe deja!!!");
                else
                {
                    _service.MapTaskStateAjouterUnEngagE();//on ajoute un "engagé" dans "MapTaskState"
                    if (_service.ProjectTaskUserAjouter(Selection))//on ajoute le "TimeSheet"
                        Utils.MaterialMessageBox.Show("Le TimeSheet : \"" + Selection.ProjectName + " " + Selection.TaskName + "\" a bien été ajouté");
                    Retour();
                    ViewModelLocator.TimeSheetVeiwModelVm.Actualiser();

                }
            }


        }

        public void Actualiser()
        {

            LstPrjTache = _service.VProjectTaskChargerLst(SelectionComboBoxProjet.ProjectName);
        }

        public void Initialiser()//cette méthode est appellée dans "TimeSheetViewModel" apres que ce dérnier affiche la fenetre d'ajout
        {
            LstPrjTache = _service.VProjectTaskChargerLst("tout");
            LstProjet = _service.ChargerContenuLstProjet();
            Project projetTout = new Project() { ProjectName = "tout" };
            LstProjet.Insert(0, projetTout);
        }



        #endregion

        public TimeSheetAjoutViewModel()
        {
            _service = new Service();
            RetourCommand = new RelayCommand(Retour);
            SauverCommand = new RelayCommand(Ajouter);
            ActualiserCommand = new RelayCommand(Actualiser);

        }
    }
}
