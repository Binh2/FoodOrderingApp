using FoodOrderingApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodOrderingApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CartPage : ContentPage
    {
        public CartPage()
        {
            InitializeComponent();
            collectionView.ItemsSource = ConsumerProvider.cart.Foods;
            priceSumLabel.Text = ConsumerProvider.cart.Foods.Aggregate(0.0, (sum, food) => sum + food.FoodQuantity * food.FoodPrice).ToString();
        }

        private void RefreshCollectionView()
        {
            collectionView.ItemsSource = null;
            collectionView.ItemsSource = ConsumerProvider.cart.Foods; ;
            priceSumLabel.Text= ConsumerProvider.cart.Foods.Aggregate(0.0, (sum, food) => sum + food.FoodQuantity * food.FoodPrice).ToString();
        }

        private void ChangeFoodQuantity(object sender, EventArgs e, int value)
        {
            Button button = sender as Button;
            Foods food = button.CommandParameter as Foods;
            ConsumerProvider.cart.Foods.Where<Foods>(f => f.FoodID == food.FoodID).First().FoodQuantity += value;
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
            Foods removedFood = swipeItem.CommandParameter as Foods;
            ConsumerProvider.cart.Foods.Remove(removedFood);
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