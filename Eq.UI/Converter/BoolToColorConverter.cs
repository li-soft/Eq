using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Eq.UI.Converter
{
    /// <summary>
    /// Convert IsRisky Transaction property to higlight grid row
    /// </summary>
    public class BoolToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool)
            {
                return (bool)value ? new SolidColorBrush(Colors.Red) : new SolidColorBrush(Colors.Transparent);
            }

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var scb = value as SolidColorBrush;
            return scb != null && scb.Color == Colors.Red;
        }
    }
}
