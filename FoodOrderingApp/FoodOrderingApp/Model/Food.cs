using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace FoodOrderingApp.Model
{
    public class Food
    {
        [PrimaryKey,AutoIncrement]
        public int FoodID { get; set; }
        public string FoodName { get; set; }
        public string FoodImages { get; set; }
        public int FoodQuantity { get; set; }
        public int FoodState { get; set; }
        public int CategoryID { get; set; }
        public int RestaurantID { get; set; }
    }

    static public class FOOD_STATE
    {
        static public int IN_RESTAURANT = 0;
        static public int IN_CART = 1;
        static public int SIGNING = 2;
        static public int SIGNED = 3;
        static public int SHIPPING = 4;
        static public int SHIPPED = 5;
        static public int RECEIVED = 6;
    }
}
