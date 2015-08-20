using System.Collections.Generic;
using DitFlo.Ditto.ValueResolvers;
using DitFlo.Models;
using Our.Umbraco.Ditto;

namespace DitFlo.ViewModels
{
    public class TopNavigationViewModel
    {
        [DittoValueResolver(typeof(MainNavResolver))]
        public IEnumerable<NavLink> MenuItems { get; set; }
    }
}