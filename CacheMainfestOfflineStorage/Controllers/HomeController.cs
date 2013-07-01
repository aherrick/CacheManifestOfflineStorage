using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CacheMainfestOfflineStorage.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CacheMainfest()
        {
            return View();
        }

        public JsonResult ValidateOnline()
        {
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}
