using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class ProductDetailsController : Controller
    {
        Context c = new Context();
        // GET: ProductDetails
        public ActionResult Index()
        {
            ProDetailsDes pd=new ProDetailsDes();
            pd.Deger1=c.Products.Where(x=>x.ProductID==1).ToList();
            pd.Deger2=c.Details.Where(x=>x.DetailID==1).ToList();
            //var degerler = c.Products.Where(x=>x.ProductID==id).ToList();
            return View(pd);
        }
    }
}