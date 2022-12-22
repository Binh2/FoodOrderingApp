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
        public string FoodQuantity { get; set; }
        public int CategoryID { get; set; }
        public int RestaurantID { get; set; }
    }
}
