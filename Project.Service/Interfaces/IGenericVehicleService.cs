using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Project.Service.Interfaces
{
    public interface IGenericVehicleService<TEntity> where TEntity : class
    {
        IQueryable<TEntity> Sort(IQueryable<TEntity> source, string sortOrder);
    }
}
