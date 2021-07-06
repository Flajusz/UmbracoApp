using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web.Models;

namespace UmbracoApp.Models
{
    public class ExampleModel : ContentModel
    {
        public ExampleModel(IPublishedContent content) : base(content)
        {

        }


        public List<ExampleMovie> ExampleList { get; set; }

        public List<string> CatsList { get; set; }
        public List<string> TagsList { get; set; }

    }
}