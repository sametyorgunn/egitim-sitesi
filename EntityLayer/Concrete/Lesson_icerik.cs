using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Lesson_icerik
    {
        [Key]
        public int içerik_id { get; set; }
        public string icerik_name{ get; set; }
        public string image_yol { get; set; }
        [Required(ErrorMessage ="Resim seçiniz")]
        [NotMapped]
        public IFormFile image { get; set; }
        public string Yol { get; set; }
        //[NotMapped]
        //public IFormFile file { get; set; }
        public int LessonLesson_id { get; set; }
        public Lesson Lesson { get; set; }
    }
}
