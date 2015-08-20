using DitFlo.Ditto.ValueResolvers;
using DitFlo.Models;
using Our.Umbraco.Ditto;

namespace DitFlo.ViewModels
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
