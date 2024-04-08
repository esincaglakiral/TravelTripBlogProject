using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Siniflar;
using TravelTripProje.Settings;

namespace TravelTripProje.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Context context = new Context();
        [Authorize]  
        // Projeyi Admin/Index'ten çalıştırmama rağmen beni önce Login Forma yönlendircek, mesela aynı işlemleri diğer controllerlar içinde yapabiliriz
        // Böylelikle yetkisi olmayan kullanıcı giriş yapmadan admin tarafına ulaşamaz

        [SessionTimeOut]  // kendim custom bir filter oluşturmuş oldum
        public ActionResult Index()
        {
            var values = context.Blogs.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult YeniBlog()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniBlog(Blog bloglar)
        {
           context.Blogs.Add(bloglar);
           context.SaveChanges();
           return RedirectToAction("Index");
        }

        public ActionResult BlogSil(int id)
        {
            var blog = context.Blogs.Find(id);
            context.Blogs.Remove(blog);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BlogGetir(int id)
        {
            var bloglar = context.Blogs.Find(id);
            return View("BlogGetir", bloglar);
        }

        public ActionResult BlogGüncelle(Blog bloglar)
        {
            var blog = context.Blogs.Find(bloglar.ID);
            blog.Aciklama = bloglar.Aciklama;
            blog.Baslik = bloglar.Baslik;
            blog.Tarih = bloglar.Tarih;
            blog.BlogImage = bloglar.BlogImage;
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult YorumListesi()
        {
            var yorumlar = context.Yorumlars.ToList();
            return View(yorumlar);
        }

        public ActionResult YorumSil(int id)
        {
            var y = context.Yorumlars.Find(id);
            context.Yorumlars.Remove(y);
            context.SaveChanges();
            return RedirectToAction("YorumListesi");
        }


        public ActionResult YorumGetir(int id)
        {
            var yorum = context.Yorumlars.Find(id);
            return View("YorumGetir", yorum);
        }

        public ActionResult YorumGuncelle(Yorumlar yorumlar)
        {
            var y = context.Yorumlars.Find(yorumlar.ID);
            y.KullaniciAdi = yorumlar.KullaniciAdi;
            y.Mail = yorumlar.Mail;
            y.Yorum = yorumlar.Yorum;
            context.SaveChanges();
            return RedirectToAction("YorumListesi");
        }


        public ActionResult MesajListesi()
        {
            var mesajlar = context.Iletisims.ToList();
            return View(mesajlar);
        }


        public ActionResult MesajSil(int id)
        {
            var m = context.Iletisims.Find(id);
            context.Iletisims.Remove(m);
            context.SaveChanges();
            return RedirectToAction("MesajListesi");
        }
    }
}