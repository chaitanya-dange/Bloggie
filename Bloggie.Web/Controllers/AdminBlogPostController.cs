using Microsoft.AspNetCore.Mvc;

namespace Bloggie.Web.Controllers
{
    public class AdminBlogPostController : Controller
    {

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
    }
}
