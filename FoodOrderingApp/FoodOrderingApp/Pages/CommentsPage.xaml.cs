using FoodOrderingApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodOrderingApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CommentsPage : ContentPage
    {
        public List<Comment> comments;
        public int foodID = 1;
        public CommentsPage()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            Title = foodID.ToString();
            comments = await WebAPI.SelectCommentsByFoodID(foodID);
            collectionView.ItemsSource = comments;
        }
    }
}