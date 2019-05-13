using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Burak_1380_MVC.Models;
using System.Web.Security;

namespace Burak_1380_MVC.Areas.Yonetim.Controllers
{
    public class AdminController : Controller
    {
        // GET: Yonetim/Admin
        MagazaContext db = new MagazaContext();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(AdminKullanici model)
        {
            var kullanicivarmi = db.KullaniciTablo.Where(m => m.KullaniciAdi == model.KullaniciAdi && m.KullaniciSifre == model.KullaniciSifre).FirstOrDefault();
            if (kullanicivarmi==null)
            {
                ViewBag.Mesaj = "Kullanıcı Adı Veya Şifre Hatalı";
                return View(model);
            }
            else
            {
                FormsAuthentication.SetAuthCookie(model.KullaniciAdi, true);
                return Redirect("/Yonetim/Urun/Index");
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}