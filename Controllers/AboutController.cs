using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Core_Fundamentals.Controllers 
{
    [Route("[controller]/[action]")]
    public class AboutController
    {
        public string Phone()
        {
            return "(+389) 071-234-567";      
        }

        public string Address()
        {
            return "Leninova 10a, 1000 Skopje";      
        }
    }    
}