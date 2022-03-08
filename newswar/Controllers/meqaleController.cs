using newswar.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace newswar.Controllers
{
    public class meqaleController : Controller
    {
        // GET: meqale
        context c = new context();
        public ActionResult indexmeq(string sortBY, string p, int? page, int say = 5)
        {

            var value = from r in c.meqales.Include("meqalesekils").Include("teqlers").OrderByDescending(x => x.meqaletarix) select r;
            if (!string.IsNullOrEmpty(p))
            {
                if (sortBY == "new")
                {
                    value = value.Where(y => y.teqler.Contains(p) || y.basliq.Contains(p)).OrderByDescending(x => x.meqaletarix);
                }
                else if (sortBY == "popular")
                {
                    value = value.Where(y => y.teqler.Contains(p) || y.basliq.Contains(p)).OrderByDescending(x => x.meqalebaxissayi);
                }
                else if (sortBY == "letter")
                {
                    value = value.OrderBy(x=>x.basliq);
                }
            }
            else
            {
                if (sortBY == "new")
                {
                    value = value.OrderByDescending(x => x.meqaletarix);
                }
                else if (sortBY == "popular")
                {
                    value = value.OrderByDescending(x => x.meqalebaxissayi);
                }
                else if (sortBY == "letter")
                {
                    value = value.OrderBy(x => x.basliq);
                }
                else
                {
                    value = value.OrderByDescending(x => x.meqaletarix);
                }
            }
            return View(value.ToList().ToPagedList(page ?? 1, say));
        }
        public ActionResult addmeq()
        {
            List<SelectListItem> val = (from x in c.subcategories.Where(x=>x.categoryid==2).ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.subaname,
                                            Value = x.subid.ToString()
                                        }
                                        ).ToList();

            List<SelectListItem> value = (from x in c.teqlers.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.teqad,
                                            Value = x.teqid.ToString()
                                        }
                                        ).ToList();
            ViewBag.val1 = val;
            ViewBag.val2 = value;
            return View();
        }
        [HttpPost]
        public ActionResult addmeq(meqale b, meqalesekil d, teqler t)
        {
      
            if (Request.Files.Count > 0)
            {
                string filename = Path.GetFileName(Request.Files[0].FileName);
                string ex = Path.GetExtension(Request.Files[0].FileName);
                string path = "~/Content/img/meqale/" + filename + ex;
                Request.Files[0].SaveAs(Server.MapPath(path));
                d.sekilad = "/Content/img/meqale/" + filename + ex;
                
            }
            b.meqaletarix= DateTime.Parse(DateTime.Now.ToShortDateString());
            d.sekilmain = true;
            b.teqler = b.teqler.Remove(0, 1);
            c.meqales.Add(b);
            c.meqalesekils.Add(d);
            //foreach (var item in t.teqad)
            //{
            //    item.ToString().Substring(1);
            //}
            //t.teqad = t.teqad.Remove(0,1);
            //c.teqlers.Add(t);

            c.SaveChanges();
            return RedirectToAction("indexmeq");
        }
        public ActionResult updmeq(int id)
        {
            var ctgu = c.meqales.FirstOrDefault(x=>x.meqaleid == id);
            return View("updmeq", ctgu);
        }
        [HttpPost]
        public ActionResult updmeq(meqale k, meqalesekil ms, teqler t)
        {
           
            var kgtu = c.meqales.FirstOrDefault(x=>x.meqaleid==k.meqaleid);
            var kgt = c.meqalesekils.FirstOrDefault(x => x.Meqaleid == ms.Meqaleid);
            kgt.sekilmain = ms.sekilmain;
            if (Request.Files.Count > 0)
            {
                string filename = Path.GetFileName(Request.Files[0].FileName);
                string ex = Path.GetExtension(Request.Files[0].FileName);
                string path = "~/Content/img/" + filename + ex;
                Request.Files[0].SaveAs(Server.MapPath(path));
                ms.sekilad = "/Content/img/" + filename + ex;

            }

            var kg = c.teqlers.FirstOrDefault(x => x.Meqaleid == t.Meqaleid);
            kgtu.uzundetal = k.uzundetal;
            kgtu.qisadetal = k.qisadetal;
            kgtu.basliq = k.basliq;
            kg.teqad=t.teqad;
            c.meqalesekils.Add(ms);
            c.SaveChanges();
            return RedirectToAction("indexmeq");
        }
        public ActionResult delmeq(FormCollection formCollection)
        {

                // TODO: Perform the delete from a repository
             

            string[] ids = formCollection["meqaleid"].Split(new char[] { ',' });
            foreach (string idi in ids)
            {
                var employee = this.c.meqales.Find(int.Parse(idi));
                this.c.meqales.Remove(employee);
                c.SaveChanges();
            }

            c.SaveChanges();
            return RedirectToAction("indexmeq");
        }

        public ActionResult infomeq(int id)
        {
            var values = c.meqales.Include("meqalesekils").Include("teqlers").SingleOrDefault(x=>x.meqaleid==id);
            return View("infomeq", values);
        }

        public ActionResult infomequser(int id, visitor visitor, meqale m)
        {
            var values = c.meqales.Include("meqalesekils").Include("teqlers").SingleOrDefault(x => x.meqaleid == id);
            IPHostEntry iphostinfo = Dns.GetHostEntry(Dns.GetHostName());
            string ipaddress = Convert.ToString(iphostinfo.AddressList.FirstOrDefault(address=>address.AddressFamily==System.Net.Sockets.AddressFamily.InterNetwork));

            //MacId
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = mc.GetInstances();
            string MacAddress = String.Empty;
            foreach (ManagementObject mo in moc)
            {
                if (MacAddress==String.Empty)
                {
                    if ((bool)mo["IPEnabled"] == true) MacAddress = mo["MacAddress"].ToString();
                }
                mo.Dispose();
            }
            MacAddress = MacAddress.Replace(":", "-");

            //add db
            visitor.IpAddress = ipaddress;
            visitor.MacId = MacAddress;
            visitor.meqaleid = id;

            //int meqsay = c.meqales.FirstOrDefault(x => x.meqaleid == id).meqalebaxissayi;
            m.meqaleid = id;
            //m.meqalebaxissayi ++;
            //meqsay = m.meqalebaxissayi;

            m.meqalebaxissayi = m.meqalebaxissayi + 1;
            values.meqalebaxissayi = m.meqalebaxissayi;
            c.visitors.Add(visitor);
            //var valuem = c.meqales.FirstOrDefault(x => x.meqaleid == id).meqalebaxissayi + 1;
            //valuem = m.meqalebaxissayi;


            c.SaveChanges();

            return View("infomequser", values);
        }
        public PartialViewResult latestuser()
        {
            var value = DateTime.Now - TimeSpan.FromDays(7);
            var values = c.meqales.Include("meqalesekils").Where(x => x.meqaletarix >value).Take(3).ToList();
            return PartialView(values);
        }
        public ActionResult updbasliq(int id)
        {
            var value = c.meqales.Find(id);
            return View("updbasliq", value);
        }


        [HttpPost]
        public ActionResult updbasliq(meqale m)
        {
            var value = c.meqales.Find(m.meqaleid);
            value.basliq = m.basliq;
            c.SaveChanges();
            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult updqisa(int id)
        {
            var value = c.meqales.Find(id);
            return View("updqisa", value);
        }


        [HttpPost]
        public ActionResult updqisa(meqale m)
        {
            var value = c.meqales.Find(m.meqaleid);
            value.qisadetal = m.qisadetal;
            c.SaveChanges();
            return Redirect(Request.UrlReferrer.ToString());
        }

        

        public ActionResult upduzun(int id)
        {
            var value = c.meqales.Find(id);
            return View("upduzun", value);
        }


        [HttpPost]
        public ActionResult upduzun(meqale m)
        {
            var value = c.meqales.Find(m.meqaleid);
            value.uzundetal = m.uzundetal;
            c.SaveChanges();
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}