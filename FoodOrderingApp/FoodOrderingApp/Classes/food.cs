using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace FoodOrderingApp.Classes
{
    class food
    {
        public string name;
        public string kind;
        public string image;
        public double starScore; // average of stars score
        public int stars; // how many people have starred the food
        public double distance; // in kilometer
        public bool isPromo;

        static public ObservableCollection<food> getData() {
            return new ObservableCollection<food>() {
                new food() { name = "Yamada's Onigiri", image = "https://eatsjapan.com/wp-content/uploads/2020/12/thumnail-1.jpg.webp", 
                    kind = "Onigiri", starScore = 4.5, stars = 1030, distance = 0.2, isPromo = true },
                new food() { name = "Yamada's Onigiri", image = "https://eatsjapan.com/wp-content/uploads/2020/12/thumnail-1.jpg.webp", 
                    kind = "Onigiri", starScore = 4.5, stars = 1030, distance = 0.2, isPromo = true },
                new food() { name = "Yamada's Onigiri", image = "https://eatsjapan.com/wp-content/uploads/2020/12/thumnail-1.jpg.webp", 
                    kind = "Onigiri", starScore = 4.5, stars = 1030, distance = 0.2, isPromo = true },
                new food() { name = "Yamada's Onigiri", image = "https://eatsjapan.com/wp-content/uploads/2020/12/thumnail-1.jpg.webp", 
                    kind = "Onigiri", starScore = 4.5, stars = 1030, distance = 0.2, isPromo = true },
            };
        }
    }
}
