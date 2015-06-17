using System;
using System.Collections.Generic;
using System.Linq;
using Our.Umbraco.Ditto;
using Umbraco.Web;

namespace DitFlo.Models
{
    public class LatestNewsViewModel
    {
        [DittoValueResolver(typeof(LatestNewsValueResolver))]
        public IEnumerable<LatestNewsItem> NewsItems { get; set; }

        [DittoValueResolver(typeof(NewsArchiveUrlValueResolver))]
        public string ArchiveUrl { get; set; }
    }

    public class LatestNewsItem
    {
        [UmbracoProperty("Title", "Name")]
        public string Title { get; set; }

        [UmbracoProperty("PublishDate", "CreateDate")]
        public DateTime Date { get; set; }

        public string Url { get; set; }

        public string UrlTarget { get; set; }
    }

    public class LatestNewsValueResolver : DittoValueResolver
    {
        public override object ResolveValue()
        {
            if (Content == null) return Enumerable.Empty<LatestNewsItem>();

            var homePage = Content.AncestorsOrSelf(1).First();
            var newsArchive = homePage.Children.FirstOrDefault(x => x.DocumentTypeAlias == "umbNewsOverview");
            if (newsArchive == null) return Enumerable.Empty<LatestNewsItem>();

            var newsItems = newsArchive.Children.Where(x => x.DocumentTypeAlias == "umbNewsItem")
                .OrderByDescending(x => x.Get<DateTime>("publishDate"))
                .ThenByDescending(x => x.CreateDate)
                .Take(5);

            return newsItems.As<LatestNewsItem>();
        }
    }

    public class NewsArchiveUrlValueResolver : DittoValueResolver
    {
        public override object ResolveValue()
        {
            if (Content == null) return null;

            var homePage = Content.AncestorsOrSelf(1).First();
            var newsArchive = homePage.Children.FirstOrDefault(x => x.DocumentTypeAlias == "umbNewsOverview");
            return (newsArchive != null) ? newsArchive.Url : null;
        }
    }
}
