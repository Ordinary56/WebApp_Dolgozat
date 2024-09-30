using Microsoft.EntityFrameworkCore;

namespace EpitmenyadoWebApp.Models
{
    public class BuildingDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(connectionString: "Data Source=Epitmenyado.db");
            optionsBuilder.EnableSensitiveDataLogging();
        }
        public DbSet<Building> Epitmenyek { get; set; } = default!;
    }
}
