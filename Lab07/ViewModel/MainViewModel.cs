using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using Lab07.Model;

namespace Lab07.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly User _user;
        private readonly RelayCommand _saveCommand;

        public MainViewModel()
        {
            _user = new User
            {
                Name = "Иван",
                Age = 16,
                IsStudent = true
            };

            _user.PropertyChanged += User_PropertyChanged;

            ClearCommand = new RelayCommand(_ => Clear());
            _saveCommand = new RelayCommand(_ => Save(), _ => !string.IsNullOrWhiteSpace(Name));
            MakeAdultCommand = new RelayCommand(_ => MakeAdult());
        }

        public string Name
        {
            get => _user.Name;
            set
            {
                if (_user.Name != value)
                {
                    _user.Name = value;
                }
            }
        }

        public int Age
        {
            get => _user.Age;
            set
            {
                if (_user.Age != value)
                {
                    _user.Age = value;
                }
            }
        }

        public bool IsStudent
        {
            get => _user.IsStudent;
            set
            {
                if (_user.IsStudent != value)
                {
                    _user.IsStudent = value;
                }
            }
        }

        public string StudentStatusText => IsStudent ? "Студент" : "Не студент";

        public ICommand ClearCommand { get; }
        public ICommand SaveCommand => _saveCommand;
        public ICommand MakeAdultCommand { get; }

        private void User_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(User.Name))
            {
                OnPropertyChanged(nameof(Name));
                _saveCommand.RaiseCanExecuteChanged();
            }
            else if (e.PropertyName == nameof(User.Age))
            {
                OnPropertyChanged(nameof(Age));
            }
            else if (e.PropertyName == nameof(User.IsStudent))
            {
                OnPropertyChanged(nameof(IsStudent));
                OnPropertyChanged(nameof(StudentStatusText));
            }
        }

        private void Clear()
        {
            Name = string.Empty;
            Age = 0;
            IsStudent = false;
        }

        private void Save()
        {
            MessageBox.Show(
                $"Сохранённые данные:\nИмя: {Name}\nВозраст: {Age}\nСтатус: {StudentStatusText}",
                "Профиль пользователя",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }

        private void MakeAdult()
        {
            Age = 18;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
