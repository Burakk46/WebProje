using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Burak_1380_MVC.Models
{
    public class Urun
    {
        [Key]
        public int UrunId { get; set; }
        [Required(ErrorMessage = "Bu Alanı Boş Geçemezsiniz!")]
        public string UrunAdi { get; set; }
        [Required(ErrorMessage = "Bu Alanı Boş Geçemezsiniz!")]
        public int UrunStok { get; set; }
        [Required(ErrorMessage = "Bu Alanı Boş Geçemezsiniz!")]
        public string KategoriId { get; set; }
        [Required(ErrorMessage = "Bu Alanı Boş Geçemezsiniz!")]
        public string UrunAciklama { get; set; }
        [Required(ErrorMessage = "Bu Alanı Boş Geçemezsiniz!")]
        public double UrunFiyat { get; set; }
        [Required(ErrorMessage = "Bu Alanı Boş Geçemezsiniz!")]
        public string UrunResim { get; set; }
        [Required(ErrorMessage = "Bu Alanı Boş Geçemezsiniz!")]
        public DateTime UrunTarih { get; set; }
        public string UrunEkleyen { get; set; }
        public Kategori Kategori {get;set;}
    }
}