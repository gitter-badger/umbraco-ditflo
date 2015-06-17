using DitFlo.Ditto.ValueResolvers;
using Our.Umbraco.Ditto;

namespace DitFlo.Models
{
    public class Link
    {
        [UmbracoProperty("Name")]
        public string Title { get; set; }

        public string Url { get; set; }

        [DittoValueResolver(typeof(UrlTargetResolver))]
        public string UrlTarget { get; set; }
    }
}
