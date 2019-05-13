using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Burak_1380_MVC.Models
{
    public class Kategori
    {
        public int KategoriId { get; set; }
        public string KategoriSira { get; set; }
        public string KategoriAdi { get; set; }
        public List<Urun>Urun { get; set; }
    }
}