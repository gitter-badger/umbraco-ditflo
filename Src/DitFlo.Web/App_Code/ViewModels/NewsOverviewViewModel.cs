using System.Collections.Generic;
using DitFlo.Ditto.ValueResolvers;
using DitFlo.Models;
using Our.Umbraco.Ditto;

namespace DitFlo.ViewModels
{
    public class NewsOverviewViewModel
    {
        [UmbracoProperty("Title", "Name")]
        public string Title { get; set; }

        [DittoValueResolver(typeof(NewsResolver))]
        public IEnumerable<NewsPreviewLink> NewsItems { get; set; }
    }
}
