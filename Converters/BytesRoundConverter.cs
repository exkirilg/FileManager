using System.Globalization;
using System.Windows;
using System;
using System.Windows.Data;

namespace FileManager.Converters;

[ValueConversion(typeof(long), typeof(string))]
public class BytesRoundConverter : IValueConverter
{
    const double Rate = 1024;

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        long lValue = (long)value;

        string result;

        if (lValue > Math.Pow(Rate, 4))
        {
            result = $"{Math.Round(lValue / Math.Pow(Rate, 4), 2):N0} TB";
        }
        else if (lValue > Math.Pow(Rate, 3))
        {
            result = $"{Math.Round(lValue / Math.Pow(Rate, 3), 2):N0} GB";
        }
        else if (lValue > Math.Pow(Rate, 2))
        {
            result = $"{Math.Round(lValue / Math.Pow(Rate, 2), 2):N0} MB";
        }
        else if (lValue > Rate)
        {
            result = $"{Math.Round(lValue / Rate, 2):N0} KB";
        }
        else {
            result = $"{lValue:N0} bytes";
        }

        return result;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return DependencyProperty.UnsetValue;
    }
}
