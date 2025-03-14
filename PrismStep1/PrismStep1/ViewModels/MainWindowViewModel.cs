using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Diagnostics;
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

        public ICommand NavigateCommand { get; set; }

        public MainWindowViewModel()
        {

        }
        public MainWindowViewModel(IContainerProvider containerProvider)
        {
            // 프리즘에서 사용하고 있는 IoC Container를 생성자 주입 후 로컬 변수로 등록하고 사용합니다.
            _containerProvider = containerProvider;
            // NavigateCommand 생성 - 꼭 생성자에서 만들 필요는 없지만 클래스가 만들어진 후 빠르게 생성하는 것이 좋습니다.
            NavigateCommand = new DelegateCommand<string>(OnNavigate, CanNavigate);
            // 네이게이션 할 View 이름들
            NavigationNames = new List<string>
            {
                "Sample1View",
                "Sample2View"
            };
        }

        private void OnNavigate(string obj)
        {
            Debug.WriteLine($"OnNavigate : {obj}");
        }

        private bool CanNavigate(string arg)
        {
            return true;
        }
    }
}
