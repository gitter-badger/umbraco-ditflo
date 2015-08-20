using System.Linq;
using Our.Umbraco.DitFlo.Models;
using Our.Umbraco.Ditto;
using Umbraco.Web;

namespace Our.Umbraco.DitFlo.Ditto.ValueResolvers
{
    public class HomeLinkResolver : DittoValueResolver
    {
        public override object ResolveValue()
        {
            if (Content == null) return null;
            return Content.AncestorOrSelf(1).As<Link>();
        }
    }
}
