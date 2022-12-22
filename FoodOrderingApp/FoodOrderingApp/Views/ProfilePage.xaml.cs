using FoodOrderingApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodOrderingApp.Views
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
    }
}