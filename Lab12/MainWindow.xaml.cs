using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
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

        public MainWindow()
        {
            InitializeComponent();
        }

        // --- 1. Видео (MediaElement) ---
        private void BtnOpenVideo_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Title = "Выберите видеофайл",
                Filter = "Видеофайлы (*.mp4;*.wmv;*.avi;*.mkv)|*.mp4;*.wmv;*.avi;*.mkv|Все файлы (*.*)|*.*"
            };

            if (dialog.ShowDialog(this) == true)
            {
                mediaPlayer.Source = new Uri(dialog.FileName, UriKind.Absolute);
                txtVideoPath.Text = dialog.FileName;
                mediaPlayer.Play();
            }
        }

        private void BtnPlayVideo_Click(object sender, RoutedEventArgs e)
        {
            if (mediaPlayer.Source != null)
            {
                mediaPlayer.Play();
            }
        }

        private void BtnPauseVideo_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Pause();
        }

        private void BtnStopVideo_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Stop();
        }

        private void MediaPlayer_MediaFailed(object? sender, ExceptionRoutedEventArgs e)
        {
            MessageBox.Show($"Ошибка воспроизведения медиа: {e.ErrorException.Message}",
                "Ошибка MediaElement", MessageBoxButton.OK, MessageBoxImage.Error);
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

        // --- 4. Фигуры и Вариант 2 (анимация Rectangle по пути) ---
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
            _pathStoryboard.Begin(this, true);
        }

        private void BtnStopPathAnim_Click(object sender, RoutedEventArgs e)
        {
            _pathStoryboard?.Stop(this);
        }
    }
}
