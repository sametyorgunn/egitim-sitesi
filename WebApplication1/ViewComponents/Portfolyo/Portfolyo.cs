using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.ViewComponents.Portfolyo
{
    public class Portfolyo:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            Context context = new Context();
            ViewBag.user_count = context.Users.Count();
            ViewBag.lesson_count = context.lessons.Count();
            ViewBag.lesson_icerik_count = context.lesson_İceriks.Count();

            return View();
        }
    }
}
