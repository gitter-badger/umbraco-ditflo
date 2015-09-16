using Our.Umbraco.DitFlo.Web.Mvc.Controllers;
using System.Web.Mvc;
using Our.Umbraco.DitFlo.ViewModels;
using Our.Umbraco.Ditto;
using Umbraco.Web.Models;

namespace Our.Umbraco.DitFlo.Controllers
{
    public class UmbTextPageController : DitFloController
    {
        public ActionResult Index(RenderModel model, long p = 1)
        {
            var typedModel = model.Content.As<TextPageViewModel>();
            typedModel.Title = "[Overwritten] " + typedModel.Title;

            return CurrentView(typedModel);
        }
    }

}
