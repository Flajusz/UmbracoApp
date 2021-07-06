using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UmbracoApp.Models
{
    public class ExampleMovie
    {
        public string Title { get; set; }
        public DateTime PublishDate { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public IExampleFill MediaFill { get; set; }
        public List<string> MovieTags { get; set; }
    }
}