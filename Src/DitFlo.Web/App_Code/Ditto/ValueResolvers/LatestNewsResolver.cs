using System;
using System.Linq;
using DitFlo.Models;
using Our.Umbraco.Ditto;
using Umbraco.Web;

namespace DitFlo.Ditto.ValueResolvers
{
    public class LatestNewsResolver : DittoValueResolver
    {
        public override object ResolveValue()
        {
            if (Content == null) return Enumerable.Empty<NewsItemLink>();

            var homePage = Content.AncestorsOrSelf(1).First();
            var newsArchive = homePage.Children.FirstOrDefault(x => x.DocumentTypeAlias == "umbNewsOverview");
            if (newsArchive == null) return Enumerable.Empty<NewsItemLink>();

            var newsItems = newsArchive.Children.Where(x => x.DocumentTypeAlias == "umbNewsItem")
                .OrderByDescending(x => x.Get<DateTime>("publishDate"))
                .ThenByDescending(x => x.CreateDate)
                .Take(5);

            return newsItems.As<NewsItemLink>();
        }
    }
}
