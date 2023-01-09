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
        }
        protected async override void OnAppearing()
        {
            //cards = await WebAPI.GetAll<Card>();
            cards = new List<Card>() { new Card() };
            collectionView.ItemsSource = cards;
        }
        private async void cardLayout_Tapped(object sender, EventArgs e)
        {
            Frame frame = sender as Frame;
            TapGestureRecognizer tapGestureRecognizer = frame.GestureRecognizers[0] as TapGestureRecognizer;
            Card card = tapGestureRecognizer.CommandParameter as Card;
            await Shell.Current.Navigation.PushAsync(new EditCardPage(card));
        }
    }
}