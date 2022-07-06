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
    public class Lesson
    {
        [Key]
        public int Lesson_id { get; set; }
        public string Lesson_name { get; set; }
        [Required(ErrorMessage ="resim seçiniz")]
        [NotMapped]
        public IFormFile Lesson_resim { get; set; }
        public string Lesson_resim_yol { get; set; }
        public int SiniflarSinif_id { get; set; }
        public Siniflar Siniflar { get; set; }
        public List<Lesson_icerik> Lesson_İceriks { get; set; }
    }
}
