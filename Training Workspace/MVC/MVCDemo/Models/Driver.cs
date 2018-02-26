using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCDemo.Models
{
    public class Driver
    {
        [Key]
        public int DriverID { get; set; }
        public String DriverName { get; set; }
        public int MobileNo { get; set; }
       
        [ForeignKey("cabdata")]
        public int? CabRefId { get; set; }
        //Nullable type in c#
        public virtual CabData cabdata { get; set; }
    }
}