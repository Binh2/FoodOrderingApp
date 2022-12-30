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
    public partial class PriceView : ContentView
    {
        public static readonly BindableProperty PriceProperty = BindableProperty.Create(nameof(Price), typeof(string), typeof(PriceView), string.Empty);

        public string Price
        {
            get => (string)GetValue(PriceView.PriceProperty);
            set => SetValue(PriceView.PriceProperty, value);
        }
        public PriceView()
        {
            InitializeComponent();
        }
    }
}