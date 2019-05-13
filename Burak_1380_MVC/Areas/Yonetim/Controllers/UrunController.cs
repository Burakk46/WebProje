using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Burak_1380_MVC.Models;
using System.Web.Security;

namespace Burak_1380_MVC.Areas.Yonetim.Controllers
{
    [Authorize]
    public class UrunController : Controller
    {
        // GET: Yonetim/Urun

        MagazaContext db = new MagazaContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UrunEkle()
        {
            ViewBag.Kategoriler = db.KategoriTablo.ToList().OrderBy(m => m.KategoriSira);
            return View();
        }
        [HttpPost]
        public ActionResult UrunEkle(Urun model, HttpPostedFileBase UrunResim)
        {
            if (ModelState.IsValid)
            {
                if (UrunResim.FileName != null)
                {
                    string resimadi = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(UrunResim.FileName);
                    UrunResim.SaveAs(Server.MapPath("~/Content/upload/" + resimadi));
                    model.UrunResim = resimadi;
                    db.UrunTablo.Add(model);
                    db.SaveChanges();                  

                    return RedirectToAction("UrunListe");
                }
                else
                {
                    db.UrunTablo.Add(model);
                    db.SaveChanges();
                }
            }
            else
            {
                return View(model);

            }
            return View();
        }
        public ActionResult KullaniciEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KullaniciEkle(AdminKullanici model)
        {
            var kayit = db.KullaniciTablo.Where(m => m.KullaniciAdi == model.KullaniciAdi).FirstOrDefault();
            if (kayit == null)
            {
                if (ModelState.IsValid)
                {
                    db.KullaniciTablo.Add(model);
                    db.SaveChanges();
                }
                else
                {
                    ViewBag.Hata = "Kayıt Eklerken Hata Oluştu";
                }
            }

            else
            {
                ViewBag.Hata = "Zaten Böyle Bir Kayıt  Var!";
            }
            return View();
        }
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(Kategori model)
        {
            if (ModelState.IsValid)
            {
                db.KategoriTablo.Add(model);
                db.SaveChanges();
            }
            return View();
        }
        public ActionResult UrunListe()
        {
            var liste = db.UrunTablo.ToList();
            return View(liste);
        }
        public ActionResult KullaniciListe()
        {
            var liste = db.KullaniciTablo.ToList();
            return View(liste);
        }
        public ActionResult KategoriListe()
        {
            var liste = db.KategoriTablo.ToList();
            return View(liste);
        }     
        public ActionResult Sil(int id)
        {
            var silinecekkayit = db.UrunTablo.Where(x => x.UrunId == id).FirstOrDefault();
            return View(silinecekkayit);
        }
        [HttpPost]
        public ActionResult Sil(Urun model)
        {
            var silinecekkayit = db.UrunTablo.Where(x => x.UrunId == model.UrunId).FirstOrDefault();
            db.UrunTablo.Remove(silinecekkayit);
            db.SaveChanges();
            return RedirectToAction("UrunListe");
        }
        public ActionResult UrunDuzenle(int id)
        {
            var duzenlenecekkayit = db.UrunTablo.Where(x => x.UrunId == id).FirstOrDefault();
            return View(duzenlenecekkayit);
        }
        [HttpPost]
        public ActionResult UrunDuzenle(Urun model)
        {
            var eskikayit = db.UrunTablo.Where(m => m.UrunId == model.UrunId).FirstOrDefault();
            eskikayit.UrunAdi = model.UrunAdi;
            eskikayit.UrunAciklama = model.UrunAciklama;
            eskikayit.UrunFiyat = model.UrunFiyat;
            eskikayit.UrunStok = model.UrunStok;
            eskikayit.UrunTarih = model.UrunTarih;           
            db.SaveChanges();
            return RedirectToAction("UrunListe");
        }
    }
}