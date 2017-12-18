using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using MyDataCustomer.data;
using TimeSheetApp.Model;
using TimeSheetApp.data;
using TimeSheetApp.Utils;
using TimeSheetApp.View;
using MessageBox = System.Windows.MessageBox;

namespace TimeSheetApp.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class SearchClientViewModel : ViewModelBase
    {
        private readonly IProjectService _service;
        public RelayCommand FilterClient { get; set; }
        public ICommand SaveClient { get; set; }
        public ICommand PreviewToDetailProject { get; set; }
        public ICommand CustomerSearch { get; set; }

    /// <summary>
        /// Initializes a new instance of the SearchClientViewModel class.
        /// </summary>
        public SearchClientViewModel()
        {
            _service = new ProjectService();
            ClientList = _service.MyCustomersList();
            FilterClient = new RelayCommand(ExecuteFiltre);
            SaveClient = new RelayCommand(SaveClientChoose);
            PreviewToDetailProject = new RelayCommand(ExecutePreviewDetail);
            CustomerSearch = new RelayCommand(CancelSerch);
        }

        private void CancelSerch()
        {
            ClienttFilter = "";
        }

        public void ExecutePreviewDetail()
        {
            ViewModelLocator.DetailProjetView.CloseClientWindow();
        }

        private List<VCustomers> _clientList;
        public List<VCustomers> ClientList
        {
            get { return _clientList; }
            set
            {
                _clientList = value;
                RaisePropertyChanged(() => ClientList);
                CountCustomer = _clientList.Count;
                Libelle = CountCustomer > 1 ? " résultats" : " résultat";
            }
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
        //Count Customer
        private int _countCustomer;
        public int CountCustomer
        {
            get { return _countCustomer; }
            set
            {
                _countCustomer = value;
                RaisePropertyChanged(() => CountCustomer);
            }
        }
        private string _libelle;
        public string Libelle
        {
            get { return _libelle; }
            set
            {
                _libelle = value;
                RaisePropertyChanged(() => Libelle);
            }
        }
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
        
        //t SaveClientChoose
        private void SaveClientChoose()
        {
            if (ClientSelected == null)
            {
                MaterialMessageBox.ShowWarning("Veuiller Selectionner un Client !");
            }
            else
            {
                if ((ViewModelLocator.DetailProjetView.ContentProject.CustomerName == null) || (ViewModelLocator.DetailProjetView.ContentProject.CustomerName == ""))
                {
                    if (MaterialMessageBox.ShowWithCancel("Voulez vous attribuer le projet " + ViewModelLocator.DetailProjetView.NameProject + " au client " + ViewModelLocator.ResearchClientVm.ClientSelected.Customername + "?") == MessageBoxResult.OK)
                    {
                        ViewModelLocator.DetailProjetView.ClientNameGet();
                        ViewModelLocator.DetailProjetView.CloseClientWindow();
                        SimpleIoc.Default.Unregister<SearchClientViewModel>();
                        SimpleIoc.Default.Register<SearchClientViewModel>();
                        //ViewModelLocator.ProjetView.MyDataBaseTorRefresh();
                    }
                    else
                    {
                        ViewModelLocator.DetailProjetView.CloseClientWindow();
                        SimpleIoc.Default.Unregister<SearchClientViewModel>();
                        SimpleIoc.Default.Register<SearchClientViewModel>();
                    }
                }
                else if((MaterialMessageBox.ShowWithCancel("Voulez vous changer le client " +ViewModelLocator.DetailProjetView.CustomerName + " du projet " + ViewModelLocator.DetailProjetView.NameProject + " au client " + ViewModelLocator.ResearchClientVm.ClientSelected.Customername + "?") == MessageBoxResult.OK))
                { 
                    ViewModelLocator.DetailProjetView.ChangeMyCustomer();
                    ViewModelLocator.DetailProjetView.CloseClientWindow();
                    SimpleIoc.Default.Unregister<SearchClientViewModel>();
                    SimpleIoc.Default.Register<SearchClientViewModel>();
                    //ViewModelLocator.ProjetView.MyDataBaseTorRefresh();
                }
            }
            
        }
        public ICommand RefreSheCustomers => new RelayCommand(() =>
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
            
    }
}