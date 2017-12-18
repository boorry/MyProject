using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using MaterialDesignThemes.Wpf;
using MyDataCustomer.data;
using TimeSheetApp.Model;
using TimeSheetApp.data;
using TimeSheetApp.Utils;
using TimeSheetApp.View;
using static System.Windows.MessageBox;
namespace TimeSheetApp.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class CustomerViewModel : ViewModelBase
    {
        private readonly IProjectService _service;
        public RelayCommand FilterClient { get; set; }

        public RelayCommand CancelClientSearch { get; set; }

        public ICommand SaveClient { get; set; }

        public ICommand PreviewToDetailProject { get; set; }
        /// <summary>
        /// Initializes a new instance of the CustomerViewModel class.
        /// </summary>
        public CustomerViewModel()
        {
            _service = new ProjectService();
            ClientList = _service.MyCustomersList();
            FilterClient = new RelayCommand(ExecuteFiltre);
            SaveClient = new RelayCommand(SaveClientChoose);
            PreviewToDetailProject = new RelayCommand(ExecutePreviewDetail);
            CancelClientSearch = new RelayCommand(CancelSearch);
        }

        private void CancelSearch()
        {
            ClienttFilter = "";
        }

        public void ExecutePreviewDetail()
        {
            ViewModelLocator.AddNewProjectView.CloseClientMyWindow();
        }

        private List<VCustomers> _clientList;
        public List<VCustomers> ClientList
        {
            get { return _clientList; }
            set
            {
                _clientList = value;
                RaisePropertyChanged(() => ClientList);
                CountClient = ClientList.Count;
                Resultats = CountClient > 1 ? "resultas" : "resultat";
            }
        }

        //Count Client

        private int _countClient;

        public int CountClient
        {
            get { return _countClient; }
            set
            {
                _countClient = value;
                RaisePropertyChanged(() => CountClient);
            }
        }

        private string _resultas;

        public string Resultats
        {
            get { return _resultas; }
            set
            {
                _resultas = value;
                RaisePropertyChanged(() => Resultats);
            }
        }

        //Refresh Client List

        public ICommand RefreSheCustomerList => new RelayCommand(() =>
        {
            if (ClienttFilter != null)
            {
                ClientList = _service.SearchClient(ClienttFilter);
            }
            else
            {
                ClientList = _service.MyCustomersList();
            }
            
        });

        //client filte
        private string _clienttFilter;
        public string ClienttFilter
        {
            get
            {
                return _clienttFilter;
            }
            set
            {
                if (value != _clienttFilter)
                {

                    _clienttFilter = value;
                    RaisePropertyChanged(() => ClienttFilter);
                }
            }
        }

        private void ExecuteFiltre()
        {
            ClientList = _service.SearchClient(ClienttFilter);
        }

        //ClientSelected

        private VCustomers _clientSelected;

        public VCustomers ClientSelected
        {
            get { return _clientSelected; }
            set
            {
                _clientSelected = value;
                RaisePropertyChanged(() => ClientSelected);
            }
        }

        //t SaveClientChoose

        private void SaveClientChoose()
        {
            if (ClientSelected == null)
            {
                MaterialMessageBox.ShowWarning("Veuiller sélectionner un client");
            }
            else
            {
                ViewModelLocator.AddNewProjectView.CustomerNameGet();
            }
            ViewModelLocator.AddNewProjectView.CloseClientMyWindow();
            SimpleIoc.Default.Unregister<CustomerViewModel>();
            SimpleIoc.Default.Register<CustomerViewModel>();
        }
    }
}