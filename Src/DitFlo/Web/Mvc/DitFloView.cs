using DitFlo.Models;
using System.Web.Mvc;
using Umbraco.Core.Models;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace DitFlo.Web.Mvc
{
    public abstract class DitFloView : DitFloView<IPublishedContent>
    { }

    public abstract class DitFloView<TViewModel>
        : UmbracoViewPage<DitFloViewModel<TViewModel>>
        where TViewModel : class
    {
        protected override void SetViewData(ViewDataDictionary viewData)
        {
            // If the current view data model is the same, just use it
            if (viewData.Model is DitFloViewModel<TViewModel>)
            {
                base.SetViewData(viewData);
                return;
            }

            // We need to give each view it's own view data dictonary
            // to allow them to have different model types
            var newViewData = new ViewDataDictionary(viewData);

            var content = viewData.Model as IPublishedContent;
            if (content != null)
            {
                newViewData.Model = new DitFloViewModel<TViewModel>(content,
                    UmbracoContext.PublishedContentRequest.Culture);

                base.SetViewData(newViewData);
                return;
            }

            var renderModel = viewData.Model as RenderModel;
            if (renderModel != null)
            {
                newViewData.Model = new DitFloViewModel<TViewModel>(renderModel.Content,
                    renderModel.CurrentCulture);

                base.SetViewData(newViewData);
                return;
            }

            base.SetViewData(newViewData);
        }
    }
}