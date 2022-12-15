using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using FoodOrderingApp.Model;
using SQLite;
namespace FoodOrderingApp.Helpers
{
    public class FoodDatabase
    {
        private readonly SQLiteConnection _connection;

        public FoodDatabase()
        {
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            _connection = new SQLiteConnection(System.IO.Path.Combine(folder,"FoodDatabase.db3"));
            _connection.CreateTable<Catelogy>();
        }
            
    }
}
