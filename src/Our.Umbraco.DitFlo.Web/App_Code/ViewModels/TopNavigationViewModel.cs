using System.Collections.Generic;
using Our.Umbraco.DitFlo.Ditto.ValueResolvers;
using Our.Umbraco.DitFlo.Models;
using Our.Umbraco.Ditto;

namespace Our.Umbraco.DitFlo.ViewModels
{
    public class TopNavigationViewModel
    {
        [DittoValueResolver(typeof(MainNavResolver))]
        public IEnumerable<NavLink> MenuItems { get; set; }
    }
}