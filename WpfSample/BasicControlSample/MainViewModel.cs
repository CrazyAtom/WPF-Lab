using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace BasicControlSample
{
    class MainViewModel : ObservableObject
    {
        private ObservableCollection<Person> _persons = new ObservableCollection<Person>
        {
                new Person{ Name = "person0101", Sex = true, Age = 11, Address = "Seoul1" },
                new Person{ Name = "person0102", Sex = false, Age = 12, Address = "Seoul2" },
                new Person{ Name = "person0103", Sex = true, Age = 13, Address = "Seoul3" },
                new Person{ Name = "person0104", Sex = false, Age = 14, Address = "Seoul4" },
                new Person{ Name = "person0105", Sex = true, Age = 15, Address = "Seoul5" },
                new Person{ Name = "person0106", Sex = false, Age = 16, Address = "Seoul6" },
                new Person{ Name = "person0107", Sex = true, Age = 17, Address = "Seoul7" },
                new Person{ Name = "person0108", Sex = false, Age = 18, Address = "Seoul8" },
                new Person{ Name = "person0109", Sex = true, Age = 19, Address = "Seoul9" },
                new Person{ Name = "person0110", Sex = false, Age = 20, Address = "Seoul10" },
        };

        public ObservableCollection<Person> Persons { get { return _persons; } }

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

        private Person _selectedListItem2;
        public Person SelectedListItem2
        {
            get { return _selectedListItem2; }
            set { SetProperty(ref _selectedListItem2, value); }
        }

        private Person _selectedComboItem2;
        public Person SelectedComboItem2
        {
            get { return _selectedComboItem2; }
            set { SetProperty(ref _selectedComboItem2, value); }
        }

        public IRelayCommand DeleteListItemCommand { get; set; }

        public IRelayCommand DeleteComboItemCommand { get; set; }

        public MainViewModel()
        {
            Init();
        }

        private void Init()
        {
            SelectedListItem = Persons.FirstOrDefault();
            SelectedComboItem = Persons.FirstOrDefault();

            // 커맨드 생성
            DeleteListItemCommand = new RelayCommand(OnDeleteListItem,
                () => SelectedListItem2 != null && (SelectedListItem2.Age % 2 == 0));
            DeleteComboItemCommand = new RelayCommand(OnDeleteComboItem,
                () => SelectedComboItem2 != null && (SelectedComboItem2.Age % 2 == 1));

            // 프로퍼티 체인지 이벤트 핸들러 추가
            PropertyChanged += MainViewModel_PropertyChanged;

        }

        private void MainViewModel_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(SelectedListItem2):
                    DeleteListItemCommand.NotifyCanExecuteChanged();
                    break;
                case nameof(SelectedComboItem2):
                    DeleteComboItemCommand.NotifyCanExecuteChanged();
                    break;
            }
        }

        private void OnDeleteListItem()
        {
            Persons.Remove(SelectedListItem2);
        }

        private void OnDeleteComboItem()
        {
            Persons.Remove(SelectedComboItem2);
        }
    }
}
