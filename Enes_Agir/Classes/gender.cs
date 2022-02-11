using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Enes_Agir.Classes
{
    
        public class Int2String : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                switch ((int)value)
                {
                    case 0: return "Female";
                    case 1: return "Male";
                    //case 2: return "Diverse";
                }
                return null;
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                switch ((string)value)
                {
                    case "Female": return 0;
                    case "Male": return 1;
                    //case "Diverse": return 2;
                }
                return null;
            }
        }
    
}
