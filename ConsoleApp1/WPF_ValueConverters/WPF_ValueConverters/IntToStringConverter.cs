using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WPF_ValueConverters
{
    internal class IntToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.ToString() != "" && int.Parse(value.ToString()) % 2 == 0)
            {
                return "Even";
            }
            else if (value.ToString() != "" && int.Parse(value.ToString()) % 2 != 0)
            {
                return "Odd";
            }
            else
            {
                return "Invalid Input";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
