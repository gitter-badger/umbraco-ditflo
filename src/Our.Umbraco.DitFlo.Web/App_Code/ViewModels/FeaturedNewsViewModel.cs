using Our.Umbraco.DitFlo.Ditto.ValueResolvers;
using Our.Umbraco.DitFlo.Models;
using Our.Umbraco.Ditto;

namespace Our.Umbraco.DitFlo.ViewModels
{
    public class FeaturedNewsViewModel
    {
        [DittoValueResolver(typeof(FeaturedNewsResolver))]
        public NewsPreviewLink FeaturedNews { get; set; }

        [DittoValueResolver(typeof(NewsArchiveLinkResolver))]
        public Link Archive { get; set; }
    }
}
