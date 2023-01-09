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
    public partial class SignupPage : ContentPage
    {
        public SignupPage()
        {
            InitializeComponent();
        }

        private async void Signup(object sender, EventArgs e)
        {
            //await Shell.Current.Navigation.PushAsync(new VerificationPage());
            string image = consumerImage.Text,
                name = consumerName.Text,
                email = consumerEmail.Text,
                username = consumerUsername.Text,
                password = consumerPassword.Text,
                confirmPassword = consumerConfirmPassword.Text;

            if (password != confirmPassword)
            {
                await DisplayAlert("Confirm password does not match with Password!!!", "", "Close");
                return;
            }

            Consumer consumer = new Consumer
            {
                ConsumerImage = image,
                ConsumerName = name,
                ConsumerEmail = email,
                ConsumerUsername = username,
                ConsumerPassword = password
            };

            Consumer returnConsumer = await WebAPI.SelectConsumerByUsername(consumer.ConsumerUsername);
            if (returnConsumer == null)
            {
                ConsumerProvider.consumer = consumer;
                //await Shell.Current.GoToAsync("//tabBar/homepage");
                await Shell.Current.GoToAsync("//verificationPage");
            }
            else await DisplayAlert(username + " is already in use.", "", "Close");
        }
    }
}