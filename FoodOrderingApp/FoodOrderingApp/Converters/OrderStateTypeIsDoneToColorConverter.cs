using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace FoodOrderingApp.Converters
{
    class OrderStateTypeIsDoneToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Color green = (Color)Application.Current.Resources["GreenColor"],
                orange = (Color)Application.Current.Resources["OrangeColor"];
            return (bool)value ? green : orange;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Color green = (Color)Application.Current.Resources["GreenColor"];
            return (Color)value == green;
        }
    }
}
