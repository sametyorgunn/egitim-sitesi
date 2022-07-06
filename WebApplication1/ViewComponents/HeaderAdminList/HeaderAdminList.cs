using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.ViewComponents.HeaderAdminList
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
