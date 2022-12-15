using FoodOrderingApp.Helpers;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodOrderingApp
{
    public partial class App : Application
    {
        public static FoodDatabase foodDb = new FoodDatabase();
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
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
