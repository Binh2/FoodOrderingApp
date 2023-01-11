using FoodOrderingApp.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace FoodOrderingApp.Converters
{
    class WebAPIImagesToListConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return new List<string>() { "" };
            string str = (string)value;
            return from image in str.Split('|') select "http://" + Constants.IP + "/WEBAPI/Images/" + image;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == new List<string>() { "" }) return "";
            List<string> strs = (List<string>)value;
            return string.Join("|", from image in strs select ((string)value).Replace("http://" + Constants.IP + "/WEBAPI/Images/", ""));
        }
    }
}
