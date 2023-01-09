using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBAPI.Models
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
    
    public class Food :IFood
    {
        public int FoodID { get; set; }
        public string FoodName { get; set; }
        public string FoodImages { get; set; }
        public string FoodDetail { get; set; }
        public double FoodPrice { get; set; }
        public double FoodRating { get; set; }
        public int FoodFavourite { get; set; }
        public int CategoryID { get; set; }
        public int RestaurantID { get; set; }

    }
}