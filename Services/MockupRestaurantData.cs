using System.Collections.Generic;
using System.Linq;
using ASP.NET_Core_Fundamentals.Models;

namespace ASP.NET_Core_Fundamentals.Services
{
    public class MockupRestaurantData : IRestaurantData
    {
        public MockupRestaurantData()
        {
            _restaurants = new List<Restaurant>
            {
                new Restaurant { Id = 1, Name = "Restaurant 1" },
                new Restaurant { Id = 2, Name = "Restaurant 2" },
                new Restaurant { Id = 3, Name = "Restaurant 3" },
                new Restaurant { Id = 4, Name = "Restaurant 4" },
                new Restaurant { Id = 5, Name = "Restaurant 5" },
                new Restaurant { Id = 6, Name = "Restaurant 6" }
            };
            
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants.OrderBy(r => r.Id);
        }

        public Restaurant GetRestaurant(int id)
        {
            return _restaurants.FirstOrDefault(r => r.Id == id);
        }

        public Restaurant AddRestaurant(Restaurant newRestaurant)
        {
            newRestaurant.Id = _restaurants.Max(r => r.Id) + 1;
            _restaurants.Add(newRestaurant);

            return newRestaurant;
        }

        public Restaurant UpdateRestaurant(Restaurant updateRestaurant)
        {
            // UPDATE RESTAURANT CODE GOES HERE...
            return updateRestaurant;
        }

        List<Restaurant> _restaurants;

    }
}