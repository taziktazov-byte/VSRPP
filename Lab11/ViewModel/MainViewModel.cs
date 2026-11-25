using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Lab11.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly Func<(int WinLogical, int WinVisual, int UcLogical, int UcVisual)> _treeInspector;
        private readonly Action _closeWindowAction;

        private bool _isNotificationVisible = true;
        private string _notificationText = "Добро пожаловать! Круглое окно можно перетаскивать мышью.";
        private bool _isToggleChecked;
        private string _treeSummary = "Нажмите «Анализ дерева», чтобы посчитать элементы.";

        public MainViewModel(
            Func<(int WinLogical, int WinVisual, int UcLogical, int UcVisual)> treeInspector,
            Action closeWindowAction)
        {
            _treeInspector = treeInspector;
            _closeWindowAction = closeWindowAction;

            CloseNotificationCommand = new RelayCommand(_ => IsNotificationVisible = false);
            ShowNotificationCommand = new RelayCommand(_ =>
            {
                NotificationText = IsToggleChecked
                    ? "Уведомление активно (переключатель ВКЛ)."
                    : "Уведомление показано (переключатель ВЫКЛ).";
                IsNotificationVisible = true;
            });
            AnalyzeTreesCommand = new RelayCommand(_ => AnalyzeTrees());
            CloseAppCommand = new RelayCommand(_ => _closeWindowAction());
        }

        public bool IsNotificationVisible
        {
            get => _isNotificationVisible;
            set
            {
                if (_isNotificationVisible != value)
                {
                    _isNotificationVisible = value;
                    OnPropertyChanged();
                }
            }
        }

        public string NotificationText
        {
            get => _notificationText;
            set
            {
                if (_notificationText != value)
                {
                    _notificationText = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsToggleChecked
        {
            get => _isToggleChecked;
            set
            {
                if (_isToggleChecked != value)
                {
                    _isToggleChecked = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(ToggleStatusText));
                }
            }
        }

        public string ToggleStatusText => IsToggleChecked ? "Состояние: ВКЛЮЧЕНО" : "Состояние: ВЫКЛЮЧЕНО";

        public string TreeSummary
        {
            get => _treeSummary;
            set
            {
                if (_treeSummary != value)
                {
                    _treeSummary = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand CloseNotificationCommand { get; }
        public ICommand ShowNotificationCommand { get; }
        public ICommand AnalyzeTreesCommand { get; }
        public ICommand CloseAppCommand { get; }

        private void AnalyzeTrees()
        {
            var stats = _treeInspector();
            TreeSummary =
                $"MainWindow: логических={stats.WinLogical}, визуальных={stats.WinVisual} | " +
                $"NotificationControl: логических={stats.UcLogical}, визуальных={stats.UcVisual}";
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
