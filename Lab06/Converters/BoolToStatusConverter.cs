using System;
using System.Globalization;
using System.Windows.Data;

namespace Lab06.Converters
{
    public class BoolToStatusConverter : IValueConverter
    {
        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return value is bool isActive && isActive ? "Активен" : "Неактивен";
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return string.Equals(value?.ToString(), "Активен", StringComparison.OrdinalIgnoreCase);
        }
    }
}
