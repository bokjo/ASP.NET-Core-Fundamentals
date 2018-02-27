using ASP.NET_Core_Fundamentals.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Core_Fundamentals.Data
{
    public class DataDbContext : DbContext
    {
        public DataDbContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}