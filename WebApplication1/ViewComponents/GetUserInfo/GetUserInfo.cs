using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.ViewComponents.GetUserInfo
{
    public class GetUserInfo:ViewComponent   
    {
        private readonly UserManager<AppUser> _userManager;
        Context c = new Context();
        public GetUserInfo(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            var username = User.Identity.Name;
            var mail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            //var namesurname = c.Users.Where(x => x.namesurname == username).Select(y => y.namesurname);
            //var sinif_id = c.Users.Where(x => x.Sinif_id == username).Select(y => y.Sinif_id);
           

            ViewBag.username = username;
            //ViewBag.mail = mail.ToString();
            //ViewBag.nameme_surname = namesurname;
            //ViewBag.sinif_id = sinif_id; 

            return View();
        }
    }
}
