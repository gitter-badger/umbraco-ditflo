using System.Collections.Generic;
using Our.Umbraco.Ditto;

namespace DitFlo.Models
{
    internal class DitFloTransferModel
    {
        public DitFloTransferModel(object model)
        {
            Model = model;
            ValueResolverContexts = new List<DittoValueResolverContext>();
        }

        public DitFloTransferModel(object model, IEnumerable<DittoValueResolverContext> resovlerContexts)
        {
            Model = model;
            ValueResolverContexts = new List<DittoValueResolverContext>(resovlerContexts);
        }

        public object Model { get; set; }

        public List<DittoValueResolverContext> ValueResolverContexts { get; set; }
    }
}
