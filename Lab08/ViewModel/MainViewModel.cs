using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using Lab08.Model;
using Microsoft.Win32;

namespace Lab08.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly User _user;
        private readonly RelayCommand _showInfoCommand;
        private readonly RelayCommand _deleteUserCommand;
        private readonly RelayCommand _confirmCommand;

        private string _selectedFilePath = "Файл не выбран";
        private string _statusMessage = "Готово к работе";

        public MainViewModel()
        {
            _user = new User
            {
                Name = "Иван",
                Age = 20,
                IsStudent = true
            };
            _user.PropertyChanged += User_PropertyChanged;

            _showInfoCommand = new RelayCommand(_ => ShowInfo(), _ => !string.IsNullOrWhiteSpace(Name));
            _deleteUserCommand = new RelayCommand(DeleteUser, p => !string.IsNullOrWhiteSpace(p?.ToString() ?? Name));
            _confirmCommand = new RelayCommand(ConfirmAction, p => !string.IsNullOrWhiteSpace(p?.ToString() ?? Name));
            ShowDialogCommand = new RelayCommand(_ => OpenFile());
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

        public string SelectedFilePath
        {
            get => _selectedFilePath;
            set
            {
                if (_selectedFilePath != value)
                {
                    _selectedFilePath = value;
                    OnPropertyChanged();
                }
            }
        }

        public string StatusMessage
        {
            get => _statusMessage;
            set
            {
                if (_statusMessage != value)
                {
                    _statusMessage = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand ShowInfoCommand => _showInfoCommand;
        public ICommand DeleteUserCommand => _deleteUserCommand;
        public ICommand ShowDialogCommand { get; }
        public ICommand ConfirmCommand => _confirmCommand;

        private void User_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(User.Name))
            {
                OnPropertyChanged(nameof(Name));
                _showInfoCommand.RaiseCanExecuteChanged();
                _deleteUserCommand.RaiseCanExecuteChanged();
                _confirmCommand.RaiseCanExecuteChanged();
            }
            else if (e.PropertyName == nameof(User.Age))
            {
                OnPropertyChanged(nameof(Age));
            }
            else if (e.PropertyName == nameof(User.IsStudent))
            {
                OnPropertyChanged(nameof(IsStudent));
            }
        }

        private void ShowInfo()
        {
            string status = IsStudent ? "Да" : "Нет";
            MessageBox.Show(
                $"Имя: {Name}\nВозраст: {Age}\nСтудент: {status}\nВыбранный файл: {SelectedFilePath}",
                "Информация о пользователе",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
            StatusMessage = $"Показана информация о пользователе {Name} (файл: {SelectedFilePath}).";
        }

        private void DeleteUser(object? parameter)
        {
            string targetName = parameter?.ToString() ?? string.Empty;
            Name = string.Empty;
            Age = 0;
            IsStudent = false;
            StatusMessage = $"Пользователь «{targetName}» удалён (поля очищены).";
        }

        private void ConfirmAction(object? parameter)
        {
            string targetName = parameter?.ToString()?.Trim() ?? string.Empty;
            if (string.IsNullOrEmpty(targetName))
            {
                targetName = "Без имени";
            }

            var result = MessageBox.Show(
                $"Удалить пользователя {targetName}?",
                "Подтверждение действия",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                Name = string.Empty;
                Age = 0;
                IsStudent = false;
                StatusMessage = $"Подтверждено удаление пользователя {targetName}.";
            }
            else
            {
                StatusMessage = $"Удаление пользователя {targetName} отменено.";
            }
        }

        private void OpenFile()
        {
            var dialog = new OpenFileDialog
            {
                Title = "Выберите файл",
                Filter = "Все файлы (*.*)|*.*|Текстовые файлы (*.txt)|*.txt"
            };

            if (dialog.ShowDialog() == true)
            {
                SelectedFilePath = dialog.FileName;
                StatusMessage = "Путь к файлу обновлён через OpenFileDialog.";
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
