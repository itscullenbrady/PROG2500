using System.ComponentModel;

namespace PROG2500_A4
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _firstName = "First Name";
        private string _lastName = "Last Name";
        private string _address = "Civic Address";
        private string _city = "City";
        private string _province = "Province";
        private string _postalCode = "Postal Code";
        private string _occupation = string.Empty;
        private string _hobbies = string.Empty;
        private bool _isDogLover = false;
        private bool _isCatLover = false;
        private int _selectedEyes = 0;
        private int _selectedNose = 0;
        private int _selectedMouth = 0;
        private int _selectedHair = 0;

        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        public string Address
        {
            get => _address;
            set
            {
                _address = value;
                OnPropertyChanged(nameof(Address));
            }
        }

        public string City
        {
            get => _city;
            set
            {
                _city = value;
                OnPropertyChanged(nameof(City));
            }
        }

        public string Province
        {
            get => _province;
            set
            {
                _province = value;
                OnPropertyChanged(nameof(Province));
            }
        }

        public string PostalCode
        {
            get => _postalCode;
            set
            {
                _postalCode = value;
                OnPropertyChanged(nameof(PostalCode));
            }
        }

        public string Occupation
        {
            get => _occupation;
            set
            {
                _occupation = value;
                OnPropertyChanged(nameof(Occupation));
            }
        }

        public string Hobbies
        {
            get => _hobbies;
            set
            {
                _hobbies = value;
                OnPropertyChanged(nameof(Hobbies));
            }
        }


        public bool IsDogLover
        {
            get => _isDogLover;
            set
            {
                _isDogLover = value;
                OnPropertyChanged(nameof(IsDogLover));
            }
        }

        public bool IsCatLover
        {
            get => _isCatLover;
            set
            {
                _isCatLover = value;
                OnPropertyChanged(nameof(IsCatLover));
            }
        }

        public int SelectedEyes
        {
            get => _selectedEyes;
            set
            {
                _selectedEyes = value;
                OnPropertyChanged(nameof(SelectedEyes));
            }
        }

        public int SelectedNose
        {
            get => _selectedNose;
            set
            {
                _selectedNose = value;
                OnPropertyChanged(nameof(SelectedNose));
            }
        }

        public int SelectedMouth
        {
            get => _selectedMouth;
            set
            {
                _selectedMouth = value;
                OnPropertyChanged(nameof(SelectedMouth));
            }
        }

        public int SelectedHair
        {
            get => _selectedHair;
            set
            {
                _selectedHair = value;
                OnPropertyChanged(nameof(SelectedHair));
            }
        }

        // The stuff to make INotifyPropertyChanged work :o
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}