using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Project.Service.Interfaces
{
    public interface IVehicleService
    {
        Task Create<T>(T entity) where T : class;
        Task<T> ReadById<T>(int id) where T : class;
        Task Update<T>(T entity) where T : class;
        Task Delete<T>(int id) where T : class;
        IQueryable<T> GetData<T>() where T : class;
        Task<IPaginatedList<T>> CreatePageAsync<T>(IQueryable<T> source, int pageIndex, int pageSize) where T : class;
    }
}
