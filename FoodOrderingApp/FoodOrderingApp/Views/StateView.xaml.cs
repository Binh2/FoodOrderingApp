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
    public partial class StateView : ContentView
    {
        public static readonly BindableProperty StateDescriptionProperty = BindableProperty.Create(nameof(StateDescription), typeof(string), typeof(PriceView), string.Empty);
        public static readonly BindableProperty ColorProperty = BindableProperty.Create(nameof(Color), typeof(string), typeof(PriceView), string.Empty);

        public string StateDescription
        {
            get => (string)GetValue(StateView.StateDescriptionProperty);
            set => SetValue(StateView.StateDescriptionProperty, value);
        }
        public string Color
        {
            get => (string)GetValue(StateView.ColorProperty);
            set => SetValue(StateView.ColorProperty, value);
        }
        public StateView()
        {
            InitializeComponent();
        }
    }
}