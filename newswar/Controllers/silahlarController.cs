using newswar.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace newswar.Controllers
{
    public class silahlarController : Controller
    {
        context c = new context();
        // GET: silahlar
        public ActionResult Index()
        {
            var values = c.silahlars.Include("Silahsekils").Include("Silahteqlers").ToList();
            return View(values);
        }
        public ActionResult addsilah()
        {
            List<SelectListItem> val = (from x in c.subcategories.Where(x=>x.categoryid==1).ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.subaname,
                                            Value = x.subid.ToString()
                                        }
                                        ).ToList();
            ViewBag.val1 = val;
            return View();
        }
        [HttpPost]
        public ActionResult addsilah(silahlar b, silahsekil d, silahteqler t)
        {

            if (Request.Files.Count > 0)
            {
                string filename = Path.GetFileName(Request.Files[0].FileName);
                string ex = Path.GetExtension(Request.Files[0].FileName);
                string path = "~/Content/img/silah/" + filename + ex;
                Request.Files[0].SaveAs(Server.MapPath(path));
                d.sekilad = "/Content/img/silah/" + filename + ex;

            }
            d.sekilmain = true;
            c.silahlars.Add(b);
            c.silahsekils.Add(d);
            c.silahteqlers.Add(t);
            c.SaveChanges();
            return RedirectToAction("index");
        }

        
        public ActionResult infosilah(int id)
        {
            var value = c.silahlars.Include("Subcategory").FirstOrDefault(x => x.silahid == id);
            return View(value);
        }
        [HttpPost]
        public ActionResult infosilah(silahlar b, silahsekil d, silahteqler t)
        {

            if (Request.Files.Count > 0)
            {
                string filename = Path.GetFileName(Request.Files[0].FileName);
                string ex = Path.GetExtension(Request.Files[0].FileName);
                string path = "~/Content/img/silah/" + filename + ex;
                Request.Files[0].SaveAs(Server.MapPath(path));
                d.sekilad = "/Content/img/silah/" + filename + ex;

            }
            d.sekilmain = true;
            c.silahlars.Add(b);
            c.silahsekils.Add(d);
            c.silahteqlers.Add(t);
            c.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult delsekil(int id)
        {
            var values = c.silahsekils.FirstOrDefault(x => x.sekilid == id);
            c.silahsekils.Remove(values);
            c.SaveChanges();
            return Redirect(Request.UrlReferrer.ToString());

        }

   
        public ActionResult delsilah(FormCollection formCollection)
        {

            // TODO: Perform the delete from a repository


            string[] ids = formCollection["silahid"].Split(new char[] { ',' });
            foreach (string idi in ids)
            {
                var employee = this.c.silahlars.Find(int.Parse(idi));
                this.c.silahlars.Remove(employee);
                c.SaveChanges();
            }

            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult addsekil(int id, silahsekil ms)
        {


            if (Request.Files.Count > 0)
            {
                string filename = Path.GetFileName(Request.Files[0].FileName);
                string ex = Path.GetExtension(Request.Files[0].FileName);
                string path = "~/Content/img/silah/" + filename + ex;
                Request.Files[0].SaveAs(Server.MapPath(path));
                ms.sekilad = "/Content/img/silah/" + filename + ex;

            }
            ms.silahid = id;
            var val = c.silahsekils.Where(x => x.silahid == id).ToList();
            if (val.Count == 0)
            {
                ms.sekilmain = true;
            }
            else
            {

                ms.sekilmain = false;
            }
            c.silahsekils.Add(ms);
            c.SaveChanges();
            return Redirect(Request.UrlReferrer.ToString());

        }

        public ActionResult infosilahuser(int id)
        {
            var value = c.silahlars.Include("Subcategory").FirstOrDefault(x => x.silahid == id);
            return View(value);
        }

        public PartialViewResult benzerpartial(int id)
        {
            var value = c.silahlars.Find(id);
            var values = c.silahlars.Where(x => x.subcategoryid == value.subcategoryid).ToList();
            return PartialView(values);
        }
    }
}