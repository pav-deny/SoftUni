using Microsoft.AspNetCore.Mvc;

namespace MvcIntro.Controllers
{
    public class ProductsController : Controller
    {
        private static readonly IEnumerable<string> products = new List<string>
        {
            "Laptops",
            "Gaming PCs",
            "Accesories"
        };

        public IActionResult Index()
        {
            ViewData["Products"] = products;

            return this.View();
        }

        [Route("{controller}/{id}")]
        [Route("{controller}/{action}/{id?}")]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return this.BadRequest("Product ID is required!");
            }

            if (id <= 0)
            {
                return this.NotFound("Product not found");
            }

            return this.Ok($"Product details: {id}");
        }
    }
}
