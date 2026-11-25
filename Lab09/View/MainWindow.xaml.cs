using System.Windows;
using Lab09.Services;
using Lab09.ViewModel;

namespace Lab09.View
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel(new WindowService());
        }
    }
}
