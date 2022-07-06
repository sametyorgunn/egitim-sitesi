using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Hakkımızda
    {
        [Key]
        public int Hakkinda_id { get; set; }
        public string Hakkinda_baslik { get; set; }
        public string Hakkinda_Altbaslik { get; set; }
        public string Hakkinda_icerik { get; set; }
    }
}
