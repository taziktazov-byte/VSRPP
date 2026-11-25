# Подробное описание лабораторных работ №1–12 (Вариант 2)

В этом документе описано, что реализовано в каждой из 12 лабораторных работ решения `VSRPP.sln`, какие файлы входят в проекты и как устроена логика их работы.

---

## Лабораторная работа №1 (`Lab01`) — Windows Forms: авторизация, регистрация, JSON и тема по полу

### Что сделано
- `Models/User.cs` — модель пользователя (`Id`, `Login`, `Password`, `FullName`, `BirthDate`, `Gender`, `Faculty`, `IsSubscribed`, `Email`, `RegisteredAt`) и вычисляемое свойство `Age` (метод `CalculateAge`).
- `Services/UserService.cs` — локальная «серверная» логика работы с файлом `users.json` (загрузка, сохранение через `System.Text.Json`, проверка логина/пароля в `Authenticate`, регистрация с проверкой уникальности логина в `Register`, обновление подписки в `UpdateSubscription`).
- `Helpers/ThemeHelper.cs` — реализация **Варианта 2**: смена цветовой темы формы и программная генерация аватара.
- `Forms/LoginForm.cs` / `LoginForm.Designer.cs` — стартовое окно входа с переходом к регистрации и личному кабинету.
- `Forms/RegisterForm.cs` / `RegisterForm.Designer.cs` — форма регистрации с валидацией полей, `DateTimePicker`, `ComboBox`, выбором пола (`RadioButton`), управлением подпиской (`CheckBox` + `Email`) и областью предпросмотра аватара (`PictureBox`).
- `Forms/ProfileForm.cs` / `ProfileForm.Designer.cs` — личный кабинет с выводом всех сведений о пользователе, расчётного возраста, аватара и возможностью изменить настройки подписки.

### Как работает
1. При запуске (`Program.cs`) открывается `LoginForm`.
2. Если у пользователя нет учётной записи, он нажимает «Регистрация» — открывается `RegisterForm`.
3. В `RegisterForm` при переключении пола (`rbMale` / `rbFemale`) срабатывает событие `Gender_CheckedChanged`, вызывающее `ThemeHelper.ApplyGenderTheme` (синяя палитра для мужского пола, розовая — для женского) и `ThemeHelper.SetAvatar` (рисует векторный аватар в `PictureBox` через `Graphics`).
4. При нажатии «Зарегистрироваться» проверяются корректность ФИО, длины логина/пароля, совпадение паролей, возраст (не менее 14 лет) и формат Email (если активна подписка). Новый объект `User` сохраняется в `users.json`.
5. После входа в `LoginForm` открывается `ProfileForm`, к которому также автоматически применяются тема и аватар в соответствии с полом вошедшего пользователя. Кнопка «Выйти» закрывает профиль и возвращает на окно авторизации.

---

## Лабораторная работа №2 (`Lab02`) — Windows Forms: графический редактор с меню, диалогами и рисованием

### Что сделано
- `Form1.Designer.cs` / `Form1.cs` — главное окно редактора с `MenuStrip`, `ContextMenuStrip`, `PictureBox` (`SizeMode = Zoom`), `StatusStrip` и стандартными диалогами (`OpenFileDialog`, `SaveFileDialog`, `ColorDialog`, `FontDialog`).
- `TextPromptForm.cs` — диалоговое окно для ввода пользовательской надписи поверх изображения.

### Как работает
1. При старте вызывается `CreateBlankCanvas(900, 560)`, создающий чистый белый холст `_workingBitmap` (и его исходную копию `_originalBitmap` для возможности сброса).
2. Через меню «Файл» или контекстное меню (ПКМ на форме или изображении) можно открыть изображение (`OpenFileDialog`), создать новый холст или сохранить результат (`SaveFileDialog` в PNG, JPEG или BMP).
3. Через меню «Вид» и «Текст» изменяются цвет фона формы (`ColorDialog`), видимость надписи (`_showText`), сам текст (`TextPromptForm`), его шрифт (`FontDialog`) и цвет (`ColorDialog`). Надпись отрисовывается поверх изображения в `PictureBoxCanvas_Paint` через `Graphics.DrawString` (и впечатывается в экспортируемую копию при сохранении).
4. **Вариант 2 (рисование мышью):** при зажатии левой кнопки мыши на `pictureBoxCanvas` события `MouseDown`, `MouseMove` и `MouseUp` пересчитывают координаты курсора из режима `PictureBoxSizeMode.Zoom` в пиксельные координаты `_workingBitmap` (`TryTranslateZoomPoint`) и рисуют сглаженные линии на холсте через `Graphics.FromImage(_workingBitmap)` и `g.DrawLine(pen, _lastImagePoint, currentImagePoint)`. Цвет и толщина кисти (2, 5, 10 px) настраиваются в меню «Рисование».

