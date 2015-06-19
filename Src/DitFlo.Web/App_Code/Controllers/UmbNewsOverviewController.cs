using System.Web.Mvc;
using Umbraco.Web.Models;
using DitFlo.Web.Mvc.Controllers;
using DitFlo.Ditto.ValueResolvers.Contexts;

namespace DitFlo.Controllers
{
    using Ditto = Our.Umbraco.Ditto.Ditto;

    public class UmbNewsOverviewController : DitFloController
    {
        public ActionResult Index(RenderModel model, long? p)
        {
            Ditto.RegisterValueResolverContext(new NewsResolverContext
            {
                CurrentPage = p.HasValue ? p.Value : 1
            });

            return CurrentView();
        }
    }

}
