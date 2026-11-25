using System.Windows;
using Lab09.ViewModel;

namespace Lab09.View
{
    public partial class UserInfoWindow : Window
    {
        public UserInfoWindow(UserInfoViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
            viewModel.RequestClose += result =>
            {
                DialogResult = result;
                Close();
            };
        }
    }
}
