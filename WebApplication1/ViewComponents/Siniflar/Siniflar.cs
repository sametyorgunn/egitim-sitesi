using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using egitim_proje.Models;

namespace egitim_proje.ViewComponents.Siniflar
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
