using System.Threading.Tasks;
using System.Collections.Generic;

namespace Project.Service.Interfaces
{
    public interface IGenericVehicleService<TEntity> where TEntity : class
    {
        Task Create(TEntity entity);
        Task<IList<TEntity>> ReadRange(int skipRows, int numberOfItems);
        Task<TEntity> ReadById(int id);
        Task Update(TEntity entity);
        Task Delete(int id);
    }
}
