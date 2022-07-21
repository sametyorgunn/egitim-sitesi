using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using egitim_proje.Models;

namespace egitim_proje.Controllers
{
    public class UserController : Controller
    {
        UserManager usermanager = new UserManager(new EfUserRepository());
        private readonly UserManager<AppUser> _userManager;

        Context context = new Context();

        public UserController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [Authorize(Roles = "Ogrenci,Admin")]
        public IActionResult Index()
        {
            
            var username = User.Identity.Name;
            var namesurname = context.Users.Where(x => x.UserName == username).Select(y => y.namesurname).FirstOrDefault();
            var sube = context.Users.Where(x => x.UserName == username).Select(y => y.sube).FirstOrDefault();
            var okul_no = context.Users.Where(x => x.UserName == username).Select(y => y.okul_no).FirstOrDefault();
            var sinif = context.Users.Where(x => x.UserName == username).Select(y => y.Siniflar.Sinif_name).FirstOrDefault();

            var yenisinif = sinif.Replace(".sınıf","/");
            ViewBag.username = username;
            ViewBag.namesurname = namesurname;
            ViewBag.sube = sube;
            ViewBag.okulno = okul_no;
            ViewBag.sinif = yenisinif;
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Ogrenci,Admin")]
        public async Task<IActionResult> ProfileSetting()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserUpdateViewModel model = new UserUpdateViewModel();
            //model.mail = values.Email;
            //model.namesurname = values.namesurname;
            //model.imgurl = values.imgUrl;
            //model.Sinif_name =  ;

            model.sube = values.sube;
            model.namesurname = values.namesurname;
            model.username = values.UserName;
            model.okul_no = values.okul_no;
            //model.eskisifre = values.PasswordHash;
            //model.password = _userManager.PasswordHasher.HashPassword(values,values.PasswordHash);
            return View(model);


        }
        [HttpPost]
        [Authorize(Roles = "Ogrenci,Admin")]
        public async Task<IActionResult> ProfileSetting(UserUpdateViewModel model)
        {

            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            values.UserName = model.username;            
             values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, model.PasswordHash);
             var result = await _userManager.UpdateAsync(values);
            return RedirectToAction("Index", "User");


           
            

        }
    }
}
