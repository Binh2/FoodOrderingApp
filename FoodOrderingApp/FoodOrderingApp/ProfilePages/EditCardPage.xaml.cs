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
        }

        private async void editBtn_Clicked(object sender, EventArgs e)
        {
            //string result = await WebAPI.Delete<Card>(1);
            //string result = await WebAPI.Insert<Card>(new Card()
            //{
            //    //CardID = 1,
            //    CardImage = "/WEBAPI/Images/visa-card1.png",
            //    CardNumber = "11",
            //    CardExpiryDate = DateTime.Now,
            //    ConsumerID = 1,
            //    CardTypeID = 1
            //});
            //await DisplayAlert("Output", result, "Close");
        }

        private async void cancelBtn_Clicked(object sender, EventArgs e)
        {
            //string result = await WebAPI.Update<Card>(new Card()
            //{
            //    CardID = 1,
            //    CardImage = "/WEBAPI/Images/visa-card1.png",
            //    CardNumber = "11",
            //    CardExpiryDate = DateTime.Now,
            //    ConsumerID = 1,
            //    CardTypeID = 1
            //});
            //await DisplayAlert("Output", result, "Close");
        }
    }
}