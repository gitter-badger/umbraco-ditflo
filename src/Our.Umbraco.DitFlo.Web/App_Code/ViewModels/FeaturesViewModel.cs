using System.Collections.Generic;
using Our.Umbraco.DitFlo.Ditto.ValueResolvers;
using Our.Umbraco.DitFlo.Models;
using Our.Umbraco.Ditto;

namespace Our.Umbraco.DitFlo.ViewModels
{
    public class FeaturesViewModel
    {
        [DittoValueResolver(typeof(FeaturesResolver))]
        public IEnumerable<FeatureLink> FeatureItems { get; set; }
    }
}
