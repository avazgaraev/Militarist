using newswar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace newswar.Controllers
{
    public class KecidbannerController : Controller
    {
        context c = new context();
        public ActionResult Indexbanner()
        {
            var values = c.kecidbanners.ToList();
            return View(values);
        }
        public ActionResult addbanner()
        {
            return View();
        }
        [HttpPost]
        public ActionResult addbanner(kecidbanner b)
        {
            c.kecidbanners.Add(b);
            c.SaveChanges();
            return RedirectToAction("indexbanner");
        }
        public ActionResult updbanner(int id)
        {
            var ctgu = c.kecidbanners.Find(id);
            return View("updbanner", ctgu);
        }
        [HttpPost]
        public ActionResult updbanner(kecidbanner k)
        {
            var kgtu = c.kecidbanners.Find(k.kecidbannerid);
            kgtu.bannerphoto = k.bannerphoto;
            kgtu.bannertext = k.bannertext;
            c.SaveChanges();
            return RedirectToAction("indexbanner");
        }
        public ActionResult delbanner(int id)
        {
            var ctg = c.kecidbanners.Find(id);
            c.kecidbanners.Remove(ctg);
            c.SaveChanges();
            return RedirectToAction("indexbanner");
        }
    }
}