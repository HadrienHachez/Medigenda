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

            TimeSpan time = TimeSpan.Parse(value.ToString());
            return time.ToString(@"\ hh\:mm\ ");
        }

        public object ConvertBack(object value, Type targetType, object parameter, string culture)
        {
            throw new NotSupportedException();
        }
    }

    public class DateTimeMonthDisplay : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
                return null;

            DateTime dt = DateTime.Parse(value.ToString());
            string mydt = dt.ToString("MMMM yyyy");
            char first = mydt[0];
            string final = "";
            bool firstcharchanged = false;
            foreach (char c in mydt)
            {
                if((c == first) && (!firstcharchanged))
                {
                    final += c.ToString().ToUpper();
                    firstcharchanged = true;
                }
                else
                {
                    final += c;
                }
            }
            return final;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string culture)
        {
            throw new NotSupportedException();
        }
    }

    public class DateTimeNumericDay : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
                return null;

            DateTime dt = DateTime.Parse(value.ToString());
            return dt.ToString("dd");
        }

        public object ConvertBack(object value, Type targetType, object parameter, string culture)
        {
            throw new NotSupportedException();
        }
    }
}
