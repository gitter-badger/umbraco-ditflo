using System.Collections.Generic;
using DitFlo.Models;
using System.Web.Mvc;
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
            var model = viewData.Model;
            var resolverContexts = new List<DittoValueResolverContext>();

            var transferModel = model as DitFloTransferModel;
            if (transferModel != null)
            {
                model = transferModel.Model;
                resolverContexts = transferModel.ValueResolverContexts;
            }

            // We need to give each view it's own view data dictonary
            // to allow them to have different model types
            var newViewData = new ViewDataDictionary(viewData);

            // If the current view data model is the same, just use it
            var typedModel = model as TViewModel;
            if (typedModel != null)
            {
                newViewData.Model = new DitFloViewModel<TViewModel>(
                        UmbracoContext.PublishedContentRequest.PublishedContent,
                        UmbracoContext.PublishedContentRequest.Culture) { View = typedModel, ValueResolverContexts = resolverContexts };

                base.SetViewData(newViewData);
                return;
            }

            var content = model as IPublishedContent;
            if (content != null)
            {
                newViewData.Model = new DitFloViewModel<TViewModel>(content,
                    UmbracoContext.PublishedContentRequest.Culture) { ValueResolverContexts = resolverContexts };

                base.SetViewData(newViewData);
                return;
            }

            var renderModel = model as RenderModel;
            if (renderModel != null)
            {
                newViewData.Model = new DitFloViewModel<TViewModel>(renderModel.Content,
                    renderModel.CurrentCulture) { ValueResolverContexts = resolverContexts };

                base.SetViewData(newViewData);
                return;
            }

            base.SetViewData(newViewData);
        }
    }
}