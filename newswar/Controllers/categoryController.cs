using newswar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace newswar.Controllers
{
    public class categoryController : Controller
    {
        context c = new context();
        // GET: category
        public ActionResult Index()
        {
            var values = c.categories.ToList();
            return View(values);
        }
        public ActionResult addcat()
        {
            return View();
        }
        [HttpPost]
        public ActionResult addcat(category d)
        {
            c.categories.Add(d);
            c.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult infocat(int id)
        {
            var values = c.categories.Include("subcategories").FirstOrDefault(x=>x.categoryid==id);
            return View(values);
        }

        public PartialViewResult addsubcati()
        {
            
            return PartialView();
        }


        [HttpPost]
        public ActionResult infocat(int id, subcategory d)
        {
            d.categoryid = id;
            c.subcategories.Add(d);
            c.SaveChanges();
            return Redirect(Request.UrlReferrer.ToString());
        }
        public ActionResult delsubcat(int id, silahlar s)
        {
            var val = c.subcategories.Find(id);
            c.subcategories.Remove(val);
            var value = c.silahlars.FirstOrDefault(x => x.subcategoryid == id);
            if (value is null)
            {

            }
            else
            {
                c.silahlars.Remove(value);
                    
            }
            c.SaveChanges();
            return Redirect(Request.UrlReferrer.ToString());
        }   
    }
}