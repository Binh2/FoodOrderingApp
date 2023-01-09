using FoodOrderingApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodOrderingApp.AccountPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResetPasswordPage : ContentPage
    {
        public ResetPasswordPage()
        {
            InitializeComponent();
            Title = "Reset password";
        }

        private async void Reset(object sender, EventArgs e)
        {
            string password = passwordEntry.Text,
                confirmPassword = confirmPasswordEntry.Text;
            Consumer consumer = ConsumerProvider.consumer;
            if (password == confirmPassword) {
                consumer.ConsumerPassword = password;
                ConsumerProvider.consumer = consumer;
                await WebAPI.UpdateConsumer(consumer);
                await Shell.Current.GoToAsync("//tabBar/homepage");
            } else
            {
                await DisplayAlert("Your password is not the same with your confirm password", "", "Close");
            }
        }
    }
}