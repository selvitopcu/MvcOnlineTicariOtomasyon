using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class ToDoController : Controller
    {
        Context c= new Context();
        // GET: ToDo
        public ActionResult Index()
        {

            var cariler= c.Currents.Count().ToString();
            ViewBag.cari= cariler;
            var urunler= c.Products.Count().ToString();
            ViewBag.urun= urunler;
            var kategoriler= c.Categories.Count().ToString();
            ViewBag.kategori= kategoriler;
            var sehirler=(from x in c.Currents select x.CurrentCity).Distinct().Count().ToString();
            ViewBag.sehir = sehirler;

            var yapilacaklar = c.ToDoes.ToList();
            return View(yapilacaklar);

        }
    }
}