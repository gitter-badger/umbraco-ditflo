using System;
using System.Linq;
using Our.Umbraco.DitFlo.Models;
using Our.Umbraco.Ditto;
using Umbraco.Web;

namespace Our.Umbraco.DitFlo.Ditto.ValueResolvers
{
    public class FeaturesResolver : DittoValueResolver
    {
        public override object ResolveValue()
        {
            if (Content == null) return Enumerable.Empty<NewsItemLink>();

            var homePage = Content.AncestorOrSelf(1);
            var featured = homePage.Children.Where(x => x.DocumentTypeAlias == "umbTextPage"
                && x.Get("featuredPage", defaultValue:false))
                .OrderBy(x => new Guid())
                .Take(4);

            return featured.As<FeatureLink>();
        }
    }
}
