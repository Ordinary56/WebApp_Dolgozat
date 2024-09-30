using Microsoft.EntityFrameworkCore;

namespace EpitmenyadoWebApp.Models
{
    public class Building
    {
        public int Id { get; set; }
        public int TaxNumber { get; set; }
        public string StreetName { get; set; }
        public string StreetNum { get; set; }
        public char Line { get; set; }
        public int Area { get; set; } // m^2
    }
    
}
