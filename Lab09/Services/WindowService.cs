using System.Windows;
using Lab09.Model;
using Lab09.View;
using Lab09.ViewModel;

namespace Lab09.Services
{
    public class WindowService : IWindowService
    {
        private AboutWindow? _aboutWindow;

        public bool OpenEditUserDialog(User userCopy)
        {
            var vm = new UserInfoViewModel(userCopy);
            var dialog = new UserInfoWindow(vm)
            {
                Owner = Application.Current.MainWindow
            };
            return dialog.ShowDialog() == true;
        }

        public void OpenAboutWindow()
        {
            if (_aboutWindow != null && _aboutWindow.IsLoaded)
            {
                _aboutWindow.Activate();
                return;
            }

            _aboutWindow = new AboutWindow
            {
                Owner = Application.Current.MainWindow
            };
            _aboutWindow.Closed += (_, _) => _aboutWindow = null;
            _aboutWindow.Show();
        }

        public bool Confirm(string message, string title)
        {
            return MessageBox.Show(message, title, MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes;
        }
    }
}
