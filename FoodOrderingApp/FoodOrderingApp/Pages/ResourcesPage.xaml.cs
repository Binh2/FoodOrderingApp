﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FoodOrderingApp.Model;

namespace FoodOrderingApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResourcesPage : ContentPage
    {
        public ResourcesPage()
        {
            InitializeComponent();
            UpdateCategoryIDPicker();
            UpdateFoodIDPicker();
            UpdateFoodCategoryIDPicker();
            UpdateRestaurantIDPicker();
        }

        private void UpdateCategoryIDPicker()
        {
            List<int> categoryIDs = Database.selectAllCategories().Select(category => category.CategoryID).ToList();
            categoryIDs.Add(-1);
            categoryIDPicker.ItemsSource = categoryIDs;
            categoryIDPicker.SelectedItem = -1;
        }
        private void UpdateFoodIDPicker()
        {
            List<int> foodIDs = Database.selectAllFoods().Select(food => food.FoodID).ToList();
            foodIDs.Add(-1);
            foodIDPicker.ItemsSource = foodIDs;
            foodIDPicker.SelectedItem = -1;
        }
        private void UpdateFoodCategoryIDPicker()
        {
            List<int> foodCategoryIDs = Database.selectAllCategories().Select(category => category.CategoryID).ToList();
            foodCategoryIDPicker.ItemsSource = foodCategoryIDs;
            //foodCategoryIDPicker.SelectedIndex = 0;
        }

        private void categoryAddUpdate_Clicked(object sender, EventArgs e)
        {
            int id = categoryIDPicker.SelectedItem == null ? -1: (int)categoryIDPicker.SelectedItem;
            string name = categoryNameEntry.Text, 
                images = categoryImagesEntry.Text, 
                link = categoryLinkEntry.Text;
            if (id == -1)
            {
                Database.insertCategory(new Categories { CategoryName = name, CategoryImage = images,  });
                UpdateCategoryIDPicker();
                UpdateFoodCategoryIDPicker();
            }
            else
            {
                Database.updateCategory(new Categories { CategoryID = id, CategoryName = name, CategoryImage = images,});
                categoryIDPicker.SelectedItem = -1;
            }
            categoryNameEntry.Text = "";
            categoryImagesEntry.Text = "";
            categoryLinkEntry.Text = "";
        }
        private void categoryDelete_Clicked(object sender, EventArgs e)
        {
            int id = (int)categoryIDPicker.SelectedItem;
            Database.deleteCategory(new Categories { CategoryID = id });
            UpdateCategoryIDPicker();
            UpdateFoodCategoryIDPicker();
            categoryNameEntry.Text = "";
            categoryImagesEntry.Text = "";
            categoryLinkEntry.Text = "";
            categoryIDPicker.SelectedItem = -1;
        }
        private void categoryIDPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            Picker picker = (Picker)sender;
            int id = picker.SelectedItem == null? -1: (int)picker.SelectedItem;
            if (id == -1)
            {
                categoryNameEntry.Text = "";
                categoryImagesEntry.Text = "";
                categoryLinkEntry.Text = "";
            }
            else
            {
                Categories category = Database.selectCategoryByIndex(new Categories { CategoryID = id });
                categoryNameEntry.Text = category.CategoryName;
                categoryImagesEntry.Text = category.CategoryImage;
            }
        }

        private void foodAddUpdate_Clicked(object sender, EventArgs e)
        {
            int id = (int)foodIDPicker.SelectedItem;
            string name = foodNameEntry.Text,
                images = foodImagesEntry.Text;
            int categoryID = (int)foodCategoryIDPicker.SelectedItem;
            if (id == -1)
            {
                Database.insertFood(new Foods { FoodName = name, FoodImages = images });
                UpdateFoodIDPicker();
            }
            else
            {
                Database.updateFood(new Foods { FoodID = id, FoodName = name, FoodImages = images, CategoryID = categoryID });
                foodIDPicker.SelectedIndex = -1;
            }
            foodNameEntry.Text = "";
            foodImagesEntry.Text = "";
        }
        private void foodDelete_Clicked(object sender, EventArgs e)
        {
            int id = (int)foodIDPicker.SelectedItem;
            Database.deleteFood(new Foods { FoodID = id });
            UpdateFoodIDPicker();
            foodIDPicker.SelectedIndex = -1;
            foodNameEntry.Text = "";
            foodImagesEntry.Text = "";
        }
        private void foodIDPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = foodIDPicker.SelectedItem == null ? -1: (int)foodIDPicker.SelectedItem;
            if (id == -1)
            {
                foodNameEntry.Text = "";
                foodImagesEntry.Text = "";
            }
            else
            {
                Foods food = Database.selectFoodByIndex(new Foods { FoodID = id });
                foodNameEntry.Text = food.FoodName;
                foodImagesEntry.Text = food.FoodImages;
                foodCategoryIDPicker.SelectedItem = food.CategoryID;
            }
        }
        private void foodCategoryIDPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            Picker picker = (Picker)sender;
            int id = picker.SelectedItem == null ? -1 : (int)picker.SelectedItem;
            if (id == -1)
            {
                foodNameEntry.Text = "";
                foodImagesEntry.Text = "";
            }
            else
            {
                Foods food = Database.selectFoodByIndex(new Foods { FoodID = id });
                foodNameEntry.Text = food.FoodName;
                foodImagesEntry.Text = food.FoodImages;
            }
        }

        private void UpdateRestaurantIDPicker()
        {
            List<int> restaurantIDs = Database.selectAllRestaurants().Select(restaurant => restaurant.RestaurantID).ToList();
            restaurantIDs.Add(-1);
            restaurantIDPicker.ItemsSource = restaurantIDs;
            restaurantIDPicker.SelectedItem = -1;
        }

        private void restaurantIDPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = restaurantIDPicker.SelectedItem == null ? -1 : (int)restaurantIDPicker.SelectedItem;
            if (id == -1)
            {
                restaurantNameEntry.Text = "";
            }
            else
            {
                Restaurant restaurant = Database.selectRestaurantByIndex(new Restaurant { RestaurantID = id });
                restaurantNameEntry.Text = restaurant.RestaurantName;
            }
        }

        private void restaurantDelete_Clicked(object sender, EventArgs e)
        {
            int id = (int)restaurantIDPicker.SelectedItem;
            Database.deleteRestaurant(new Restaurant { RestaurantID = id });
            UpdateRestaurantIDPicker();
            //restaurantIDPicker.SelectedIndex = -1;
            restaurantNameEntry.Text = "";
        }

        private void restaurantAddUpdate_Clicked(object sender, EventArgs e)
        {
            int id = (int)restaurantIDPicker.SelectedItem;
            string name = restaurantNameEntry.Text;
            if (id == -1)
            {
                Database.insertRestaurant(new Restaurant { RestaurantName = name });
                UpdateRestaurantIDPicker();
            }
            else
            {
                Database.updateRestaurant(new Restaurant { RestaurantID = id, RestaurantName = name });
                //restaurantIDPicker.SelectedIndex = -1;
            }
            restaurantNameEntry.Text = "";
        }
    }
}