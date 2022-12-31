using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrderingApp.Model
{
    class Order
    {
        //public DateTime OrderDate { get; set; }
        public int OrderID { get; set; }
        public int OrderPrice { get; set; }
        public string OrderImages { get; set; }
        public int OrderState { get; set; }
        public DateTime OrderDate { get; set; }
    }
    static public class ORDER_STATE
    {
        public const int IN_RESTAURANT = 0;
        public const int IN_CART = 1;
        public const int SIGNING = 2;
        public const int SIGNED = 3;
        public const int PROCESSING = 4;
        public const int PROCESSED = 5;
        public const int SHIPPING = 6;
        public const int SHIPPED = 7;
        public const int RECEIVED = 8;
    }
}
