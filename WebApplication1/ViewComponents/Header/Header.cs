using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using egitim_proje.Models;

namespace egitim_proje.ViewComponents.Header
{
    public class Header:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            Context context = new Context();
            var value = context.headers.ToList();
            return View(value);
        }
    }
}
