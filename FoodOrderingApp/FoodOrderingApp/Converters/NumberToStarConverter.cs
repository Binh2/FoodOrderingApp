using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace FoodOrderingApp.Converters
{
    class NumberToStarConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            List<string> list = new List<string>();
            for (int i = 0; i < (int)value; i++)
            {
                list.Add("star.png");
            }
            for (int i = (int)value; i < 5; i++)
            {
                list.Add("unactive_star.png");
            }
            return list;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (from image in (List<string>)value where image == "star.png" select image).Count();
        }
    }
}
