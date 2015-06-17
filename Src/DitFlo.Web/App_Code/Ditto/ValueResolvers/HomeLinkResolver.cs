using System.Linq;
using DitFlo.Models;
using Our.Umbraco.Ditto;
using Umbraco.Web;

namespace DitFlo.Ditto.ValueResolvers
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
