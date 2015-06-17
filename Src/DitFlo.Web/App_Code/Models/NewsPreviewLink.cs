using System.Web;
using DitFlo.Ditto.ValueResolvers;
using Our.Umbraco.Ditto;

namespace DitFlo.Models
{
    public class NewsPreviewLink : NewsItemLink
    {
        [UmbracoProperty("SubHeader")]
        public string SubTitle { get; set; }

        public string Image { get; set; }

        [DittoValueResolver(typeof(ExtractResolver))]
        public HtmlString Extract { get; set; }
    }

}
