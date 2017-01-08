using E_Ticaret.Models.Managers;
using E_Ticaret.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Ticaret.Controllers
{
    public class LoginController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string kullaniciAdi, string sifre, bool cbBeniHatirla = false)
        {


            kullaniciAdi = kullaniciAdi?.Trim();
            sifre = sifre?.Trim();

            if (string.IsNullOrEmpty(kullaniciAdi) || string.IsNullOrEmpty(sifre))
            {
                ModelState.AddModelError("", "Kullanıcı adı ve şifre boş geçilemez!");
            }
            else
            {
                // AsNoTracking : Sadece verileri okumak içindir üzerinde değişiklik yapmaya izin vermez.

                Kullanici user = db.Kullanici.AsNoTracking().FirstOrDefault(x => x.KULLANICIADI == kullaniciAdi && x.SIFRE == sifre);

                if (user != null)
                {
                    //Son login tarihi kayıt ediliyor
                    Kullanici kullanici = db.Kullanici.Where(x => x.ID == user.ID).FirstOrDefault();
                    kullanici.SONGIRIS = DateTime.Now;
                    int sonuc = db.SaveChanges();

                    user.SIFRE = string.Empty;   // Güvenlik için session bilgisinden şifre siliniyor 
                    Session["login"] = user;    // Kullanıcı bilgileri sessiona atılıyor

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Hatalı kullanıcı adı veya şifre");
                }
            }
            return View();
        }


        public ActionResult Cikis()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }

    }
}