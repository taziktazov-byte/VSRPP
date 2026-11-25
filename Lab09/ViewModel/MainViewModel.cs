using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Lab09.Model;
using Lab09.Services;

namespace Lab09.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly IWindowService _windowService;
        private string _lastActionInfo = "Профиль загружен.";

        public User CurrentUser { get; }

        public string LastActionInfo
        {
            get => _lastActionInfo;
            set
            {
                if (_lastActionInfo != value)
                {
                    _lastActionInfo = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand EditProfileCommand { get; }
        public ICommand DeleteProfileCommand { get; }
        public ICommand AboutCommand { get; }

        public MainViewModel(IWindowService windowService)
        {
            _windowService = windowService;
            CurrentUser = new User
            {
                Name = "Алексей Морозов",
                Age = 21,
                IsStudent = true
            };

            EditProfileCommand = new RelayCommand(_ => EditProfile());
            DeleteProfileCommand = new RelayCommand(_ => DeleteProfile());
            AboutCommand = new RelayCommand(_ => OpenAbout());
        }

        private void EditProfile()
        {
            User editableCopy = CurrentUser.Clone();
            bool saved = _windowService.OpenEditUserDialog(editableCopy);

            if (saved)
            {
                CurrentUser.CopyFrom(editableCopy);
                LastActionInfo = $"Профиль обновлён (DialogResult = true): {CurrentUser.Name}, {CurrentUser.Age} лет.";
            }
            else
            {
                LastActionInfo = "Редактирование отменено (DialogResult = false). Изменения не сохранены.";
            }
        }

        private void DeleteProfile()
        {
            bool confirmed = _windowService.Confirm(
                $"Вы действительно хотите удалить профиль пользователя «{CurrentUser.Name}»?",
                "Подтверждение удаления");

            if (confirmed)
            {
                CurrentUser.Name = "Не задано";
                CurrentUser.Age = 0;
                CurrentUser.IsStudent = false;
                LastActionInfo = "Профиль сброшен пользователем.";
            }
            else
            {
                LastActionInfo = "Удаление профиля отменено.";
            }
        }

        private void OpenAbout()
        {
            _windowService.OpenAboutWindow();
            LastActionInfo = "Открыто немодальное окно «О программе» (Show()).";
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
