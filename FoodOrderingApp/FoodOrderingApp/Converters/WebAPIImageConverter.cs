using FoodOrderingApp.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Linq;
using Xamarin.Forms;

namespace FoodOrderingApp.Converters
{
    class WebAPIImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string str = (string)value;
            return "http://" + Constants.IP + "/WEBAPI/Images/" + image;
            //return string.Join("|", from image in str.Split('|') select "http://" + Constants.IP + "/WEBAPI/Images/" + image);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string str = (string)value;
            return "http://" + Constants.IP + "/WEBAPI/Images/" + image;
            //return string.Join("|", from image in str.Split('|') select ((string)value).Replace("http://" + Constants.IP + "/WEBAPI/Images/", ""));
        }
    }
}
