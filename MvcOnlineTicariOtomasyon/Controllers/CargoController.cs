using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CargoController : Controller
    {
        Context c = new Context();
        // GET: Cargo
        public ActionResult Index(string p)
        {
            var kargo = from x in c.CargoDetails select x;
            if (!string.IsNullOrEmpty(p))
            {
                kargo = kargo.Where(y => y.TrackingCode.Contains(p));
            }
            return View(kargo.ToList());
 
        }
        [HttpGet]
        public ActionResult NewCargo()
        {
            Random rnd = new Random();
            string[] karakterler = { "A", "B", "C", "D" };
            int k1, k2, k3 ;
            k1 = rnd.Next(0, karakterler.Length);
            k2 = rnd.Next(0, karakterler.Length);
            k3 = rnd.Next(0, karakterler.Length);
            int s1, s2, s3;
            s1= rnd.Next(100,1000);
            s2= rnd.Next(10,99);
            s3= rnd.Next(10,99);
            string kod = s1.ToString() + karakterler[k1] + karakterler[k2] + s2 + karakterler[k3] +s3;
            ViewBag.takipkod = kod;
            return View();
        }
        [HttpPost]
        public ActionResult NewCargo(CargoDetail p)
        {
            c.CargoDetails.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CargoTracking(string id)
        {
           
            var degerler = c.CargoTrackings.Where(x=>x.TrackingCode==id).ToList();
            return View(degerler);
        }
    }
}