using System.Collections.Generic;

namespace Project.Service.Interfaces
{
    public interface IPaginatedList<TEntity> : IList<TEntity>
    {
        int PageIndex { get; }
        int TotalPages { get; }
        bool HasPreviousPage { get; }
        bool HasNextPage { get; }
        
    }
}