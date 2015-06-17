using System.Web;
using DitFlo.Ditto.ValueResolvers;
using Our.Umbraco.Ditto;

namespace DitFlo.Models
{
    public class FeatureLink : Link
    {
        public string Image { get; set; }

        [DittoValueResolver(typeof(ExtractResolver))]
        public HtmlString Extract { get; set; }
    }
}