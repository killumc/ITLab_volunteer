using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace test2.Converters
{
    public class IntEqualsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int selected && int.TryParse(parameter?.ToString(), out int param))
                return selected == param;
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value && int.TryParse(parameter?.ToString(), out int param))
                return param;
            return Binding.DoNothing;
        }
    }

}
