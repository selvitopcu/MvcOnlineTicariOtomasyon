using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class InvoiceItem
    {
        [Key]
        public int InvoiceItemID { get; set; }
        [Column(TypeName = "Varchar")]
        [Display(Name = "Açıklama")]
        [StringLength(100)]
        public string Description { get; set; }
        [Display(Name = "Miktar")]
        public int Quantity { get; set; }
        [Display(Name = "Birim Fiyat")]
        public decimal UnitPrice { get; set; }
        [Display(Name = "Tutar")]
        public decimal Amount { get; set; }
        public int EmployeeID { get; set; }
        public virtual Invoice Invoice { get; set; }
    }
}