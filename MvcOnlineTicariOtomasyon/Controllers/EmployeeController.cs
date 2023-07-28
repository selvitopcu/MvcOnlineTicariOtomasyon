using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class EmployeeController : Controller
    {
        Context c = new Context();
        // GET: Employee
        public ActionResult Index()
        {
            var urunler = c.Employees.Where(x => x.Status == true).ToList();
            return View(urunler);
        }
        [HttpGet]
        public ActionResult EmployeeAdd()
        {
            List<SelectListItem> deger1 = (from x in c.Departments.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmentName,
                                               Value = x.DepartmentID.ToString()
                                           }).ToList();
            ViewBag.Deger1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult EmployeeAdd(Employee e)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol= "/Image/" + dosyaadi+ uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                e.EmployeeImage= "/Image/"+dosyaadi+uzanti;
            }
            e.Status = true;
            c.Employees.Add(e);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult EmployeeGet(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Departments.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmentName,
                                               Value = x.DepartmentID.ToString()
                                           }).ToList();
            ViewBag.Deger1 = deger1;
            var urundeger = c.Employees.Find(id);
            return View("EmployeeGet", urundeger);
        }
        public ActionResult EmployeeUpdate(Employee e)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "/Image/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                e.EmployeeImage = "/Image/" + dosyaadi + uzanti;
            }
            var emp = c.Employees.Find(e.EmployeeID);
            emp.EmployeeName=e.EmployeeName;
            emp.EmployeeSurname=e.EmployeeSurname;
            emp.EmployeeImage=e.EmployeeImage;
            emp.DepartmentID = e.DepartmentID;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult EmployeeList()
        {
            var sorgu = c.Employees.ToList();
            return View(sorgu);
        }
    }
}