using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Enes_Agir
{
    public class Int2String : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((int)value)
            {
                case 0: return "Celtic studies";
                case 1: return "Classical studies";
                case 2: return "Greek History";
                case 3: return "Early Mediterranean";
                                
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((string)value)
            {
                case "Celtic studies": return 0;
                case "Classical studies": return 1;
                case "Greek History": return 2;
                case "Early Mediterranean": return 3;
                
            }
            return null;
        }
    }
}