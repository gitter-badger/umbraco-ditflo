using DitFlo.Models;
using Our.Umbraco.Ditto;
using System.Web.Mvc;
using Umbraco.Core.Logging;
using Umbraco.Core.Models;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace DitFlo.Web.Mvc.Controllers
{
    public abstract class AbstractDitFloController : SurfaceController, IRenderMvcController
    {
        public virtual ActionResult Index(RenderModel model)
        {
            return CurrentView();
        }

        protected virtual ActionResult CurrentView(object model = null)
        {
            var viewName = ControllerContext.RouteData.Values["action"].ToString();

            if (ViewExists(viewName, false))
                return View(viewName, model);

            return Content("");
        }

        protected virtual ActionResult CurrentPartialView(object model = null)
        {
            var viewName = ControllerContext.RouteData.Values["action"].ToString();

            if (ViewExists(viewName, true))
                return PartialView(viewName, model);

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
    }

    public abstract class DitFloController<TViewModel> : AbstractDitFloController
        where TViewModel : class
    {
        private DitFloViewModel<TViewModel> _model;
        public DitFloViewModel<TViewModel> Model
        {
            get
            {
                return _model ?? (_model = new DitFloViewModel<TViewModel>(
                    CurrentPage,
                    UmbracoContext.PublishedContentRequest.Culture));
            }
            set { _model = value; }
        }

        protected override ActionResult CurrentView(object model = null)
        {
            if (model == null)
                model = Model;

            return base.CurrentView(model);
        }

        protected override ActionResult CurrentPartialView(object model = null)
        {
            if (model == null)
                model = Model;

            return base.CurrentPartialView(model);
        }

        protected virtual void RegisterValueResolverContext<TContextType>(TContextType context)
            where TContextType : DittoValueResolverContext
        {
            Model.ValueResolverContexts.Add(context);
        }
    }

    public abstract class DitFloController : DitFloController<IPublishedContent>
    { }
}
