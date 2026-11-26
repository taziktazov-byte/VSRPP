using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using Microsoft.Win32;

namespace Lab12
{
    public partial class MainWindow : Window
    {
        private readonly Color[] _palette =
        {
            Color.FromRgb(96, 165, 250),
            Color.FromRgb(251, 191, 36),
            Color.FromRgb(52, 211, 153),
            Color.FromRgb(244, 114, 182),
            Color.FromRgb(167, 139, 250)
        };

        private int _colorIndex;

        private Storyboard? _pathStoryboard;
        private bool _isPathAnimStarted;
        private bool _isPathAnimPaused;

        private readonly DispatcherTimer _videoTimer;
        private bool _isDraggingVideoSlider;
        private bool _isUpdatingSliderFromTimer;

        public MainWindow()
        {
            InitializeComponent();

            _videoTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(200)
            };
            _videoTimer.Tick += VideoTimer_Tick;
            Closed += (_, _) => _videoTimer.Stop();
        }

        // --- 1. Видео (MediaElement + полоска выбора времени) ---
        private void BtnOpenVideo_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Title = "Выберите видеофайл",
                Filter = "Видеофайлы (*.mp4;*.wmv;*.avi;*.mkv)|*.mp4;*.wmv;*.avi;*.mkv|Все файлы (*.*)|*.*"
            };

            if (dialog.ShowDialog(this) == true)
            {
                _videoTimer.Stop();
                sldVideoProgress.IsEnabled = false;
                sldVideoProgress.Value = 0;
                txtVideoTime.Text = "00:00 / 00:00";

                mediaPlayer.Source = new Uri(dialog.FileName, UriKind.Absolute);
                txtVideoPath.Text = dialog.FileName;
                mediaPlayer.Play();
                _videoTimer.Start();
            }
        }

        private void BtnPlayVideo_Click(object sender, RoutedEventArgs e)
        {
            if (mediaPlayer.Source != null)
            {
                mediaPlayer.Play();
                _videoTimer.Start();
            }
        }

        private void BtnPauseVideo_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Pause();
            _videoTimer.Stop();
        }

        private void BtnStopVideo_Click(object sender, RoutedEventArgs e)
        {
            _videoTimer.Stop();
            mediaPlayer.Stop();
            UpdateSliderValueFromCode(0);
            UpdateVideoTimeLabel(TimeSpan.Zero);
        }

        private void MediaPlayer_MediaOpened(object? sender, RoutedEventArgs e)
        {
            if (mediaPlayer.NaturalDuration.HasTimeSpan)
            {
                TimeSpan total = mediaPlayer.NaturalDuration.TimeSpan;
                sldVideoProgress.Maximum = Math.Max(1, total.TotalSeconds);
                sldVideoProgress.IsEnabled = true;
                UpdateSliderValueFromCode(0);
                UpdateVideoTimeLabel(TimeSpan.Zero);
            }
        }

        private void MediaPlayer_MediaEnded(object? sender, RoutedEventArgs e)
        {
            _videoTimer.Stop();
            mediaPlayer.Stop();
            UpdateSliderValueFromCode(0);
            UpdateVideoTimeLabel(TimeSpan.Zero);
        }

        private void MediaPlayer_MediaFailed(object? sender, ExceptionRoutedEventArgs e)
        {
            _videoTimer.Stop();
            MessageBox.Show($"Ошибка воспроизведения медиа: {e.ErrorException.Message}",
                "Ошибка MediaElement", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void VideoTimer_Tick(object? sender, EventArgs e)
        {
            if (_isDraggingVideoSlider || !mediaPlayer.NaturalDuration.HasTimeSpan)
            {
                return;
            }

            TimeSpan pos = mediaPlayer.Position;
            UpdateSliderValueFromCode(pos.TotalSeconds);
            UpdateVideoTimeLabel(pos);
        }

        private void SldVideoProgress_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _isDraggingVideoSlider = true;
        }

        private void SldVideoProgress_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _isDraggingVideoSlider = false;
            SeekVideoToSlider();
        }

        private void SldVideoProgress_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (_isUpdatingSliderFromTimer)
            {
                return;
            }

            var targetPos = TimeSpan.FromSeconds(sldVideoProgress.Value);
            UpdateVideoTimeLabel(targetPos);

            if (!_isDraggingVideoSlider)
            {
                SeekVideoToSlider();
            }
        }

        private void SeekVideoToSlider()
        {
            if (mediaPlayer.Source != null && mediaPlayer.NaturalDuration.HasTimeSpan)
            {
                mediaPlayer.Position = TimeSpan.FromSeconds(sldVideoProgress.Value);
            }
        }

        private void UpdateSliderValueFromCode(double seconds)
        {
            _isUpdatingSliderFromTimer = true;
            sldVideoProgress.Value = seconds;
            _isUpdatingSliderFromTimer = false;
        }

        private void UpdateVideoTimeLabel(TimeSpan current)
        {
            string curText = FormatTime(current);
            string totalText = mediaPlayer.NaturalDuration.HasTimeSpan
                ? FormatTime(mediaPlayer.NaturalDuration.TimeSpan)
                : "00:00";
            txtVideoTime.Text = $"{curText} / {totalText}";
        }

        private static string FormatTime(TimeSpan time)
        {
            return time.TotalHours >= 1
                ? time.ToString(@"hh\:mm\:ss")
                : time.ToString(@"mm\:ss");
        }

        // --- 2. Изображения (Image) ---
        private void BtnOpenImage_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Title = "Выберите изображение",
                Filter = "Изображения (*.png;*.jpg;*.jpeg;*.bmp;*.gif)|*.png;*.jpg;*.jpeg;*.bmp;*.gif|Все файлы (*.*)|*.*"
            };

            if (dialog.ShowDialog(this) == true)
            {
                var bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(dialog.FileName, UriKind.Absolute);
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.EndInit();

                imgPreview.Source = bitmap;
                txtImagePath.Text = $"Путь: {dialog.FileName}";
            }
        }

        private void BtnClearImage_Click(object sender, RoutedEventArgs e)
        {
            imgPreview.Source = null;
            txtImagePath.Text = "Путь: файл не выбран";
        }

        // --- 3. Рисование (InkCanvas) ---
        private void BtnToggleErase_Click(object sender, RoutedEventArgs e)
        {
            if (inkCanvas.EditingMode == InkCanvasEditingMode.Ink)
            {
                inkCanvas.EditingMode = InkCanvasEditingMode.EraseByPoint;
                txtInkMode.Text = "Режим: Ластик";
            }
            else
            {
                inkCanvas.EditingMode = InkCanvasEditingMode.Ink;
                txtInkMode.Text = "Режим: Рисование";
            }
        }

        private void BtnClearInk_Click(object sender, RoutedEventArgs e)
        {
            inkCanvas.Strokes.Clear();
        }

        // --- 4. Фигуры и Вариант 2 (анимация Rectangle по пути с остановкой на месте) ---
        private void BtnChangeShapeColors_Click(object sender, RoutedEventArgs e)
        {
            _colorIndex = (_colorIndex + 1) % _palette.Length;

            shapeRect.Fill = new SolidColorBrush(_palette[_colorIndex]);
            shapeEllipse.Fill = new SolidColorBrush(_palette[(_colorIndex + 1) % _palette.Length]);
            shapePolygon.Fill = new SolidColorBrush(_palette[(_colorIndex + 2) % _palette.Length]);
        }

        private void BtnAnimateAlongPath_Click(object sender, RoutedEventArgs e)
        {
            _pathStoryboard ??= (Storyboard)Resources["RectPathStoryboard"];

            if (!_isPathAnimStarted)
            {
                _pathStoryboard.Begin(this, true);
                _isPathAnimStarted = true;
                _isPathAnimPaused = false;
            }
            else if (_isPathAnimPaused)
            {
                _pathStoryboard.Resume(this);
                _isPathAnimPaused = false;
            }
        }

        private void BtnStopPathAnim_Click(object sender, RoutedEventArgs e)
        {
            if (_pathStoryboard != null && _isPathAnimStarted && !_isPathAnimPaused)
            {
                _pathStoryboard.Pause(this);
                _isPathAnimPaused = true;
            }
        }
    }
}
