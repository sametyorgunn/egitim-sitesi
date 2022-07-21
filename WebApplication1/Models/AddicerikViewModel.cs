using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace egitim_proje.Models
{
    public class AddicerikViewModel
    {
        public string icerik_name { get; set; }
       
        public string Yol { get; set; }
        //[NotMapped]
        //public IFormFile file { get; set; }
        public int LessonLesson_id { get; set; }
        public string image_yol { get; set; }
        [Required(ErrorMessage = "Resim seçiniz")]
        [NotMapped]
        public IFormFile image { get; set; }

        public int Sinif_id { get; set; }
    }
}
