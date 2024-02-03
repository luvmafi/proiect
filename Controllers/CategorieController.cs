using Microsoft.AspNetCore.Mvc;

namespace proiect.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
