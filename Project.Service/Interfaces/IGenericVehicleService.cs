using System.Threading.Tasks;

namespace Project.Service.Interfaces
{
    public interface IGenericVehicleService<TEntity> where TEntity : class
    {
        Task<IPaginatedList<TEntity>> GetPageAsync(string sortOrder,string searchString, int pageIndex = 1);
    }

}
