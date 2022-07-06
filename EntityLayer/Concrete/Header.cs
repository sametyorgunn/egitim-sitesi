using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Header
    {
        [Key]
        public int Header_id { get; set; }
        public string Header_icerik { get; set; }
        public string Header_baslik { get; set; }
    }
}
