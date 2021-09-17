using System.Collections.Generic;
using Project.Service.Interfaces;
using Project.Service.Models;

namespace Project.MVC.Models
{
    public class VehicleMakeViewModel : IVehicleMake
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public ICollection<VehicleModel> VehicleModels { get; set; }
    }
}