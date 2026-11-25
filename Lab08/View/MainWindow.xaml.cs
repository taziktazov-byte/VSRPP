using System.Windows;
using Lab08.ViewModel;

namespace Lab08.View
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
