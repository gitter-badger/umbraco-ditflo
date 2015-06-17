using System.Web;
using DitFlo.Ditto.TypeConverters;
using Our.Umbraco.Ditto;
using System.ComponentModel;

namespace DitFlo.Models
{
    [UmbracoProperties(Prefix = "banner")]
    public class BannerViewModel
    {
        [UmbracoProperty("HideBanner")]
        [TypeConverter(typeof(InvertBooleanConverter))]
        public bool IsVisible { get; set; }

        public string BackgroundImage { get; set; }

        public HtmlString Header { get; set; }

        public HtmlString SubHeader { get; set; }

        /* This will automatically convert to Link because
         * this property is a content picker and we have an
         * umbraco value converter installed that will resolve
         * it to IPublishedContent which then resolves to Link
         * through ditto because of the recursive conversion 
         * it does on IPublishedContent nodes*/
        public Link Link { get; set; }

        public string LinkText { get; set; }
    }

    public class Link
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public string UrlTarget { get; set; }
    }
}