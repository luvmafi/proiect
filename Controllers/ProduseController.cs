using Microsoft.AspNetCore.Mvc;

namespace proiect.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
