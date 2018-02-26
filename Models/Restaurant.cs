namespace ASP.NET_Core_Fundamentals.Models 
{
    public class Restaurant 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CuisineType Cuisine { get; set; }
    }    
}