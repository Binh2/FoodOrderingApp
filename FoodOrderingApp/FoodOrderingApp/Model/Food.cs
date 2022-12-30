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
        public int FoodPrice { get; set; }
        public int FoodQuantity { get; set; }
        public int FoodState { get; set; }
        public bool FoodFavourite { get; set; }
        public int CategoryID { get; set; }
        public int RestaurantID { get; set; }
    }

    static public class FOOD_STATE
    {
        public const int AVAILABLE = 0;
        public const int NOT_AVAILABLE = 1;
    }
}
