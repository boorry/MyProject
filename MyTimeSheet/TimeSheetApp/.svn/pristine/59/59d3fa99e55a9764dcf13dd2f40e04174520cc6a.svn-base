using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace TimeSheetApp.ViewModel
{
    public class DialogueBoxDemandeNomIntervenantViewModel : ViewModelBase
    {
        #region Attributs
        private string _inetervenant;



        #endregion

        #region Commandes
        public ICommand AccepterCommand { get; set; }
        public ICommand AnnulerCommand { get; set; }
        #endregion



        #region Propriétes
        public string Inetervenant
        {
            get { return _inetervenant; }
            set
            {
                _inetervenant = value;
                RaisePropertyChanged(() => Inetervenant);
            }
        }


        #endregion

        #region Méthodes

        private void Accepter()
        {
            if (Inetervenant != null)
            {
                ViewModelLocator.TimeSheetDetailVeiwModelVm.AssignierAUnIntervenant(Inetervenant);
                ViewModelLocator.TimeSheetDetailVeiwModelVm.FermerDialogueBoxDemandeNomIntervenant();
            }
            else
            {
                MessageBox.Show("INTERVENANT VIDE !!");
            }

        }

        private void Annuler()
        {
            ViewModelLocator.TimeSheetDetailVeiwModelVm.FermerDialogueBoxDemandeNomIntervenant();
        }


        #endregion


        public DialogueBoxDemandeNomIntervenantViewModel()
        {
            AccepterCommand = new RelayCommand(Accepter);
            AnnulerCommand = new RelayCommand(Annuler);
        }



    }
}
