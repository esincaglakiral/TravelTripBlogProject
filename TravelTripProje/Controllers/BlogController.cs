using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Siniflar;


namespace TravelTripProje.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        Context context = new Context();
        BlogYorum by = new BlogYorum();

        public ActionResult Index()
        {
            //var bloglar = context.Blogs.ToList();
            by.Deger1 = context.Blogs.ToList();
            by.Deger3 = context.Blogs.Take(3).ToList();
            return View(by);
        }

        public ActionResult BlogDetay(int id)
        {

           // var bulunacakBlog = context.Blogs.Where(x => x.ID == id).ToList();
           by.Deger1 = context.Blogs.Where(x => x.ID == id).ToList();
            by.Deger2 = context.Yorumlars.Where(x => x.Blogid == id).ToList();

            return View(by);
        }

        [HttpGet]
        public PartialViewResult YorumYap(int id)
        {
            ViewBag.deger = id;
            return PartialView();

        }

        [HttpPost]
        public PartialViewResult YorumYap(Yorumlar y)
        {
            context.Yorumlars.Add(y);
            context.SaveChanges();
            return PartialView();
        }
    }
}