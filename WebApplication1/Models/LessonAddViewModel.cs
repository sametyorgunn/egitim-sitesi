using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class LessonAddViewModel
    {
        public string Lesson_name { get; set; }
        [NotMapped]
        public IFormFile Lesson_resim { get; set; }
        public string Lesson_resim_yol { get; set; }
        public List<int> siniflar { get; set; }


    }
}
