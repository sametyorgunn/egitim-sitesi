using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _usermanager;


        public RegisterController(UserManager<AppUser> usermanager)
        {
            _usermanager = usermanager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            Context c = new Context();
            var value = c.siniflars.ToList();

            ViewBag.Siniflars = value;

            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Index(UserSıgnUpModel p)
        {
            Context c = new Context();


            if (ModelState.IsValid)
            {
                AppUser user = new AppUser()
                {   
                    //Email = p.mail,
                    UserName = p.username,
                    namesurname = p.namesurname,
                    SiniflarSinif_id = p.SiniflarSinif_id,
                    okul_no = p.okul_no,
                    sube = p.sube,
                    
                };
                var result = await _usermanager.CreateAsync(user, p.password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index","Register");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                    return View();
                }
            }
            else
            {
                return View();
            }
            
        }
    }
}
