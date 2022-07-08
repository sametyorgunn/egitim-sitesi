using Aspose.Slides;
using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {

        private readonly UserManager<AppUser> _userManager;
        public List<Lesson_icerik> lesson_İceriks;
        private readonly IWebHostEnvironment _webHost;
        LessonManager lm = new LessonManager(new EfLessonRepository());
        Lesson_icerik_Manager lim = new Lesson_icerik_Manager(new EfLesson_icerikRepository());
        UserManager um = new UserManager(new EfUserRepository());



        public AdminController(UserManager<AppUser> userManager, IWebHostEnvironment webHost)
        {
            _userManager = userManager;
            _webHost = webHost;
        }

        public IActionResult Index()
        {
            Context context = new Context();

            ViewBag.ders = context.lessons.Count();
            ViewBag.icerik = context.lesson_İceriks.Count();
            ViewBag.uye = context.Users.Count();
            var id = context.UserRoles.Where(x => x.RoleId == 1).Select(y => y.UserId).FirstOrDefault();
            ViewBag.admn = context.Users.Where(z => z.Id == Convert.ToInt32(id)).Select(y => y.UserName).FirstOrDefault();
            //string admin = admn.ToString();
            //ViewBag.admin_username = admin;
            return View();
        }

        [HttpGet]
        public IActionResult AddLessons()
        {
            Context c = new Context();
            //var val = c.siniflars.ToList();
            //List<SelectListItem> categoryvalues = (from x in val
            //                                       select new SelectListItem
            //                                       {
            //                                           Text = x.Sinif_name,
            //                                           Value = x.Sinif_id.ToString()
            //                                       }).ToList();

            //ViewBag.v = categoryvalues;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddLessons(LessonAddViewModel p)
        {
            List<Lesson> LessonList = new List<Lesson>();
            string wwwRootPath = _webHost.WebRootPath;
            string filename = Path.GetFileNameWithoutExtension(p.Lesson_resim.FileName);
            string extension = Path.GetExtension(p.Lesson_resim.FileName);
            p.Lesson_resim_yol = filename = filename + extension;//yol == path
            string path = Path.Combine(wwwRootPath + "/Derskapakresim/", filename);  // + DateTime.Now.ToString("yymmssfff") 
            using (var filestream = new FileStream(path, FileMode.Create))
            {
                await p.Lesson_resim.CopyToAsync(filestream);    //.CopyToAsync
            }
            for (int i = 0; i < p.siniflar.Count(); i++)
            {

                Lesson lesson = new Lesson
                {
                    Lesson_name = p.Lesson_name,
                    Lesson_resim = p.Lesson_resim,
                    Lesson_resim_yol = p.Lesson_resim_yol,
                    SiniflarSinif_id = p.siniflar[i]
                };

                LessonList.Add(lesson);
            }

            Context c = new Context();
            c.AddRange(LessonList);
            c.SaveChanges();
            TempData["success"] = "Ders başarıyla kaydedildi";
            return View();




            //Context c = new Context();
            ////var val = c.siniflars.ToList();
            ////List<SelectListItem> categoryvalues = (from x in val
            ////                                       select new SelectListItem
            ////                                       {
            ////                                           Text = x.Sinif_name,
            ////                                           Value = x.Sinif_id.ToString()
            ////                                       }).ToList();

            ////ViewBag.v = categoryvalues;
            //if (ModelState.IsValid)
            //{


            //    string wwwRootPath = _webHost.WebRootPath;
            //    string filename = Path.GetFileNameWithoutExtension(p.Lesson_resim.FileName);
            //    string extension = Path.GetExtension(p.Lesson_resim.FileName);
            //    p.Lesson_resim_yol = filename = filename + extension;//yol == path
            //    string path = Path.Combine(wwwRootPath + "/Derskapakresim/", filename);  // + DateTime.Now.ToString("yymmssfff") 
            //    using (var filestream = new FileStream(path, FileMode.Create))
            //    {
            //        await p.Lesson_resim.CopyToAsync(filestream);    //.CopyToAsync
            //    }

            //    //Lesson les = new Lesson
            //    //{
            //    //    SiniflarSinif_id = p.SiniflarSinif_id,
            //    //    Lesson_name = p.Lesson_name,
            //    //    Lesson_resim = p.Lesson_resim,
            //    //    Lesson_resim_yol = p.Lesson_resim_yol,

            //    //};
            //    lm.TAdd(p);

            //}


        }

        public IActionResult DersListele()
        {
            Context context = new Context();
            var values = context.lessons.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult Addicerik()
        {
            List<SelectListItem> categoryvalues = (from x in lm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Lesson_name,
                                                       Value = x.Lesson_id.ToString()
                                                   }).ToList();

            ViewBag.v = categoryvalues;


            Context c = new Context();
            var value = c.siniflars.ToList();
            List<SelectListItem> siniflarlist = (from x in value
                                                 select new SelectListItem
                                                 {
                                                     Text = x.Sinif_name,
                                                     Value = x.Sinif_id.ToString()
                                                 }).ToList();

            ViewBag.siniflarlist = siniflarlist;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Addicerik(Lesson_icerik p)       //public async Task<IActionResult> Addicerik(Lesson_icerik p )    
        {

            List<SelectListItem> categoryvalues = (from x in lm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Lesson_name,
                                                       Value = x.Lesson_id.ToString()
                                                   }).ToList();

            ViewBag.v = categoryvalues;

            Context c = new Context();
            var value = c.siniflars.ToList();
            List<SelectListItem> siniflarlist = (from x in value
                                                 select new SelectListItem
                                                 {
                                                     Text = x.Sinif_name,
                                                     Value = x.Sinif_id.ToString()
                                                 }).ToList();

            ViewBag.siniflarlist = siniflarlist;


            if (ModelState.IsValid)
            {

                p.Yol = p.Yol.Replace("amp;", String.Empty);
                string wwwRootPath = _webHost.WebRootPath;
                string filename = Path.GetFileNameWithoutExtension(p.image.FileName);
                string extension = Path.GetExtension(p.image.FileName);
                p.image_yol = filename = filename + extension;
                string path = Path.Combine(wwwRootPath + "/Ders_icerik_resim/", filename);  // + DateTime.Now.ToString("yymmssfff") 
                using (var filestream = new FileStream(path, FileMode.Create))
                {
                    await p.image.CopyToAsync(filestream);
                }
                lim.TAdd(p);
                TempData["success"] = "içerik Başarıyla kaydedildi";
                return View();

            }
            return View(p);
        }

       

        public IActionResult EditLesson(int id)
        {
            Context context = new Context();

            var sinif = context.siniflars.ToList();
            List<SelectListItem> categoryvalues = (from x in sinif
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Sinif_name,
                                                       Value = x.Sinif_id.ToString()
                                                   }).ToList();

            ViewBag.v = categoryvalues;
            var value = lm.TGetById(id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> EditLesson(Lesson lesson)
        {
            Context context = new Context();

            var value = context.siniflars.ToList();
            List<SelectListItem> categoryvalues = (from x in value
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Sinif_name,
                                                       Value = x.Sinif_id.ToString()
                                                   }).ToList();

            ViewBag.v = categoryvalues;
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHost.WebRootPath;
                string filename = Path.GetFileNameWithoutExtension(lesson.Lesson_resim.FileName);
                string extension = Path.GetExtension(lesson.Lesson_resim.FileName);
                lesson.Lesson_resim_yol = filename = filename + extension;//yol == path
                string path = Path.Combine(wwwRootPath + "/Derskapakresim/", filename + DateTime.Now.ToString("yymmssfff"));  // + DateTime.Now.ToString("yymmssfff") 
                using (var filestream = new FileStream(path, FileMode.Create))
                {
                    await lesson.Lesson_resim.CopyToAsync(filestream);    //.CopyToAsync
                }
                lm.TUpdate(lesson);
                TempData["success"] = "Ders başarıyla Güncellendi";
                return RedirectToAction("DersListele", "Admin");
            }
            else
            {
                return View();
            }

        }




        public IActionResult DeleteLesson(int id)
        {
            Context c = new Context();
            var value = c.lessons.Find(id);
            lm.TDelete(value);
            TempData["success"] = "Ders Başarıyla silindi";
            return RedirectToAction("DersListele", "Admin");
        }

        [HttpGet]
        public IActionResult DersicerigiListele(int id)
        {
            Context c = new Context();
            var value = c.lessons.Find(id);
            List<SelectListItem> categoryvalues = (from x in lm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Lesson_name,
                                                       Value = x.Lesson_id.ToString()
                                                   }).ToList();

            ViewBag.v = categoryvalues;
            var datas = c.lesson_İceriks.Where(x => x.LessonLesson_id == id).ToList();

            return View(value);
        }



        public IActionResult PersonList()
        {
            var result = um.GetListJoinSinif();
            return View(result);
        }
        public IActionResult PersonDelete(int id)
        {

            Context c = new Context();
            var res = c.Users.Find(id);
            um.TDelete(res);
            TempData["success"] = "kişi başarıyla silindi";
            return RedirectToAction("PersonList", "Admin");
        }

        [HttpGet]
        public IActionResult PersonEdit(int id)
        {
            Context context = new Context();

            var value = um.TGetById(id);
            var sinif = context.siniflars.ToList();
            List<SelectListItem> categoryvalues = (from x in sinif
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Sinif_name,
                                                       Value = x.Sinif_id.ToString()
                                                   }).ToList();

            ViewBag.siniflar = categoryvalues;


            return View(value);
        }
        [HttpPost]
        public IActionResult PersonEdit(UserUpdateViewModel app)
        {
            Context context = new Context();

            var sinif = context.siniflars.ToList();
            List<SelectListItem> categoryvalues = (from x in sinif
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Sinif_name,
                                                       Value = x.Sinif_id.ToString()
                                                   }).ToList();

            ViewBag.siniflar = categoryvalues;




            if (ModelState.IsValid)
            {

                var ogrenci = context.Users.Where(x => x.Id == app.id).FirstOrDefault();

                ogrenci.namesurname = app.namesurname;
                ogrenci.UserName = app.username;
                ogrenci.okul_no = app.okul_no;
                ogrenci.sube = app.sube;
                ogrenci.SiniflarSinif_id = app.SiniflarSinif_id;
                ogrenci.PasswordHash = app.PasswordHash;
                ogrenci.PasswordHash = _userManager.PasswordHasher.HashPassword(ogrenci,ogrenci.PasswordHash);
                //ogrenci.PasswordHash = _userManager.PasswordHasher.HashPassword(ogrenci,app.PasswordHash);
                context.Users.Update(ogrenci);
                context.SaveChanges();
                TempData["success"] = "kişi başarıyla güncellendi";

                return RedirectToAction("PersonList", "Admin");
            }
            else
            {
                return View();
            }

        }




        [HttpPost]
        public IActionResult IcerikListele(int id)
        {
            Context c = new Context();
            var datas = c.lesson_İceriks.Where(x => x.LessonLesson_id == id).ToList();
            return Ok(datas);
        }

        public IActionResult Dersiceriksil(int id)
        {
            Context context = new Context();
            var sil = context.lesson_İceriks.Find(id);
            context.lesson_İceriks.Remove(sil);
            context.SaveChanges();
            TempData["success"] = "içerik başarıyla silindi";
            return RedirectToAction("DersicerigiListele", "Admin");
            //return Ok();
        }
        [HttpGet]
        public IActionResult Dersicerikguncelle(int id)
        {
            Context c = new Context();
            var value = c.lesson_İceriks.Find(id);
            List<SelectListItem> categoryvalues = (from x in lm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Lesson_name,
                                                       Value = x.Lesson_id.ToString()
                                                   }).ToList();

            ViewBag.v = categoryvalues;
            return View(value);

        }

        [HttpPost]
        public IActionResult Dersicerikguncelle(Lesson_icerik li)
        {
            List<SelectListItem> categoryvalues = (from x in lm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Lesson_name,
                                                       Value = x.Lesson_id.ToString()
                                                   }).ToList();


            ViewBag.v = categoryvalues;
            Lesson_icerik icerik;
            using (Context con = new Context())
            {
                icerik = con.lesson_İceriks.Where(x => x.içerik_id == li.içerik_id).FirstOrDefault();
                icerik.icerik_name = li.icerik_name;
                icerik.Yol = li.Yol;
            }
            lim.TUpdate(icerik);
            TempData["success"] = "icerik başarıyla güncellendi";
            return RedirectToAction("DersicerigiListele", "Admin");

            //if (ModelState.IsValid)
            //{
                
                
            //}
            //else
            //{
            //    return Ok();
            //}


        }
        [HttpGet]
        public IActionResult SinifAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SinifAdd(Siniflar sinif)
        {
            Context context = new Context();

            if (ModelState.IsValid)
            {
                context.siniflars.Add(sinif);
                context.SaveChanges();
                TempData["success"] = "sınıf başarıyla kaydedildi";
                return View();
            }
            else
            {
                return View();

            }

        }

        [HttpGet]
        public IActionResult EditClass(int id)
        {
            Context context = new Context();

            var value = context.siniflars.Find(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult EditClass(Siniflar sinif)
        {
            Context context = new Context();

            if (ModelState.IsValid)
            {
                context.siniflars.Update(sinif);
                context.SaveChanges();
                TempData["success"] = "sınıf başarıyla güncellendi";
                return RedirectToAction("SinifAdd", "Admin");
            }
            else
            {
                return View();
            }

        }

        public IActionResult DeleteClass(int id)
        {
            Context context = new Context();

            var sil = context.siniflars.Find(id);
            context.siniflars.Remove(sil);
            context.SaveChanges();
            return RedirectToAction("SinifAdd", "Admin");
        }


        public IActionResult LoginPageFoto()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginPageFoto(LoginPhoto resim)
        {
            Context context = new Context();

            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHost.WebRootPath;
                string filename = Path.GetFileNameWithoutExtension(resim.photo.FileName);
                string extension = Path.GetExtension(resim.photo.FileName);
                resim.photo_path = filename = filename + DateTime.Now.ToString("yymmssfff") + extension;//yol == path
                string path = Path.Combine(wwwRootPath + "/Login_Sayfası_resim/", filename);  // + DateTime.Now.ToString("yymmssfff") 
                using (var filestream = new FileStream(path, FileMode.Create))
                {
                    await resim.photo.CopyToAsync(filestream);    //.CopyToAsync
                }
                context.loginPhotos.Add(resim);
                context.SaveChanges();
                TempData["success"] = "Resim başarıyla kaydedildi";
                return RedirectToAction("LoginPageFoto", "Admin");
            }
            else
            {
                return View();
            }


        }

        public IActionResult LoginPhotoDelete(int id)
        {
            Context context = new Context();

            var pht = context.loginPhotos.Find(id);
            context.loginPhotos.Remove(pht);
            context.SaveChanges();
            TempData["success"] = "resim başarıyla silindi";
            return RedirectToAction("LoginPageFoto", "Admin");
        }

        [HttpPost]
        public IActionResult GetSinif(int id)
        {
            Context c = new Context();
            var value = c.lessons.Where(x => x.SiniflarSinif_id == id)
                .Select(y => new SelectListItem { Text = y.Lesson_name, Value = y.Lesson_id.ToString() })
                .ToList();

            return Ok(value);
        }







    }
}
