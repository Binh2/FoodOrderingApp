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
    public partial class CardsPage : ContentPage
    {
        List<Card> cards;
        public CardsPage()
        {
            InitializeComponent();
            cards = new List<Card>
            {
                new Card() { CardHolderName = UserProvider.user.UserName, CardExpiryDate = DateTime.Now,
                CardNumber = "4560 5674 3224 4543", CardType = "Visa" },
                new Card() { CardHolderName = UserProvider.user.UserName, CardExpiryDate = DateTime.Now,
                CardNumber = "4560 5674 3224 4543", CardType = "MasterCard" },
            };
            collectionView.ItemsSource = cards;
        }

        private async void cardLayout_Tapped(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PushAsync(new EditCardPage());
        }
    }
}