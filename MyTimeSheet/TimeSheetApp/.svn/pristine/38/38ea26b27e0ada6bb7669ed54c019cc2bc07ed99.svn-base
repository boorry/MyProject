using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BespokeFusion;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using TimeSheetApp.Model;
using Task = TimeSheetApp.data.Task;
/*Tsiry 
 * dérnier modif : 13-12-2017
 */

namespace TimeSheetApp.ViewModel
{
    //Cette classe est lié à la vue "TacheView", elle sérvira à faire le traitement des actions de l'utilisateur sur cette vue
    // et aussi d'interagire avec la base
    //elle charge toutes les taches, permetera de modifie une et d'en ajouter
    public class TacheViewModel : ViewModelBase
    {

        #region Attribut
        private readonly IService _service;// le sérvice sérvira à toutes les interractions avec la base de données
        private List<Task> _lstTache;//la liste de toutes les tachs
        private string _filtre;//le texte dans la zone de texte pour filtrer les données
        private string _nbResult;//le nb de résulta
        private Task _selection;//la tache sélectionnée
        private bool _isUniquementMesTaches;//pour filtrer uniquement les taches de l'utilisateur


        #endregion


        #region Commandes
        //les commandes sont liées à la vue par le "Binding" et en suite liées à differents méthodes pour faire les traitements

        public ICommand FiltrerCommand { get; set; }//cette commande est lier au zone de texte, des que le texte chanche, le filtre des résultats est fait


        public ICommand CancelFiltreCommand { get; set; }

        public ICommand AfficherDetailCommand { get; set; }

        public ICommand ActualiserCommand { get; set; }

        public ICommand AjoutCommand { get; set; }

        public ICommand CheckOuPasCommand { get; set; }


        #endregion

        #region Propriétes
        //les Propriétes sont les données qui sont affichées par la vue via le "Binding"
        public List<Task> LstTache
        {
            get { return _lstTache; }
            set
            {
                _lstTache = value;
                RaisePropertyChanged(() => LstTache);
                NbResult = LstTache.Count.ToString() + " resultat(s)";//on charge le nombre de résultats
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

        public Task Selection
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

        public bool IsUniquementMesTaches
        {
            get { return _isUniquementMesTaches; }
            set
            {
                _isUniquementMesTaches = value;
                RaisePropertyChanged(() => IsUniquementMesTaches);
                Actuialiser();

            }
        }

        #endregion

        #region Méthodes

        public void Filtrer()
        {
            LstTache = _service.TaskChargerLst(Filtre, IsUniquementMesTaches);
        }



        public void CancelFiltre()//on vide la texte de filtre et quand ce texte est vide: on affiche tout
        {
            Filtre = "";
        }
        public void CheckOuPas()
        {
            Actuialiser();
            Utils.Outils.VerificationEtChangementEtatTache(Selection);
            Actuialiser();
        }
        public void Actuialiser()
        {
            LstTache = _service.TaskChargerLst(Filtre, IsUniquementMesTaches);
        }

        public void AfficherDetail()
        {
            if (Selection == null)
            {
                Utils.MaterialMessageBox.ShowWarning("Sélectionenr un champ!!!");
            }

            else
            {
                ViewModelLocator.Main.CurrentView = ViewModelLocator.TacheDetailViewModelVm;
                Messenger.Default.Send(Selection);
                ViewModelLocator.Main.TacheOngletActuel = MainViewModel.TacheOnglet.TacheDetail;
            }
        }

        public void Ajouter()
        {

            ViewModelLocator.Main.CurrentView = ViewModelLocator.TacheAjoutViewModelVm;
            ViewModelLocator.Main.TacheOngletActuel = MainViewModel.TacheOnglet.TacheAjout;


        }

        #endregion


        public TacheViewModel()
        {
            _service = new Service();
            IsUniquementMesTaches = false;
            Actuialiser();
            FiltrerCommand = new RelayCommand(Filtrer);
            CancelFiltreCommand = new RelayCommand(CancelFiltre);
            AfficherDetailCommand = new RelayCommand(AfficherDetail);
            ActualiserCommand = new RelayCommand(Actuialiser);
            AjoutCommand = new RelayCommand(Ajouter);
            CheckOuPasCommand = new RelayCommand(CheckOuPas);
        }
    }
}
