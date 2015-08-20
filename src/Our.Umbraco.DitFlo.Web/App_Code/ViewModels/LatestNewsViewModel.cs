using System.Collections.Generic;
using DitFlo.Ditto.ValueResolvers;
using DitFlo.Models;
using Our.Umbraco.Ditto;

namespace DitFlo.ViewModels
{
    public class LatestNewsViewModel
    {
        [DittoValueResolver(typeof(LatestNewsResolver))]
        public IEnumerable<NewsItemLink> NewsItems { get; set; }

        [DittoValueResolver(typeof(NewsArchiveLinkResolver))]
        public Link Archive { get; set; }
    }
}
