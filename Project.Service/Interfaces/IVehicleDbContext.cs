using Microsoft.EntityFrameworkCore;
using Project.Service.Models;

namespace Project.Service.Interfaces
{
    public interface IVehicleDbContext
    {
        DbSet<VehicleMake> VehicleMakes { get; set; }
        DbSet<VehicleModel> VehicleModels { get; set; }
    }
}