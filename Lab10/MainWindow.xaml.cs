using System.Windows;
using System.Windows.Media.Animation;

namespace Lab10
{
    public partial class MainWindow : Window
    {
        private Storyboard? _storyboard;

        public MainWindow()
        {
            InitializeComponent();
            Loaded += (_, _) =>
            {
                _storyboard = (Storyboard)Resources["MainAnimationStoryboard"];
                _storyboard.Begin(this, true);
            };
        }

        private void BtnStartAnimation_Click(object sender, RoutedEventArgs e)
        {
            _storyboard ??= (Storyboard)Resources["MainAnimationStoryboard"];
            _storyboard.Begin(this, true);
        }

        private void BtnStopAnimation_Click(object sender, RoutedEventArgs e)
        {
            _storyboard?.Stop(this);
        }
    }
}
