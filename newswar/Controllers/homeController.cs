using newswar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;


namespace newswar.Controllers
{
    public class homeController : Controller
    {
        // GET: home
        context c = new context();
        public ActionResult home()
        {
            return View();
        }
        public PartialViewResult partmeq()
        {
            var value = c.meqales.Include("meqalesekils").OrderByDescending(x=>x.meqalebaxissayi).FirstOrDefault();
            return PartialView(value);
        }
        public ActionResult news(string sortBY, string p, int? page, int say=5)
        {
            var value = from r in c.meqales.Include("meqalesekils").Include("teqlers") select r;
            if (!string.IsNullOrEmpty(p))
            {
                if (sortBY == "new")
                {
                        value = value.Where(y=>y.teqler.Contains(p) || y.basliq.Contains(p)).OrderBy(x=>x.meqaletarix);
                }
                else if (sortBY == "popular")
                {
                        value = value.Where(y => y.teqler.Contains(p) || y.basliq.Contains(p)).OrderByDescending(x=>x.meqalebaxissayi);
                }
            }
            else
            {
                if (sortBY == "new")
                {
                    value = value.OrderBy(x => x.meqaletarix);
                }
                else if (sortBY == "popular")
                {
                    value = value.OrderByDescending(x => x.meqalebaxissayi);
                }
                else
                {
                    value = value.OrderBy(x => x.meqaletarix);
                }
            }
            return View(value.ToList().ToPagedList(page ?? 1, say));
        }

        public ActionResult allitems(string p, int page = 1)
        {
            var value = from x in c.silahlars.Include("silahsekils").Include("subcategory") select x;
            if (!string.IsNullOrEmpty(p))
            {
                value = value.Where(y => y.silahad.Contains(p));
            }

            return View(value.OrderBy(x => x.silahad).ToList());
        }
        public ActionResult about()
        {
            var values = c.elaqes.ToList();
            return View(values);
        }
        public PartialViewResult partialfooter()
        {
            var values=c.bizs.ToList();
            return PartialView(values);
        }
        public ActionResult partialelaqe()
        {
            var values = c.elaqes.ToList();
            return PartialView(values);
        }
        public ActionResult partialaltbanner()
        {
            var values = c.altbanners.ToList();
            return PartialView(values);
        }
        public ActionResult partialkecid()
        {
            var values = c.kecidbanners.ToList();
            return PartialView(values);
        }
        public ActionResult partialnavbar()
        {
            var values = c.navbars.ToList();
            return PartialView(values);
        }
        public ActionResult partbanner()
        {
            var values = c.meqbanners.ToList();
            return PartialView(values);
        }
        public ActionResult latest()    
        {
            var value = DateTime.Now - TimeSpan.FromDays(7);
            var values = c.meqales.Include("meqalesekils").Where(x => x.meqaletarix > value).Take(3).ToList();
            return PartialView(values);
        }

    }
}