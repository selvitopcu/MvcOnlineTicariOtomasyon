using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;


namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class InvoiceController : Controller
    {
        Context c = new Context();
        // GET: Invoice
        public ActionResult Index()
        {
            var liste = c.Invoices.ToList();
            return View(liste);
        }
        [HttpGet]
        public ActionResult InvoiceAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult InvoiceAdd(Invoice invoice)
        {
            c.Invoices.Add(invoice);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult InvoiceGet(int id)
        {
            var fatura = c.Invoices.Find(id);
            return View("InvoiceGet",fatura);

        }
        public ActionResult InvoiceUpdate(Invoice p)
        {
            var fatura = c.Invoices.Find(p.EmployeeID);
            fatura.InvoiceNo = p.InvoiceNo;
            fatura.InvoiceSerialNo= p.InvoiceSerialNo;
            fatura.Hour = p.Hour;
            fatura.Date= p.Date;
            fatura.Receiver = p.Receiver;
            fatura.Submitter = p.Submitter;
            fatura.TaxAdministration = p.TaxAdministration;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult InvoiceDetails(int id)
        {
            var degerler = c.InvoiceItems.Where(x => x.EmployeeID == id).ToList();
         
            return View(degerler);
        }
        [HttpGet]
        public ActionResult NewMove()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMove(InvoiceItem II)
        {
            c.InvoiceItems.Add(II);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DynamcInvoice()
        {
            Class4 cs=new Class4();
            cs.deger1=c.Invoices.ToList();
            cs.deger2=c.InvoiceItems.ToList();
            return View(cs);
        }
        public ActionResult InvoiceSave(string InvoiceNo,string InvoiceSerialNo,DateTime Date,string TaxAdministration,string Hour,string Submitter,string Receiver,string Total, InvoiceItem[] items)
        {
            Invoice f=new Invoice();
            f.InvoiceNo=InvoiceNo;
            f.InvoiceSerialNo=InvoiceSerialNo;
            f.Date=Date;
            f.TaxAdministration=TaxAdministration;
            f.Hour = Hour;
            f.Submitter=Submitter;
            f.Receiver=Receiver;
            f.Total=decimal.Parse(Total);
            c.Invoices.Add(f);
            foreach (var x in items)
            {
                InvoiceItem fk = new InvoiceItem();
                fk.Description = x.Description;
                fk.UnitPrice = x.UnitPrice;
                fk.EmployeeID=x.InvoiceItemID;
                fk.Amount = x.Amount;
                fk.Quantity = x.Quantity;
                c.InvoiceItems.Add(fk);
            }
            c.SaveChanges();
            return Json("İşlem Başarılı", JsonRequestBehavior.AllowGet);
        }
    }
}