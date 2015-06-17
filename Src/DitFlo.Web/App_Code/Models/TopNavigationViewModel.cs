using System.Collections.Generic;
using System.Linq;
using Our.Umbraco.Ditto;
using Umbraco.Web;

namespace DitFlo.Models
{
    public class TopNavigationViewModel
    {
        [DittoValueResolver(typeof(MainMenuValueResolver))]
        public IEnumerable<MenuItem> MenuItems { get; set; }
    }

    public class MenuItem
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public string UrlTarget { get; set; }

        [DittoValueResolver(typeof(ActiveMenuItemValueResolver))]
        public bool IsActive { get; set; }
    }

    public class MainMenuValueResolver : DittoValueResolver
    {
        public override object ResolveValue()
        {
            if (Content == null) return Enumerable.Empty<MenuItem>();

            var homePage = Content.AncestorsOrSelf(1).First();
            var menuItems = new []{ homePage }.Union(homePage.Children.Where(x => x.IsVisible()));
            return menuItems.As<MenuItem>();
        }
    }

    public class ActiveMenuItemValueResolver : DittoValueResolver
    {
        public override object ResolveValue()
        {
            if (Content == null) return false;

            return Content.Id == UmbracoContext.Current.PageId;
        }
    }
}