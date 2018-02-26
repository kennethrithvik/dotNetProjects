using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCDemo.Models
{
    public class CabData
    {
        [Key]
        public int CabNo { get; set; }
        public CarType CabType { get; set; }
        public int Capacity { get; set; }
      
    }
}