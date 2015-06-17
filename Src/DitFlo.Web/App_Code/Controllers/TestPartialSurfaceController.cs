using System.Web.Mvc;
using DitFlo.Models;
using DitFlo.Web.Mvc.Controllers;

namespace DitFlo.Controllers
{
    public class TestPartialSurfaceController
        : DitFloController<HomeViewModel>
    {
        [ChildActionOnly]
        public ActionResult TestPartial2()
        {
            Model.View.Name = "Overwridden title";

            return CurrentPartialView();
        }
    }

}
