using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        Context c=new Context();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult CurrentSave()
        {

            return PartialView();
        } 
        [HttpPost]
        public PartialViewResult CurrentSave(Current cr)
        {
            c.Currents.Add(cr);
            c.SaveChanges();
            return PartialView();
        }
        [HttpGet]
        public ActionResult CurrentLogin()
        {
            return View();
        }  
        [HttpPost]
        public ActionResult CurrentLogin(Current cr)
        {
            var bilgiler=c.Currents.FirstOrDefault(x=>x.CurrentMail== cr.CurrentMail && x.CurrentPassword==cr.CurrentPassword);
            if(bilgiler!=null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.CurrentMail, false);
                Session["CariMail"]=bilgiler.CurrentMail.ToString();
                return RedirectToAction("Index", "CurrentPanel");

            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        [HttpGet]
        public ActionResult AdminLogin()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin p)
        {
            var bilgiler=c.Admins.FirstOrDefault(x=>x.UserName==p.UserName && x.Password==p.Password);
            if(bilgiler!=null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.UserName,false);
                Session["UserName"]= bilgiler.UserName.ToString();
                return RedirectToAction("Index", "Category");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
      
        }
    }
}