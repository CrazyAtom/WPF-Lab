using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System.Windows.Input;

namespace PrismStep4.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;

        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public ICommand NavigationCommand { get; set; }


        public MainWindowViewModel()
        {
            NavigationCommand = new DelegateCommand<string>(OnNavigation);
        }

        public MainWindowViewModel(IRegionManager regionManager)
            : this()
        {
            //IRegionManager를 Injection 받아서 사용하기 위해 _regionManager에 연결합니다.
            _regionManager = regionManager;
        }
        private void OnNavigation(string obj)
        {
            switch (obj)
            {
                case "Back":
                    {
                        IRegionNavigationJournal journal = _regionManager.Regions["ContentRegion"].NavigationService.Journal;
                        if (journal.CanGoBack)
                        {
                            journal.GoBack();
                        }
                    }
                    break;
                default:
                    _regionManager.RequestNavigate("ContentRegion", obj);
                    break;
            }
        }
    }
}
