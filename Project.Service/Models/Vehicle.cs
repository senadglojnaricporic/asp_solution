using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Project.Service.Interfaces;

namespace Project.Service.Models
{
    public class VehicleMake : IVehicleMake
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }

        public ICollection<VehicleModel> VehicleModels { get; set; }
    }

    public class VehicleModel : IVehicleModel
    {
        [Key]
        public int Id { get; set; }
        public int MakeId { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }

        [ForeignKey("MakeId")]
        public VehicleMake VehicleMake { get; set; }
    }
}