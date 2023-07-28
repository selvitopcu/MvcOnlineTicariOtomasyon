using MvcOnlineTicariOtomasyon.Models;
using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class GraphicController : Controller
    {
        // GET: Graphic
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index2()
        {
            var grafikciz = new Chart(600, 600);
            grafikciz.AddTitle("Kategori-Ürün Stok Sayısı").AddLegend("Stok").AddSeries("Değerler", xValue: new[] { "Mobilya", "Ofis Eşyaları", "Bilgisayar" }, yValues: new[] { 85, 65, 98 }).Write();
            return File(grafikciz.ToWebImage().GetBytes(), "image/jpeg");
        }
        Context c = new Context();
        public ActionResult Index3()
        {
            ArrayList xvalue = new ArrayList();
            ArrayList yvalue = new ArrayList();
            var sonuclar = c.Products.ToList();
            sonuclar.ToList().ForEach(x => xvalue.Add(x.ProductName));
            sonuclar.ToList().ForEach(y => yvalue.Add(y.Stock));
            var grafik = new Chart(width: 800, height: 600).AddTitle("Stoklar").AddSeries(chartType: "Pie", name: "Stok", xValue: xvalue, yValues: yvalue);
            return File(grafik.ToWebImage().GetBytes(), "image/jpeg");
        }

        public ActionResult Index4()
        {
            return View();
        }
        public ActionResult VisualizeProductResult()
        {
            return Json(ProductList(), JsonRequestBehavior.AllowGet);
        }
        public List<Class1> ProductList()
        {
            List<Class1> snf = new List<Class1>();
            snf.Add(new Class1()
            {
                ProductName = "Bilgisayar",
                Stock = 150
            });
            snf.Add(new Class1()
            {
                ProductName = "Maobilya",
                Stock = 70
            });
            snf.Add(new Class1()
            {
                ProductName = "Küçük Ev Aletleri",
                Stock = 180
            });
            snf.Add(new Class1()
            {
                ProductName = "Mobil Cihazlar",
                Stock = 90
            });
            return snf;
        }

        public ActionResult Index5()
        {
            return View();
        }
        public ActionResult VisualizeProductResult2()
        {
            return Json(ProductList2(), JsonRequestBehavior.AllowGet);
        }
        public List<Class2> ProductList2()
        {
            List<Class2> snf = new List<Class2>();
            using (var c = new Context())
            {
                snf = c.Products.Select(x => new Class2
                {
                    urun = x.ProductName,
                    stok = x.Stock
                }).ToList();
            }
            return snf;
        }
        public ActionResult Index6()
        {
            return View();
        }
        public ActionResult Index7()
        {
            return View();
        }
    }
}