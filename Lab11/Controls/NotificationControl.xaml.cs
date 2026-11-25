using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Lab11.Controls
{
    public partial class NotificationControl : UserControl
    {
        public static readonly DependencyProperty MessageTextProperty =
            DependencyProperty.Register(
                nameof(MessageText),
                typeof(string),
                typeof(NotificationControl),
                new PropertyMetadata("Новое уведомление"));

        public static readonly DependencyProperty CloseCommandProperty =
            DependencyProperty.Register(
                nameof(CloseCommand),
                typeof(ICommand),
                typeof(NotificationControl),
                new PropertyMetadata(null));

        public string MessageText
        {
            get => (string)GetValue(MessageTextProperty);
            set => SetValue(MessageTextProperty, value);
        }

        public ICommand? CloseCommand
        {
            get => (ICommand?)GetValue(CloseCommandProperty);
            set => SetValue(CloseCommandProperty, value);
        }

        public event EventHandler? CloseRequested;

        public NotificationControl()
        {
            InitializeComponent();
        }

        private void BtnCloseNotification_Click(object sender, RoutedEventArgs e)
        {
            CloseRequested?.Invoke(this, EventArgs.Empty);

            if (CloseCommand != null && CloseCommand.CanExecute(null))
            {
                CloseCommand.Execute(null);
            }
        }
    }
}
