using FoodOrderingApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodOrderingApp.ProfilePages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditProfilePage : ContentPage
    {
        public EditProfilePage()
        {
            InitializeComponent();
        }

        private async void Signup(object sender, EventArgs e)
        {
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
                ConsumerID = ConsumerProvider.consumer.ConsumerID,
                ConsumerImage = image,
                ConsumerName = name,
                ConsumerEmail = email,
                ConsumerUsername = username,
                ConsumerPassword = password
            };

            //Consumer returnedConsumer = Database.selectConsumerByEmail(consumer);
            Consumer returnedConsumer = await WebAPI.SelectConsumerByID(consumer.ConsumerID);
            if (returnedConsumer != null)
            {
                await Shell.Current.Navigation.PopAsync();
                //Database.updateConsumer(consumer);
                await WebAPI.UpdateConsumer(consumer);
                ConsumerProvider.consumer = consumer;
            }
        }
    }
}