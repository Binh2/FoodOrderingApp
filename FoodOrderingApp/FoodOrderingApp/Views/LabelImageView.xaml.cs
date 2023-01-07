using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodOrderingApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LabelImageView : ContentView
    {
        public static readonly BindableProperty TapCommandProperty = BindableProperty.Create(nameof(TapCommand), typeof(ICommand), typeof(LabelImageView));
        public ICommand TapCommand
        {
            get => (ICommand)GetValue(LabelImageView.TapCommandProperty);
            set => SetValue(LabelImageView.TapCommandProperty, value);
        }
        public static readonly BindableProperty TapCommandParameterProperty = BindableProperty.Create(nameof(TapCommandParameter), typeof(string), typeof(LabelImageView));
        public string TapCommandParameter
        {
            get => (string)GetValue(LabelImageView.TapCommandParameterProperty);
            set => SetValue(LabelImageView.TapCommandParameterProperty, value);
        }

        public static readonly BindableProperty ImageWidthRequestProperty = BindableProperty.Create(nameof(ImageWidthRequest), typeof(int), typeof(LabelImageView), 30);
        public int ImageWidthRequest
        {
            get => (int)GetValue(LabelImageView.ImageWidthRequestProperty);
            set => SetValue(LabelImageView.ImageWidthRequestProperty, value);
        }

        public static readonly BindableProperty ImageSourceProperty = BindableProperty.Create(nameof(ImageSource), typeof(string), typeof(LabelImageView));
        public string ImageSource
        {
            get => (string)GetValue(LabelImageView.ImageSourceProperty);
            set => SetValue(LabelImageView.ImageSourceProperty, value);
        }

        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(LabelImageView));
        public string Text
        {
            get => (string)GetValue(LabelImageView.TextProperty);
            set => SetValue(LabelImageView.TextProperty, value);
        }
        public LabelImageView()
        {
            InitializeComponent();
            BindingContext = this;
        }
    }
}