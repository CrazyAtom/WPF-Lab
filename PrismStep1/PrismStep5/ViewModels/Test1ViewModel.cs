using Prism;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PrismStep5.ViewModels
{
    public class Test1ViewModel : BindableBase, INavigationAware, IActiveAware
    {
        public string Header { get; set; }
        private IList<string> _messages = new ObservableCollection<string>();

        public event EventHandler IsActiveChanged;
        private bool _isActive;
        public bool IsActive
        {
            get { return _isActive; }
            set
            {
                SetProperty(ref _isActive, value,
                    () => Messages.Add($"{GetType().Name} IsActive : {IsActive}"));
            }
        }

        public IList<string> Messages
        {
            get { return _messages; }
            set { SetProperty(ref _messages, value); }
        }

        public Test1ViewModel()
        {
            Header = GetType().Name;
            Messages.Add(Header);
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            Messages.Add($"{GetType().Name} OnNavigatedFrom");
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            Messages.Add($"{GetType().Name} OnNavigatedTo - {navigationContext.NavigationService.Journal.CurrentEntry}");
        }
    }
}
