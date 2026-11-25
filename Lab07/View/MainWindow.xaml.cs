using System.Windows;
using Lab07.ViewModel;

namespace Lab07.View
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}
