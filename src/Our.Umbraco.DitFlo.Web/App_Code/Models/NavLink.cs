using Our.Umbraco.DitFlo.Ditto.ValueResolvers;
using Our.Umbraco.Ditto;

namespace Our.Umbraco.DitFlo.Models
{
    public class NavLink : Link
    {
        [DittoValueResolver(typeof(ActiveNavLinkResolver))]
        public bool IsActive { get; set; }
    }
}
