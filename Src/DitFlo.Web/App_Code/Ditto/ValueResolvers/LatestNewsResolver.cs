using System.Linq;
using DitFlo.Models;
using Our.Umbraco.Ditto;

namespace DitFlo.Ditto.ValueResolvers
{
    public class LatestNewsResolver : BaseNewsResolver
    {
        public override object ResolveValue()
        {
            return GetNews().Take(5).As<NewsItemLink>();
        }
    }
}
