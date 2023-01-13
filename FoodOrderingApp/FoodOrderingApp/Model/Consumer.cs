using FoodOrderingApp.OrderModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace FoodOrderingApp.Model
{
    public interface IConsumer
    {
        int ConsumerID { get; set; }
        string ConsumerName { get; set; }
        string ConsumerEmail { get; set; }
        string ConsumerImage { get; set; }
        string ConsumerUsername { get; set; }
        string ConsumerPassword { get; set; }
    }
    public class Consumer : IConsumer
    {
        public int ConsumerID { get; set; }
        public string ConsumerName { get; set; }
        public string ConsumerEmail { get; set; }
        public string ConsumerImage { get; set; }
        public string ConsumerUsername { get; set; }
        public string ConsumerPassword { get; set; }
        
    }
    public class ConsumerProvider
    {
        static public Consumer consumer { get; set; } 
        static public Cart cart;

        static public ObservableCollection<OrderFood> orderFoods = new ObservableCollection<OrderFood>();
        static public ObservableCollection<Foods> foods = new ObservableCollection<Foods>();
        

        static public void AddOrderID(int orderID)
        {
            orderFoods = new ObservableCollection<OrderFood>(from orderFood in orderFoods
                select new OrderFood()
                {
                    FoodID = orderFood.FoodID,
                    FoodQuantity = orderFood.FoodQuantity,
                    FoodPrice = orderFood.FoodPrice,
                    OrderID = orderID
                });
        }
        static public bool AddFood(Foods food)
        {
            try
            {
                if (foods != null)
                {
                    List<Foods> fs = new List<Foods>(from f in foods where food.FoodID == f.FoodID select f);
                    if (fs == null || fs.Any()) return false;
                }
                foods.Add(food);
                orderFoods.Add(new OrderFood()
                {
                    FoodID = food.FoodID,
                    FoodQuantity = 0,
                    FoodPrice = food.FoodPrice
                });
            }
            catch (Exception e) { return false; }
            return true;
        }
        static public bool DeleteFood(Foods food)
        {
            return DeleteFood(food.FoodID);
        }
        static public bool DeleteFood(int foodID)
        {
            try
            {
                Foods food = (from f in foods where f.FoodID == foodID select f).First();
                OrderFood orderFood = (from o in orderFoods where o.FoodID == foodID select o).First();
                foods.Remove(food);
                orderFoods.Remove(orderFood);
            }
            catch { return false; }
            return true;
        }
        static public void ClearCart()
        {
            foods.Clear();
            orderFoods.Clear();
        }
    }
}
