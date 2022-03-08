using newswar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace newswar.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        context c = new context();
        public ActionResult biz()
        {
            var values = c.bizs.ToList();
            return View(values);
        }
        public ActionResult addsosial()
        {
            return View();
        }
        [HttpPost]
        public ActionResult addsosial(biz b)
        {
            c.bizs.Add(b);
            c.SaveChanges();
            return RedirectToAction("biz");
        }
       
        public ActionResult updsoial(int id)
        {
            var ctgu = c.bizs.Find(id);
            return View("updsoial", ctgu);
        }
        [HttpPost]
        public ActionResult updsoial(biz k)
        {
            var kgtu = c.bizs.Find(k.bizid);
            kgtu.sosialad = k.sosialad;
            kgtu.sosiallink = k.sosiallink;
            c.SaveChanges();
            return RedirectToAction("biz");
        }
        public ActionResult delsosial(int id)
        {
            var ctg = c.bizs.Find(id);
            c.bizs.Remove(ctg);
            c.SaveChanges();
            return RedirectToAction("biz");
        }
    }
}