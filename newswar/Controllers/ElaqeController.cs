using newswar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace newswar.Controllers
{
    public class ElaqeController : Controller
    {
        // GET: Elaqe
        context c = new context();
        public ActionResult indexela()
        {
            var values = c.elaqes.ToList();
            return View(values);
        }
       
        public ActionResult addcontact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult addcontact(elaqe b)
        {
            c.elaqes.Add(b);
            c.SaveChanges();
            return RedirectToAction("indexela");
        }
        public ActionResult updelaqe(int id)
        {
            var ctgu = c.elaqes.Find(id);
            return View("updelaqe", ctgu);
        }
        [HttpPost]
        public ActionResult updelaqe(elaqe k)
        {
            var kgtu = c.elaqes.Find(k.bizid);
            kgtu.email = k.email;
            kgtu.phone = k.phone;
            c.SaveChanges();
            return RedirectToAction("indexela");
        }
        public ActionResult delelaqe(int id)
        {
            var ctg = c.elaqes.Find(id);
            c.elaqes.Remove(ctg);
            c.SaveChanges();
            return RedirectToAction("indexela");
        }
    }
}