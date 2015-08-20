using DitFlo.Ditto.ValueResolvers.Contexts;
using DitFlo.Web.Mvc.Controllers;
using System.Web.Mvc;
using Umbraco.Web.Models;

namespace DitFlo.Controllers
{
    public class UmbNewsOverviewController : DitFloController
    {
        public ActionResult Index(RenderModel model, long p = 1)
        {
            RegisterValueResolverContext(new NewsResolverContext
            {
                CurrentPage = p
            });

            return CurrentView(model);
        }
    }

}
