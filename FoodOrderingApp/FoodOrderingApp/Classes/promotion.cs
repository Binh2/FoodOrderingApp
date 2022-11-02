using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Numerics;
using System.Text;

namespace FoodOrderingApp.Classes
{
    public class promotion : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        private ObservableCollection<sale> Sales;

        public ObservableCollection<sale> sales
        {
            get { return Sales; }
            set { Sales = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("sales"));
            }
        }

        public promotion()
        {
            sales = new ObservableCollection<sale>();
            addData();
        }

        private void addData()
        {
            sales.Add(new sale
            {

                id = 0,
                imgSource = "https://popeyes.vn/media/images/Bannerprom1t1web.jpg"
            });
            sales.Add(new sale
            {

                id = 0,
                imgSource = "https://popeyes.vn/media/images/t4m1t1web.jpg"
            });
            sales.Add(new sale
            {

                id = 0,
                imgSource = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSJrdl9MprbscWiQBBIWw6kqFe7ornBXhCBxw&usqp=CAU"
            });
        }

    }
}