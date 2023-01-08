using FoodOrderingApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodOrderingApp.Pages
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
                password = consumerPassword.Text,
                confirmPassword = consumerConfirmPassword.Text;

            if (password != confirmPassword)
            {
                await DisplayAlert("Confirm password does not match with Password!!!", "", "Close");
                return;
            }

            //Consumer consumer = new Consumer
            //{
            //    ConsumerImage = image,
            //    ConsumerName = name,
            //    ConsumerEmail = email,
            //    ConsumerPassword = password
            //};

            //Consumer returnConsumer = Database.selectConsumerByEmail(consumer);
            //if (returnConsumer == null)
            //{
            //    await Shell.Current.GoToAsync("//tabBar/homepage");
            //    Database.insertConsumer(consumer);
            //    ConsumerProvider.consumer = consumer;
            //}
            //else await DisplayAlert(email + " is already in use.", "", "Close");
        }
    }
}