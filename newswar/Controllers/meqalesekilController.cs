using newswar.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace newswar.Controllers
{
    public class meqalesekilController : Controller
    {
        // GET: meqalesekil
        context c = new context();
        public ActionResult Index(int id)
        {
            var values = c.meqalesekils.FirstOrDefault(x => x.sekilid == id);
            return View(values);
        }
        [HttpPost]
        public ActionResult Index(meqalesekil ms)
        {
            var vlue = c.meqalesekils.Find(ms.sekilid);
            vlue.sekilmain = ms.sekilmain;
            c.SaveChanges();
            return RedirectToAction("Indexmeq", "meqale");
        }

        public ActionResult deleteimg(int id)
        {
            var values = c.meqalesekils.FirstOrDefault(x => x.sekilid == id);
            c.meqalesekils.Remove(values);
            c.SaveChanges();
            return Redirect(Request.UrlReferrer.ToString());

        }

        public ActionResult addimg(int id, meqalesekil ms)
        {
            
            
            if (Request.Files.Count > 0)
            {
                string filename = Path.GetFileName(Request.Files[0].FileName);
                string ex = Path.GetExtension(Request.Files[0].FileName);
                string path = "~/Content/img/meqale/" + filename + ex;
                Request.Files[0].SaveAs(Server.MapPath(path));
                ms.sekilad = "/Content/img/meqale/" + filename + ex;

            }
            ms.Meqaleid = id;
            var val = c.meqales.Where(x => x.meqaleid == id).ToList();
            if (val.Count ==0)
            {
                ms.sekilmain = true;
            }
            else
            {
                
                ms.sekilmain = false;
            }
            c.meqalesekils.Add(ms);
            c.SaveChanges();
            return Redirect(Request.UrlReferrer.ToString());

        }

        public ActionResult mainchange(int id, meqalesekil ms)
        {
            var value = c.meqalesekils.Find(id);
            ms.sekilmain = value.sekilmain;
            c.SaveChanges();
            return RedirectToAction("indexmeq", "meqale");
        }
    }
}