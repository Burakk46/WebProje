using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Burak_1380_MVC.Models;
using System.Web.Security;
using PagedList;
using PagedList.Mvc;

namespace Burak_1380_MVC.Controllers
{
    public class HomeController : Controller
    {
        MagazaContext db = new MagazaContext();
        // GET: Home
        public ActionResult Index()
        {
            var liste = db.KategoriTablo.ToList();
            return View(liste);
        }
        public ActionResult KayitOl()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KayitOl(Kullanici model)
        {
            if (ModelState.IsValid)
            {
   
                db.UyeTablo.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GirisYap(Kullanici model)
        {
            var kullanicivarmi = db.UyeTablo.Where(x => x.KullaniciEmail == model.KullaniciEmail && x.KullaniciSifre == model.KullaniciSifre).FirstOrDefault();
            if (kullanicivarmi == null)
            {
                ViewBag.Mesaj = "Kullanıcı Adı Veya Şifre Hatalı";
                return View(model);
            }
            else
            {
                FormsAuthentication.SetAuthCookie(model.KullaniciEmail, true);
                return Redirect("/Home/Index");
            }
        }
        public ActionResult CikisYap()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("GirisYap");
        }
        public ActionResult Urunler(int Page=1)
        {
            ViewBag.Kategori = db.KategoriTablo.OrderBy(x => x.KategoriSira).ToList();
            ViewBag.KatSayi = db.KategoriTablo.Count();
            var liste = db.UrunTablo.OrderByDescending(m => m.UrunId).ToPagedList(Page, 12);
            return View(liste);
        }
        public ActionResult Detay(int id)
        {
            var gosterilecekkayit = db.UrunTablo.Where(x => x.UrunId == id).FirstOrDefault();
            return View(gosterilecekkayit);
        }
    }
}