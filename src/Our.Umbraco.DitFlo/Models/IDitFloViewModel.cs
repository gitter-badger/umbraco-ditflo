using Umbraco.Core.Models;
using Umbraco.Web.Models;

namespace Our.Umbraco.DitFlo.Models
{
    public interface IDitFloViewModel : IRenderModel
    {
        IPublishedContent CurrentPage { get; }
    }
}