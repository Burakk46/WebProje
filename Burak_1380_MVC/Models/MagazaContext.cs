using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Burak_1380_MVC.Models
{
    public class MagazaContext:DbContext
    {
        public MagazaContext():base("name=baglanti") { }
        public DbSet<Kategori> KategoriTablo { get; set; }
        public DbSet<AdminKullanici> KullaniciTablo { get; set; }
        public DbSet<Urun> UrunTablo { get; set; }
        public DbSet<Kullanici> UyeTablo { get; set; }
    }
}