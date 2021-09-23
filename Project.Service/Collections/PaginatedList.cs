using System;
using System.Collections.Generic;
using Project.Service.Interfaces;

namespace Project.Service.Collections
{
    public class PaginatedList<TEntity> : List<TEntity>, IPaginatedList<TEntity>
    {
        public List<TEntity> Items { get; private set; }
        public int ItemsCount { get; private set; }
        public int PageIndex { get; private set; }
        public int PageSize { get; private set; }
        public int TotalPages { get; private set; }

        public PaginatedList(List<TEntity> items, int count, int pageIndex, int pageSize)
        {
            Items = items;
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            this.AddRange(items);
        }

        public bool HasPreviousPage
        {
            get
            {
                return (PageIndex > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (PageIndex < TotalPages);
            }
        }

    }
}