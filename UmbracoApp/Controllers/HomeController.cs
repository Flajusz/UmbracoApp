using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;
using UmbracoApp.Models;

namespace UmbracoApp.Controllers
{
    public class HomeController : RenderMvcController
    {
        public ActionResult Index(ContentModel item)
        {
            ExampleModel model = new ExampleModel(item.Content)
            {
                ExampleList = new List<ExampleMovie>(),
                TagsList = new List<string>(),
                CatsList = new List<string>()
            };

            var data = UmbracoContext.PublishedRequest.PublishedContent;
            var elements = data.Children.Where(x => x.IsVisible());

            List<IPublishedContent> childrenList = new List<IPublishedContent>();
            List<IPublishedContent> tagsElements = elements.Where(x => x.ContentType.Alias.Equals("customTag")).ToList();
            List<IPublishedContent> catsElements = elements.Where(x => x.ContentType.Alias.Equals("categories")).ToList();

            foreach (var singleElement in tagsElements)
            {
                foreach (var elementChild in singleElement.Children)
                {
                    model.TagsList.Add(elementChild.Value("Title").ToString());
                }
            }

            foreach (var cats in catsElements)
            {
                model.CatsList.Add(cats.Name.ToString());
            }

            foreach (var elem in elements)
            {
                var child = elem.Children.Where(x => x.IsVisible()).Where(x => x.ContentType.Alias.Equals("examples")).ToList();
                for (int i = 0; i < child.Count(); i++)
                {
                    childrenList.Add(child[i]);
                }
            }

            foreach (var currentChild in childrenList)
            {
                var whatTypeOfMedia = GetExampleType.GetExmapleFill(currentChild);

                var currentMovieTags = GetExampleType.GetMovieTags(currentChild);

                var childcategory = currentChild.Parent.Name.ToString();

                var ready = new ExampleModel(currentChild)
                {
                    ExampleList = new List<ExampleMovie>()
                    {
                        new ExampleMovie()
                        {
                            Title=currentChild.Value("Title").ToString(),
                            PublishDate=(DateTime)currentChild.Value("PublishDate"),
                            Description=currentChild.Value("Description").ToString(),
                            Category=childcategory,
                            MediaFill = whatTypeOfMedia,
                            MovieTags=currentMovieTags
                        }
                    }
                };
                model.ExampleList.Add(ready.ExampleList[0]);
            }
            return CurrentTemplate(model);
        }
    }
}