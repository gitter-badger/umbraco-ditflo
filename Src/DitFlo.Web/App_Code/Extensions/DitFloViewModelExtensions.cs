using DitFlo.Models;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace DitFlo
{
    public static class DitFloViewModelExtensions
    {
        public static IPublishedContent SitePage(this IDitFloViewModel model)
        {
            return model.CurrentPage.AncestorOrSelf(1);
        }

        public static IPublishedContent RegionPage(this IDitFloViewModel model)
        {
            return model.CurrentPage.AncestorOrSelf(2);
        }

        public static IPublishedContent HomePage(this IDitFloViewModel model)
        {
            return model.CurrentPage.AncestorOrSelf(3);
        }
    }
}
