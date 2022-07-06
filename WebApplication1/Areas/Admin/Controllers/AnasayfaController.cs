using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AnasayfaController : Controller
    {
        Context context = new Context();
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Hakkımızda hak)
        {
            if(ModelState.IsValid)
            {
                context.hakkımızdas.Add(hak);
                context.SaveChanges();
                return View();
            }
            return View();
        }

        public IActionResult HakkimizdaList()
        {
            var values = context.hakkımızdas.ToList();
            return View(values);
        }

        public IActionResult HakkimizdaSil(int id)
        {
            var value = context.hakkımızdas.Find(id);
            context.hakkımızdas.Remove(value);
            context.SaveChanges();
            return RedirectToAction("HakkimizdaList","Anasayfa");
        }
        [HttpGet]
        public IActionResult HakkimizdaGuncelle(int id)
        {
            var value = context.hakkımızdas.Find(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult HakkimizdaGuncelle(Hakkımızda hak)
        {
            if (ModelState.IsValid)
            {
                context.hakkımızdas.Update(hak);
                context.SaveChanges();
                return RedirectToAction("HakkimizdaList", "Anasayfa");
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public IActionResult HeaderAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult HeaderAdd(Header header)
        {
            if (ModelState.IsValid)
            {
                context.headers.Add(header);
                context.SaveChanges();
                return RedirectToAction("HeaderList", "Anasayfa");
            }
            else
            {
                return View();
            }
        }

        public IActionResult HeaderList()
        {
            var values = context.headers.ToList();
            return View(values);
        }

        public IActionResult HeaderDelete(int id)
        {
            var value = context.headers.Find(id);
            context.headers.Remove(value);
            context.SaveChanges();
            return RedirectToAction("HeaderList", "Anasayfa");
        }

        [HttpGet]
        public IActionResult HeaderGuncelle(int id)
        {
            var value = context.headers.Find(id);
            return View(value);

        }
        [HttpPost]
        public IActionResult HeaderGuncelle(Header header)
        {
            if (ModelState.IsValid)
            {
                context.headers.Update(header);
                context.SaveChanges();
                return RedirectToAction("HeaderList", "Anasayfa");
            }
            else
            {
                return View();
            }
        }
    }
}
