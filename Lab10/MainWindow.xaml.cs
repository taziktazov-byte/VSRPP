using System.Windows;
using System.Windows.Media.Animation;

namespace Lab10
{
    public partial class MainWindow : Window
    {
        private Storyboard? _storyboard;
        private bool _isStarted;
        private bool _isPaused;

        public MainWindow()
        {
            InitializeComponent();
            Loaded += (_, _) =>
            {
                _storyboard = (Storyboard)Resources["MainAnimationStoryboard"];
                _storyboard.Begin(this, true);
                _isStarted = true;
                _isPaused = false;
            };
        }

        private void BtnStartAnimation_Click(object sender, RoutedEventArgs e)
        {
            _storyboard ??= (Storyboard)Resources["MainAnimationStoryboard"];
            if (!_isStarted)
            {
                _storyboard.Begin(this, true);
                _isStarted = true;
                _isPaused = false;
            }
            else if (_isPaused)
            {
                _storyboard.Resume(this);
                _isPaused = false;
            }
        }

        private void BtnStopAnimation_Click(object sender, RoutedEventArgs e)
        {
            if (_storyboard != null && _isStarted && !_isPaused)
            {
                _storyboard.Pause(this);
                _isPaused = true;
            }
        }
    }
}
