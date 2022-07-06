using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;

namespace EntityLayer.Concrete
{
    public class AppUser:IdentityUser<int>
    {
        public string namesurname { get; set; }
        public string imgUrl { get; set; }
        public int SiniflarSinif_id { get; set; }
        public string okul_no { get; set; }
        public string sube { get; set; }
        public Siniflar Siniflar { get; set; }
    }
}
