using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
namespace EntityLayer.Concrete
{
    public class Siniflar
    {
        [Key]
        public int Sinif_id { get; set; }
        public string Sinif_name { get; set; }
        //public bool check_box { get; set; }
        public List<AppUser> appUsers { get; set; }
        public List<Lesson> Lessons { get; set; }
    }
}
