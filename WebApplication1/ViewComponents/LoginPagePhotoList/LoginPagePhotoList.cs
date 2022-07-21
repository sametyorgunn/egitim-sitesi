using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace egitim_proje.ViewComponents.LoginPagePhotoList
{
    public class LoginPagePhotoList:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            Context context = new Context();
            var resim = context.loginPhotos.ToList();
            return View(resim);

        }
    }
}
