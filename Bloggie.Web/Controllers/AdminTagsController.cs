using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Bloggie.Web.Models.ViewModels;
using Bloggie.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bloggie.Web.Controllers
{
    public class AdminTagsController : Controller
    {
        private readonly BloggieDbContext bloggieDbContext;
        private readonly ITagRepository tagRepository;


        //constructor injection
        public AdminTagsController(ITagRepository tagRepository )
        {
            this.tagRepository = tagRepository;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task< IActionResult > Add(AddTagRequest request)
        {
            // Mapping AddTagRequest to Tag domain modal
            var tag = new Tag
            {
                Name = request.Name,
                DisplayName = request.DisplayName,
            };

            await tagRepository.AddAsync(tag);

            return RedirectToAction("List");
        }

        [HttpGet]
        public async Task<IActionResult> List() {
            // use dbContext to read the tags
            var tags= await tagRepository.GetAllAsync();
            return View(tags);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var tag= await tagRepository.GetAsync(id);
            if(tag != null)
            {
                var editTagRequest = new EditTagRequest
                {
                    Id = tag.Id,
                    Name = tag.Name,
                    DisplayName = tag.DisplayName,
                };

                return View(editTagRequest);
            } 
            return View(null);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditTagRequest editTagRequest)
        {
            var tag = new Tag
            {
                Id=editTagRequest.Id,
                Name = editTagRequest.Name,
                DisplayName = editTagRequest.DisplayName
            };

            var updatedTag = await tagRepository.UpdateAsync(tag);

            if (updatedTag != null)
            {

                //Show success notification (doing in future)

            }
            else
            {

            }

            //Show error/failure notification (doing in future)
            return RedirectToAction("Edit", new { id=editTagRequest?.Id });

        }

        [HttpPost]
        public async Task<IActionResult> Delete(EditTagRequest editTagRequest)
        {
            var deletedTag= await tagRepository.DeleteAsync(editTagRequest.Id);
            if (deletedTag != null)
            {
                // show success notification
                return RedirectToAction("List");
            }

            // show an error notification ( will work on later )

            return RedirectToAction("Edit", new {id = editTagRequest?.Id});
        }
    }
}
