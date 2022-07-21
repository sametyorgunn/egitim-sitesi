using Microsoft.AspNetCore.Mvc;

namespace egitim_proje.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Error1()
        {
            return View();
        }
    }
}
