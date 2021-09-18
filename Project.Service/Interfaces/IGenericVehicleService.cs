using System.Threading.Tasks;

namespace Project.Service.Interfaces
{
    public interface IGenericVehicleService<TEntity> where TEntity : class
    {
        Task<IPaginatedList<TEntity>> Sort(IPaginatedList<TEntity> source, string sortOrder);
    }
}
