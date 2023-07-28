using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{

    [Authorize]
   
    public class DepartmentController : Controller
    {
        Context c = new Context();
        // GET: Department
        public ActionResult Index()
        {
            var degerler = c.Departments.Where(x=>x.Status==true).ToList();
            return View(degerler);
        }
        [HttpGet]
        [Authorize(Roles = "A")]
        public ActionResult DepartmentAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DepartmentAdd(Department d)
        {
            c.Departments.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmentDelete(int id)
        {
            var dep = c.Departments.Find(id);
            dep.Status = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmentGet(int id)
        {
            var dpt = c.Departments.Find(id);
            return View("DepartmentGet", dpt);
        }
        public ActionResult DepartmentUpdate(Department d)
        {
            var dpt = c.Departments.Find(d.DepartmentID);
            dpt.DepartmentName = d.DepartmentName;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmentDetails(int id)
        {
            var degerler=c.Employees.Where(x=>x.EmployeeID==id).ToList();
            var dpt=c.Departments.Where(x=>x.DepartmentID==id).Select(y=>y.DepartmentName).FirstOrDefault();
            ViewBag.d=dpt;
            return View(degerler);
        }
        public ActionResult DepartmentEmployeeSales(int id)
        {
            var degerler=c.SalesMoves.Where(x=>x.EmployeeID==id).ToList();
         var per=c.Employees.Where(x=>x.EmployeeID==id).Select(y=>y.EmployeeName + y.EmployeeSurname).FirstOrDefault();
            ViewBag.dpers=per;
            return View(degerler);
        }
    }
}