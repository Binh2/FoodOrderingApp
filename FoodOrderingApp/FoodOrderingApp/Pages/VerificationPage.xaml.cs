using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodOrderingApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VerificationPage : ContentPage
    {
        List<Entry> verificationEntries = null;
        //public ICommand ResendVerificationCommand { get; } = new Command<String>(async (_) => await Shell.Current.Navigation.PushAsync(new SignupPage()));
        public VerificationPage()
        {
            InitializeComponent();
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
            if (enteredVerification == "123456")
                await Shell.Current.GoToAsync("//tabBar/homepage");
            else await DisplayAlert("Incorrect verification code", "Please reenter the correct verification code", "Close");
        }
        private string GenerateRandom6DigitString()
        {
            Random generator = new Random();
            return generator.Next(0, 1000000).ToString("D6");
        }

    }
}