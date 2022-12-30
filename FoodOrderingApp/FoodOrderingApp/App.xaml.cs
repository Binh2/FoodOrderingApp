using FoodOrderingApp.Helpers;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FoodOrderingApp.Model;
using FoodOrderingApp.Views;

namespace FoodOrderingApp
{
    public partial class App : Application
    {
        public static FoodDatabase foodDb = new FoodDatabase();
        public App()
        {
            InitializeComponent();
            MainPage = new Homepage();


            
            if (!File.Exists(Database.dbFile))
            {
                //Database.deleteDatabase(); //Uncomment this line to renew database every run
                File.Delete(Database.dbFile); //Uncomment this line to renew database every run
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
