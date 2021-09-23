using System.Collections.Generic;

namespace Project.Service.Interfaces
{
    public interface IPaginatedList<TEntity> : IList<TEntity>
    {
        List<TEntity> Items { get; }
        int ItemsCount { get; }
        int PageIndex { get; }
        int PageSize { get; }
        int TotalPages { get; }
        bool HasPreviousPage { get; }
        bool HasNextPage { get; }
        
    }
}