using Project.Service.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Service.Interfaces
{
    public interface IVehicleModelService : IGenericVehicleService<VehicleModelDataModel>, IVehicleService
    {
        IQueryable<VehicleModelDataModel> FilterModelByMake(IQueryable<VehicleModelDataModel> source, string searchString);
    }
}