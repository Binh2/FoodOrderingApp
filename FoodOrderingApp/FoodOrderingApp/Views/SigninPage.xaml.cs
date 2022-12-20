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
        }

        private async void signin_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//tabbar/homepage");
        }
    }
}