---

## Лабораторная работа №3 (`Lab03`) — WPF: первое XAML-приложение

### Что сделано
- `App.xaml` / `App.xaml.cs` — точка входа WPF-приложения (`StartupUri="MainWindow.xaml"`).
- `MainWindow.xaml` / `MainWindow.xaml.cs` — окно с контейнерами `Grid` и `StackPanel`, элементами `Label`, `TextBox` (`txtUserName`), `Button` (`btnGreet`), `TextBlock` (`txtGreeting`), а также элементами **Варианта 2**: `CheckBox` (`chkShowDate`) с подписью «Показать дату» и `TextBlock` (`txtDateOutput`) под кнопкой.

### Как работает
1. Пользователь вводит имя в `txtUserName` и нажимает «Поприветствовать» (`BtnGreet_Click`).
2. Если поле пустое, выводится предупреждение; иначе формируется персональное приветствие, которое выводится в `txtGreeting` и в `MessageBox.Show`.
3. **Вариант 2:** при установке флажка «Показать дату» (`Checked` / `Unchecked` -> `ChkShowDate_Changed`) метод `UpdateDateDisplay()` делает видимым `txtDateOutput` под кнопкой и выводит актуальные дату и время через `DateTime.Now`. При снятии флажка блок скрывается.

---

## Лабораторная работа №4 (`Lab04`) — WPF: панели компоновки и навигация через TreeView

### Что сделано
- `MainWindow.xaml` / `MainWindow.xaml.cs` — адаптивный справочник технологий, объединяющий `Grid` (строки `Auto`, `*`, `Auto` и колонки с `MinWidth`), `DockPanel` (верхняя шапка, левая область и нижняя панель кнопок), `StackPanel`, `WrapPanel` (карточки разделов), `TabControl` и `Canvas` (схема архитектурных слоёв).
- **Вариант 2:** в левой части окна размещено навигационное дерево `TreeView` (`tvCategories`) с раскрываемыми ветками («Языки программирования», «Платформы UI», «Системы хранения»).

### Как работает
1. При выборе любого узла в `tvCategories` срабатывает `TvCategories_SelectedItemChanged`.
2. По `Tag` выбранного `TreeViewItem` из словаря `_catalog` извлекаются заголовок, описание и набор карточек.
3. В правой области динамически обновляются текстовый заголовок, карточки внутри `WrapPanel` (`cardsWrapPanel`, автоматически перестраивающиеся при изменении ширины окна) и активный блок на вкладке «Схема слоёв (Canvas)».
4. Нижняя панель позволяет кнопками раскрывать/сворачивать все ветки дерева, переключаться между вкладками `TabControl` и открывать справку.

---

## Лабораторная работа №5 (`Lab05`) — WPF: стили, ресурсы, триггеры и DynamicResource

### Что сделано
- `Styles/SharedResources.xaml` — внешний словарь ресурсов (`ResourceDictionary`) с кистями и стилем `StyledTextBoxStyle` (подсветка рамки при фокусе).
- `App.xaml` — подключение внешнего словаря через `MergedDictionaries`, глобальные ресурсы: `GlobalCheckBoxBrush`, `GlobalLabelStyle`, `GlobalCheckBoxStyle`.
- `MainWindow.xaml` / `MainWindow.xaml.cs` — локальные ресурсы в `Window.Resources`: размер шрифта `LocalTitleFontSize`, кисть `LocalTitleBrush`, стиль `LocalButtonStyle` с триггерами `IsMouseOver` (смена фона) и `IsPressed` (смена фона и цвета текста), а также ресурс фона окна `WindowBackgroundBrush` (**Вариант 2**).

