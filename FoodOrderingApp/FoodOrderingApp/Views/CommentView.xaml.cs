using FoodOrderingApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodOrderingApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CommentView : ContentView
    {
        List<Comment> comments;
        public CommentView()
        {

            InitializeComponent();
            comments = new List<Comment>()
            {
                new Comment() { CommenterName = "David Spade", CommenterImage = "david_spade.png", CommentComment = "Dripping saliva!!!"},
                new Comment() { CommenterName = "David Spade", CommenterImage = "david_spade.png", CommentComment = "Look so delicious!!!"}
            };
            collectionView.ItemsSource = comments;
        }
    }
}