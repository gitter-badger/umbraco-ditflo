using DitFlo.Models;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace DitFlo
{
    public static class DitFloViewModelExtensions
    {
        public static IPublishedContent HomePage(this IDitFloViewModel model)
        {
            return model.CurrentPage.AncestorOrSelf(1);
        }
    }
}
