using Umbraco.Core.Models;
using Umbraco.Web.Models;

namespace DitFlo.Models
{
    public interface IDitFloViewModel : IRenderModel
    {
        IPublishedContent CurrentPage { get; }
    }
}
