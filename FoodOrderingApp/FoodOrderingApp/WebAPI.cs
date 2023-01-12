using FoodOrderingApp.OrderModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingApp.Model
{
    class WebAPI
    {
        static public async Task<List<Foods>> SelectAllFoods()
        {
            HttpClient http = new HttpClient();
            var result = await http.GetStringAsync(ProcURL.SELECT_ALL_FOODS);
            var consumers = JsonConvert.DeserializeObject<List<Foods>>(result);
            return consumers;
        }

        static public async Task<List<Consumer>> SelectAllConsumers()
        {
            HttpClient http = new HttpClient();
            var result = await http.GetStringAsync(ProcURL.SELECT_ALL_CONSUMERS);
            var consumers = JsonConvert.DeserializeObject<List<Consumer>>(result);
            return consumers;
        }
        static public async Task<Consumer> SelectConsumerByID(int ConsumerID)
        {
            HttpClient http = new HttpClient();
            var result = await http.GetStringAsync(ProcURL.SELECT_CONSUMERS_BY_ID + "?ConsumerID=" + ConsumerID);
            var consumers = JsonConvert.DeserializeObject<List<Consumer>>(result);
            if (consumers.Count > 0)
                return consumers[0];
            return null;
        }
        static public async Task<Consumer> SelectConsumerByUsername(string ConsumerUsername)
        {
            HttpClient http = new HttpClient();
            var result = await http.GetStringAsync(ProcURL.SELECT_CONSUMERS_BY_USERNAME + "?ConsumerUsername=" + ConsumerUsername);
            var consumers = JsonConvert.DeserializeObject<List<Consumer>>(result);
            if (consumers.Count > 0) 
                return consumers[0];
            return null;
        }
        static public async Task<Consumer> SelectConsumerByEmail(string ConsumerEmail)
        {
            HttpClient http = new HttpClient();
            var result = await http.GetStringAsync(ProcURL.SELECT_CONSUMERS_BY_EMAIL + "?ConsumerEmail=" + ConsumerEmail);
            var consumers = JsonConvert.DeserializeObject<List<Consumer>>(result);
            if (consumers.Count > 0) 
                return consumers[0];
            return null;
        }
        static public async Task<int> InsertConsumer(Consumer consumer)
        {
            HttpClient http = new HttpClient();
            string json = JsonConvert.SerializeObject(consumer);
            StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var reponse = await http.PostAsync(ProcURL.INSERT_CONSUMER, stringContent);
            var resultString = await reponse.Content.ReadAsStringAsync();
            return int.Parse(resultString.ToString());
        }
        static public async Task<int> UpdateConsumer(Consumer consumer)
        {
            HttpClient http = new HttpClient();
            string json = JsonConvert.SerializeObject(consumer);
            StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var reponse = await http.PostAsync(ProcURL.UPDATE_CONSUMER, stringContent);
            var resultString = await reponse.Content.ReadAsStringAsync();
            return int.Parse(resultString.ToString());
        }
        static public async Task<int> DeleteConsumer(int ConsumerID)
        {
            HttpClient http = new HttpClient();
            var reponse = await http.PostAsync(ProcURL.UPDATE_CONSUMER + "?ConsumerID=" + ConsumerID.ToString(), new StringContent(""));
            var resultString = await reponse.Content.ReadAsStringAsync();
            return int.Parse(resultString.ToString());
        }

        static public async Task<List<Producer>> SelectAllProducers()
        {
            HttpClient http = new HttpClient();
            var result = await http.GetStringAsync(ProcURL.SELECT_ALL_PRODUCERS);
            var producers = JsonConvert.DeserializeObject<List<Producer>>(result);
            return producers;
        }
        static public async Task<Producer> SelectProducerByID(int ProducerID)
        {
            HttpClient http = new HttpClient();
            var result = await http.GetStringAsync(ProcURL.SELECT_PRODUCERS_BY_ID + "?ProducerID=" + ProducerID);
            var producers = JsonConvert.DeserializeObject<List<Producer>>(result);
            if (producers.Count > 0)
                return producers[0];
            return null;
        }
        static public async Task<Producer> SelectProducerByUsername(string ProducerUsername)
        {
            HttpClient http = new HttpClient();
            var result = await http.GetStringAsync(ProcURL.SELECT_PRODUCERS_BY_USERNAME + "?ProducerUsername=" + ProducerUsername);
            var producers = JsonConvert.DeserializeObject<List<Producer>>(result);
            if (producers.Count > 0)
                return producers[0];
            return null;
        }
        static public async Task<Producer> SelectProducerByEmail(string ProducerEmail)
        {
            HttpClient http = new HttpClient();
            var result = await http.GetStringAsync(ProcURL.SELECT_PRODUCERS_BY_EMAIL + "?ProducerEmail=" + ProducerEmail);
            var producers = JsonConvert.DeserializeObject<List<Producer>>(result);
            if (producers.Count > 0)
                return producers[0];
            return null;
        }
        static public async Task<int> InsertProducer(Producer producer)
        {
            HttpClient http = new HttpClient();
            string json = JsonConvert.SerializeObject(producer);
            StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var reponse = await http.PostAsync(ProcURL.INSERT_PRODUCER, stringContent);
            var resultString = await reponse.Content.ReadAsStringAsync();
            return int.Parse(resultString.ToString());
        }
        static public async Task<int> UpdateProducer(Producer producer)
        {
            HttpClient http = new HttpClient();
            string json = JsonConvert.SerializeObject(producer);
            StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var reponse = await http.PostAsync(ProcURL.UPDATE_PRODUCER, stringContent);
            var resultString = await reponse.Content.ReadAsStringAsync();
            return int.Parse(resultString.ToString());
        }
        static public async Task<int> DeleteProducer(int ProducerID)
        {
            HttpClient http = new HttpClient();
            var reponse = await http.PostAsync(ProcURL.UPDATE_PRODUCER + "?ProducerID=" + ProducerID.ToString(), new StringContent(""));
            var resultString = await reponse.Content.ReadAsStringAsync();
            return int.Parse(resultString.ToString());
        }

        static public async Task<List<Restaurant>> SelectAllRestaurants()
        {
            HttpClient http = new HttpClient();
            var result = await http.GetStringAsync(ProcURL.SELECT_ALL_RESTAURANTS);
            var restaurants = JsonConvert.DeserializeObject<List<Restaurant>>(result);
            return restaurants;
        }
        static public async Task<Restaurant> SelectRestaurantByID(int RestaurantID)
        {
            HttpClient http = new HttpClient();
            var result = await http.GetStringAsync(ProcURL.SELECT_RESTAURANTS_BY_ID + "?RestaurantID=" + RestaurantID);
            var restaurants = JsonConvert.DeserializeObject<List<Restaurant>>(result);
            if (restaurants.Count > 0)
                return restaurants[0];
            return null;
        }
        static public async Task<Restaurant> SelectRestaurantByUsername(string RestaurantUsername)
        {
            HttpClient http = new HttpClient();
            var result = await http.GetStringAsync(ProcURL.SELECT_RESTAURANTS_BY_USERNAME + "?RestaurantUsername=" + RestaurantUsername);
            var restaurants = JsonConvert.DeserializeObject<List<Restaurant>>(result);
            if (restaurants.Count > 0)
                return restaurants[0];
            return null;
        }
        static public async Task<Restaurant> SelectRestaurantByEmail(string RestaurantEmail)
        {
            HttpClient http = new HttpClient();
            var result = await http.GetStringAsync(ProcURL.SELECT_RESTAURANTS_BY_EMAIL + "?RestaurantEmail=" + RestaurantEmail);
            var restaurants = JsonConvert.DeserializeObject<List<Restaurant>>(result);
            if (restaurants.Count > 0)
                return restaurants[0];
            return null;
        }
        static public async Task<int> InsertRestaurant(Restaurant restaurant)
        {
            HttpClient http = new HttpClient();
            string json = JsonConvert.SerializeObject(restaurant);
            StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var reponse = await http.PostAsync(ProcURL.INSERT_RESTAURANT, stringContent);
            var resultString = await reponse.Content.ReadAsStringAsync();
            return int.Parse(resultString.ToString());
        }
        static public async Task<int> UpdateRestaurant(Restaurant restaurant)
        {
            HttpClient http = new HttpClient();
            string json = JsonConvert.SerializeObject(restaurant);
            StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var reponse = await http.PostAsync(ProcURL.UPDATE_RESTAURANT, stringContent);
            var resultString = await reponse.Content.ReadAsStringAsync();
            return int.Parse(resultString.ToString());
        }
        static public async Task<int> DeleteRestaurant(int RestaurantID)
        {
            HttpClient http = new HttpClient();
            var reponse = await http.PostAsync(ProcURL.UPDATE_RESTAURANT + "?RestaurantID=" + RestaurantID.ToString(), new StringContent(""));
            var resultString = await reponse.Content.ReadAsStringAsync();
            return int.Parse(resultString.ToString());
        }

        static public async Task<List<Card>> SelectAllCards()
        {
            HttpClient http = new HttpClient();
            var result = await http.GetStringAsync(ProcURL.SELECT_ALL_CARDS);
            var cards = JsonConvert.DeserializeObject<List<Card>>(result);
            return cards;
        }
        static public async Task<List<Card>> SelectCardsByConsumerID(int ConsumerID)
        {
            HttpClient http = new HttpClient();
            var result = await http.GetStringAsync(ProcURL.SELECT_CARDS_BY_CONSUMER_ID + "?ConsumerID=" + ConsumerID);
            var cards = JsonConvert.DeserializeObject<List<Card>>(result);
            return cards;
        }
        static public async Task<int> InsertCard(Card card)
        {
            HttpClient http = new HttpClient();
            string json = JsonConvert.SerializeObject(card);
            StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var reponse = await http.PostAsync(ProcURL.INSERT_CARD, stringContent);
            var resultString = await reponse.Content.ReadAsStringAsync();
            return int.Parse(resultString.ToString());
        }
        static public async Task<int> UpdateCard(Card card)
        {
            HttpClient http = new HttpClient();
            string json = JsonConvert.SerializeObject(card);
            StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var reponse = await http.PostAsync(ProcURL.UPDATE_CARD, stringContent);
            var resultString = await reponse.Content.ReadAsStringAsync();
            return int.Parse(resultString.ToString());
        }
        static public async Task<int> DeleteCard(int CardID)
        {
            HttpClient http = new HttpClient();
            var reponse = await http.PostAsync(ProcURL.DELETE_CARD + "?CardID=" + CardID, new StringContent(""));
            var resultString = await reponse.Content.ReadAsStringAsync();
            return int.Parse(resultString.ToString());
        }

        static public async Task<List<Order>> SelectAllOrders()
        {
            HttpClient http = new HttpClient();
            var result = await http.GetStringAsync(ProcURL.SELECT_ALL_ORDERS);
            var orders = JsonConvert.DeserializeObject<List<Order>>(result);
            return orders;
        }
        static public async Task<List<Order>> SelectOrdersByConsumerID(int ConsumerID)
        {
            HttpClient http = new HttpClient();
            var result = await http.GetStringAsync(ProcURL.SELECT_ORDERS_BY_CONSUMER_ID + "?ConsumerID=" + ConsumerID);
            var orders = JsonConvert.DeserializeObject<List<Order>>(result);
            return orders;
        }
        static public async Task<int> InsertOrder(Order order)
        {
            HttpClient http = new HttpClient();
            string json = JsonConvert.SerializeObject(order);
            StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var reponse = await http.PostAsync(ProcURL.INSERT_ORDER, stringContent);
            var resultString = await reponse.Content.ReadAsStringAsync();
            return int.Parse(resultString.ToString());
        }
        static public async Task<int> UpdateOrder(Order order)
        {
            HttpClient http = new HttpClient();
            string json = JsonConvert.SerializeObject(order);
            StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var reponse = await http.PostAsync(ProcURL.UPDATE_ORDER, stringContent);
            var resultString = await reponse.Content.ReadAsStringAsync();
            return int.Parse(resultString.ToString());
        }
        static public async Task<int> DeleteOrder(int OrderID)
        {
            HttpClient http = new HttpClient();
            var reponse = await http.PostAsync(ProcURL.DELETE_ORDER + "?OrderID=" + OrderID, new StringContent(""));
            var resultString = await reponse.Content.ReadAsStringAsync();
            return int.Parse(resultString.ToString());
        }

        static public async Task<List<OrderState>> SelectAllOrderStates()
        {
            HttpClient http = new HttpClient();
            var result = await http.GetStringAsync(ProcURL.SELECT_ALL_ORDER_STATES);
            var orderStates = JsonConvert.DeserializeObject<List<OrderState>>(result);
            return orderStates;
        }
        static public async Task<List<OrderState>> SelectOrderStatesByOrderID(int OrderID)
        {
            HttpClient http = new HttpClient();
            var result = await http.GetStringAsync(ProcURL.SELECT_ORDER_STATES_BY_ORDER_ID + "?OrderID=" + OrderID);
            var orderStates = JsonConvert.DeserializeObject<List<OrderState>>(result);
            return orderStates;
        }
        static public async Task<int> InsertOrderState(OrderState orderState)
        {
            HttpClient http = new HttpClient();
            string json = JsonConvert.SerializeObject(orderState);
            StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var reponse = await http.PostAsync(ProcURL.INSERT_ORDER_STATE, stringContent);
            var resultString = await reponse.Content.ReadAsStringAsync();
            return int.Parse(resultString.ToString());
        }
        static public async Task<int> UpdateOrderState(OrderState orderState)
        {
            HttpClient http = new HttpClient();
            string json = JsonConvert.SerializeObject(orderState);
            StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var reponse = await http.PostAsync(ProcURL.UPDATE_ORDER_STATE, stringContent);
            var resultString = await reponse.Content.ReadAsStringAsync();
            return int.Parse(resultString.ToString());
        }
        static public async Task<int> DeleteOrderState(int OrderStateID)
        {
            HttpClient http = new HttpClient();
            var reponse = await http.PostAsync(ProcURL.DELETE_ORDER_STATE + "?OrderStateID=" + OrderStateID, new StringContent(""));
            var resultString = await reponse.Content.ReadAsStringAsync();
            return int.Parse(resultString.ToString());
        }

        static public async Task<List<OrderFood>> SelectAllOrderFoods()
        {
            HttpClient http = new HttpClient();
            var result = await http.GetStringAsync(ProcURL.SELECT_ALL_ORDER_FOODS);
            var orderFoods = JsonConvert.DeserializeObject<List<OrderFood>>(result);
            return orderFoods;
        }
        static public async Task<List<OrderFood>> SelectOrderFoodsByOrderID(int OrderID)
        {
            HttpClient http = new HttpClient();
            var result = await http.GetStringAsync(ProcURL.SELECT_ORDER_FOODS_BY_ORDER_ID + "?OrderFoodID=" + OrderID);
            var orderFoods = JsonConvert.DeserializeObject<List<OrderFood>>(result);
            return orderFoods;
        }
        static public async Task<int> InsertOrderFood(OrderFood orderFood)
        {
            HttpClient http = new HttpClient();
            string json = JsonConvert.SerializeObject(orderFood);
            StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var reponse = await http.PostAsync(ProcURL.INSERT_ORDER_FOOD, stringContent);
            var resultString = await reponse.Content.ReadAsStringAsync();
            return int.Parse(resultString.ToString());
        }
        static public async Task<int> UpdateOrderFood(OrderFood orderFood)
        {
            HttpClient http = new HttpClient();
            string json = JsonConvert.SerializeObject(orderFood);
            StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var reponse = await http.PostAsync(ProcURL.UPDATE_ORDER_FOOD, stringContent);
            var resultString = await reponse.Content.ReadAsStringAsync();
            return int.Parse(resultString.ToString());
        }
        static public async Task<int> DeleteOrderFood(int OrderFoodID)
        {
            HttpClient http = new HttpClient();
            var reponse = await http.PostAsync(ProcURL.UPDATE_ORDER_FOOD + "?OrderFoodID=" + OrderFoodID.ToString(), new StringContent(""));
            var resultString = await reponse.Content.ReadAsStringAsync();
            return int.Parse(resultString.ToString());
        }

        static public async Task<List<Comment>> SelectAllComments()
        {
            HttpClient http = new HttpClient();
            var result = await http.GetStringAsync(ProcURL.SELECT_ALL_COMMENTS);
            var comments = JsonConvert.DeserializeObject<List<Comment>>(result);
            return comments;
        }
        static public async Task<List<Comment>> SelectCommentsByFoodID(int FoodID)
        {
            HttpClient http = new HttpClient();
            var result = await http.GetStringAsync($"{ProcURL.SELECT_COMMENTS_BY_FOOD_ID}?{nameof(FoodID)}={FoodID}");
            var comments = JsonConvert.DeserializeObject<List<Comment>>(result);
            return comments;
        }
        static public async Task<int> InsertComment(Comment comment)
        {
            HttpClient http = new HttpClient();
            string json = JsonConvert.SerializeObject(comment);
            StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var reponse = await http.PostAsync(ProcURL.INSERT_COMMENT, stringContent);
            var resultString = await reponse.Content.ReadAsStringAsync();
            return int.Parse(resultString.ToString());
        }
        static public async Task<int> UpdateComment(Comment comment)
        {
            HttpClient http = new HttpClient();
            string json = JsonConvert.SerializeObject(comment);
            StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var reponse = await http.PostAsync(ProcURL.UPDATE_COMMENT, stringContent);
            var resultString = await reponse.Content.ReadAsStringAsync();
            return int.Parse(resultString.ToString());
        }
        static public async Task<int> DeleteComment(int CommentID)
        {
            HttpClient http = new HttpClient();
            var reponse = await http.PostAsync(ProcURL.DELETE_COMMENT + "?CommentID=" + CommentID, new StringContent(""));
            var resultString = await reponse.Content.ReadAsStringAsync();
            return int.Parse(resultString.ToString());
        }
    }
    public static class ProcURL
    {
        public static readonly string SELECT_ALL_FOODS = "http://" + Constants.IP + "/webapi/api/FoodController/GetAllFoods";

        public static readonly string SELECT_ALL_CARDS = "http://" + Constants.IP + "/webapi/api/CardController/SelectAllCards";
        public static readonly string SELECT_CARDS_BY_CONSUMER_ID = "http://" + Constants.IP + "/webapi/api/CardController/SelectCardsByConsumerID";
        public static readonly string INSERT_CARD = "http://" + Constants.IP + "/webapi/api/CardController/InsertCard";
        public static readonly string UPDATE_CARD = "http://" + Constants.IP + "/webapi/api/CardController/UpdateCard";
        public static readonly string DELETE_CARD = "http://" + Constants.IP + "/webapi/api/CardController/DeleteCard";

        public static readonly string SELECT_ALL_CONSUMERS = "http://" + Constants.IP + "/webapi/api/ConsumerController/SelectAllConsumers";
        public static readonly string SELECT_CONSUMERS_BY_ID = "http://" + Constants.IP + "/webapi/api/ConsumerController/SelectConsumersByID";
        public static readonly string SELECT_CONSUMERS_BY_USERNAME = "http://" + Constants.IP + "/webapi/api/ConsumerController/SelectConsumersByUsername";
        public static readonly string SELECT_CONSUMERS_BY_EMAIL = "http://" + Constants.IP + "/webapi/api/ConsumerController/SelectConsumersByEmail";
        public static readonly string INSERT_CONSUMER = "http://" + Constants.IP + "/webapi/api/ConsumerController/InsertConsumer";
        public static readonly string UPDATE_CONSUMER = "http://" + Constants.IP + "/webapi/api/ConsumerController/UpdateConsumer";
        public static readonly string DELETE_CONSUMER = "http://" + Constants.IP + "/webapi/api/ConsumerController/DeleteConsumer";

        public static readonly string SELECT_ALL_PRODUCERS = "http://" + Constants.IP + "/webapi/api/ProducerController/SelectAllProducers";
        public static readonly string SELECT_PRODUCERS_BY_ID = "http://" + Constants.IP + "/webapi/api/ProducerController/SelectProducersByID";
        public static readonly string SELECT_PRODUCERS_BY_USERNAME = "http://" + Constants.IP + "/webapi/api/ProducerController/SelectProducersByUsername";
        public static readonly string SELECT_PRODUCERS_BY_EMAIL = "http://" + Constants.IP + "/webapi/api/ProducerController/SelectProducersByEmail";
        public static readonly string INSERT_PRODUCER = "http://" + Constants.IP + "/webapi/api/ProducerController/InsertProducer";
        public static readonly string UPDATE_PRODUCER = "http://" + Constants.IP + "/webapi/api/ProducerController/UpdateProducer";
        public static readonly string DELETE_PRODUCER = "http://" + Constants.IP + "/webapi/api/ProducerController/DeleteProducer";

        public static readonly string SELECT_ALL_RESTAURANTS = "http://" + Constants.IP + "/webapi/api/RestaurantController/SelectAllRestaurants";
        public static readonly string SELECT_RESTAURANTS_BY_ID = "http://" + Constants.IP + "/webapi/api/RestaurantController/SelectRestaurantsByID";
        public static readonly string SELECT_RESTAURANTS_BY_USERNAME = "http://" + Constants.IP + "/webapi/api/RestaurantController/SelectRestaurantsByUsername";
        public static readonly string SELECT_RESTAURANTS_BY_EMAIL = "http://" + Constants.IP + "/webapi/api/RestaurantController/SelectRestaurantsByEmail";
        public static readonly string INSERT_RESTAURANT = "http://" + Constants.IP + "/webapi/api/RestaurantController/InsertRestaurant";
        public static readonly string UPDATE_RESTAURANT = "http://" + Constants.IP + "/webapi/api/RestaurantController/UpdateRestaurant";
        public static readonly string DELETE_RESTAURANT = "http://" + Constants.IP + "/webapi/api/RestaurantController/DeleteRestaurant";

        public static readonly string SELECT_ALL_ORDERS = "http://" + Constants.IP + "/webapi/api/OrderController/SelectAllOrders";
        public static readonly string SELECT_ORDERS_BY_CONSUMER_ID = "http://" + Constants.IP + "/webapi/api/OrderController/SelectOrdersByConsumerID";
        public static readonly string INSERT_ORDER = "http://" + Constants.IP + "/webapi/api/OrderController/InsertOrder";
        public static readonly string UPDATE_ORDER = "http://" + Constants.IP + "/webapi/api/OrderController/UpdateOrder";
        public static readonly string DELETE_ORDER = "http://" + Constants.IP + "/webapi/api/OrderController/DeleteOrder";

        public static readonly string SELECT_ALL_ORDER_STATES = "http://" + Constants.IP + "/webapi/api/OrderStateController/SelectAllOrderStates";
        public static readonly string SELECT_ORDER_STATES_BY_ORDER_ID = "http://" + Constants.IP + "/webapi/api/OrderStateController/SelectOrderStatesByOrderID";
        public static readonly string INSERT_ORDER_STATE = "http://" + Constants.IP + "/webapi/api/OrderStateController/InsertOrderState";
        public static readonly string UPDATE_ORDER_STATE = "http://" + Constants.IP + "/webapi/api/OrderStateController/UpdateOrderState";
        public static readonly string DELETE_ORDER_STATE = "http://" + Constants.IP + "/webapi/api/OrderStateController/DeleteOrderState";

        public static readonly string SELECT_ALL_ORDER_FOODS = "http://" + Constants.IP + "/webapi/api/OrderFoodController/SelectAllOrderFoods";
        public static readonly string SELECT_ORDER_FOODS_BY_ORDER_ID = "http://" + Constants.IP + "/webapi/api/OrderFoodController/SelectOrderFoodsByOrderID";
        public static readonly string INSERT_ORDER_FOOD = "http://" + Constants.IP + "/webapi/api/OrderFoodController/InsertOrderFood";
        public static readonly string UPDATE_ORDER_FOOD = "http://" + Constants.IP + "/webapi/api/OrderFoodController/UpdateOrderFood";
        public static readonly string DELETE_ORDER_FOOD = "http://" + Constants.IP + "/webapi/api/OrderFoodController/DeleteOrderFood";

        public static readonly string SELECT_ALL_COMMENTS = "http://" + Constants.IP + "/webapi/api/CommentController/SelectAllComments";
        public static readonly string SELECT_COMMENTS_BY_FOOD_ID = "http://" + Constants.IP + "/webapi/api/CommentController/SelectCommentsByFoodID";
        public static readonly string INSERT_COMMENT = "http://" + Constants.IP + "/webapi/api/CommentController/InsertComment";
        public static readonly string UPDATE_COMMENT = "http://" + Constants.IP + "/webapi/api/CommentController/UpdateComment";
        public static readonly string DELETE_COMMENT = "http://" + Constants.IP + "/webapi/api/CommentController/DeleteComment";
    }
}
