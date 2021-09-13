using System.Linq;

namespace Project.Service.Interfaces
{
    public interface IGenericVehicleService<TEntity> where TEntity : class
    {
        IQueryable<TEntity> Sort(IQueryable<TEntity> source, string sortOrder);
    }
}
