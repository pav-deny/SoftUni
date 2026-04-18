using _01.Numbers.Models;
using Microsoft.AspNetCore.Mvc;

namespace _01.Numbers.Controllers
{
    public class PostController : Controller
    {

        private static List<PostModel> posts = new();
        public IActionResult Index()
        {
            return View(posts);
        }

        [HttpPost]
        public IActionResult Index(string tittle, string description)
        {
            PostModel post = new()
            {
                Tittle = tittle,
                Description = description
            };

            posts.Add(post);

            return View(posts);
        }
    }
}
