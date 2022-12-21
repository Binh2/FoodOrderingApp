using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrderingApp.Model
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserImage { get; set; }
        public string UserPassword { get; set; }
    }
    static public class UserProvider
    {
        static public User user;
    }
}
