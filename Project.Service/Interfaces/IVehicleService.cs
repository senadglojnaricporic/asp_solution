using System.Threading.Tasks;

namespace Project.Service.Interfaces
{
    public interface IVehicleService
    {
        Task Create<T>(T entity) where T : class;
        Task<T> ReadById<T>(int id) where T : class;
        Task Update<T>(T entity) where T : class;
        Task Delete<T>(int id) where T : class;
    }
}
