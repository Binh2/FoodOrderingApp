using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace FoodOrderingApp.Model
{
    public class Category
    {
        [PrimaryKey,AutoIncrement]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryImages { get; set; }
        public string CategoryLink { get; set;}


    }
}
