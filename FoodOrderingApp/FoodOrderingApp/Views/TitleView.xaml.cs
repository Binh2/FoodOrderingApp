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
    public partial class ShellNavBarTitleView : ContentView
    {
        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(ShellNavBarTitleView));

        public string Text
        {
            get => (string)GetValue(ShellNavBarTitleView.TextProperty);
            set => SetValue(ShellNavBarTitleView.TextProperty, value);
        }

        public ShellNavBarTitleView()
        {
            InitializeComponent();
            BindingContext = this;
        }
    }
}