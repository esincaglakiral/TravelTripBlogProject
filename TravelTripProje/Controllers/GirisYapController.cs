using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TravelTripProje.Models.Siniflar;

namespace TravelTripProje.Controllers
{
    public class GirisYapController : Controller
    {
        // GET: GirisYap

        Context login = new Context();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Admin admin)
        {
            var kullaniciBilgileri = login.Admins.FirstOrDefault(x => x.Kullanici == admin.Kullanici && x.Sifre == admin.Sifre);
            if(kullaniciBilgileri != null) // parametre olarak gönderdiğim admin değeri ile veritabanındaki bilgiler birbirine eşitse
            {
               
                FormsAuthentication.SetAuthCookie(kullaniciBilgileri.Kullanici, false); // tarayıcı kapatınca cookie silincek yani kalıcı olmıcak
                Session["Kullanici"] = kullaniciBilgileri.Kullanici.ToString();                                                                                 
                return RedirectToAction("Index", "Admin");

                // başarıyla giriş yapmış olduğu anlamına gelir. Bu durumda, kullanıcı için bir oturum tanımlama bilgisi (cookie) oluşturulur. 
                // FormsAuthentication.SetAuthCookie metodu, kullanıcının tarayıcısında, kullanıcı adıyla birlikte bir oturum tanımlama bilgisi 
                // oluşturarak kullanıcıyı oturum açmış olarak işaretler. false parametresi, tarayıcı kapandığında oturum tanımlama bilgisinin silinmesi gerektiğini belirtir.
                // Kullanıcının adı, Session nesnesine Kullanici anahtarı ile kaydedilir. 
                // Bu, kullanıcının adının, sunucu tarafında kullanıcı oturumu boyunca saklanacağı anlamına gelir.
            }
            else
            {
                // Eğer eşleşen bir kullanıcı bulunamazsa (kullaniciBilgileri == null), kullanıcının giriş bilgileri yanlış demektir. 
                // Bu durumda, kullanıcıya yeniden giriş yapması için giriş sayfası (View()) gösterilir.
                ModelState.AddModelError("", "Kullanıcı adı veya şifre yanlış");
                return View();
            }

        }



        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Login","GirisYap");  //Login controller'ı GirişYap Action'u
        }
    }
}