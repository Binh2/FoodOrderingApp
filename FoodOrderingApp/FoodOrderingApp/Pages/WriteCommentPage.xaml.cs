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
    public partial class WriteCommentPage : ContentPage
    {
        public WriteCommentPage(Foods food)
        {
            InitializeComponent();
            Title = "Write your review";
        }


        private void starView_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }
    }
}