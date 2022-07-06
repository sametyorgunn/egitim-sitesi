using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebApplication1.ViewComponents.UserProfile
{
    public class UserProfile:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            Context context = new Context();

            var username = User.Identity.Name;
            var sube = context.Users.Where(x => x.UserName == username).Select(y => y.sube).FirstOrDefault();
            var okul_no = context.Users.Where(x => x.UserName == username).Select(y => y.okul_no).FirstOrDefault();
            var name_surname = context.Users.Where(x => x.UserName == username).Select(y => y.namesurname).FirstOrDefault();
            var password = context.Users.Where(x => x.UserName == username).Select(y => y.PasswordHash).FirstOrDefault();
            var sinif = context.Users.Where(x => x.UserName == username).Select(y => y.Siniflar.Sinif_name).FirstOrDefault();
            var yenisinif = sinif.Replace(".sınıf", "/");
            ViewBag.sube = sube;
            ViewBag.okul_no = okul_no;
            ViewBag.name_surname = name_surname;
            ViewBag.password = password;
            ViewBag.username = username;
            ViewBag.sinif = yenisinif;

            return View();

        }
    }
}
