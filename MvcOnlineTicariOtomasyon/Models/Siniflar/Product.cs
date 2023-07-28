using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        [Display(Name ="Ürün Adı")]
        [Column(TypeName ="Varchar")]
        [StringLength(30)]
        public string ProductName { get; set; }
        [Display(Name = "Ürün Markası")]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Brand { get; set; }
        [Display(Name = "Ürün Stok")]
        public short Stock { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        [Display(Name = "Ürün Görseli")]
        public string ProductImage { get; set; }

        [Display(Name = "Alış Fiyatı")]
        public decimal UnitPrice { get; set; }
        [Display(Name = "Satış Fiyatı")]
        public decimal ListPrice { get; set; }
        public bool Status { get; set; }    
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public ICollection<SalesMove> SalesMoves { get; set; }
    }
}