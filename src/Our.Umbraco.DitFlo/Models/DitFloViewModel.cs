using System.Collections.Generic;
using System.Globalization;
using Our.Umbraco.Ditto;
using Umbraco.Core.Models;
using Umbraco.Web.Models;

namespace Our.Umbraco.DitFlo.Models
{
    public abstract class BaseDitFloViewModel : RenderModel, IDitFloViewModel
    {
        protected BaseDitFloViewModel(
            IPublishedContent content, 
            CultureInfo culture = null, 
            IEnumerable<DittoValueResolverContext> valueResolverContexts = null)
            : base(content, culture)
        {
            ValueResolverContexts = valueResolverContexts ?? new List<DittoValueResolverContext>();
        }

        public IPublishedContent CurrentPage { get { return Content; } }

        internal IEnumerable<DittoValueResolverContext> ValueResolverContexts { get; set; }
    }

    public class DitFloViewModel<TViewModel> : BaseDitFloViewModel
        where TViewModel : class
    {
        public DitFloViewModel(
            IPublishedContent content,
            CultureInfo culture = null,
            IEnumerable<DittoValueResolverContext> valueResolverContexts = null,
            TViewModel viewModel = null)
            : base(content, culture, valueResolverContexts)
        {
            if(viewModel != null)
                View = viewModel;
        }

        private TViewModel _view;
        public TViewModel View
        {
            get
            {
                if (_view == null)
                {
                    if (Content is TViewModel)
                    {
                        _view = Content as TViewModel;
                    }
                    else
                    {
                        _view = Content.As<TViewModel>(valueResolverContexts: ValueResolverContexts);
                    }
                }

                return _view;
            }
            internal set
            {
                _view = value;
            }
        }
        
    }

    public class DitFloViewModel : DitFloViewModel<IPublishedContent>
    {
        protected DitFloViewModel(
            IPublishedContent content,
            CultureInfo culture = null,
            IEnumerable<DittoValueResolverContext> valueResolverContexts = null)
            : base(content, culture, valueResolverContexts)
        { }
    }

}