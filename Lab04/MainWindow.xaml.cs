using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Lab04
{
    public partial class MainWindow : Window
    {
        private record CategoryEntry(string Title, string Description, (string Heading, string Body)[] Cards);

        private readonly Dictionary<string, CategoryEntry> _catalog = new()
        {
            ["lang_root"] = new(
                "Языки программирования",
                "Основные языки, используемые при разработке клиентских и серверных систем.",
                new[]
                {
                    ("C# (.NET 8)", "Объектно-ориентированный язык для WPF, WinForms, ASP.NET Core."),
                    ("Python", "Высокоуровневый язык для автоматизации, анализа данных и бэкенда."),
                    ("TypeScript", "Строго типизированное надмножество JavaScript для веб-приложений.")
                }),
            ["csharp"] = new(
                "C# (.NET 8)",
                "Основной язык платформы .NET с поддержкой LINQ, async/await, pattern matching и строгой типизацией.",
                new[]
                {
                    ("Парадигма", "ООП, обобщённое и функциональное программирование."),
                    ("Экосистема", "WPF, WinForms, Blazor, ASP.NET Core, Entity Framework Core."),
                    ("Инструменты", "Visual Studio 2022, .NET CLI, Roslyn.")
                }),
            ["python"] = new(
                "Python",
                "Лаконичный язык с динамической типизацией и богатой стандартной библиотекой.",
                new[]
                {
                    ("Применение", "ML/AI, веб-сервисы (FastAPI, Django), скрипты."),
                    ("Особенности", "Читаемый синтаксис, отступы вместо фигурных скобок."),
                    ("Пакеты", "pip, PyPI, виртуальные окружения venv.")
                }),
            ["ts"] = new(
                "TypeScript",
                "Добавляет статические типы поверх JavaScript, компилируется в чистый JS.",
                new[]
                {
                    ("Преимущества", "Раннее выявление ошибок, автодополнение в IDE."),
                    ("Фреймворки", "React, Angular, Vue, Node.js."),
                    ("Система типов", "Интерфейсы, union-типы, дженерики.")
                }),
            ["ui_root"] = new(
                "Платформы пользовательского интерфейса",
                "Технологии .NET для создания графических настольных и кроссплатформенных приложений.",
                new[]
                {
                    ("WPF", "Векторный UI на базе DirectX и декларативного XAML."),
                    ("WinForms", "Быстрая разработка классических оконных приложений Windows."),
                    (".NET MAUI", "Кроссплатформенный UI для Windows, macOS, Android, iOS.")
                }),
            ["wpf"] = new(
                "WPF (Windows Presentation Foundation)",
                "Современная подсистема построения интерфейсов Windows с XAML, привязкой данных и MVVM.",
                new[]
                {
                    ("Компоновка", "Grid, DockPanel, StackPanel, WrapPanel, Canvas."),
                    ("Стилизация", "Styles, ControlTemplate, ResourceDictionary, Trigger."),
                    ("Архитектура", "Идеально подходит для паттерна MVVM и ICommand.")
                }),
            ["winforms"] = new(
                "Windows Forms",
                "Событийно-ориентированная библиотека элементов управления для настольных приложений.",
                new[]
                {
                    ("Дизайнер", "Визуальное проектирование форм с генерацией *.Designer.cs."),
                    ("Графика", "GDI+ (Graphics, Pen, Brush, Bitmap)."),
                    ("Диалоги", "OpenFileDialog, SaveFileDialog, ColorDialog, FontDialog.")
                }),
            ["maui"] = new(
                ".NET MAUI",
                "Эволюция Xamarin.Forms для единой кодовой базы под мобильные и десктопные ОС.",
                new[]
                {
                    ("Платформы", "Android, iOS, macOS Catalyst, Windows (WinUI 3)."),
                    ("Разметка", "XAML или C# Markup + Hot Reload.")
                }),
            ["db_root"] = new(
                "Системы хранения данных",
                "Реляционные СУБД для надёжного хранения и обработки структурированных данных.",
                new[]
                {
                    ("PostgreSQL", "Мощная клиент-серверная СУБД с поддержкой JSONB и расширений."),
                    ("SQLite", "Встраиваемая файловая СУБД без отдельного сервера.")
                }),
            ["postgres"] = new(
                "PostgreSQL",
                "Свободная объектно-реляционная СУБД промышленного уровня.",
                new[]
                {
                    ("Возможности", "ACID, MVCC, оконные функции, JSONB, полнотекстовый поиск."),
                    ("Подключение в .NET", "Npgsql и Entity Framework Core.")
                }),
            ["sqlite"] = new(
                "SQLite",
                "Компактная локальная БД, хранящая все таблицы в одном файле.",
                new[]
                {
                    ("Сценарии", "Локальные кэши, настольные утилиты, мобильные приложения."),
                    ("Подключение в .NET", "Microsoft.Data.Sqlite.")
                })
        };

        public MainWindow()
        {
            InitializeComponent();
            tviWpf.IsSelected = true;
        }

        private void TvCategories_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (e.NewValue is not TreeViewItem item)
            {
                return;
            }

            string key = item.Tag?.ToString() ?? string.Empty;
            if (!_catalog.TryGetValue(key, out var entry))
            {
                return;
            }

            txtCategoryTitle.Text = entry.Title;
            txtCategoryDescription.Text = entry.Description;
            txtCurrentBranch.Text = $"Выбрано: {item.Header}";
            txtCanvasSelectedInfo.Text = $"Активный раздел: {entry.Title}";

            RenderCards(entry.Cards);
        }

        private void RenderCards((string Heading, string Body)[] cards)
        {
            cardsWrapPanel.Children.Clear();

            foreach (var (heading, body) in cards)
            {
                var cardBorder = new Border
                {
                    Width = 230,
                    Margin = new Thickness(0, 0, 12, 12),
                    Padding = new Thickness(14),
                    Background = new SolidColorBrush(Color.FromRgb(248, 250, 252)),
                    BorderBrush = new SolidColorBrush(Color.FromRgb(203, 213, 225)),
                    BorderThickness = new Thickness(1),
                    CornerRadius = new CornerRadius(8)
                };

                var stack = new StackPanel();
                stack.Children.Add(new TextBlock
                {
                    Text = heading,
                    FontSize = 14,
                    FontWeight = FontWeights.Bold,
                    Foreground = new SolidColorBrush(Color.FromRgb(30, 58, 138)),
                    TextWrapping = TextWrapping.Wrap,
                    Margin = new Thickness(0, 0, 0, 6)
                });
                stack.Children.Add(new TextBlock
                {
                    Text = body,
                    FontSize = 12.5,
                    Foreground = new SolidColorBrush(Color.FromRgb(51, 65, 85)),
                    TextWrapping = TextWrapping.Wrap
                });

                cardBorder.Child = stack;
                cardsWrapPanel.Children.Add(cardBorder);
            }
        }

        private void BtnExpandAll_Click(object sender, RoutedEventArgs e)
        {
            SetExpandedState(tvCategories.Items, true);
        }

        private void BtnCollapseAll_Click(object sender, RoutedEventArgs e)
        {
            SetExpandedState(tvCategories.Items, false);
        }

        private static void SetExpandedState(ItemCollection items, bool expanded)
        {
            foreach (object obj in items)
            {
                if (obj is TreeViewItem tvi)
                {
                    tvi.IsExpanded = expanded;
                    SetExpandedState(tvi.Items, expanded);
                }
            }
        }

        private void BtnSwitchPage_Click(object sender, RoutedEventArgs e)
        {
            tabPages.SelectedIndex = tabPages.SelectedIndex == 0 ? 1 : 0;
        }

        private void BtnAbout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "Лабораторная работа №4 (Вариант 2).\nНавигация выполнена на базе TreeView с раскрывающимися ветками, а рабочая область адаптируется под размер окна.",
                "О справочнике",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }
    }
}
