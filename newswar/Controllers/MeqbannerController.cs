using newswar.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace newswar.Controllers
{
    public class MeqbannerController : Controller
    {
        // GET: Meqbanner
        context c = new context();
        public ActionResult Index()
        {
            var values = c.meqbanners.ToList();
            return View(values);
        }
        public ActionResult addbanner()
        {
            return View();
        }
        [HttpPost]
        public ActionResult addbanner(meqbanner b)
        {
            if (Request.Files.Count > 0)
            {
                string filename = Path.GetFileName(Request.Files[0].FileName);
                string ex = Path.GetExtension(Request.Files[0].FileName);
                string path = "~/Content/img/" + filename + ex;
                Request.Files[0].SaveAs(Server.MapPath(path));
                b.sekil = "/Content/img/" + filename + ex;

            }
            b.available = true;
            c.meqbanners.Add(b);
            c.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult updbanner(int id)
        {
            var ctgu = c.meqbanners.Find(id);
            return View("updbanner", ctgu);
        }
        [HttpPost]
        public ActionResult updbanner(meqbanner k)
        {
            var kgtu = c.meqbanners.Find(k.bannerid);

            if (Request.Files.Count > 0)
            {
                string filename = Path.GetFileName(Request.Files[0].FileName);
                if (filename== "")
                {
                    
                }
                else
                {

                string ex = Path.GetExtension(Request.Files[0].FileName);
                string path = "~/Content/img/" + filename + ex;
                Request.Files[0].SaveAs(Server.MapPath(path));
                k.sekil = "/Content/img/" + filename + ex;
                }

            }
            kgtu.sekil = k.sekil;
            kgtu.bannerad = k.bannerad;
            kgtu.banneradreng = k.banneradreng;
            kgtu.available = k.available;
            c.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult delbanner(int id)
        {
            var ctg = c.meqbanners.Find(id);
            c.meqbanners.Remove(ctg);
            c.SaveChanges();
            return RedirectToAction("index");
        }
    }
}