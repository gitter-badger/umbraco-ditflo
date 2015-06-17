using Our.Umbraco.Ditto;
using Umbraco.Web;

namespace DitFlo.Models
{
    [UmbracoProperties(Recursive = true)]
    public class LayoutViewModel
    {
        public string SiteName { get; set; }

        public string SiteDescription { get; set; }

        public string Copyright { get; set; }

        [DittoValueResolver(typeof(SiteUrlValueResolver))]
        public string SiteUrl { get; set; }
    }

    public class SiteUrlValueResolver : DittoValueResolver
    {
        public override object ResolveValue()
        {
            if (Content == null) return null;

            return Content.AncestorOrSelf(1).Url;
        }
    }
}
