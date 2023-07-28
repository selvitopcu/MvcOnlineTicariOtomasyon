using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class SalesMoveController : Controller
    {
        Context c = new Context();
        // GET: SalesMove
        public ActionResult Index()
        {
            var satislar = c.SalesMoves.ToList();
            return View(satislar);
        }
        [HttpGet]
        public ActionResult NewSales()
        {
            List<SelectListItem> urunler = (from x in c.Products.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.ProductName,
                                                Value = x.ProductID.ToString()
                                            }).ToList();

            List<SelectListItem> cariler = (from x in c.Currents.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.CurrentName + " " + x.CurrentSurname,
                                                Value = x.CurrentID.ToString()
                                            }).ToList();

            List<SelectListItem> personeller = (from x in c.Employees.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.EmployeeName + " " + x.EmployeeSurname,
                                                    Value = x.EmployeeID.ToString()
                                                }).ToList();

            ViewBag.urun = urunler;
            ViewBag.cari = cariler;
            ViewBag.personel = personeller;
            return View();
        }
        [HttpPost]
        public ActionResult NewSales(SalesMove s)
        {
            s.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SalesMoves.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SalesGet(int id)
        {
            List<SelectListItem> urunler = (from x in c.Products.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.ProductName,
                                                Value = x.ProductID.ToString()
                                            }).ToList();
            List<SelectListItem> cariler = (from x in c.Currents.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.CurrentName + " " + x.CurrentSurname,
                                                Value = x.CurrentID.ToString()
                                            }).ToList();
            List<SelectListItem> personeller = (from x in c.Employees.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.EmployeeName + " " + x.EmployeeSurname,
                                                    Value = x.EmployeeID.ToString()
                                                }).ToList();

            ViewBag.urun = urunler;
            ViewBag.cari = cariler;
            ViewBag.personel = personeller;
            var deger = c.SalesMoves.Find(id);
            return View("SalesGet", deger);
        }
    
        public ActionResult SalesUpdate(SalesMove sl)
        {
            var deger = c.SalesMoves.Find(sl.SatisID);
            deger.ProductID = sl.ProductID;
            deger.CurrentID= sl.CurrentID;
            deger.EmployeeID = sl.EmployeeID;
            deger.Piece = sl.Piece;
            deger.Price=sl.Price;
            deger.Date = sl.Date;
            deger.TotalAmount = sl.TotalAmount;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SalesDetails(int id)
        {
            var degerler=c.SalesMoves.Where(x=>x.SatisID==id).ToList();
            return View(degerler);
        }
    }
}