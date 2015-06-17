using System;
using System.Collections.Generic;
using System.Linq;
using Our.Umbraco.Ditto;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace DitFlo.Ditto.ValueResolvers
{
    public abstract class BaseNewsResolver : DittoValueResolver
    {
        protected IEnumerable<IPublishedContent> GetNews()
        {
            if (Content == null) return Enumerable.Empty<IPublishedContent>();

            var homePage = Content.AncestorsOrSelf(1).First();
            var newsArchive = homePage.Children.FirstOrDefault(x => x.DocumentTypeAlias == "umbNewsOverview");
            if (newsArchive == null) return Enumerable.Empty<IPublishedContent>();

            return newsArchive.Children.Where(x => x.DocumentTypeAlias == "umbNewsItem")
                .OrderByDescending(x => x.Get<DateTime>("publishDate"))
                .ThenByDescending(x => x.CreateDate);
        }
    }
}
