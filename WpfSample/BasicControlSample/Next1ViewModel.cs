using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Controls;

namespace BasicControlSample
{
    class Next1ViewModel : ObservableObject
    {
        private ObservableCollection<Person> _persons = new ObservableCollection<Person>
        {
                new Person{ Name = "person0101", Sex = true, Age = 11, Address = "06090" },
                new Person{ Name = "person0102", Sex = false, Age = 12, Address = "06090" },
                new Person{ Name = "person0103", Sex = true, Age = 13, Address = "06090" },
                new Person{ Name = "person0104", Sex = false, Age = 14, Address = "06090" },
                new Person{ Name = "person0105", Sex = true, Age = 15, Address = "06090" },
                new Person{ Name = "person0106", Sex = false, Age = 16, Address = "06090" },
                new Person{ Name = "person0107", Sex = true, Age = 17, Address = "02043" },
                new Person{ Name = "person0108", Sex = false, Age = 18, Address = "02043" },
                new Person{ Name = "person0109", Sex = true, Age = 19, Address = "02043" },
                new Person{ Name = "person0110", Sex = false, Age = 20, Address = "02043" },
        };

        public ObservableCollection<Person> Persons { get { return _persons; } }

        public ObservableCollection<CodeModel> Sexs { get; set; } =
        [
            new CodeModel { Name = "Male", Value = true, Code = "male" },
            new CodeModel { Name = "Female", Value = false, Code = "female"}
        ];

        public ObservableCollection<CodeModel> Addressies { get; set; } =
        [
            new CodeModel { Name = "서울 강남구", Code = "06090" },
            new CodeModel { Name = "서울 중량구", Code = "02043" },
        ];

        private Person _selectedListItem;
        public Person SelectedListItem
        {
            get { return _selectedListItem; }
            set { SetProperty(ref _selectedListItem, value); }
        }

        private Person _selectedComboItem;
        public Person SelectedComboItem
        {
            get { return _selectedComboItem; }
            set { SetProperty(ref _selectedComboItem, value); }
        }

        /// <summary>
        /// 리스트 셀렉션 체인지 이벤트 커맨드
        /// </summary>
        public IRelayCommand ListSelectionChangedCommand { get; set; }

        /// <summary>
        /// 리스트 아이템 삭제 커맨드
        /// </summary>
        public IRelayCommand DeleteListItemCommand { get; set; }

        /// <summary>
        /// 콤보 셀렉션 체인지 이벤트 커맨드
        /// </summary>
        public IRelayCommand<object> ComboSelectionChangedCommand { get; set; }

        /// <summary>
        /// 콤보 아이템 삭제 커맨드
        /// </summary>
        public IRelayCommand DeleteComboItemCommand { get; set; }

        public Next1ViewModel()
        {
            Init();
        }

        private void Init()
        {
            //SelectedListItem = Persons.FirstOrDefault();
            //SelectedComboItem = Persons.FirstOrDefault();
            ListSelectionChangedCommand = new RelayCommand(OnListSelectionChanged);
            DeleteListItemCommand = new RelayCommand(OnDeleteListItem,
                () => SelectedListItem != null && (SelectedListItem.Age % 2 == 0));
            ComboSelectionChangedCommand = new RelayCommand<object>(OnComboSelectionChanged);
            DeleteComboItemCommand = new RelayCommand(OnDeleteComboItem,
                () => SelectedComboItem != null && (SelectedComboItem.Age % 2 == 1));
        }
        private void OnDeleteListItem()
        {
            Persons.Remove(SelectedListItem);
        }

        private void OnListSelectionChanged()
        {
            DeleteListItemCommand.NotifyCanExecuteChanged();
        }

        private void OnDeleteComboItem()
        {
            Persons.Remove(SelectedComboItem);
        }

        private void OnComboSelectionChanged(object arg)
        {
            var eventArg = arg as SelectionChangedEventArgs;
            if (eventArg == null)
            {
                return;
            }

            Debug.WriteLine(eventArg.ToString());

            DeleteComboItemCommand.NotifyCanExecuteChanged();
        }

    }
}
