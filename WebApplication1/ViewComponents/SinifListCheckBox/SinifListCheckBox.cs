using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebApplication1.ViewComponents.SinifListCheckBox
{
    public class SinifListCheckBox:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            Context c = new Context();
            var value = c.siniflars.ToList();
            return View(value);
        }
    }
}
