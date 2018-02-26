using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCDemo.Models
{
    public class Cab_Cust
    {

        [ForeignKey("cabdata"), Key]
        [Column(Order = 0)]
        public int? CabRefId { get; set; }
        //Nullable type in c#
        public virtual CabData cabdata { get; set; }

        [ForeignKey("customer"), Key]
        [Column(Order = 1)]
        public int? CustomerRefId { get; set; }
        public virtual Customer customer { get; set; }


        [ForeignKey("driver"), Key]
        [Column(Order = 2)]
        public int? DriverRefId { get; set; }
        public virtual Driver driver { get; set; }
    }
}