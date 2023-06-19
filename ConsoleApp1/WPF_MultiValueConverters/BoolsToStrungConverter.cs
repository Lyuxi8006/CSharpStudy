using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WPF_MultiValueConverters
{
    public class BoolsToStrungConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            string answer = "Your answer is : ";
            if ((bool) values[0] == true && (bool)values[1] == true && (bool)values[2] == true)
            {
                return answer + "CORRECT"; 
            }
            else if ((bool)values[0] == false && (bool)values[1] == false && (bool)values[2] == false)
            {
                return answer; 
            }
            else
            {
                return answer + "INCORRECT";
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
