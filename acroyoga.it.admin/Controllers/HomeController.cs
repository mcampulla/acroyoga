using acroyoga.it.admin.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
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


        #region events
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
                    if (model.EventId == 0)
                    {
                        model.CreateDate = DateTime.Now;
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
        #endregion

        #region galleries
        public ActionResult Galleries()
        {
            var model = ctx.Galleries;
            return View(model);

        }

        public ActionResult GalleryDetail(int? id)
        {
            Gallery model = new Gallery();
            if (id.HasValue)
                model = ctx.Galleries.Find(id.Value);
            return View(model);
        }

        [HttpPost]
        public ActionResult GalleryDetail(Gallery model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.GalleryId == 0)
                    {
                        ctx.Galleries.Add(model);
                        ctx.SaveChanges();
                    }
                    else
                    {
                        ctx.Entry(model).State = System.Data.Entity.EntityState.Modified;
                        ctx.SaveChanges();
                    }
                    return RedirectToAction("Galleries");
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

        public ActionResult GalleryDelete(int id)
        {
            try
            {
                Gallery model = ctx.Galleries.Find(id);
                ctx.Galleries.Remove(model);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {

            }
            return RedirectToAction("Galleries");
        }
        #endregion

        #region pictures
        public ActionResult Pictures()
        {
            var model = ctx.Pictures;
            return View(model);

        }

        public ActionResult PictureDetail(int? id)
        {
            Picture model = new Picture();
            if (id.HasValue)
                model = ctx.Pictures.Find(id.Value);
            return View(model);
        }

        [HttpPost]
        public ActionResult PictureDetail(Picture model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.PictureId == 0)
                    {
                        model.CreateDate = DateTime.Now;
                        ctx.Pictures.Add(model);
                        ctx.SaveChanges();
                    }
                    else
                    {
                        ctx.Entry(model).State = System.Data.Entity.EntityState.Modified;
                        ctx.SaveChanges();
                    }
                    return RedirectToAction("Pictures");
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

        public ActionResult PictureDelete(int id)
        {
            try
            {
                Picture model = ctx.Pictures.Find(id);
                ctx.Pictures.Remove(model);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {

            }
            return RedirectToAction("Pictures");
        }
        #endregion

        #region utility

        public ActionResult CloseFancybox()
        {
            return View();
        }


        [HttpPost]
        public ActionResult UploadFile()
        {
            string uploadPath = ConfigurationManager.AppSettings["UploadPath"] as string;

            HttpPostedFile file1 = System.Web.HttpContext.Current.Request.Files[0];
            string url = string.Empty;
            string foldername = string.Empty;

            if (file1 != null)
            {
                string filename = string.Format("{0}_{1}", DateTime.Now.ToString("yyyyMMdd-HHmmss"), System.IO.Path.GetFileName(file1.FileName));
                url = string.Format(uploadPath.Substring(1) + "/{1}", DateTime.Now.Year, filename);
                foldername = Server.MapPath(string.Format(uploadPath, DateTime.Now.Year));

                if (!System.IO.Directory.Exists(foldername))
                    System.IO.Directory.CreateDirectory(foldername);

                string path = System.IO.Path.Combine(foldername, filename);
                // file is uploaded
                file1.SaveAs(path);

                // save the image path path to the database or you can send image directly to database
                // in-case if you want to store byte[] ie. for DB
                using (MemoryStream ms = new MemoryStream())
                {
                    file1.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                }
            }

            return Json(new
            {
                files = new[] {
                    new {name = file1.FileName, size = file1.ContentLength, url = url}
                }
            });
        }

        #endregion

        protected override void Dispose(bool disposing)
        {
            ctx.Dispose();
            base.Dispose(disposing);
        }
    }
}