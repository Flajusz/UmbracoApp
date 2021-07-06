using System.Collections.Generic;
using System.Linq;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace UmbracoApp.Models
{
    public class GetExampleType
    {
        public static IExampleFill GetExmapleFill(IPublishedContent content)
        {
            var media = (List<IPublishedElement>)content.Value("elementChoice");

            var chosen = media[0];

            if ((List<MediaWithCrops>)chosen.Value("CustomImage") != null)
            {
                var crops = (List<MediaWithCrops>)chosen.Value("CustomImage");

                if (crops.Count == 1)
                {
                    var firstCrop = crops[0].LocalCrops.ToString();
                    List<string> cropsList = new List<string>();
                    cropsList.Add(firstCrop);
                    OneImage oneImage = new OneImage()
                    {
                        exampleType = ExampleType.SingleImage,
                        Urls = cropsList
                    };
                    return oneImage;
                }
                else
                {
                    List<string> cropsList = new List<string>();
                    for (int i = 0; i < crops.Count; i++)
                    {
                        var singleCrop = crops[i].LocalCrops.ToString();
                        cropsList.Add(singleCrop);
                    }
                    MultiImage multiImage = new MultiImage()
                    {
                        exampleType = ExampleType.MultiImage,
                        Urls = cropsList
                    };
                    return multiImage;
                }
            }

            else if (chosen.Value("CustomUrl") != null)
            {
                var crops = chosen.Value("CustomUrl").ToString();
                List<string> cropsList = new List<string>();
                cropsList.Add(crops);
                YTMovie ytMovie = new YTMovie()
                {
                    exampleType = ExampleType.YTMovie,
                    Urls = cropsList
                };
                return ytMovie;
            }

            else if (chosen.Value("CustomMP4") != null)
            {
                var crops = (MediaWithCrops)chosen.Value("CustomMP4");
                var path = crops.LocalCrops.Src.ToString();
                List<string> cropsList = new List<string>();
                cropsList.Add(path);
                MP4Movie mp4Movie = new MP4Movie()
                {
                    exampleType = ExampleType.MP4Movie,
                    Urls = cropsList
                };
                return mp4Movie;
            }

            return null;
        }

        public static List<string> GetMovieTags(IPublishedContent content)
        {
            List<string> movieTags = new List<string>();
            var getTags = (List<IPublishedContent>)content.Value("customTags");
            foreach (var item in getTags)
            {
                movieTags.Add(item.Value("Title").ToString());
            }
            return movieTags;
        }
    }
}