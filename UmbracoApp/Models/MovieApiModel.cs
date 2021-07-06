using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UmbracoApp.Models
{
    public class MovieApiModel
    {
        public MovieApiModel()
        {
            
        }

        public List<ExampleMovie> MoviesList { get; set; }
        public List<string> TagsList { get; set; }
        public List<string> CategoriesList { get; set; }

    }
}