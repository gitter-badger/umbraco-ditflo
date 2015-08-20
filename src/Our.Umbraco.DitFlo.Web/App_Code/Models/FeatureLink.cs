using System.Web;
using Our.Umbraco.DitFlo.Ditto.ValueResolvers;
using Our.Umbraco.Ditto;

namespace Our.Umbraco.DitFlo.Models
{
    public class FeatureLink : Link
    {
        public string Image { get; set; }

        [DittoValueResolver(typeof(ExtractResolver))]
        public HtmlString Extract { get; set; }
    }
}