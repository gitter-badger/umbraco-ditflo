using DitFlo.Ditto.ValueResolvers;
using DitFlo.Models;
using Our.Umbraco.Ditto;

namespace DitFlo.ViewModels
{
    public class FeaturedNewsViewModel
    {
        [DittoValueResolver(typeof(FeaturedNewsResolver))]
        public NewsPreviewLink FeaturedNews { get; set; }

        [DittoValueResolver(typeof(NewsArchiveLinkResolver))]
        public Link Archive { get; set; }
    }
}
