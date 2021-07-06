using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmbracoApp.Models
{
    public interface IExampleFill
    {
        List<string> Urls { get; set; }

        ExampleType exampleType { get; set; }
    }


    public enum ExampleType
    {
        SingleImage,
        MultiImage,
        YTMovie,
        MP4Movie
    }
}
