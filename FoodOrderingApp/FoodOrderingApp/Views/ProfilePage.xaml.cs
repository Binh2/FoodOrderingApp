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
        }

        private void deleteAccountBtn_Tapped(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//signinPage");
            Database.deleteUser(UserProvider.user);
        }

        private void signoutBtn_Tapped(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//signinPage");
        }
    }
}