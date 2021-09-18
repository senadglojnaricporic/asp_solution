using System.Collections.Generic;

namespace Project.Service.Interfaces
{
    public interface IVehicleMakeGenericModel<TEntity>
    {
        int Id { get; set; }
        string Name { get; set; }
        string Abrv { get; set; }

        ICollection<TEntity> VehicleModels { get; set; }
    }
}