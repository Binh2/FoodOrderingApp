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

namespace FoodOrderingApp.AccountPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SigninPage : ContentPage
    {
        public ICommand ForgotPasswordCommand { get; } = new Command<String>(async (_) => await Shell.Current.Navigation.PushAsync(new ForgotPasswordPage()));
        public ICommand SignupCommand { get; } = new Command<String>(async (_) => await Shell.Current.Navigation.PushAsync(new SignupPage()));
        //public ICommand TapCommand { get; } = new Command<String>(async (_) => {
        //    new Consumer()
        //    {
        //        Consu
        //    }
        //    await Shell.Current.Navigation.PushAsync(new SignupPage());
        //});
        private string GenerateRandom6DigitString()
        {
            Random generator = new Random();
            return generator.Next(0, 1000000).ToString("D6");
        }
        public SigninPage()
        {
            InitializeComponent();
            BindingContext = this;
            signinBtn.IsTabStop = false;
        }

        private async void Signin(object sender, EventArgs e)
        {
            string username = consumerUsername.Text,
                password = consumerPassword.Text;

            Consumer consumer = new Consumer
            {
                ConsumerUsername = username,
                ConsumerPassword = password
            };

            //Consumer returnConsumer = Database.selectConsumerByEmail(consumer);
            Consumer returnConsumer = await WebAPI.SelectConsumerByUsername(username);
            if (returnConsumer == null || returnConsumer.ConsumerPassword != consumer.ConsumerPassword)
            {
                await DisplayAlert("Email or password is not correct", "", "Close");
                return;
            }

            if (returnConsumer.ConsumerPassword == consumer.ConsumerPassword)
            {
                await Shell.Current.GoToAsync(Route.HOMEPAGE);
                ConsumerProvider.consumer = returnConsumer;
            }
        }
    }
}