using Microsoft.EntityFrameworkCore;
using Project.Service.Models;
using Project.Service.Interfaces;

namespace Project.Service.Data
{
    public class VehicleDbContext : DbContext, IVehicleDbContext
    {
        public VehicleDbContext(DbContextOptions<VehicleDbContext> options)
            : base(options)
        {
        }

        public DbSet<VehicleMake> VehicleMakes { get; set; }
        public DbSet<VehicleModel> VehicleModels { get; set; }
    }
}
