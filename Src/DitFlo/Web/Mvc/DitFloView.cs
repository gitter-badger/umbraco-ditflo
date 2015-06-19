using System.Collections.Generic;
using System.Web.Mvc;
using DitFlo.Models;
using Our.Umbraco.Ditto;
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
            // We need to give each view it's own view data dictonary
            // to allow them to have different model types
            var newViewData = new ViewDataDictionary(viewData);

            if (viewData.Model is DitFloViewModel<TViewModel>)
            {
                base.SetViewData(newViewData);
                return;
            }

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