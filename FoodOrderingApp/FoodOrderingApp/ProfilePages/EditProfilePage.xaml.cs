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
            string image = userImage.Text,
                name = userName.Text,
                email = userEmail.Text,
                password = userPassword.Text,
                confirmPassword = userConfirmPassword.Text;

            if (password != confirmPassword)
            {
                await DisplayAlert("Confirm password does not match with Password!!!", "", "Close");
                return;
            }

            User user = new User
            {
                UserID = UserProvider.user.UserID,
                UserImage = image,
                UserName = name,
                UserEmail = email,
                UserPassword = password
            };

            User returnUser = Database.selectUserByEmail(user);
            if (returnUser != null)
            {
                await Shell.Current.Navigation.PopAsync();
                Database.updateUser(user);
                UserProvider.user = user;
            }
        }
    }
}