using System.Linq;
using Our.Umbraco.DitFlo.Models;
using Our.Umbraco.Ditto;

namespace Our.Umbraco.DitFlo.Ditto.ValueResolvers
{
    public class FeaturedNewsResolver : BaseNewsResolver
    {
        public override object ResolveValue()
        {
            return GetNews().First().As<NewsPreviewLink>();
        }
    }
}
