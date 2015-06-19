using System.Web.Mvc;
using DitFlo.ViewModels;
using Umbraco.Web.Models;
using DitFlo.Web.Mvc.Controllers;
using DitFlo.Ditto.ValueResolvers.Contexts;

namespace DitFlo.Controllers
{
    public class UmbNewsOverviewController : DitFloController<NewsOverviewViewModel>
    {
        public ActionResult Index(RenderModel model, long p = 1)
        {
            RegisterValueResolverContext(new NewsResolverContext
            {
                CurrentPage = p
            });
            
            return CurrentView();
        }
    }

}
