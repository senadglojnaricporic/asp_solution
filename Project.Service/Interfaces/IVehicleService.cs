using Project.Service.Models;
using System.Threading.Tasks;
using System.Linq;
using Project.Service.Collections;

namespace Project.Service.Interfaces
{
    public interface IVehicleService : IGenericVehicleService<VehicleMake>, IGenericVehicleService<VehicleModel>
    {
        Task Create<T>(T entity) where T : class;
        Task<T> ReadById<T>(int id) where T : class;
        Task Update<T>(T entity) where T : class;
        Task Delete<T>(int id) where T : class;
        Task<PaginatedList<T>> CreatePageAsync<T>(IQueryable<T> source, int pageIndex, int pageSize) where T : class;
        IQueryable<VehicleModel> FilterModelByMake(IQueryable<VehicleModel> source, string searchString);
    }
}
