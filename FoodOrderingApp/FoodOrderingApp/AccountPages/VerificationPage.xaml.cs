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
    public partial class VerificationPage : ContentPage
    {
        List<Entry> verificationEntries = null;
        public ICommand ResendVerificationCommand { get; set; }
        string random;
        string nextPage = "//tabBar/homepage";

        public VerificationPage()
        {
            InitializeComponent();
        }
        public VerificationPage(string nextPage)
        {
            InitializeComponent();
            this.nextPage = nextPage;
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            ResendVerificationCommand = new Command<String>(async (_) => { 
                await SendEmail(); 
            });
            resendPINLabel.GestureRecognizers.Add(new TapGestureRecognizer() { Command = ResendVerificationCommand });
            await SendEmail();
        }
        private void verificationEntry1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue.Length == 1) verificationEntry2.Focus();
        }
        private void verificationEntry2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue.Length == 1) verificationEntry3.Focus();
            else verificationEntry1.Focus();
        }
        private void verificationEntry3_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue.Length == 1) verificationEntry4.Focus();
            else verificationEntry2.Focus();
        }
        private void verificationEntry4_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue.Length == 1) verificationEntry5.Focus();
            else verificationEntry3.Focus();
        }
        private void verificationEntry5_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue.Length == 1) verificationEntry6.Focus();
            else verificationEntry4.Focus();
        }
        private void verificationEntry6_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue.Length == 1)
            {
                verificationEntry6.Unfocus();
                Verify();
            }
            else verificationEntry5.Focus();
        }
        private async void Verify() 
        {
            if (verificationEntries == null)
            {
                verificationEntries = new List<Entry>();
                verificationEntries.Add(verificationEntry1);
                verificationEntries.Add(verificationEntry2);
                verificationEntries.Add(verificationEntry3);
                verificationEntries.Add(verificationEntry4);
                verificationEntries.Add(verificationEntry5);
                verificationEntries.Add(verificationEntry6);
            };
            string enteredVerification = "";
            foreach (Entry entry in verificationEntries) {
                enteredVerification += entry.Text;
            }
            if (enteredVerification == random)
            {
                await WebAPI.InsertConsumer(ConsumerProvider.consumer);
                await Shell.Current.GoToAsync(nextPage);
            }
            else
            {
                for (int i = verificationEntries.Count-1; i >= 0; i--)
                {
                    Entry Entry = verificationEntries[i];
                    Entry.Text = "";
                }
                await DisplayAlert("Incorrect verification code", "Please reenter the correct verification code", "Close");
            }
        }
        private string GenerateRandom6DigitString()
        {
            Random generator = new Random();
            return generator.Next(0, 1000000).ToString("D6");
        }
        public async Task SendEmail()
        {
            random = GenerateRandom6DigitString();
            await DisplayAlert("PIN", random, "Close");
            //try
            //{
            //    string subject = "Please verify your email";
            //    random = GenerateRandom6DigitString();
            //    string body = string.Format("This is your verification code: {0}", random);
            //    List<string> recipients = new List<string>() { UserProvider.user.UserEmail };
            //    var message = new EmailMessage
            //    {
            //        Subject = subject,
            //        Body = body,
            //        To = recipients,
            //        //Cc = ccRecipients,
            //        //Bcc = bccRecipients
            //    };
            //    await Email.ComposeAsync(message);
            //}
            //catch (FeatureNotSupportedException fbsEx)
            //{
            //    // Email is not supported on this device
            //}
            //catch (Exception ex)
            //{
            //    // Some other exception occurred
            //}
        }
    }
}