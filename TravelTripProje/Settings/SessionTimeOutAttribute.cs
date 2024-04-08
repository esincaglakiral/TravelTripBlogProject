using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TravelTripProje.Settings
{
    public class SessionTimeOutAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Controller controller = filterContext.Controller as Controller;

            HttpContext httpContext = HttpContext.Current;
            var rd = httpContext.Request.RequestContext.RouteData;
            string currentAction = rd.GetRequiredString("action");
            string currentController = rd.GetRequiredString("controller");

            if (HttpContext.Current.Session["Kullanici"] == null)
            {
                filterContext.Result = new RedirectResult("~/GirisYap/Login?ReturnUrl=" + currentController + "/" + currentAction);
                return;

            }
            base.OnActionExecuting(filterContext);


        }
    }
}