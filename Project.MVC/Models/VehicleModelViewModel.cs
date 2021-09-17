using Project.Service.Interfaces;
using Project.Service.Models;

namespace Project.MVC.Models
{
    public class VehicleModelViewModel : IVehicleModel
    {
        public int Id { get; set; }
        public int MakeId { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public VehicleMake VehicleMake { get; set; }
    }
}