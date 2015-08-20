using System;
using Our.Umbraco.Ditto;

namespace DitFlo.Models
{
    public class NewsItemLink : Link
    {
        [UmbracoProperty("PublishDate", "CreateDate")]
        public DateTime Date { get; set; }
    }

}
