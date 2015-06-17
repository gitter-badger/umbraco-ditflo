using System.Collections.Generic;
using DitFlo.Ditto.ValueResolvers;
using DitFlo.Models;
using Our.Umbraco.Ditto;

namespace DitFlo.ViewModels
{
    public class FeaturesViewModel
    {
        [DittoValueResolver(typeof(FeaturesResolver))]
        public IEnumerable<FeatureLink> FeatureItems { get; set; }
    }
}
