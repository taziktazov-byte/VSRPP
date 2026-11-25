using System;
using System.Windows;

namespace Lab03
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnGreet_Click(object sender, RoutedEventArgs e)
        {
            string userName = txtUserName.Text.Trim();
            if (string.IsNullOrEmpty(userName))
            {
                MessageBox.Show("Пожалуйста, введите ваше имя.", "Предупреждение",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                txtUserName.Focus();
                return;
            }

            string greeting = $"Здравствуйте, {userName}! Рады видеть вас в WPF-приложении.";
            txtGreeting.Text = greeting;
            UpdateDateDisplay();

            MessageBox.Show(greeting, "Приветствие", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ChkShowDate_Changed(object sender, RoutedEventArgs e)
        {
            UpdateDateDisplay();
        }

        private void UpdateDateDisplay()
        {
            if (chkShowDate.IsChecked == true)
            {
                txtDateOutput.Text = $"Текущая дата и время: {DateTime.Now:dd.MM.yyyy HH:mm:ss}";
                txtDateOutput.Visibility = Visibility.Visible;
            }
            else
            {
                txtDateOutput.Text = string.Empty;
                txtDateOutput.Visibility = Visibility.Collapsed;
            }
        }
    }
}
