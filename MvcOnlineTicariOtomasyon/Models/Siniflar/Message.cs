using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Message
    {
        [Key]
        public int MessageID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        [Display(Name = "Gönderici")]
        public string Submitter { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        [Display(Name = "Alıcı")]
        public string Receiver { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        [Display(Name = "Konu")]
        public string Subject { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(2000)]
        [Display(Name = "İçerik")]
        public string Content { get; set; }
        [Column(TypeName = "Smalldatetime")]
        public DateTime Date { get; set; }

    }
}