using System.Windows;

namespace Lab09.View
{
    public partial class AboutWindow : Window
    {
        public AboutWindow()
        {
            InitializeComponent();
        }

        private void BtnCloseAbout_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
