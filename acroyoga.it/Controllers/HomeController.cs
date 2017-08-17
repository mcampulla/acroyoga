using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace acroyoga.it.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult Index2()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index2(bool IsPost = true)
        {
            string name = Request["form-name"];
            string email = Request["form-email"];
            string subject = Request["form-subject"];
            string msg = Request["form-message"];

            string body = string.Format(@"<table><tr><td>Nome</td><td>{0}</td></tr>
                                                <tr><td>Email</td><td>{1}</td></tr>
                                                <tr><td>Oggetto</td><td>{2}</td></tr>
                                                <tr><td>Messaggio</td><td>{3}</td></tr></table>"
                                        , name, email, subject, msg);

            SmtpClient client = new SmtpClient("smtp.acroyogapadova.it");
            //client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = false;
            client.Timeout = 10000;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("188202@aruba.it", "89485c966c");

            try
            {
                MailMessage mm = new MailMessage("info@acroyogapadova.it", "info@acroyogapadova.it", string.Format("Messaggio da {0}", email), body);
                //mm.BodyEncoding = UTF8Encoding.UTF8;
                mm.IsBodyHtml = true;
                //mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

                client.Send(mm);
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                ViewBag.Error = ex.Message;
            }
            return View();
        }

        public ActionResult AcroYogaRagazzi()
        {
            return View();
        }

        public ActionResult Yoga()
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

        public ActionResult Event(int? id)
        {
            if (id.HasValue)
                return View(id);
            else
                return RedirectToAction("/");
        }

        public ActionResult Orari()
        {
            return View();
        }

        public ActionResult Gallery()
        {
            return View();
        }
    }
}