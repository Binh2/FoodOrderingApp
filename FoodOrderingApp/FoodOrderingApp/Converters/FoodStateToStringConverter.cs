using FoodOrderingApp.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace FoodOrderingApp.Converters
{
    class FoodStateToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((int)value)
            {
                case FOOD_STATE.AVAILABLE:
                    return "Available";
                case FOOD_STATE.NOT_AVAILABLE:
                    return "Not available";
            }
            return "Available";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((string)value)
            {
                case "Available":
                    return FOOD_STATE.AVAILABLE;
                case "Not available":
                    return FOOD_STATE.NOT_AVAILABLE;
            }
            return FOOD_STATE.AVAILABLE;
        }
    }
}
