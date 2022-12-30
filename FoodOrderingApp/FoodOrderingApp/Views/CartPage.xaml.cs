using FoodOrderingApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodOrderingApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CartPage : ContentPage
    {
        ObservableCollection<Food> cart;
        public CartPage()
        {
            InitializeComponent();
            cart = new ObservableCollection<Food>
            {
                new Food() { FoodID = 1, FoodImages = "pizza.png", FoodName = "Pizza", FoodPrice = 3, FoodQuantity = 1},
                new Food() { FoodID = 2, FoodImages = "fruits.png", FoodName = "Fruits", FoodPrice = 2, FoodQuantity = 2},
                new Food() { FoodID = 3, FoodImages = "hot_dog.png", FoodName = "Hot dog", FoodPrice = 1, FoodQuantity = 1},
                new Food() { FoodID = 4, FoodImages = "hamburger_and_chips.png", FoodName = "Hamburger and chips", FoodPrice = 3, FoodQuantity = 1}
            };
            collectionView.ItemsSource = cart;
            priceSumLabel.Text = cart.Aggregate(0, (sum, food) => sum + food.FoodQuantity * food.FoodPrice).ToString();
        }

        private void RefreshCollectionView()
        {
            collectionView.ItemsSource = null;
            collectionView.ItemsSource = cart;
            priceSumLabel.Text= cart.Aggregate(0, (sum, food) => sum + food.FoodQuantity * food.FoodPrice).ToString();
        }

        private void ChangeFoodQuantity(object sender, EventArgs e, int value)
        {
            Button button = sender as Button;
            Food food = button.CommandParameter as Food;
            cart.Where<Food>(f => f.FoodID == food.FoodID).First().FoodQuantity += value;
            RefreshCollectionView();
        }

        private void decrementBtn_Clicked(object sender, EventArgs e)
        {
            ChangeFoodQuantity(sender, e, -1);
        }

        private void incrementBtn_Clicked(object sender, EventArgs e)
        {
            ChangeFoodQuantity(sender, e, 1);
        }

        private void collectionView_BindingContextChanged(object sender, EventArgs e)
        {
            //List<Food> smallCart = new List<Food>
            //{
            //    new Food() { FoodImages = "pizza.png", FoodName = "Pizza", FoodPrice = 3, FoodQuantity = 1},
            //    new Food() { FoodImages = "fruits.png", FoodName = "Fruits", FoodPrice = 2, FoodQuantity = 2},
            //    new Food() { FoodImages = "hot_dog.png", FoodName = "Hot dog", FoodPrice = 1, FoodQuantity = 1}
            //};
            //collectionView.ItemsSource = null;
            //collectionView.ItemsSource = smallCart;
        }

        private void deleteSwipe_Invoked(object sender, EventArgs e)
        {
            SwipeItem swipeItem = sender as SwipeItem;
            Food removedFood = swipeItem.CommandParameter as Food;
            cart.Remove(removedFood);
            RefreshCollectionView();
        }

        private void favouriteSwipe_Invoked(object sender, EventArgs e)
        {

        }

        private void checkoutBtn_Clicked(object sender, EventArgs e)
        {

        }
    }
}