using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using egitim_proje.Models;
using System.Linq;
using System;

namespace egitim_proje.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        //private readonly UserManager<AppUser> _userManager;
        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserSignInViewModel p)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(p.username, p.password, false, true);
                if (result.Succeeded)
                {
                    Context c = new Context();
                    var adminid = c.Users.Where(x => x.UserName == p.username).Select(y => y.Id).FirstOrDefault();
                    var admina = c.UserRoles.Where(x => x.UserId == adminid).Select(y => y.RoleId).FirstOrDefault();

                    if (admina == 1)
                    {

                       
                        return RedirectToAction("Index", "Admin", new { Areas = "Admin" });



                    }
                    else
                    {

                        return RedirectToAction("Icerik", "Home");

                    }
                    //return RedirectToAction("Icerik", "Home");
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }
            }
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }
    }
}
