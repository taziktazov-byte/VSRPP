using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Lab11.ViewModel;

namespace Lab11
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel(InspectTrees, Close);
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private (int WinLogical, int WinVisual, int UcLogical, int UcVisual) InspectTrees()
        {
            int winLogical = CountLogicalDescendants(this);
            int winVisual = CountVisualDescendants(this);
            int ucLogical = CountLogicalDescendants(notificationControl);
            int ucVisual = CountVisualDescendants(notificationControl);
            return (winLogical, winVisual, ucLogical, ucVisual);
        }

        private static int CountLogicalDescendants(DependencyObject root)
        {
            int count = 0;
            foreach (object child in LogicalTreeHelper.GetChildren(root))
            {
                count++;
                if (child is DependencyObject depChild)
                {
                    count += CountLogicalDescendants(depChild);
                }
            }
            return count;
        }

        private static int CountVisualDescendants(DependencyObject root)
        {
            int count = 0;
            int childrenCount = VisualTreeHelper.GetChildrenCount(root);
            for (int i = 0; i < childrenCount; i++)
            {
                count++;
                DependencyObject child = VisualTreeHelper.GetChild(root, i);
                count += CountVisualDescendants(child);
            }
            return count;
        }
    }
}
