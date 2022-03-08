using newswar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace newswar.Controllers
{
    public class AltBannerlarController : Controller
    {
        // GET: AltBannerlar
        context c = new context();
        public ActionResult Indexbanner()
        {
            var values = c.altbanners.ToList();
            return View(values);
        }
        public ActionResult addbanner()
        {
            return View();
        }
        [HttpPost]
        public ActionResult addbanner(altbanner b)
        {
            c.altbanners.Add(b);
            c.SaveChanges();
            return RedirectToAction("indexbanner");
        }
        public ActionResult updbanner(int id)
        {
            var ctgu = c.altbanners.Find(id);
            return View("updbanner", ctgu);
        }
        [HttpPost]
        public ActionResult updbanner(altbanner k)
        {
            var kgtu = c.altbanners.Find(k.bannerid);
            kgtu.bannerad = k.bannerad;
            kgtu.bannerbuttontext = k.bannerbuttontext;
            kgtu.bannerbuttonbgcolor = k.bannerbuttonbgcolor;
            kgtu.bannercolor = k.bannercolor;
            kgtu.bannerbuttoncolor = k.bannerbuttoncolor;
            kgtu.bannerphoto = k.bannerphoto;
            c.SaveChanges();
            return RedirectToAction("indexbanner");
        }
        public ActionResult delbanner(int id)
        {
            var ctg = c.altbanners.Find(id);
            c.altbanners.Remove(ctg);
            c.SaveChanges();
            return RedirectToAction("indexbanner");
        }
    }
}