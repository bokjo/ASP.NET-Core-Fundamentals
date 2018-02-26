using System.Collections.Generic;
using ASP.NET_Core_Fundamentals.Models;

namespace ASP.NET_Core_Fundamentals.Services
{
    public interface IRestaurantData
    {
       IEnumerable<Restaurant> GetAll();
        Restaurant GetRestaurant(int id);
    }
}