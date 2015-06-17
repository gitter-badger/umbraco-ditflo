using System.Web.Mvc;
using DitFlo.Models;
using DitFlo.Web.Mvc.Controllers;
using Umbraco.Web.Models;

namespace DitFlo.Controllers
{
    public class HomeController : DitFloController<HomeViewModel>
    {
        public override ActionResult Index(RenderModel model)
        {
            Model.View.Name += " Modified";

            return CurrentView();
        }
    }
}
