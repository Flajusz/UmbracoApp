using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.Web.WebApi;
using UmbracoApp.Models;

namespace UmbracoApp.Controllers
{
    public class MovieApiController : UmbracoApiController
    {
        // GET: MovieApi
        [HttpGet]
        public System.Web.Http.Results.JsonResult<MovieApiModel> GetMovies() 
        {
            MovieApiModel movieModel = new MovieApiModel()
            {
                MoviesList=new List<ExampleMovie>(),
                CategoriesList=new List<string>(),
                TagsList=new List<string>()

            };

            var elements = Umbraco.Content(1099).Children;
            var categories = Umbraco.Content(1099).Children.Where(x => x.ContentType.Alias.Equals("categories")).ToList();
            var tags = Umbraco.Content(1099).Children.Where(x => x.ContentType.Alias.Equals("customTag")).ToList();

            List<IPublishedContent> childrenList = new List<IPublishedContent>();

            var moviesList = new List<ExampleMovie>();

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

                var ready = new ExampleMovie()
                {
                    Title = currentChild.Value("Title").ToString(),
                    PublishDate = (DateTime)currentChild.Value("PublishDate"),
                    Description = currentChild.Value("Description").ToString(),
                    Category = childcategory,
                    MediaFill = whatTypeOfMedia,
                    MovieTags = currentMovieTags
                };
               
                moviesList.Add(ready);
            }

            var categoriesList = new List<string>();

            foreach (var item in categories)
            {
                categoriesList.Add(item.Name.ToString());
            }

            var tagsList = new List<string>();

            foreach (var item in tags)
            {
                foreach (var subItem in item.Children)
                {
                    tagsList.Add(subItem.Value("Title").ToString());
                }
            }

            movieModel.MoviesList = moviesList;
            movieModel.CategoriesList = categoriesList;
            movieModel.TagsList = tagsList;
            return Json(movieModel);
        }

    }
}