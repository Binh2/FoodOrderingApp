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
    public partial class ImagesView : ContentView
    {
        public static readonly BindableProperty ImagesProperty = BindableProperty.Create(nameof(Images), typeof(string), typeof(PriceView), string.Empty);

        public string Images
        {
            get => (string)GetValue(ImagesView.ImagesProperty);
            set => SetValue(ImagesView.ImagesProperty, value);
        }

        public ImagesView()
        {
            InitializeComponent();
            collectionView.ItemsSource = Images.Split('|');
        }
    }
}