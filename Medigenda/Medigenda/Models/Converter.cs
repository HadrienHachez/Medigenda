using System;
using Windows.UI.Xaml.Data;

namespace Medigenda.Converter
{
    public class TimeSpanHourAndMinuteDisplay : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
                return null;

            TimeSpan dt = TimeSpan.Parse(value.ToString());
            return dt.ToString(@"\ hh\:mm\ ");
        }

        public object ConvertBack(object value, Type targetType, object parameter, string culture)
        {
            throw new NotSupportedException();
        }
    }
}
