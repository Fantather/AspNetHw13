using AspNetHw13.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetHw13.Helpers
{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; private set; }
        public int PageSize { get; private set; }
        public int TotalPages { get; private set; }
        public int TotalCount { get; private set; }


        public PaginatedList(IEnumerable<T> items, int count, PaginationParameters parameters)
        {
            PageIndex = parameters.PageIndex;
            PageSize = parameters.PageSize;
            TotalCount = count;
            TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);

            this.AddRange(items);
        }

        private PaginatedList(IEnumerable<T> items, int totalCount, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalCount = totalCount;
            TotalPages = (int)Math.Ceiling(TotalCount/(double)PageSize);

            this.AddRange(items);
        }


        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, PaginationParameters parameters)
        {
            int count = await source.CountAsync();
            List<T> items = await source
                                    .Skip((parameters.PageIndex - 1) * parameters.PageSize)
                                    .Take(parameters.PageSize)
                                    .ToListAsync();

            return new PaginatedList<T>(items, count, parameters);
        }


        public PaginatedList<TResult> Select<TResult>(Func<T, TResult> selector)
        {
            IEnumerable<TResult> mappedItems = ((IEnumerable<T>)this).Select(selector);

            return new PaginatedList<TResult>(mappedItems, TotalCount, PageIndex, PageSize);
        }
    }
}
