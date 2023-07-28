using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CurrentController : Controller
    {
        Context c = new Context();
        // GET: Current
        public ActionResult Index()
        {
            var degerler = c.Currents.Where(x => x.Status == true).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult NewCurrent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewCurrent(Current cr)
        {
            cr.Status = true;
            c.Currents.Add(cr);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CurrentDelete(int id)
        {
            var crd = c.Currents.Find(id);
            crd.Status = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CurrentGet(int id)
        {
            var urundeger = c.Currents.Find(id);
            return View("CurrentGet", urundeger);
        }
        public ActionResult CurrentUpdate(Current cr)
        {
            if (!ModelState.IsValid)
            {
                return View("CurrentGet");
            }
            else
            {
                var cari = c.Currents.Find(cr.CurrentID);
                cari.CurrentName = cr.CurrentName;
                cari.CurrentSurname = cr.CurrentSurname;
                cari.CurrentCity = cr.CurrentCity;
                cari.CurrentMail = cr.CurrentMail;
                c.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        public ActionResult CustomerSales(int id)
        {
            var degerler = c.SalesMoves.Where(x => x.CurrentID == id).ToList();
            var cr=c.Currents.Where(x=>x.CurrentID == id).Select(y=>y.CurrentName+" "+ y.CurrentSurname).FirstOrDefault();
            ViewBag.cari=cr;
            return View(degerler);

        }

    }
}