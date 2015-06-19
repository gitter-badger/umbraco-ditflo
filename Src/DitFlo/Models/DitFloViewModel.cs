using System.Globalization;
using Our.Umbraco.Ditto;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Web.Models;

namespace DitFlo.Models
{
    public class DitFloViewModel<TViewModel> : RenderModel, IDitFloViewModel
        where TViewModel : class
    {
        public DitFloViewModel(IPublishedContent content, CultureInfo culture)
            : base(content, culture)
        { }

        public DitFloViewModel(IPublishedContent content)
            : base(content)
        { }

        public TViewModel View
        {
            get
            {
               return (TViewModel)Cache.RequestCache.GetCacheItem("DitFloViewModel_GetView_"
                    + typeof(TViewModel).AssemblyQualifiedName + "_" + Content.Id, () =>
                    {
                        if (Content is TViewModel)
                            return Content as TViewModel;

                        return Content.As<TViewModel>();
                    });
            }
        }

        public IPublishedContent CurrentPage
        {
            get { return Content; }
        }

        internal CacheHelper Cache
        {
            get { return ApplicationContext.Current.ApplicationCache; }
        }
    }

    public class DitFloViewModel : DitFloViewModel<IPublishedContent>
    {
        public DitFloViewModel(IPublishedContent content, CultureInfo culture)
            : base(content, culture)
        { }

        public DitFloViewModel(IPublishedContent content)
            : base(content)
        { }
    }

}