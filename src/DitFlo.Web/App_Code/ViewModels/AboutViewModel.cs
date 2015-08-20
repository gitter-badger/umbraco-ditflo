using System.Web;
using Our.Umbraco.Ditto;

namespace DitFlo.ViewModels
{
    [UmbracoProperties(Prefix = "about", Recursive = true)]
    public class AboutViewModel
    {
        public string Title { get; set; }
        public HtmlString Text { get; set; }
    }
}
