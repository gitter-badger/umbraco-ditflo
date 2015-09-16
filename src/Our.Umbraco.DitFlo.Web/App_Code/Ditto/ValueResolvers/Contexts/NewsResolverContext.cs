using Our.Umbraco.Ditto;

namespace Our.Umbraco.DitFlo.Ditto.ValueResolvers.Contexts
{
    public class NewsResolverContext : DittoValueResolverContext
    {
        public long CurrentPage { get; set; }
    }
}
