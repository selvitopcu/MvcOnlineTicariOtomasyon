using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class IstatisticController : Controller
    {
        Context c = new Context();
        // GET: Istatistic
        public ActionResult Index()
        {
            var deger1 = c.Currents.Count().ToString();
            ViewBag.d1 = deger1;
            var deger2 = c.Products.Count().ToString();
            ViewBag.d2 = deger2;
            var deger3 = c.Employees.Count().ToString();
            ViewBag.d3 = deger3;
            var deger4 = c.Categories.Count().ToString();
            ViewBag.d4 = deger4;
            var deger5 = c.Products.Sum(x => x.Stock).ToString();
            ViewBag.d5 = deger5;
            var deger6 = (from x in c.Products select x.Brand).Distinct().Count().ToString();
            ViewBag.d6 = deger6;
            var deger7 = c.Products.Count(x => x.Stock <= 20).ToString();
            ViewBag.d7 = deger7;
            var deger8 = (from x in c.Products orderby x.ListPrice descending select x.ProductName).FirstOrDefault();
            ViewBag.d8 = deger8;
            var deger9 = (from x in c.Products orderby x.ListPrice ascending select x.ProductName).FirstOrDefault();
            ViewBag.d9 = deger9;
            var deger10 = c.Products.Count(x => x.ProductName == "BuzDolabı").ToString();
            ViewBag.d10 = deger10;
            var deger11 = c.Products.Count(x => x.ProductName == "Laptop").ToString();
            ViewBag.d11 = deger11;
            var deger12 = c.Products.GroupBy(x => x.Brand).OrderByDescending(y => y.Count()).Select(z => z.Key).FirstOrDefault();
            ViewBag.d12 = deger12;
            var deger13 = c.Products.Where(u => u.ProductID == (c.SalesMoves.GroupBy(x => x.ProductID).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault())).Select(k => k.ProductName).FirstOrDefault();
            ViewBag.d13 = deger13;
            var deger14 = c.SalesMoves.Sum(x => x.TotalAmount).ToString();
            ViewBag.d14 = deger14;
            DateTime bugun = DateTime.Today;
            var deger15 = c.SalesMoves.Count(x => x.Date == bugun).ToString();
            ViewBag.d15 = deger15;
            var deger16 = c.SalesMoves.Where(x => x.Date == bugun).Sum(y => (decimal?)y.TotalAmount);
            ViewBag.d16 = deger16;
            //decimal? null olabilir diyor
            return View();
        }
        public ActionResult SimpleTables()
        {
            var sorgu = from x in c.Currents
                        group x by x.CurrentCity into g
                        select new GroupClass
                        {
                            City = g.Key,
                            Number = g.Count()
                        };
            return View(sorgu.ToList());
        }
        public PartialViewResult Partial()
        {
            var sorgu2 = from x in c.Employees
                         group x by x.Department.DepartmentName into g
                         select new GroupClass2
                         {
                             Department = g.Key,
                             Number = g.Count()
                         };
            return PartialView(sorgu2.ToList());
        }
        public PartialViewResult Partial2()
        {
            var sorgu = c.Currents.ToList();
            return PartialView(sorgu);
        }
        public PartialViewResult Partial3()
        {
            var sorgu = c.Products.ToList();
            return PartialView(sorgu);
        }
        public PartialViewResult Partial4()
        {
            var sorgu = from x in c.Products
                         group x by x.Brand into g
                         select new GroupClass3
                         {
                             Brand = g.Key,
                             Number = g.Count()
                         };
            return PartialView(sorgu.ToList());
        }
    }
}