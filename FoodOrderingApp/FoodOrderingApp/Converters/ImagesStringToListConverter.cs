using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace FoodOrderingApp.Converters
{
    class ImagesStringToListConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            List<string> images = ((string)value).Split('|').Take<string>(4).ToList<string>();
            return images;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return string.Join<string>("|", (List<string>)value);
        }
    }
}