### Как работает
1. К элементам интерфейса применены глобальные стили из `App.xaml` через `StaticResource` и локальный стиль кнопок из `Window.Resources`.
2. **Вариант 2:** свойство `Window.Background` привязано к `{DynamicResource WindowBackgroundBrush}`.
3. По нажатию кнопки «Сменить цвет фона окна» (`BtnChangeWindowBg_Click`) в коде выполняется `Resources["WindowBackgroundBrush"] = new SolidColorBrush(color)`. Благодаря `DynamicResource` фон всего окна мгновенно обновляется во время работы приложения без перезапуска. Кнопка сброса возвращает исходный цвет.

---

## Лабораторная работа №6 (`Lab06`) — WPF: привязка данных и конвертеры

### Что сделано
- `Models/Person.cs` — модель данных со свойствами `Name`, `Age`, `IsActive`, реализующая `INotifyPropertyChanged`.
- `Converters/BoolToStatusConverter.cs` — конвертер `bool` в строки `"Активен"` / `"Неактивен"`.
- `Converters/AgeToBrushConverter.cs` — конвертер **Варианта 2** (`IValueConverter`), преобразующий возраст в цвет текста (`< 18` — `Brushes.Red`, `18–60` — `Brushes.Black`, `> 60` — `Brushes.Blue`).
- `MainWindow.xaml` / `MainWindow.xaml.cs` — окно с коллекцией `ObservableCollection<Person>`, списком `ListBox` и панелью редактирования выбранного объекта.

### Как работает
1. `DataContext` окна указывает на `MainWindow`, содержащий `People` (`ObservableCollection<Person>`) и `SelectedPerson`.
2. Слева `ListBox` отображает всех пользователей через `DataTemplate`, где к возрасту сразу применён `StringFormat` (`Возраст: {0} лет`) и `AgeToBrushConverter`, а к флагу активности — `BoolToStatusConverter`.
3. Справа поля редактирования (`TextBox`, `Slider`, `CheckBox`) связаны с `SelectedPerson` двусторонней привязкой (`Mode=TwoWay`, `UpdateSourceTrigger=PropertyChanged`).
4. При изменении возраста ползунком или вводом в `TextBox` цвет текста возраста одновременно обновляется и в блоке предпросмотра, и в списке `ListBox`.

---

## Лабораторная работа №7 (`Lab07`) — WPF: паттерн MVVM (Model / ViewModel / View)

### Что сделано
Проект строго разделён на три папки:
- `Model/User.cs` — модель `User` (`Name`, `Age`, `IsStudent`) с `INotifyPropertyChanged`.
- `ViewModel/RelayCommand.cs` — реализация `ICommand` с поддержкой `CanExecute` и `RaiseCanExecuteChanged()`.
- `ViewModel/MainViewModel.cs` — вся логика приложения, свойства `Name`, `Age`, `IsStudent`, вычисляемое свойство `StudentStatusText` (`"Студент"` / `"Не студент"` без конвертеров), команды `ClearCommand`, `SaveCommand` и команда **Варианта 2** `MakeAdultCommand`.
- `View/MainWindow.xaml` / `View/MainWindow.xaml.cs` — разметка с двусторонними привязками (`Mode=TwoWay`) и пустой code-behind, содержащий только `DataContext = new MainViewModel();`.

### Как работает
1. Изменения в `TextBox`, `Slider` и `CheckBox` напрямую обновляют свойства `MainViewModel` и модели `User`, а те уведомляют блок отображения.
2. `SaveCommand` проверяет `!string.IsNullOrWhiteSpace(Name)` — пока поле имени пустое, кнопка «Сохранить» автоматически отключена. При нажатии выводится `MessageBox.Show` со всеми полями.
3. `ClearCommand` сбрасывает `Name = ""`, `Age = 0`, `IsStudent = false`.
4. **Вариант 2:** кнопка «Сделать совершеннолетним» связана с `MakeAdultCommand` и устанавливает `Age = 18`, что сразу отражается на `Slider` и текстовых полях.

---

## Лабораторная работа №8 (`Lab08`) — WPF: команды ICommand и CommandParameter в MVVM

