using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models
{
    public class CargoTracking
    {
        [Key]
        public int CargoTrackingID { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(10)]
        public string TrackingCode { get; set; } //1234123AB

        [Column(TypeName = "VarChar")]
        [StringLength(100)]
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}