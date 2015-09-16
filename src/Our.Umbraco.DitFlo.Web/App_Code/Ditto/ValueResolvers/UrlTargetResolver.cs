using Our.Umbraco.Ditto;

namespace Our.Umbraco.DitFlo.Ditto.ValueResolvers
{
    public class UrlTargetResolver : DittoValueResolver
    {
        public override object ResolveValue()
        {
            if (Content == null) return null;

            return Content.Url.StartsWith("/") ? "_self" : "_blank";
        }
    }
}
