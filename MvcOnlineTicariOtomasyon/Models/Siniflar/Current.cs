using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Current
    {
        [Key]
        public int CurrentID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage="En fazla 30 karakter yazailirsiniz.")]
        public string CurrentName { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz.")]
        public string CurrentSurname { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(13)]
        public string CurrentCity { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string CurrentMail { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string CurrentPassword { get; set; }
        public bool Status { get; set; }
        public ICollection<SalesMove> SalesMoves { get; set; }
    }
}