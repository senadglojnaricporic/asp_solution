using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public static async Task<IPaginatedList<TEntity>> CreatePageAsync(IQueryable<TEntity> source, int pageIndex, int pageSize)
        {
            var _source = source;
            var count = await _source.CountAsync();
            var items = await _source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginatedList<TEntity>(items, count, pageIndex, pageSize);
        }

    }
}