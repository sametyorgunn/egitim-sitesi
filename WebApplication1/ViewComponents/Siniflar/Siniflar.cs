using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.ViewComponents.Siniflar
{
    public class Siniflar:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            Context context = new Context();
            var value = context.siniflars.ToList();
            return View(value);
        }
    }
}
