using DitFlo.Ditto.ValueResolvers.Contexts;
using DitFlo.ViewModels;
using DitFlo.Web.Mvc.Controllers;
using System.Web.Mvc;
using Umbraco.Web.Models;

namespace DitFlo.Controllers
{
    public class UmbNewsOverviewController : DitFloController<NewsOverviewViewModel>
    {
        public ActionResult Index(RenderModel model, long p = 1)
        {
            // IMPORTANT! ALWAYS register resolver contexts before accessing Model.View
            // if you need to access the view model in your controller
            RegisterValueResolverContext(new NewsResolverContext
            {
                CurrentPage = p
            });
            
            return CurrentView();
        }
    }

}
