using Our.Umbraco.DitFlo.Ditto.ValueResolvers;
using Our.Umbraco.DitFlo.Models;
using Our.Umbraco.Ditto;

namespace Our.Umbraco.DitFlo.ViewModels
{
    [UmbracoProperties(Recursive = true)]
    public class LayoutViewModel
    {
        public string SiteName { get; set; }

        public string SiteDescription { get; set; }

        public string Copyright { get; set; }

        [DittoValueResolver(typeof(HomeLinkResolver))]
        public Link HomeLink { get; set; }
    }
}
