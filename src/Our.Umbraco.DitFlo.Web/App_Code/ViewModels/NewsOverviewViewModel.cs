using System.Collections.Generic;
using Our.Umbraco.DitFlo.Ditto.ValueResolvers;
using Our.Umbraco.DitFlo.Models;
using Our.Umbraco.Ditto;

namespace Our.Umbraco.DitFlo.ViewModels
{
    public class NewsOverviewViewModel
    {
        [UmbracoProperty("Title", "Name")]
        public string Title { get; set; }

        [DittoValueResolver(typeof(NewsResolver))]
        public PagedCollection<NewsPreviewLink> NewsItems { get; set; }
    }
}
