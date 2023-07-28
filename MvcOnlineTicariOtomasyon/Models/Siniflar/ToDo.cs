using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models
{
    public class ToDo
    {
        [Key]
        public int ToDoID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Title { get; set; }
        [Column(TypeName = "Bit")]
        public bool Status { get; set; }

    }
}