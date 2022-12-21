using FoodOrderingApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodOrderingApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SigninPage : ContentPage
    {
        public ICommand TapCommand { get; } = new Command<String>(async (_) => await Shell.Current.Navigation.PushAsync(new SignupPage()));
        public SigninPage()
        {
            InitializeComponent();
            BindingContext = this;
            signinBtn.IsTabStop = false;
        }

        private async void Signin(object sender, EventArgs e)
        {
            string email = userEmail.Text,
                password = userPassword.Text;

            User user = new User
            {
                UserEmail = email,
                UserPassword = password
            };

            User returnUser = Database.selectUserByEmail(user);
            if (returnUser == null)
            {
                await DisplayAlert("Email or password is not correct", "", "Close");
                return;
            }

            if (returnUser.UserPassword == user.UserPassword)
            {
                await Shell.Current.GoToAsync("//tabBar/homepage");
                UserProvider.user = returnUser;
            }
        }
    }
}