using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace WpfTestApp.Converters
{
    public class BoolToGender : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not bool boolean)
            {
                return DependencyProperty.UnsetValue;
            }
            return boolean ? "남자" : "여자";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
