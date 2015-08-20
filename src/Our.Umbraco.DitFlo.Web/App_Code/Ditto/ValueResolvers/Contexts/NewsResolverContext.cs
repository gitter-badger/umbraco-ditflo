using Our.Umbraco.Ditto;

namespace DitFlo.Ditto.ValueResolvers.Contexts
{
    public class NewsResolverContext : DittoValueResolverContext
    {
        public long CurrentPage { get; set; }
    }
}
