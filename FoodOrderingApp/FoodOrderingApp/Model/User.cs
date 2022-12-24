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
        public string UserUsename { get; set; }
        public string UserEmail { get; set; }
        public string UserImage { get; set; }
        public string UserPassword { get; set; }
        public int UserType { get; set; }
    }
    static public class UserProvider
    {
        static public User user;
    }
    static public class USER_TYPE
    {
        static public int CONSUMER = 0;
        static public int PRODUCER = 1;
        static public int ADMIN = 2;
    }
}
