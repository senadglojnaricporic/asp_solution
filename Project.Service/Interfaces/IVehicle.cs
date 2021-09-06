using System.Collections.Generic;
using Project.Service.Models;

namespace Project.Service.Interfaces
{
    public interface IVehicleMake
    {
        int Id { get; set; }
        string Name { get; set; }
        string Abrv { get; set; }

        ICollection<VehicleModel> VehicleModels { get; set; }
    }

    public interface IVehicleModel
    {
        int Id { get; set; }
        int MakeId { get; set; }
        string Name { get; set; }
        string Abrv { get; set; }

        VehicleMake VehicleMake { get; set; }
    }
}