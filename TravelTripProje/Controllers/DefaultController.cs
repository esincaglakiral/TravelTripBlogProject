using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Siniflar;


namespace TravelTripProje.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default

        Context context = new Context();
        public ActionResult Index()
        {
            var values = context.Blogs.Take(10).ToList();
            return View(values);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Iletisim()
        {
            return View();
        }

        public PartialViewResult Partial1()
        {
            var value = context.Blogs.OrderByDescending(i => i.ID).Take(2).ToList();
            return PartialView(value);
        }

        public PartialViewResult Partial2()
        {
            var values = context.Blogs.Where(x => x.ID == 1).ToList();
            return PartialView(values);

        }

        public PartialViewResult Partial3()
        {
            var value = context.Blogs.Take(10).ToList();
            return PartialView(value);

        }
        public PartialViewResult Partial4()
        {
            var value = context.Blogs.Take(3).ToList();
            return PartialView(value);

        }
        public PartialViewResult Partial5()
        {
            var value = context.Blogs.Take(3).OrderByDescending(x=>x.ID).ToList();
            return PartialView(value);

        }


        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult SendMessage(Iletisim iletisim)
        {
            context.Iletisims.Add(iletisim);
            context.SaveChanges();
            return PartialView();
        }

    }
}