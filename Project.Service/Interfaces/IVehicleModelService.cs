using Project.Service.Models;
using System.Threading.Tasks;

namespace Project.Service.Interfaces
{
    public interface IVehicleModelService : IGenericVehicleService<VehicleModelDataModel>, IVehicleService
    {
        Task<IPaginatedList<VehicleModelDataModel>> FilterModelByMake(IPaginatedList<VehicleModelDataModel> source, string searchString);
    }
}