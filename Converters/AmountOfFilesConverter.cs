using System.Globalization;
using System.Windows;
using System;
using System.Windows.Data;

namespace FileManager.Converters;

[ValueConversion(typeof(int), typeof(string))]
public class AmountOfFilesConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        long intValue = (int)value;
        return $"{intValue:N0} files";
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is string strValue)
        {
            if (int.TryParse(strValue.Replace(" files", string.Empty), out int result))
            {
                return result;
            }
        }

        return DependencyProperty.UnsetValue;
    }
}
