using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class GalleryController : Controller
    {
        Context c = new Context();
        // GET: Gallery
        public ActionResult Index()
        {
            var gorseller=c.Products.ToList();
            return View(gorseller);
        }
    }
}