using System.Windows;
using System.Windows.Media;

namespace Lab05
{
    public partial class MainWindow : Window
    {
        private readonly (string Name, Color Color)[] _themes =
        {
            ("Голубой (#EFF6FF)", Color.FromRgb(239, 246, 255)),
            ("Мятный (#ECFDF5)", Color.FromRgb(236, 253, 245)),
            ("Лавандовый (#F5F3FF)", Color.FromRgb(245, 243, 255)),
            ("Персиковый (#FFF7ED)", Color.FromRgb(255, 247, 237)),
            ("Тёмно-сланцевый (#1E293B)", Color.FromRgb(30, 41, 59))
        };

        private int _currentIndex;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnChangeWindowBg_Click(object sender, RoutedEventArgs e)
        {
            _currentIndex = (_currentIndex + 1) % _themes.Length;
            var (name, color) = _themes[_currentIndex];

            Resources["WindowBackgroundBrush"] = new SolidColorBrush(color);
            lblCurrentColor.Content = $"Текущий фон окна: {name}";

            if (chkUseCustomBorder.IsChecked == true && !string.IsNullOrWhiteSpace(txtNote.Text))
            {
                Title = $"Лаб. №5 — {name} ({txtNote.Text.Trim()})";
            }
        }

        private void BtnResetBg_Click(object sender, RoutedEventArgs e)
        {
            _currentIndex = 0;
            var (name, color) = _themes[0];
            Resources["WindowBackgroundBrush"] = new SolidColorBrush(color);
            lblCurrentColor.Content = $"Текущий фон окна: {name}";
            Title = "Лабораторная работа №5 — Стили, ресурсы и триггеры";
        }
    }
}
