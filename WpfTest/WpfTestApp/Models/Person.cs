using CommunityToolkit.Mvvm.ComponentModel;

namespace WpfTestApp.Models
{
    class Person : ObservableObject
    {
        private int _id;
        public int Id { 
            get { return _id; } 
            set { SetProperty(ref _id, value); } 
        }

        private string? _name;
        public string? Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private bool _gender;
        public bool Gender
        {
            get { return _gender; }
            set { SetProperty(ref _gender, value); }
        }
    }
}
