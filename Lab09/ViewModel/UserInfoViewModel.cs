using System;
using System.Windows.Input;
using Lab09.Model;

namespace Lab09.ViewModel
{
    public class UserInfoViewModel
    {
        public User EditableUser { get; }

        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        public event Action<bool>? RequestClose;

        public UserInfoViewModel(User user)
        {
            EditableUser = user;
            SaveCommand = new RelayCommand(_ => RequestClose?.Invoke(true));
            CancelCommand = new RelayCommand(_ => RequestClose?.Invoke(false));
        }
    }
}
