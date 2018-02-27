using System.Collections.Generic;
using System.Linq;
using ASP.NET_Core_Fundamentals.Data;
using ASP.NET_Core_Fundamentals.Models;

namespace ASP.NET_Core_Fundamentals.Services
{
    public class DbRestaurantData : IRestaurantData
    {
        private DataDbContext _context;

        public DbRestaurantData(DataDbContext context)
        {
            _context = context;    
        }
        public Restaurant AddRestaurant(Restaurant newRestaurant)
        {
            _context.Restaurants.Add(newRestaurant);
            _context.SaveChanges();

            return newRestaurant;
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _context.Restaurants.OrderBy(r => r.Id);
        }

        public Restaurant GetRestaurant(int id)
        {
            return _context.Restaurants.FirstOrDefault(r => r.Id == id);
        }
    }
}