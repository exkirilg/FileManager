using System.Globalization;
using System.Windows;
using System;
using System.Windows.Data;

namespace FileManager.Converters;

[ValueConversion(typeof(DateTime), typeof(string))]
public class DateTimeConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        DateTime dtValue = (DateTime)value;
        return dtValue.ToString();
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return DependencyProperty.UnsetValue;
    }
}