### Что сделано
- `Model/User.cs` — модель `User` (`Name`, `Age`, `IsStudent`).
- `ViewModel/RelayCommand.cs` — реализация `ICommand` с `RaiseCanExecuteChanged()`.
- `ViewModel/MainViewModel.cs` — команды `ShowInfoCommand`, `DeleteUserCommand`, `ShowDialogCommand` и команда **Варианта 2** `ConfirmCommand`.
- `View/MainWindow.xaml` / `View/MainWindow.xaml.cs` — интерфейс, полностью привязанный к командам ViewModel (в code-behind только установка `DataContext`).

### Как работает
1. При изменении свойства `Name` вызывается `RaiseCanExecuteChanged()`, управляющий доступностью кнопок команд.
2. `ShowInfoCommand` открывает `MessageBox` с текущими данными пользователя.
3. `DeleteUserCommand` получает имя пользователя через `CommandParameter="{Binding Name}"`, очищает поля и фиксирует удалённое имя в статусе.
4. `ShowDialogCommand` открывает стандартный `Microsoft.Win32.OpenFileDialog` и сохраняет выбранный путь в свойство `SelectedFilePath`.
5. **Вариант 2:** кнопка «Подтвердить» вызывает `ConfirmCommand` с `CommandParameter="{Binding Name}"`. Команда отображает `MessageBox.Show($"Удалить пользователя {targetName}?", ..., MessageBoxButton.YesNo)` и при подтверждении (`Yes`) очищает профиль.

---

## Лабораторная работа №9 (`Lab09`) — WPF: множественные окна и диалоги в MVVM

### Что сделано
- `Model/User.cs` — модель `User` с методами `Clone()` и `CopyFrom()` для безопасного редактирования без порчи исходных данных при отмене.
- `Services/IWindowService.cs` и `Services/WindowService.cs` — сервис открытия окон и диалогов из ViewModel без нарушения MVVM.
- `ViewModel/MainViewModel.cs` и `ViewModel/UserInfoViewModel.cs` — логика главного окна и диалога редактирования.
- `View/MainWindow.xaml` — главное окно профиля.
- `View/UserInfoWindow.xaml` — модальное окно редактирования (`ShowDialog()`).
- `View/AboutWindow.xaml` — окно «О программе» (**Вариант 2**), открываемое немодально (`Show()`).

### Как работает
1. При нажатии «Редактировать профиль» `MainViewModel` клонирует `CurrentUser` и открывает `UserInfoWindow` через `ShowDialog()`.
2. В `UserInfoWindow` нажатие «Сохранить» вызывает `SaveCommand` (`DialogResult = true`), после чего `MainViewModel` переносит изменения в `CurrentUser`. Нажатие «Отмена» закрывает диалог с `DialogResult = false`, оставляя исходные данные нетронутыми.
3. Кнопка «Удалить профиль» вызывает `MessageBox.Show` с подтверждением Yes/No и при согласии сбрасывает данные пользователя.
4. **Вариант 2:** кнопка «О программе» вызывает `WindowService.OpenAboutWindow()`, открывающий `AboutWindow` методом `Show()` (немодально — пользователь может продолжать работу с главным окном, пока открыто «О программе»; повторное нажатие активирует уже открытое окно).

---

## Лабораторная работа №10 (`Lab10`) — WPF: визуальные эффекты и анимации

### Что сделано
- `MainWindow.xaml` / `MainWindow.xaml.cs` — окно с `Canvas`, фигурами `Rectangle`, `Ellipse`, `Path` (`PathGeometry`), текстовыми блоками и общим `Storyboard` (`MainAnimationStoryboard`) в `Window.Resources`.

### Как работает
При запуске окна (и по кнопке «Запуск анимации» / «Остановить» через `Storyboard.Begin` и `Storyboard.Stop`) одновременно воспроизводятся:
1. **Простая анимация с `EasingFunction`:** изменение `Width` (`BounceEase`) и `Height` (`SineEase`) у `animatedRect`.
2. **Анимация прозрачности:** плавное мигание `Opacity` у `animatedEllipse`.
3. **Анимация по ключевым кадрам (`KeyFrames`):** `txtKeyframe` одновременно смещается по оси X (`DoubleAnimationUsingKeyFrames`), поворачивается (`RotateTransform.Angle`) и меняет цвет (`ColorAnimationUsingKeyFrames`).
4. **Анимация по пути (`PathAnimation`):** зелёный маркер `pathRunner` движется вдоль замкнутой кривой `MotionPath` с помощью `MatrixAnimationUsingPath`.
5. **Вариант 2:** в нижней правой области `txtFloatingFade` плавно опускается сверху вниз по `Canvas.Top` (с `SineEase`) и одновременно исчезает за счёт затухания `Opacity` от `1.0` до `0.0`.

