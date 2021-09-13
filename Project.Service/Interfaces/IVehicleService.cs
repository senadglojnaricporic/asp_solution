using Project.Service.Models;
using System.Threading.Tasks;
using System.Linq;

namespace Project.Service.Interfaces
{
    public interface IVehicleService : IGenericVehicleService<VehicleMake>, IGenericVehicleService<VehicleModel>
    {
        Task Delete<T>(int id) where T : class;
        Task<T> ReadById<T>(int id) where T : class;
        IQueryable<VehicleModel> FilterModelByMake(IQueryable<VehicleModel> source, string searchString);
    }
}