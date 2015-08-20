using Our.Umbraco.Ditto;
using Umbraco.Web;

namespace DitFlo.Ditto.ValueResolvers
{
    public class ActiveNavLinkResolver : DittoValueResolver
    {
        public override object ResolveValue()
        {
            if (Content == null) return false;
            return Content.Id == UmbracoContext.Current.PageId;
        }
    }
}
