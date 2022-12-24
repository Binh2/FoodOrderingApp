﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Firebase.Database;
using FoodOrderingApp.Model;
using SQLite;

namespace FoodOrderingApp.Model
{
    static class Database
    {
        // Use Database.createDatabase() to create database
        static public string folder = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        static public string dbFile = System.IO.Path.Combine(
            System.Environment.GetFolderPath(Environment.SpecialFolder.Personal),
            "foodDB.db"
        );
        static public bool createDatabase()
        {
            try
            {
                using (var connection = new SQLiteConnection(dbFile))
                {
                    connection.CreateTable<Category>();
                    connection.CreateTable<Food>();
                    connection.CreateTable<User>();
                    connection.CreateTable<Restaurant>();
                    return true;
                }
            }
            catch (SQLiteException)
            {
                return false;
            }
        }
        static public bool deleteDatabase()
        {
            try
            {
                File.Delete(dbFile);
                return true;
            }
            catch (SQLiteException)
            {
                return false;
            }
        }

        public static List<Restaurant> selectAllRestaurants()
        {
            try
            {
                var connection = new SQLiteConnection(dbFile);
                return connection.Table<Restaurant>().ToList();

            }
            catch (SQLiteException)
            {
                return null;
            }
        }
        public static Restaurant selectRestaurantByIndex(Restaurant restaurant)
        {
            try
            {
                var connection = new SQLiteConnection(dbFile);
                var restaurantsNull = connection.Query<Restaurant>("select * from Restaurant where RestaurantID=" + restaurant.RestaurantID.ToString());
                if (restaurantsNull != null)
                {
                    List<Restaurant> restaurants = new List<Restaurant>(restaurantsNull);
                    if (restaurants.Count == 0) return null;
                    return restaurants[0];
                }
                return null;
            }
            catch (SQLiteException)
            {
                return null;
            }
        }
        public static bool insertRestaurant(Restaurant restaurant)
        {
            try
            {
                var connection = new SQLiteConnection(dbFile);
                connection.Insert(restaurant);
                return true;

            }
            catch (SQLiteException)
            {
                return false;
            }
        }
        public static bool updateRestaurant(Restaurant restaurant)
        {
            try
            {
                var connection = new SQLiteConnection(dbFile);
                connection.Update(restaurant);
                return true;
            }
            catch (SQLiteException)
            {
                return false;
            }
        }
        public static bool deleteRestaurant(Restaurant restaurant)
        {
            try
            {
                var connection = new SQLiteConnection(dbFile);
                connection.Delete(restaurant);
                return true;
            }
            catch (SQLiteException)
            {
                return false;
            }
        }

        public static List<Category> selectAllCategories()
        {
            try
            {
                var connection = new SQLiteConnection(dbFile);
                return connection.Table<Category>().ToList();

            }
            catch (SQLiteException)
            {
                return null;
            }
        }
        public static Category selectCategoryByIndex(Category category)
        {
            try
            {
                var connection = new SQLiteConnection(dbFile);
                var categoriesNull = connection.Query<Category>("select * from Category where CategoryID=" + category.CategoryID.ToString());
                if (categoriesNull != null) { 
                    List<Category> categories = new List<Category>(categoriesNull);
                    if (categories.Count == 0) return null;
                    return categories[0];
                }
                return null;
            }
            catch (SQLiteException)
            {
                return null;
            }
        }
        public static bool insertCategory(Category category)
        {
            try
            {
                var connection = new SQLiteConnection(dbFile);
                connection.Insert(category);
                return true;

            }
            catch (SQLiteException)
            {
                return false;
            }
        }
        public static bool updateCategory(Category category)
        {
            try
            {
                var connection = new SQLiteConnection(dbFile);
                connection.Update(category);
                return true;
            }
            catch (SQLiteException)
            {
                return false;
            }
        }
        public static bool deleteCategory(Category category)
        {
            try
            {
                var connection = new SQLiteConnection(dbFile);
                connection.Delete(category);
                return true;
            }
            catch (SQLiteException)
            {
                return false;
            }
        }

        public static List<Food> selectAllFoods()
        {
            try
            {
                var connection = new SQLiteConnection(dbFile);
                return connection.Table<Food>().ToList();

            }
            catch (SQLiteException)
            {
                return null;
            }
        }
        public static Food selectFoodByIndex(Food food)
        {
            try
            {
                var connection = new SQLiteConnection(dbFile);
                var foodsNull = connection.Query<Food>("select * from Food where FoodID=" + food.FoodID.ToString());
                if (foodsNull != null)
                {
                    List<Food> foods = new List<Food>(foodsNull);
                    if (foods.Count == 0) return null;
                    return foods[0];
                }
                return null;
            }
            catch (SQLiteException)
            {
                return null;
            }
        }
        public static List<Food> selectFoodByCategory(Category category)
        {
            try
            {
                var connection = new SQLiteConnection(dbFile);
                return connection.Query<Food>("select * from Food where CategoryID=" + category.CategoryID.ToString());
            }
            catch (SQLiteException)
            {
                return null;
            }
        }
        public static bool insertFood(Food food)
        {
            try
            {
                var connection = new SQLiteConnection(dbFile);
                connection.Insert(food);
                return true;

            }
            catch (SQLiteException)
            {
                return false;
            }
        }
        public static bool updateFood(Food food)
        {
            try
            {
                var connection = new SQLiteConnection(dbFile);
                connection.Update(food);
                return true;
            }
            catch (SQLiteException)
            {
                return false;
            }
        }
        public static bool deleteFood(Food food)
        {
            try
            {
                var connection = new SQLiteConnection(dbFile);
                connection.Delete(food);
                return true;
            }
            catch (SQLiteException)
            {
                return false;
            }
        }

        public static List<User> selectAllUsers()
        {
            try
            {
                var connection = new SQLiteConnection(dbFile);
                return connection.Table<User>().ToList();

            }
            catch (SQLiteException)
            {
                return null;
            }
        }
        public static User selectUserByIndex(User user)
        {
            try
            {
                var connection = new SQLiteConnection(dbFile);
                var usersNull = connection.Query<User>("select * from User where UserID=" + user.UserID.ToString());
                if (usersNull != null)
                {
                    List<User> users = new List<User>(usersNull);
                    if (users.Count == 0) return null;
                    return users[0];
                }
                return null;
            }
            catch (SQLiteException)
            {
                return null;
            }
        }
        public static User selectUserByEmail(User user)
        {
            try
            {
                var connection = new SQLiteConnection(dbFile);
                var usersNull = connection.Query<User>("select * from User where UserEmail='" + user.UserEmail.ToString() + "'");
                if (usersNull != null)
                {
                    List<User> users = new List<User>(usersNull);
                    if (users.Count == 0) return null;
                    return users[0];
                }
                return null;
            }
            catch (SQLiteException)
            {
                return null;
            }
        }
        public static bool insertUser(User user)
        {
            try
            {
                var connection = new SQLiteConnection(dbFile);
                connection.Insert(user);
                return true;

            }
            catch (SQLiteException)
            {
                return false;
            }
        }
        public static bool updateUser(User user)
        {
            try
            {
                var connection = new SQLiteConnection(dbFile);
                connection.Update(user);
                return true;
            }
            catch (SQLiteException)
            {
                return false;
            }
        }
        public static bool deleteUser(User user)
        {
            try
            {
                var connection = new SQLiteConnection(dbFile);
                connection.Delete(user);
                return true;
            }
            catch (SQLiteException)
            {
                return false;
            }
        }
    }
}
