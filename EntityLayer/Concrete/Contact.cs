using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Contact
    {
        [Key]
        public int Contact_id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string mail { get; set; }
        public string message { get; set; }

        public string message_detay { get; set; }
    }
}
