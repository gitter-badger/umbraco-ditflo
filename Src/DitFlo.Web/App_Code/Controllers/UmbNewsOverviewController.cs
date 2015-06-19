using System.Web.Mvc;
using Umbraco.Web.Models;
using DitFlo.Web.Mvc.Controllers;
using DitFlo.Ditto.ValueResolvers.Contexts;

namespace DitFlo.Controllers
{
    public class UmbNewsOverviewController : DitFloController
    {
        public ActionResult Index(RenderModel model, long? p)
        {
            RegisterValueResolverContext(new NewsResolverContext
            {
                CurrentPage = p.HasValue ? p.Value : 1
            });
            
            return CurrentView();
        }
    }

}
