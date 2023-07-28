using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Invoice
    {
        [Key]
        public int EmployeeID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(1)]
        public string InvoiceNo { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(6)]
        public string InvoiceSerialNo { get; set; }
        [Display(Name = "Tarih")]
        public DateTime Date { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(60)]
        [Display(Name = "Vergi Dairesi")]
        public string TaxAdministration
        { get; set; }
        [Display(Name = "Saat")]
        public string Hour { get; set; }
        [Column(TypeName = "Varchar")]
        [Display(Name = "Teslim Eden")]
        [StringLength(30)]
        public string Submitter { get; set; }
        [Column(TypeName = "Varchar")]
        [Display(Name = "Teslim Alan")]
        [StringLength(30)]
        public string Receiver { get; set; }
        [Display(Name = "Toplam")]
        public decimal Total { get; set; }
        public ICollection<InvoiceItem> InvoiceItems { get; set; }
    }
}