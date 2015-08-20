using System.Collections.Generic;
using Our.Umbraco.Ditto;
using System.Web.Mvc;
using Our.Umbraco.DitFlo.Models;
using Umbraco.Core.Logging;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace Our.Umbraco.DitFlo.Web.Mvc.Controllers
{
    public abstract class DitFloController : SurfaceController, IRenderMvcController
    {
        protected List<DittoValueResolverContext> _resolverContexts;

        protected DitFloController()
        {
            _resolverContexts = new List<DittoValueResolverContext>();
        }

        public virtual ActionResult Index(RenderModel model)
        {
            return CurrentView(model);
        }

        protected virtual ActionResult CurrentView(object model = null)
        {
            if (model == null)
                model = CurrentPage;

            var transferModel = new DitFloTransferModel(model, _resolverContexts);

            var viewName = ControllerContext.RouteData.Values["action"].ToString();

            if (ViewExists(viewName, false))
                return View(viewName, transferModel);

            return Content("");
        }

        protected virtual ActionResult CurrentPartialView(object model = null)
        {
            if (model == null)
                model = CurrentPage;

            var transferModel = new DitFloTransferModel(model, _resolverContexts);

            var viewName = ControllerContext.RouteData.Values["action"].ToString();

            if (ViewExists(viewName, true))
                return PartialView(viewName, transferModel);

            return Content("");
        }

        protected bool ViewExists(string viewName, bool isPartial = false)
        {
            var result = !isPartial
                ? ViewEngines.Engines.FindView(ControllerContext, viewName, null)
                : ViewEngines.Engines.FindPartialView(ControllerContext, viewName);

            if (result.View != null)
                return true;

            LogHelper.Warn<DitFloController>("No view file found with the name " + viewName);
            return false;
        }

        protected virtual void RegisterValueResolverContext<TContextType>(TContextType context)
            where TContextType : DittoValueResolverContext
        {
            _resolverContexts.Add(context);
        }
    }
}
