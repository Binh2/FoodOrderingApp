using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
namespace FoodOrderingApp.Model
{
    public class Food
    {
        [PrimaryKey, AutoIncrement]
        public int FoodID { get; set; }
        public string FoodName { get; set; }
        public string FoodImages { get; set; }
        public string FoodDecription { get; set; }
        public decimal FoodPrice { get; set; }
        public string Rating { get; set; }
        public string Favourite { get; set; }
        public int FoodQuantity { get; set; }
        public int FoodState { get; set; }
        public string FoodQuantity { get; set; }
        public int CategoryID { get; set; }
        public int RestaurantID { get; set; }
    }

    static public class FOOD_STATE
    {
        public const int AVAILABLE = 0;
        public const int NOT_AVAILABLE = 1;
    }
}
