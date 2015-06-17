using System.Linq;
using DitFlo.Models;
using Our.Umbraco.Ditto;
using Umbraco.Web;

namespace DitFlo.Ditto.ValueResolvers
{
    public class NewsArchiveLinkResolver : DittoValueResolver
    {
        public override object ResolveValue()
        {
            if (Content == null) return null;
            var homePage = Content.AncestorOrSelf(1);
            var newsArchive = homePage.Children.FirstOrDefault(x => x.DocumentTypeAlias == "umbNewsOverview");
            return (newsArchive != null) ? newsArchive.As<Link>() : null;
        }
    }
}
