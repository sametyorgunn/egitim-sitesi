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
    public class LoginPhoto
    {
        [Key]
        public int photo_id { get; set; }
        public string photo_path { get; set; }
        [NotMapped]
        public IFormFile photo { get; set; }

    }
}
