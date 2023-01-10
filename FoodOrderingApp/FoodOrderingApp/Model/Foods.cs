using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
namespace FoodOrderingApp.Model
{
    public interface IFood
    {
        int FoodID { get; set; }
        string FoodName { get; set; }
        string FoodImages { get; set; }
        string FoodDetail { get; set; }
        double FoodPrice { get; set; }
        double FoodRating { get; set; }
        int FoodFavourite { get; set; }
        int CategoryID { get; set; }
        int RestaurantID { get; set; }

    }
    public class Foods
    {
        public int FoodID { get; set; }
        public string FoodName { get; set; }
        public string FoodImages { get; set; }
        public string FoodDetail { get; set; }
        public double FoodPrice { get; set; }
        public string FoodRating { get; set; }
        public string FoodFavourite { get; set; }
        public int FoodCount { get; set; }
        public int FoodQuantity { get; set; }
        public int FoodState { get; set; }
        public int CategoryID { get; set; }
        public int RestaurantID { get; set; }
    }

    static public class FOOD_STATE
    {
        public const int AVAILABLE = 0;
        public const int NOT_AVAILABLE = 1;
    }
}
