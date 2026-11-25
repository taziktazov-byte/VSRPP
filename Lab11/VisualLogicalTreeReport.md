# Отчёт по анализу логического и визуального дерева (Лабораторная работа №11)

## Описание различий
- **Логическое дерево (`LogicalTreeHelper`)** отражает структуру элементов, объявленную непосредственно в XAML (панели компоновки, `UserControl`, `Button`, `TextBlock`, `ToggleButton` и т. д.), без раскрытия внутренних шаблонов (`ControlTemplate`).
- **Визуальное дерево (`VisualTreeHelper`)** включает все реальные отрисовываемые объекты WPF: `AdornerDecorator`, `ContentPresenter`, `Border`, `Rectangle`, `Ellipse`, `TextBlock` и внутренние элементы шаблонов `ControlTemplate`.

## Структура и подсчёт элементов
В приложении реализована встроенная кнопка **«Анализ дерева»**, которая во время выполнения рекурсивно обходит `LogicalTreeHelper.GetChildren(...)` и `VisualTreeHelper.GetChild(...)` для `MainWindow` и пользовательского элемента `NotificationControl`.

1. **Основное окно `MainWindow`**:
   - **Логические дочерние элементы** (`LogicalTreeHelper`): включают `outerGrid`, фоновый `Ellipse`, внутренний `Grid`, `contentStack`, `TextBlock` заголовка и подсказки, `NotificationControl` (+ его внутренний логический подграф при раскрытии), `ToggleButton`, `Button` (3 шт.), `Border` статистики и текстовые элементы — около **21–25** логических узлов (включая текстовые строки/контент).
   - **Визуальные дочерние элементы** (`VisualTreeHelper`): за счёт `Border` самого окна, `AdornerDecorator`, `AdornerLayer`, `ContentPresenter`, а также развёрнутых `ControlTemplate` для каждой кнопки (`Grid`, `Rectangle`, `ContentPresenter`, `TextBlock`) и `ToggleButton` (`Grid`, `Border`, `Ellipse`, `ContentPresenter`, `TextBlock`) визуальное дерево содержит примерно **55–65** визуальных элементов.

2. **Пользовательский элемент `NotificationControl` (`UserControl`)**:
   - **Логические дочерние элементы**: `Border` -> `Grid` -> `TextBlock` (`txtNotification`) и `Button` (`btnCloseNotification`, плюс текстовый контент кнопки) = **5** логических узлов.
   - **Визуальные дочерние элементы**: включает `ContentPresenter` самого `UserControl`, `Border`, `Grid`, `TextBlock`, `Button` и внутренний `Border`/`ContentPresenter`/`TextBlock` стандартного шаблона кнопки = **9** визуальных узлов.
