using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace egitim_proje.ViewComponents.LoginPhoto
{
    public class LoginPhoto:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            Context context = new Context();
            var values = context.loginPhotos.ToList();
            return View(values);
        }
    }
}
