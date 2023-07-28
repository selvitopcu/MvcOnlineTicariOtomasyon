using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    [Authorize]
    public class CurrentPanelController : Controller
    {
        Context c = new Context();
        [Authorize]
        // GET: CurrentPanel
        public ActionResult Index()
        {
            var carimail = (string)Session["CariMail"];
            var degerler = c.Messages.Where(x => x.Receiver == carimail).ToList();
            ViewBag.m = carimail;
            var mailid = c.Currents.Where(x => x.CurrentMail == carimail).Select(y => y.CurrentID).FirstOrDefault();
            ViewBag.mid = mailid;
            var toplamsatis = c.SalesMoves.Where(x => x.CurrentID == mailid).Count();
            ViewBag.tsatis = toplamsatis;
            var toplamtutar = c.SalesMoves.Where(x => x.CurrentID == mailid).Sum(y => y.TotalAmount);
            ViewBag.ttutar = toplamtutar;
            var toplamurunsayisi = c.SalesMoves.Where(x => x.CurrentID == mailid).Sum(y => y.Piece);
            ViewBag.turun = toplamurunsayisi;
            var adsoyad = c.Currents.Where(x => x.CurrentMail == carimail).Select(y => y.CurrentName + " " + y.CurrentSurname).FirstOrDefault();
            ViewBag.adsoyad = adsoyad;
            return View(degerler);

        }
        public ActionResult MyOrders()
        {
            var carimail = (string)Session["CariMail"];
            var id = c.Currents.Where(x => x.CurrentMail == carimail.ToString()).Select(y => y.CurrentID).FirstOrDefault();
            var degerler = c.SalesMoves.Where(x => x.CurrentID == id).ToList();
            return View(degerler);
        }

        public ActionResult IncomingMessage()
        {
            var mail = (string)Session["CariMail"];
            var mesajlar = c.Messages.Where(x => x.Receiver == mail).OrderByDescending(x => x.MessageID).ToList();
            var gidensayisi = c.Messages.Count(x => x.Submitter == mail).ToString();
            var gelensayisi = c.Messages.Count(x => x.Receiver == mail).ToString();
            ViewBag.gms = gelensayisi;
            ViewBag.gims = gidensayisi;
            return View(mesajlar);
        }
        public ActionResult OutgoingMessage()
        {
            var mail = (string)Session["CariMail"];
            var mesajlar = c.Messages.Where(x => x.Submitter == mail).OrderByDescending(x => x.MessageID).ToList();
            var gidensayisi = c.Messages.Count(x => x.Submitter == mail).ToString();
            var gelensayisi = c.Messages.Count(x => x.Receiver == mail).ToString();
            ViewBag.gms = gelensayisi;
            ViewBag.gims = gidensayisi;
            return View(mesajlar);
        }
        public ActionResult MessageDetails(int id)
        {
            var degerler = c.Messages.Where(x => x.MessageID == id).ToList();
            var mail = (string)Session["CariMail"];
            var mesajlar = c.Messages.Where(x => x.Submitter == mail).ToList();
            var gidensayisi = c.Messages.Count(x => x.Submitter == mail).ToString();
            var gelensayisi = c.Messages.Count(x => x.Receiver == mail).ToString();
            ViewBag.gms = gelensayisi;
            ViewBag.gims = gidensayisi;
            return View(degerler);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            var mail = (string)Session["CariMail"];
            var mesajlar = c.Messages.Where(x => x.Submitter == mail).ToList();
            var gidensayisi = c.Messages.Count(x => x.Submitter == mail).ToString();
            var gelensayisi = c.Messages.Count(x => x.Receiver == mail).ToString();
            ViewBag.gms = gelensayisi;
            ViewBag.gims = gidensayisi;
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message m)
        {
            var mail = (string)Session["CariMail"];
            m.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            m.Submitter = mail;
            c.Messages.Add(m);
            c.SaveChanges();
            return View();
        }
        public ActionResult CargoTracking(string p)
        {
            var kargo = from x in c.CargoDetails select x;
            kargo = kargo.Where(y => y.TrackingCode.Contains(p));
            return View(kargo.ToList());
        }
        public ActionResult CurrentCargoTracking(string id)
        {
            var degerler = c.CargoTrackings.Where(x => x.TrackingCode == id).ToList();
            return View(degerler);
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
        public PartialViewResult ProfileSetting()
        {
            var carimail = (string)Session["CariMail"];
            var id = c.Currents.Where(x => x.CurrentMail == carimail).Select(y => y.CurrentID).FirstOrDefault();
            var caribul = c.Currents.Find(id);
            return PartialView("ProfileSetting", caribul);
        }
        public PartialViewResult Announcement()
        {
            var veriler = c.Messages.Where(x => x.Submitter=="admin").ToList();
            return PartialView(veriler);
        }
        public ActionResult CurrentInformationUpdate(Current current )
        {
            var cari = c.Currents.Find(current.CurrentID);
            cari.CurrentName = current.CurrentName;
            cari.CurrentSurname = current.CurrentSurname;
            cari.CurrentPassword = current.CurrentPassword;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}