---

## Лабораторная работа №11 (`Lab11`) — WPF: пользовательские элементы, шаблоны и круглое окно

### Что сделано
- `Controls/NotificationControl.xaml` / `.xaml.cs` — пользовательский `UserControl` «Уведомление» с `DependencyProperty` (`MessageText`, `CloseCommand`), событием `CloseRequested` и кнопкой «Закрыть».
- `ViewModel/MainViewModel.cs` / `RelayCommand.cs` — MVVM-логика уведомления, переключателя, анализа дерева и закрытия окна.
- `MainWindow.xaml` / `.xaml.cs` — круглое окно (`WindowStyle="None"`, `AllowsTransparency="True"`, `EllipseGeometry` clip, перетаскивание через `DragMove()`), переопределённый шаблон `Button` (`GradientButtonStyle`) с `VisualStateManager` (`Normal`, `MouseOver`, `Pressed`) и шаблон `ToggleButton` (**Вариант 2**).
- `VisualLogicalTreeReport.md` — письменный отчёт по анализу логического и визуального дерева.

### Как работает
1. Круглое окно свободно перетаскивается мышью за любую область (`Window_MouseLeftButtonDown` -> `DragMove()`).
2. Кнопки используют кастомный `ControlTemplate` с градиентным `Rectangle` и плавной анимацией цвета и масштаба через `VisualStateManager`.
3. **Вариант 2:** `ToggleButton` (`tglSwitch`) оформлен через `AnimatedToggleStyle` с `VisualStateManager` (`CheckStates`: `Checked` / `Unchecked`). При переключении фон трека плавно меняет цвет (серый ↔ изумрудный), а круглый ползунок смещается вправо/влево.
4. Кнопка «Анализ дерева» в реальном времени рекурсивно обходит `LogicalTreeHelper` и `VisualTreeHelper` для `MainWindow` и `NotificationControl` и выводит точное количество логических и визуальных элементов.

---

## Лабораторная работа №12 (`Lab12`) — WPF: мультимедиа, изображения, InkCanvas и PathAnimation

### Что сделано
- `MainWindow.xaml` / `MainWindow.xaml.cs` — окно, разделённое на 4 интерактивных блока:
  1. **Видео (`MediaElement`):** загрузка видео через `OpenFileDialog`, кнопки «Воспроизвести», «Пауза», «Остановить».
  2. **Изображения (`Image`):** загрузка фото через `OpenFileDialog`, кнопка «Очистить изображение», отображение пути под картинкой.
  3. **Рисование (`InkCanvas`):** свободное рисование мышью, переключение режима «Рисование / Ластик» (`EditingMode`) и очистка холста.
  4. **Фигуры, `PathGeometry` и Вариант 2:** `Rectangle`, `Ellipse`, `Polygon` со сменой цветов по кнопке, сложная траектория `Path` (`ArcSegment`, `BezierSegment`, `LineSegment`) и анимация `movingRect`.

### Как работает
1. Блок видео управляет воспроизведением вручную (`LoadedBehavior="Manual"`), блок изображений загружает `BitmapImage` и показывает путь к файлу в `txtImagePath`.
2. `InkCanvas` переключает `EditingMode` между `InkCanvasEditingMode.Ink` и `InkCanvasEditingMode.EraseByPoint`.
3. **Вариант 2:** при нажатии кнопки «Запустить Rectangle по пути» запускается `Storyboard` (`RectPathStoryboard`) с `MatrixAnimationUsingPath` (`DoesRotateWithTangent="True"`), и красный прямоугольник `movingRect` начинает непрерывно двигаться и поворачиваться вдоль всей траектории `CustomTrackGeometry`. Кнопка «Стоп» останавливает движение.
