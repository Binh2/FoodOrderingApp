using FoodOrderingApp.Helpers;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FoodOrderingApp.Model;
using FoodOrderingApp.Views;
using FoodOrderingApp.ProfilePages;
using FoodOrderingApp.Pages;
namespace FoodOrderingApp
{
    public partial class App : Application
    {
        public static FoodDatabase foodDb = new FoodDatabase();
        public App()
        {
            InitializeComponent();
            MainPage = new CategoriesPage();

            //Database.deleteDatabase(); //Uncomment this line to renew database every run
            if (!File.Exists(Database.dbFile))
            {
                Database.createDatabase();
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
