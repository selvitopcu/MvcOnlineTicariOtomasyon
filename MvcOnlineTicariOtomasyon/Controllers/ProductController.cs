using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;


namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class ProductController : Controller
    {
        Context c = new Context();
        // GET: Product
        public ActionResult Index( string p)
        {
            var urunler = from x in c.Products select x ;
            if (!string.IsNullOrEmpty(p))
            {
                urunler = urunler.Where(y => y.ProductName.Contains(p));
            }
            return View(urunler.ToList());
        }
        [HttpGet]
        public ActionResult NewProduct()
        {
            List<SelectListItem> deger1 = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.Deger1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult NewProduct(Product p)
        {
            c.Products.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ProductDelete(int id)
        {
            var prd = c.Products.Find(id);
            prd.Status = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ProductGet(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.Deger1 = deger1;
            var urundeger = c.Products.Find(id);
            return View("ProductGet", urundeger);
        }
        public ActionResult ProductUpdate(Product p)
        {
            var prd = c.Products.Find(p.ProductID);
            prd.ProductName = p.ProductName;
            prd.Status = p.Status;
            prd.CategoryID = p.CategoryID;
            prd.ListPrice = p.ListPrice;
            prd.Brand = p.Brand;
            prd.UnitPrice = p.UnitPrice;
            prd.Stock = p.Stock;
            prd.ProductImage = p.ProductImage;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ProductList()
        {
            var urunler = c.Products.ToList();
            return View(urunler);
        }
        [HttpGet]
        public ActionResult MakeSale(int id)
        {
            List<SelectListItem> personeller = (from x in c.Employees.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.EmployeeName + " " + x.EmployeeSurname,
                                                    Value = x.EmployeeID.ToString()
                                                }).ToList();
            ViewBag.personel = personeller;
            var urunid = c.Products.Find(id);
            ViewBag.urun = urunid.ProductID;
            ViewBag.satisf = urunid.ListPrice;
            return View();
        }
        [HttpPost]
        public ActionResult MakeSale(SalesMove salesMove)
        {
            salesMove.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SalesMoves.Add(salesMove);
            c.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}