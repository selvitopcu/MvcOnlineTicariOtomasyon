using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Controllers;
using MvcOnlineTicariOtomasyon.Models.Siniflar;
using PagedList;
using PagedList.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CategoryController : Controller
    {
        Context c = new Context();
        // GET: Category
        [HttpGet]
        public ActionResult Index(int sayfa=1)
        {
            var degerler = c.Categories.ToList().ToPagedList(sayfa,4);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult CategoryAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CategoryAdd(Category k)
        {
            c.Categories.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CategoryDelete(int id)
        {
            var ktg = c.Categories.Find(id);
            c.Categories.Remove(ktg);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CategoryGet(int id)
        {
            var kategori=c.Categories.Find(id);
            return View("CategoryGet",kategori);
        }
        public ActionResult CategoryUpdate(Category cat)
        {
            var ktgr=c.Categories.Find(cat.CategoryID);
            ktgr.CategoryName = cat.CategoryName;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Deneme()
        {
            Class3 cs= new Class3();
            cs.Categories = new SelectList(c.Categories, "CategoryID", "CategoryName");
            cs.Products = new SelectList(c.Products, "ProductID", "ProductName");
            return View(cs);
        }
        public JsonResult ProductGet(int p)
        {
            var urunlist = (from x in c.Products
                            join y in c.Categories
                            on x.Category.CategoryID equals y.CategoryID
                            where x.Category.CategoryID == p
                            select new
                            {
                                Text = x.ProductName,
                                value = x.ProductID.ToString()
                            }).ToList();
            return Json(urunlist, JsonRequestBehavior.AllowGet);
        }
    }
}