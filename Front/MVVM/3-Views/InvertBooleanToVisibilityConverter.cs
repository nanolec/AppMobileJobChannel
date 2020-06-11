using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace AppMobileJobChannel
{
    public class InvertBooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is bool && targetType == typeof(Visibility))
            {
                if ((bool)value)
                    return Visibility.Collapsed;
                else
                    return Visibility.Visible;
            }
            else
                throw new InvalidCastException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}