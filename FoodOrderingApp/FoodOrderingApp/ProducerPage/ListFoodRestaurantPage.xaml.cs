using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodOrderingApp.ProducerPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListFoodRestaurantPage : ContentPage
    {
        public ListFoodRestaurantPage()
        {
            InitializeComponent();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

        }
    }
}