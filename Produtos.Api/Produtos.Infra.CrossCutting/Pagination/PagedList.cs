using System;
using System.Collections.Generic;

namespace Produtos.Infra.CrossCutting.Pagination
{
    public class PagedList<T> where T : class
    {
        public PagedList(IEnumerable<T> source, int pageNumber, int pageSize, int totalItems)
        {
            TotalItems = totalItems;
            PageNumber = pageNumber;
            PageSize = pageSize;
            Items = source;
        }

        public int TotalItems { get; }
        public int PageNumber { get; }
        public int PageSize { get; }
        public IEnumerable<T> Items { get; }
        public int TotalPages => (int)Math.Ceiling(TotalItems / (double)PageSize);
        public bool HasPreviousPage => PageNumber > 1;
        public bool HasNextPage => PageNumber < TotalPages;
        public int NextPageNumber => HasNextPage ? PageNumber + 1 : TotalPages;
        public int PreviousPageNumber => HasPreviousPage ? PageNumber - 1 : 1;

        public PagingHeader GetHeader()
        {
            return new PagingHeader(TotalItems, PageNumber, PageSize, TotalPages);
        }
    }
}
