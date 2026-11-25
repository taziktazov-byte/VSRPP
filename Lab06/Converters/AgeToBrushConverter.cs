using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Lab06.Converters
{
    public class AgeToBrushConverter : IValueConverter
    {
        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is int age)
            {
                if (age < 18)
                    return Brushes.Red;
                if (age <= 60)
                    return Brushes.Black;
                return Brushes.Blue;
            }

            return Brushes.Black;
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
