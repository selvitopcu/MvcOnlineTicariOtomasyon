using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        [Display(Name = "Kategori Adı")]
        public string CategoryName { get; set; } 

        public ICollection<Product> Products { get; set; }
    }
}