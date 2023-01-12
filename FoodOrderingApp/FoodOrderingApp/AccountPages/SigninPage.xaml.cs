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
        public ICommand TapCommand { get; private set; }
        Consumer consumer = null;
        private string GenerateRandom3DigitString()
        {
            Random generator = new Random();
            return generator.Next(0, 999).ToString("D3");
        }
        private Consumer GenerateRandomCunsumer()
        {
            Random generator = new Random();
            List<string> firstNames = new List<string>()
            {
                "James", "Robert", "John", "Michael", "David",
                "Mary", "Patricia", "Jennifer", "Linda", "Elizabeth"
            };
            List<string> lastNames = new List<String>()
            {
                "Smith", "Brown"
            };
            string firstName = firstNames[generator.Next(0, firstNames.Count - 1)];
            string lastName = lastNames[generator.Next(0, lastNames.Count - 1)];
            string random3Digit = GenerateRandom3DigitString();
            return new Consumer()
            {
                ConsumerName = $"{firstName} {lastName}",
                ConsumerEmail = $"{firstName}{random3Digit}@gmail.com",
                ConsumerImage = $"{firstName}_{lastName}.png",
                ConsumerUsername = $"{firstName}{random3Digit}",
                ConsumerPassword = "123"
            };
        }
        public SigninPage()
        {
            InitializeComponent();
            BindingContext = this;
            signinBtn.IsTabStop = false;
            TapCommand = new Command<String>(async (_) =>
            {
                consumer = GenerateRandomCunsumer();
                Signin(signinBtn, new EventArgs());
                await Shell.Current.Navigation.PushAsync(new SignupPage());
            });
        }

        private async void Signin(object sender, EventArgs e)
        {
            string username = "", password = "";
            if (consumer == null)
            {
                username = consumerUsername.Text;
                password = consumerPassword.Text;

                consumer = new Consumer
                {
                    ConsumerUsername = username,
                    ConsumerPassword = password
                };
            }
            

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