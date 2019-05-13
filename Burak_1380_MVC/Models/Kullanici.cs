using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Burak_1380_MVC.Models
{
    public class Kullanici
    {
        public int KullaniciId { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public DateTime KullaniciDogumTarihi { get; set; }
        public string KullaniciSifre { get; set; }
        [System.ComponentModel.DataAnnotations.Compare("KullaniciSifre",ErrorMessage ="Şifreler Eşleşmiyor")]
        public string KullaniciSifreTekrar { get; set; }
        public string KullaniciEmail { get; set; }
        public string KullaniciTelefon { get; set; }
        public string Cinsiyet { get; set; }
    }
}