using WpfTestApp.Models;
using WpfTestApp.ViewModels.Bases;

namespace WpfTestApp.ViewModels
{
    class MainWindowViewModel : ViewModelBase
    {
        private IList<bool> _genderTypes = new List<bool>() { true, false };
        public IList<bool> GenderTypes { get => _genderTypes; }

        private IList<Person>? _people;
        public IList<Person>? People { 
            get => _people;
            set => SetProperty(ref _people, value);
        }
        
        private Person? _selectedPerson;
        public Person? SelectedPerson
        {
            get => _selectedPerson;
            set => SetProperty(ref _selectedPerson, value);
        }

        public MainWindowViewModel()
        {
            People = new List<Person>
            {
                new Person{Id = 119302, Name = "김정현", Gender = true},
                new Person{Id = 119303, Name = "이현재", Gender = true},
                new Person{Id = 119304, Name = "송정환", Gender = true},
                new Person{Id = 119305, Name = "이보현", Gender = true},
                new Person{Id = 119306, Name = "고진욱", Gender = true},
                new Person{Id = 119307, Name = "황보아", Gender = true},
                new Person{Id = 119308, Name = "김푸름", Gender = true},
                new Person{Id = 119309, Name = "백아인", Gender = true},
                new Person{Id = 119310, Name = "신소현", Gender = false},
                new Person{Id = 119311, Name = "주명길", Gender = true},
            };
        }
    }
}
