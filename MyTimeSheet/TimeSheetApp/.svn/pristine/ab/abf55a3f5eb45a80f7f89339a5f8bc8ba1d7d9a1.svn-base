using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using TimeSheetApp.data;
using TimeSheetApp.Model;
/*Tsiry 
 * dérnier modif : 11-12-2017
 */

namespace TimeSheetApp.ViewModel
{
    //cette ViewModel Affiche seulement la liste de modifications effectués sur un "TaskTime"
    public class UserTimeHistoryViewModel : ViewModelBase
    {


        #region Attribus
        private readonly IService _service;//pour l'interaction avec la base
        private List<TaskUserTimeHistory> _lstUserTimeHistory;//la lisye des UserTimeHistory liés à la "TaskTime"
        private string _nbResult;

        #endregion

        #region commandes
        public ICommand RetourCommand { get; set; }
        #endregion

        #region Preproétes
        //les Propriétes sont les données qui sont affichées par la vue via le "Binding"
        public List<TaskUserTimeHistory> LstUserTimeHistory
        {
            get { return _lstUserTimeHistory; }
            set
            {
                _lstUserTimeHistory = value;
                RaisePropertyChanged(() => LstUserTimeHistory);
                NbResult = LstUserTimeHistory.Count.ToString() + " résulta(s)";
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

        #endregion




        #region Méthodes

        public void Retour()
        {
            SimpleIoc.Default.Unregister<UserTimeViewModel>();
            SimpleIoc.Default.Register<UserTimeViewModel>();

            Messenger.Default.Send("fermerUserTimeHistoryView");//envoi une message à UserTimeViewModel qui fermera "UserTimeHistory"
        }
        public void LectureDuMessageEtInitialisation(VTaskTime selection)//reception de la "VTaskTime" sélectionnée
        {
            LstUserTimeHistory = _service.TaskUserTimeHistoryChargerLst(selection);
        }


        #endregion

        public UserTimeHistoryViewModel()
        {
            _service=new Service();
            
            RetourCommand = new RelayCommand(Retour);

            Messenger.Default.Register<VTaskTime>(this, LectureDuMessageEtInitialisation);//pour recevoir la sélection
        }
    }
}
