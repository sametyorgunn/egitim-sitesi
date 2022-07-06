using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.ViewComponents.Hakkimizda_adminList
{
    public class Hakkimizda_adminList:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            Context context = new Context();
            var list = context.hakkımızdas.ToList();
            return View(list);
        }
    }

}
