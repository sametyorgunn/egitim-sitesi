using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Error1()
        {
            return View();
        }
    }
}
