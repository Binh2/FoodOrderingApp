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
    public partial class ForgotPasswordPage : ContentPage
    {
        public ForgotPasswordPage()
        {
            InitializeComponent();
            Title = "Forgot password?";
        }

        private async void Continue(object sender, EventArgs e)
        {
            ConsumerProvider.consumer = await WebAPI.SelectConsumerByEmail(emailEntry.Text);
            await Shell.Current.Navigation.PushAsync(new VerificationPage("//resetPasswordPage"));
        }
    }
}