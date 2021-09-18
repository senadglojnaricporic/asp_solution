using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Project.Service.Interfaces;

namespace Project.Service.Models
{
    public class VehicleModelDataModel : IVehicleModelGenericModel<VehicleMakeDataModel>
    {
        [Key]
        public int Id { get; set; }
        public int MakeId { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }

        [ForeignKey("MakeId")]
        public VehicleMakeDataModel VehicleMake { get; set; }
    }
}