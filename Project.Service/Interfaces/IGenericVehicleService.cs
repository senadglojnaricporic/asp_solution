using System.Threading.Tasks;
using System.Linq;
using Project.Service.Collections;

namespace Project.Service.Interfaces
{
    public interface IGenericVehicleService<TEntity> where TEntity : class
    {
        Task Create(TEntity entity);
        Task Update(TEntity entity);
        Task<PaginatedList<TEntity>> CreatePageAsync(IQueryable<TEntity> source, int pageIndex, int pageSize);
    }
}
