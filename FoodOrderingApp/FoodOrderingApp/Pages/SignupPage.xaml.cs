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
            await Shell.Current.Navigation.PushAsync(new VerificationPage());
            //string image = userImage.Text,
            //    name = userName.Text,
            //    email = userEmail.Text,
            //    password = userPassword.Text,
            //    confirmPassword = userConfirmPassword.Text;

            //if (password != confirmPassword)
            //{
            //    await DisplayAlert("Confirm password does not match with Password!!!", "", "Close");
            //    return;
            //}
            
            //User user = new User
            //{
            //    UserImage = image,
            //    UserName = name,
            //    UserEmail = email,
            //    UserPassword = password
            //};

            //User returnUser = Database.selectUserByEmail(user);
            //if (returnUser == null)
            //{
            //    await Shell.Current.GoToAsync("//tabBar/homepage");
            //    Database.insertUser(user);
            //    UserProvider.user = user;
            //}
            //else await DisplayAlert(email + " is already in use.", "", "Close");
        }
    }
}