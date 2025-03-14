using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using PrismStep1.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace PrismStep1.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        /// <summary>
        /// ContainerProvider
        /// </summary>
        private readonly IContainerProvider _containerProvider;

        private IList<string> _navigationNames;

        /// <summary>
        /// Navigation Names
        /// </summary>
        public IList<string> NavigationNames
        {
            get { return _navigationNames; }
            set { SetProperty(ref _navigationNames, value); }
        }

        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        /// <summary>
        /// 선택된 네이게이션 할 뷰 이름
        /// </summary>
        private string _selectedNavigationName;
        public string SelectedNavigationName
        {
            get { return _selectedNavigationName; }
            set { SetProperty(ref _selectedNavigationName, value); }
        }

        public ICommand NavigateCommand { get; set; }

        public ICommand CreatePersonCommand { get; set; }

        public ICommand CreatePerson2Command { get; set; }

        public MainWindowViewModel()
        {

        }
        public MainWindowViewModel(IContainerProvider containerProvider)
        {
            // 프리즘에서 사용하고 있는 IoC Container를 생성자 주입 후 로컬 변수로 등록하고 사용합니다.
            _containerProvider = containerProvider;
            // NavigateCommand 생성 - 꼭 생성자에서 만들 필요는 없지만 클래스가 만들어진 후 빠르게 생성하는 것이 좋습니다.
            NavigateCommand = new DelegateCommand(OnNavigate, CanNavigate)
                .ObservesProperty(() => SelectedNavigationName);
            // 네이게이션 할 View 이름들
            NavigationNames = new List<string>
            {
                "Sample1View",
                "Sample2View"
            };

            CreatePersonCommand = new DelegateCommand(OnCreatePerson);

            CreatePerson2Command = new DelegateCommand(OnCreatePerson2);
        }
        private void OnNavigate()
        {
            Debug.WriteLine($"OnNavigate : {SelectedNavigationName}");
        }

        private bool CanNavigate()
        {
            return string.IsNullOrEmpty(SelectedNavigationName) == false;
        }

        private void OnCreatePerson()
        {
            var person1 = _containerProvider.Resolve<Person>();
            var person2 = _containerProvider.Resolve<Person>();
            ShowMessage(person1, person2, "Create Person");
        }

        private void OnCreatePerson2()
        {
            var person1 = _containerProvider.Resolve<Person>("p1");
            var person2 = _containerProvider.Resolve<Person>("p2");
            ShowMessage(person1, person2, "Create Person2");
        }

        private void ShowMessage(object one, object two, string title = "")
        {
            if (one == null || two == null)
            {
                MessageBox.Show("Both objects must be not null", title);
                return;
            }
            if (one.Equals(two))
            {
                MessageBox.Show("It's the same instance", title);
            }
            else
            {
                MessageBox.Show("They are different instance", title);
            }
        }
    }
}
