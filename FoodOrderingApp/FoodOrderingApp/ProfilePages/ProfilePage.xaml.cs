﻿using FoodOrderingApp.Model;
using FoodOrderingApp.ProfilePages;
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
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
            BindingContext = UserProvider.user;
        }

        private async void deleteAccountBtn_Tapped(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Are you sure you want to delete this account?", "", "Yes", "No");
            if (answer) { 
                await Shell.Current.GoToAsync("//signinPage");
                Database.deleteUser(UserProvider.user);
            }
        }

        private async void signoutBtn_Tapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//signinPage");
        }


        private async void editProfileBtn_Tapped(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PushAsync(new EditProfilePage());
        }

        private async void shippingAddressBtn_Tapped(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PushAsync(new ShippingAddressPage());
        }

        private async void wishlistBtn_Tapped(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PushAsync(new WishlistPage());
        }

        private async void orderHistoryBtn_Tapped(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PushAsync(new OrderHistoryPage());
        }

        private async void trackOrderBtn_Tapped(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PushAsync(new TrackOrderPage());
        }

        private async void cardsBtn_Tapped(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PushAsync(new CardsPage());
        }

        private async void notificationsBtn_Tapped(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PushAsync(new NotificationsPage());
        }
    }
}