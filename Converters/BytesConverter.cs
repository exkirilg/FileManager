using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace FileManager.Converters;

[ValueConversion(typeof(long), typeof(string))]
public class BytesConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        long lValue = (long)value;
        return $"{lValue:N0} bytes";
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is string strValue)
        {
            if (long.TryParse(strValue.Replace(" bytes", string.Empty), out long result))
            {
                return result;
            }
        }

        return DependencyProperty.UnsetValue;
    }
}
