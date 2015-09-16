using Our.Umbraco.Ditto;
using Umbraco.Core;
using Umbraco.Web;

namespace Our.Umbraco.DitFlo.Ditto.ValueResolvers
{
    public class ExtractResolver : DittoValueResolver
    {
        public override object ResolveValue()
        {
            if (Content == null) return null;
            if (Content.HasValue("extract")) return Content.Get<string>("extract");
            if (Content.HasValue("bodyText")) return Content.Get<string>("bodyText").StripHtml().Truncate(100);
            return null;
        }
    }
}
