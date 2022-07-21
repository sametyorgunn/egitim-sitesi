using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using egitim_proje.Models;

namespace egitim_proje.ViewComponents.HeaderAdminList
{
    public class HeaderAdminList:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            Context context = new Context();
            var value = context.headers.ToList();
            return View(value);
        }
    }
}
