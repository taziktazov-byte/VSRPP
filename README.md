# ВСРПП — Лабораторные работы №1–12 (Вариант 2)

В репозитории реализованы все 12 лабораторных работ по курсу ВСРПП на платформе `.NET 8` (`net8.0-windows`, Windows Forms и WPF). Для каждой работы выполнен **Вариант 2**.

## Состав решения (`VSRPP.sln`)

| Папка | Технология | Тема и особенность Варианта 2 |
|---|---|---|
| `Lab01` | Windows Forms | Авторизация, регистрация, профиль и сохранение в `users.json`. **Вариант 2:** смена цветовой темы (синяя/розовая) и генерация аватара в `PictureBox` при выборе пола. |
| `Lab02` | Windows Forms | Графический редактор (`MenuStrip`, `ContextMenuStrip`, диалоги, текст поверх изображения). **Вариант 2:** рисование поверх изображения мышью (`MouseDown`, `MouseMove`, `Graphics.DrawLine`). |
| `Lab03` | WPF | Базовое WPF-приложение на XAML с приветствием. **Вариант 2:** `CheckBox` «Показать дату», отображающий `DateTime.Now` под кнопкой. |
| `Lab04` | WPF | Адаптивный справочник (`Grid`, `DockPanel`, `StackPanel`, `WrapPanel`, `Canvas`, `TabControl`). **Вариант 2:** левое навигационное меню на основе `TreeView` с раскрывающимися категориями. |
| `Lab05` | WPF | Локальные и глобальные ресурсы, `ResourceDictionary` (`MergedDictionaries`), триггеры, `StaticResource` и `DynamicResource`. **Вариант 2:** динамический ресурс цвета фона окна, изменяемый программно по кнопке. |
| `Lab06` | WPF | Привязка данных (`Binding`, `Mode=TwoWay`), `INotifyPropertyChanged`, `ObservableCollection`, `IValueConverter`, `StringFormat`. **Вариант 2:** `AgeToBrushConverter` (`<18` — красный, `18–60` — чёрный, `>60` — синий). |
| `Lab07` | WPF (MVVM) | Строгое разделение на `Model`, `ViewModel`, `View`, команды `ClearCommand` и `SaveCommand`. **Вариант 2:** кнопка «Сделать совершеннолетним» (`MakeAdultCommand`, `Age = 18`). |
| `Lab08` | WPF (MVVM) | Команды `ICommand`, `CommandParameter`, `CanExecute`/`RaiseCanExecuteChanged`, `MessageBox` и `OpenFileDialog`. **Вариант 2:** команда «Подтвердить» (`ConfirmCommand`) с `MessageBox` и передачей имени через `CommandParameter`. |
| `Lab09` | WPF (MVVM) | Множественные окна (`MainWindow`, `UserInfoWindow`), `ShowDialog()` с возвратом `DialogResult`, подтверждение удаления. **Вариант 2:** отдельное немодальное окно «О программе» (`AboutWindow.Show()`). |
| `Lab10` | WPF | Анимации: `DoubleAnimation` (`Width`, `Height`, `Opacity`), `KeyFrames`, `MatrixAnimationUsingPath`, `EasingFunction` (`BounceEase`, `SineEase`), `Storyboard.Begin`/`Stop`. **Вариант 2:** `TextBlock`, опускающийся сверху вниз с затуханием `Opacity`. |
| `Lab11` | WPF | `UserControl` «Уведомление», `ControlTemplate` для `Button` с `VisualStateManager`, круглое окно (`DragMove()`), анализ логического/визуального дерева (`VisualLogicalTreeReport.md`). **Вариант 2:** `ToggleButton` с шаблоном и анимацией фона. |
| `Lab12` | WPF | `MediaElement`, `Image`, `InkCanvas`, фигуры (`Rectangle`, `Ellipse`, `Polygon`), `Path` + `PathGeometry`. **Вариант 2:** кнопка запуска анимации перемещения `Rectangle` вдоль `PathGeometry` (`MatrixAnimationUsingPath`). |

## Сборка и запуск (Windows)

Требуется [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) или Visual Studio 2022 (с нагрузкой «Разработка классических приложений .NET»):

```powershell
dotnet build VSRPP.sln
dotnet run --project Lab01
```
