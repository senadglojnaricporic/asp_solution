using System.Collections.Generic;
using Project.MVC.Interfaces;

namespace Project.MVC.Models
{
    public class VehicleMakeViewModel : IVehicleMakeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public ICollection<VehicleModelViewModel> VehicleModels { get; set; }
    }
}