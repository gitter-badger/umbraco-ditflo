using System.Linq;
using Our.Umbraco.DitFlo.Models;
using Our.Umbraco.Ditto;

namespace Our.Umbraco.DitFlo.Ditto.ValueResolvers
{
    public class LatestNewsResolver : BaseNewsResolver
    {
        public override object ResolveValue()
        {
            return GetNews().Take(5).As<NewsItemLink>();
        }
    }
}
