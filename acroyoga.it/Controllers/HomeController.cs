using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace acroyoga.it.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index2()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(bool IsPost=true)
        {
            return View();
        }

        public ActionResult Laura()
        {
            return View();
        }

        public ActionResult Guido()
        {
            return View();
        }

        public ActionResult Event()
        {
            return View();
        }
    }
}