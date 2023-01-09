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
    public partial class EditCardPage : ContentPage
    {
        Card card;
        public EditCardPage(Card card)
        {
            InitializeComponent();
            Title = "Edit Card";
            this.card = card;
            cardNumberEntry.Text = card.CardNumber;
            consumerNameEntry.Text = card.ConsumerName;
        }

        private async void editBtn_Clicked(object sender, EventArgs e)
        {
            await WebAPI.UpdateCard(card);
            await Shell.Current.Navigation.PopAsync();
        }

        private async void cancelBtn_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PopAsync();
        }
    }
}