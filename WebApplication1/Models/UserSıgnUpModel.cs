﻿using EntityLayer.Concrete;
using System.ComponentModel.DataAnnotations;

namespace egitim_proje.Models
{
    public class UserSıgnUpModel
    {
        [Display(Name = "Ad soyad")]
        [Required(ErrorMessage = "Lütfen isim ve soyisim giriniz.")]
        public string namesurname { get; set; }

        [Display(Name = "şifre")]
        [Required(ErrorMessage = "lütfen şifre giriniz")]
        public string password { get; set; }

        [Compare("password", ErrorMessage = "şifreler uyuşmuyor")]
        [Display(Name = "şifre tekrar")]
        public string confirmpassword { get; set; }

        //[Display(Name = "mail adresi")]
        //[Required(ErrorMessage = "lütfen mail giriniz")]
        //public string mail { get; set; }

        [Display(Name = "kullanıcı adı")]
        [Required(ErrorMessage = "lütfen kullanıcı adı giriniz")]
        public string username { get; set; }
        public int SiniflarSinif_id { get; set; }
        public string Sinif_name { get; set; }

        public string sube { get; set; }
        public string okul_no { get; set; }



    }
}
