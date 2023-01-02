using FoodOrderingApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodOrderingApp.ProfilePages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WishlistPage : ContentPage
    {
        ObservableCollection<Foods> foods;
        public WishlistPage()
        {
            InitializeComponent();
            Title = "Wishlist";
            foods = new ObservableCollection<Foods>()
            {
                new Foods() { FoodImages = "pizza.png", FoodName = "Pizza", FoodPrice = 1, FoodState = FOOD_STATE.AVAILABLE },
                new Foods() { FoodImages = "fruits.png", FoodName = "Fruits", FoodPrice = 2, FoodState = FOOD_STATE.NOT_AVAILABLE },
                new Foods() { FoodImages = "hamburger_and_chips.png", FoodName = "Hamburger and chips", FoodPrice = 5, FoodState = FOOD_STATE.AVAILABLE },
                new Foods() { FoodImages = "hot_dog.png", FoodName = "Hot dog", FoodPrice = 2, FoodState = FOOD_STATE.NOT_AVAILABLE },
            };
            collectionView.ItemsSource = foods;
        }
    }
}