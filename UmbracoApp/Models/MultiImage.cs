using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UmbracoApp.Models
{
    public class MultiImage : IExampleFill
    {
        public List<string> Urls { get; set; }
        public ExampleType exampleType { get; set; }
    }
}