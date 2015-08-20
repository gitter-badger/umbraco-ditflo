using System.Collections.Generic;
using Our.Umbraco.DitFlo.Ditto.ValueResolvers;
using Our.Umbraco.DitFlo.Models;
using Our.Umbraco.Ditto;

namespace Our.Umbraco.DitFlo.ViewModels
{
    public class LatestNewsViewModel
    {
        [DittoValueResolver(typeof(LatestNewsResolver))]
        public IEnumerable<NewsItemLink> NewsItems { get; set; }

        [DittoValueResolver(typeof(NewsArchiveLinkResolver))]
        public Link Archive { get; set; }
    }
}
