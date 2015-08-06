using System.Collections.Generic;
using System.Globalization;
using Our.Umbraco.Ditto;
using Umbraco.Core.Models;
using Umbraco.Web.Models;

namespace DitFlo.Models
{
    public abstract class BaseDitFloViewModel : RenderModel, IDitFloViewModel
    {
        protected BaseDitFloViewModel(IPublishedContent content, CultureInfo culture)
            : base(content, culture)
        {
            ValueResolverContexts = new List<DittoValueResolverContext>();
        }
        
        protected BaseDitFloViewModel(IPublishedContent content) 
            : this(content, null)
        { }

        public IPublishedContent CurrentPage { get { return Content; } }

        internal List<DittoValueResolverContext> ValueResolverContexts { get; set; }
    }

    public class DitFloViewModel<TViewModel> : BaseDitFloViewModel
        where TViewModel : class
    {
        public DitFloViewModel(IPublishedContent content, CultureInfo culture)
            : base(content, culture)
        { }

        protected DitFloViewModel(IPublishedContent content)
            : base(content)
        { }

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
        public DitFloViewModel(IPublishedContent content, CultureInfo culture)
            : base(content, culture)
        { }

        protected DitFloViewModel(IPublishedContent content)
            : base(content)
        { }
    }

}