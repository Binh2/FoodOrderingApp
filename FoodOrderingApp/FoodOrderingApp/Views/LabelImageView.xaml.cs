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
        public static readonly BindableProperty TapCommandProperty = BindableProperty.Create(nameof(TapCommand), typeof(ICommand), typeof(LabelImageView), new Command(()=> { }));
        public ICommand TapCommand
        {
            get => (ICommand)GetValue(LabelImageView.TapCommandProperty);
            set => SetValue(LabelImageView.TapCommandProperty, value);
        }

        public static readonly new BindableProperty WidthRequestProperty = BindableProperty.Create(nameof(WidthRequest), typeof(int), typeof(LabelImageView), 0);
        public new int WidthRequest
        {
            get => (int)GetValue(LabelImageView.WidthRequestProperty);
            set => SetValue(LabelImageView.WidthRequestProperty, value);
        }

        public static readonly BindableProperty SourceProperty = BindableProperty.Create(nameof(Source), typeof(string), typeof(LabelImageView), String.Empty);
        public string Source
        {
            get => (string)GetValue(LabelImageView.SourceProperty);
            set => SetValue(LabelImageView.SourceProperty, value);
        }

        //public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(LabelImageView), string.Empty);
        //public string Text
        //{
        //    get => (string)GetValue(LabelImageView.TextProperty);
        //    set => SetValue(LabelImageView.TextProperty, value);
        //}
        public static readonly BindableProperty MyTextProperty = BindableProperty.Create(nameof(MyText), typeof(string), typeof(LabelImageView), string.Empty);
        public string MyText
        {
            get => (string)GetValue(LabelImageView.MyTextProperty);
            set => SetValue(LabelImageView.MyTextProperty, value);
        }
        public LabelImageView()
        {
            InitializeComponent();
            BindingContext = this;
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

        }
    }
}