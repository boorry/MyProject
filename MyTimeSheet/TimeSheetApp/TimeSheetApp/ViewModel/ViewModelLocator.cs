/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:TimeSheetApp"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using System.Dynamic;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using TimeSheetApp.View;

namespace TimeSheetApp.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<TimeSheetViewModel>();
            SimpleIoc.Default.Register<TimeSheetDetailViewModel>();
            SimpleIoc.Default.Register<TimeSheetAjoutViewModel>();
            SimpleIoc.Default.Register<TacheViewModel>();
            SimpleIoc.Default.Register<TacheDetailViewModel>();
            SimpleIoc.Default.Register<TacheAjoutViewModel>();
            SimpleIoc.Default.Register<UserTimeHistoryViewModel>();
            SimpleIoc.Default.Register<UserTimeViewModel>();
            SimpleIoc.Default.Register<ProjetViewModel>();
            SimpleIoc.Default.Register<DetailProjetViewModel>();
            SimpleIoc.Default.Register<HistroryProjectViewModel>();
            SimpleIoc.Default.Register<SearchClientViewModel>();
            SimpleIoc.Default.Register<AddNewProjectViewModel>();
            SimpleIoc.Default.Register<CustomerViewModel>();
        }

        public static CustomerViewModel CustomerView
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CustomerViewModel>();
                
            }
        }

        public static AddNewProjectViewModel AddNewProjectView
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AddNewProjectViewModel>();
                
            }
        }

        public static SearchClientViewModel ResearchClientVm
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SearchClientViewModel>();
            }
        }

        public static DetailProjetViewModel DetailProjetView
        {
            get
            {
                return ServiceLocator.Current.GetInstance<DetailProjetViewModel>();
                
            }
        }

        public static HistroryProjectViewModel HistroryProjectView
        {
            get
            {
                return ServiceLocator.Current.GetInstance<HistroryProjectViewModel>();

            }
        }

        public static MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public static ProjetViewModel ProjetView
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ProjetViewModel>();

            }
        }

        public static TimeSheetViewModel TimeSheetVeiwModelVm //
        {
            get { return ServiceLocator.Current.GetInstance<TimeSheetViewModel>(); }
        }

        public static TimeSheetDetailViewModel TimeSheetDetailVeiwModelVm //
        {
            get { return ServiceLocator.Current.GetInstance<TimeSheetDetailViewModel>(); }
        }

        public static TimeSheetAjoutViewModel TimeSheetAjoutViewModelVm //
        {
            get
            {
                return ServiceLocator.Current.GetInstance<TimeSheetAjoutViewModel>();
            }
        }

        public static TacheViewModel TacheViewModelVm //
        {
            get
            {
                return ServiceLocator.Current.GetInstance<TacheViewModel>();
            }
        }


        public static TacheDetailViewModel TacheDetailViewModelVm //
        {
            get
            {
                return ServiceLocator.Current.GetInstance<TacheDetailViewModel>();
            }
        }

        public static TacheAjoutViewModel TacheAjoutViewModelVm //
        {
            get
            {
                return ServiceLocator.Current.GetInstance<TacheAjoutViewModel>();
            }
        }

        public static UserTimeHistoryViewModel UserTimeHistoryViewModelVm //
        {
            get
            {
                return ServiceLocator.Current.GetInstance<UserTimeHistoryViewModel>();
            }
        }

        public static UserTimeViewModel UserTimeViewModelVm //
        {
            get
            {
                return ServiceLocator.Current.GetInstance<UserTimeViewModel>();
            }
        }


        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}