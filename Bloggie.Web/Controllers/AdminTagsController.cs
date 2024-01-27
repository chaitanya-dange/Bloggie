using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Bloggie.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bloggie.Web.Controllers
{
    public class AdminTagsController : Controller
    {
        private readonly BloggieDbContext bloggieDbContext;


        //constructor
        public AdminTagsController(BloggieDbContext bloggieDbContext)
        {
            this.bloggieDbContext = bloggieDbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddTagRequest request)
        {
            // Mapping AddTagRequest to Tag domain modal
            var tag = new Tag
            {
                Name = request.Name,
                DisplayName = request.DisplayName,
            };

            bloggieDbContext.Tags.Add(tag);
            bloggieDbContext.SaveChanges();

            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult List() {
            // use dbContext to read the tags
            var tags=bloggieDbContext.Tags.ToList();
            return View(tags);
        }
    }
}
