using acroyoga.it.admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace acroyoga.it.admin.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        AcroyogaContext ctx = new AcroyogaContext();

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Events()
        {
            var model = ctx.Events;
            return View(model);

        }

        public ActionResult EventDetail(int? id)
        {
            Event model = new Event();
            if (id.HasValue)
                model = ctx.Events.Find(id.Value);
            return View(model);
        }

        [HttpPost]
        public ActionResult EventDetail(Event model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.Id == 0)
                    {
                        ctx.Events.Add(model);
                        ctx.SaveChanges();
                    }
                    else
                    {
                        ctx.Entry(model).State = System.Data.Entity.EntityState.Modified;
                        ctx.SaveChanges();
                    }
                    return RedirectToAction("Events");
                }
                else
                {
                    ViewBag.Error = "Model state is invalid";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View(model);
        }

        public ActionResult EventDelete(int id)
        {
            try
            {
                Event model = ctx.Events.Find(id);
                ctx.Events.Remove(model);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {

            }
            return RedirectToAction("Events");
        }

        protected override void Dispose(bool disposing)
        {
            ctx.Dispose();
            base.Dispose(disposing);
        }
    }
}