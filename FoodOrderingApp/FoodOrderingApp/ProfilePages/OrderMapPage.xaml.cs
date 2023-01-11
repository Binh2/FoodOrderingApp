using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodOrderingApp.ProfilePages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderMapPage : ContentPage
    {
        int orderID;
        public OrderMapPage(int orderID)
        {
            InitializeComponent();
            this.orderID = orderID;
        }
    }
}