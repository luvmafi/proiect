using Microsoft.AspNetCore.Mvc;

namespace proiect.Controllers
{
    public class OrdersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
