using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Lab08.Model
{
    public class User : INotifyPropertyChanged
    {
        private string _name = string.Empty;
        private int _age;
        private bool _isStudent;

        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Age
        {
            get => _age;
            set
            {
                if (_age != value)
                {
                    _age = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsStudent
        {
            get => _isStudent;
            set
            {
                if (_isStudent != value)
                {
                    _isStudent = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
