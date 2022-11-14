using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace FoodOrderingApp.NewFolder
{
    public class Menu
    {
        [PrimaryKey,AutoIncrement]
        public int MenuId { get; set; }
        public string Name { get; set; }
        public string Menuimage { get; set; }
        

    }
}
