using Our.Umbraco.DitFlo.Ditto.ValueResolvers.Contexts;
using Our.Umbraco.DitFlo.Models;
using Our.Umbraco.Ditto;
using System;
using System.Linq;

namespace Our.Umbraco.DitFlo.Ditto.ValueResolvers
{
    public class NewsResolver : BaseNewsResolver<NewsResolverContext>
    {
        public override object ResolveValue()
        {
            var currentPage = Context.CurrentPage;
            var pageSize = 2;

            var items = GetNews().ToList();
            var totalItems = items.Count;
            var totalPages = (long)Math.Ceiling(totalItems/(decimal)pageSize);

            currentPage = Math.Max(1, Math.Min(currentPage, totalPages));

            var pagedItems = items.Skip((int)(currentPage-1)*pageSize).Take(pageSize)
                .As<NewsPreviewLink>();

            return new PagedCollection<NewsPreviewLink>
            {
                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalItems = totalItems,
                TotalPages = totalPages,
                Items = pagedItems
            };
        }
    }
}
