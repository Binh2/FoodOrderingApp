using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBAPI.Models
{
	public interface IProducer
    {
		int ProducerID { get; set; }
		string ProducerName { get; set; }
		string ProducerEmail { get; set; }
		string ProducerImage { get; set; }
		string ProducerUsername { get; set; }
		string ProducerPassword { get; set; }
		int RestaurantID { get; set; }
	}
    public class Producer:IProducer, IRestaurant
    {
		public int ProducerID { get; set; }
		public string ProducerName { get; set; }
		public string ProducerEmail { get; set; }
		public string ProducerImage { get; set; }
		public string ProducerUsername { get; set; }
		public string ProducerPassword { get; set; }
		
		public int RestaurantID { get; set; }
		public string RestaurantName { get; set; }
		public string RestaurantImage { get; set; }
		public string RestaurantLocation { get; set; }
	}
}