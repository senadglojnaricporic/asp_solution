using Microsoft.EntityFrameworkCore;
using Project.Service.Models;

namespace Project.MVC.Data
{
    public class VehicleDbContext : DbContext
    {
        public DbSet<VehicleMakeDataModel> VehicleMakes { get; set; }
        public DbSet<VehicleModelDataModel> VehicleModels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Test");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
