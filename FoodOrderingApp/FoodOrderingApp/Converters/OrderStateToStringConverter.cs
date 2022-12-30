using FoodOrderingApp.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace FoodOrderingApp.Converters
{
    class OrderStateToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((int)value)
            {
                case ORDER_STATE.IN_RESTAURANT:
                    return "Still in restaurant";
                case ORDER_STATE.IN_CART:
                    return "Still in cart";
                case ORDER_STATE.SIGNING:
                    return "Signing...";
                case ORDER_STATE.SIGNED:
                    return "Signed";
                case ORDER_STATE.PROCESSING:
                    return "Processing...";
                case ORDER_STATE.PROCESSED:
                    return "Processed";
                case ORDER_STATE.SHIPPING:
                    return "Shipping...";
                case ORDER_STATE.SHIPPED:
                    return "SHIPPED";
                case ORDER_STATE.RECEIVED:
                    return "Received";
            }
            return "Still in restaurant";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((string)value)
            {
                case "Still in restaurant":
                    return ORDER_STATE.IN_RESTAURANT;
                case "Still in cart":
                    return ORDER_STATE.IN_CART;
                case "Signing...":
                    return ORDER_STATE.SIGNING;
                case "Signed":
                    return ORDER_STATE.SIGNED;
                case "Processing...":
                    return ORDER_STATE.PROCESSING;
                case "Processed":
                    return ORDER_STATE.PROCESSED;
                case "Shipping...":
                    return ORDER_STATE.SHIPPING;
                case "SHIPPED":
                    return ORDER_STATE.SHIPPED;
                case "Received":
                    return ORDER_STATE.RECEIVED;
            }
            return ORDER_STATE.IN_RESTAURANT;
        }
    }
}
