using System.Collections.Generic;
using System.Globalization;
using Our.Umbraco.Ditto;
using Umbraco.Core.Models;
using Umbraco.Web.Models;

namespace DitFlo.Models
{
    public abstract class BaseDitoFloViewModel : RenderModel, IDitFloViewModel
    {
        protected BaseDitoFloViewModel(IPublishedContent content, CultureInfo culture)
            : base(content, culture)
        {
            ValueResolverContexts = new List<DittoValueResolverContext>();
        }

        protected BaseDitoFloViewModel(IPublishedContent content) 
            : this(content, null)
        { }

        public IPublishedContent CurrentPage { get { return Content; } }

        internal List<DittoValueResolverContext> ValueResolverContexts { get; set; }
    }

    public class DitFloViewModel<TViewModel> : BaseDitoFloViewModel
        where TViewModel : class
    {
        public DitFloViewModel(IPublishedContent content, CultureInfo culture)
            : base(content, culture)
        { }

        protected DitFloViewModel(IPublishedContent content)
            : base(content)
        { }

        public TViewModel View
        {
            get
            {
                if (Content is TViewModel)
                    return Content as TViewModel;

                return Content.As<TViewModel>(valueResolverContexts: ValueResolverContexts);
            }
        }
    }

    public class DitFloViewModel : DitFloViewModel<IPublishedContent>
    {
        public DitFloViewModel(IPublishedContent content, CultureInfo culture)
            : base(content, culture)
        { }

        protected DitFloViewModel(IPublishedContent content)
            : base(content)
        { }
    }

}