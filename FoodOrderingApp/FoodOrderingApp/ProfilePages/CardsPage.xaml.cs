using FoodOrderingApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
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
            Title = "Cards";
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            Refresh();
        }
        private async void Refresh()
        {
            cards = await WebAPI.SelectCardsByConsumerID(ConsumerProvider.consumer.ConsumerID);
            collectionView.ItemsSource = cards;
        }

        private async void editSwipe_Invoked(object sender, EventArgs e)
        {
            SwipeItem swipeItem = sender as SwipeItem;
            Card card = (Card)swipeItem.CommandParameter;
            await Shell.Current.Navigation.PushAsync(new EditCardPage(card));
        }

        private async void deleteSwipe_Invoked(object sender, EventArgs e)
        {
            SwipeItem swipeItem = sender as SwipeItem;
            Card card = (Card)swipeItem.CommandParameter;
            await WebAPI.DeleteCard(card.CardID);
            Refresh();
        }
    }
}