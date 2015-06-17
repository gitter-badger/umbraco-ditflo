using System.Linq;
using DitFlo.Models;
using Our.Umbraco.Ditto;

namespace DitFlo.Ditto.ValueResolvers
{
    public class FeaturedNewsResolver : BaseNewsResolver
    {
        public override object ResolveValue()
        {
            return GetNews().First().As<NewsPreviewLink>();
        }
    }
}
