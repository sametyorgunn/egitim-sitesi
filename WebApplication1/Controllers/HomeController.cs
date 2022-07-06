using Aspose.Slides;
using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly ILogger<HomeController> _logger;
        LessonManager lm = new LessonManager(new EfLessonRepository());
        Lesson_icerik_Manager lim = new Lesson_icerik_Manager(new EfLesson_icerikRepository());
        private readonly IWebHostEnvironment _webHost;
        public List<Lesson_icerik> lesson_İceriks;


        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment webHost)
        {
            _logger = logger;
            _webHost = webHost;
        }


        public IActionResult Index()
        {
            return View();
        }

       
        [Authorize]
        public IActionResult Icerik()
        {
            Context c = new Context();
            var tumdersler = c.lessons.ToList();
            var username = User.Identity.Name;
            //var id = c.Users.Where(x => x.UserName == username).Select(y => y.Sinif_id).FirstOrDefault();
            //var value = c.lessons.Where(x => x.Sinif_id == id).ToList();
            //return View(value);

            var adminid = c.Users.Where(x => x.UserName == username).Select(y => y.Id).FirstOrDefault();
            var admina = c.UserRoles.Where(x => x.UserId == adminid).Select(y => y.RoleId).FirstOrDefault();

            if(admina==1)
            {
                var ff = c.lessons.ToList();
                return View(ff);
            }
            else
            {
                var id = c.Users.Where(x => x.UserName == username).Select(y => y.SiniflarSinif_id).FirstOrDefault();
                var value = c.lessons.Where(x => x.SiniflarSinif_id == id).ToList();
                return View(value);
            }
            
 
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            //return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            return View();
        }
        [Authorize]
        [HttpGet]
        public IActionResult Details(int id)
        {   
            Context context = new Context();
            var values = context.lesson_İceriks.Where(x=>x.LessonLesson_id==id).ToList();
            return View(values);
        }
        [Authorize]
        [HttpGet]
        public IActionResult Detail(int id)
        {
            Context context = new Context();
            var values = context.lesson_İceriks.Where(x => x.LessonLesson_id == id).ToList();
            return View(values);
        }
        //[Authorize]
        //[HttpGet]
        //public IActionResult PresentationWatch(string Yol, string FileName)
        //{
        //    lesson_İceriks = new List<Lesson_icerik>();
        //    if (FileName == null) //a to FileName
        //    {

        //        // Display default PowerPoint file on page load
        //        lesson_İceriks = RenderPresentationAsImage(Yol);  //"6.pptx"

        //    }
        //    else
        //    {

        //        lesson_İceriks = RenderPresentationAsImage(FileName);
        //    }

        //    return View(lesson_İceriks);
        //}
        //public List<Lesson_icerik> RenderPresentationAsImage(string FileName) //string FileName
        //{
        //    var webRoot = _webHost.WebRootPath;
        //    // Load the PowerPoint presentation
        //    Presentation presentation = new Presentation(Path.Combine(webRoot, "Presentations", FileName));  //FileName
        //    var slides = new List<EntityLayer.Concrete.Lesson_icerik>();

        //    string imagePath = "";
        //    // Save and view presentation slides
        //    for (int j = 0; j < presentation.Slides.Count; j++)
        //    {
        //        ISlide sld = presentation.Slides[j];
        //        Bitmap bmp = sld.GetThumbnail(1f, 1f);
        //        imagePath = Path.Combine(webRoot, "Slides", string.Format("slide_{0}.png", j));
        //        bmp.Save(imagePath, System.Drawing.Imaging.ImageFormat.Png);
        //        // Add to the list
        //        slides.Add(new Lesson_icerik { içerik_id = j, Yol = string.Format("slide_{0}.png", j) }); //yol == path
        //    }

        //    return slides;
        //}

        [Authorize]
        public IActionResult izle(int id)
        {
            Context context = new Context();
            var values = context.lesson_İceriks.Where(x => x.içerik_id == id).FirstOrDefault();
            return View(values);
           
        }



    }
}
