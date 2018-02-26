using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Carwala.Models
{
    public class Car
    {
        [Key]
        public int CarID { get; set; }
        public String Name { get; set; }
        public String Model { get; set; }
        public int Price { get; set; }
        public String Image { get; set; }
        public String Description { get; set; }
        
    }
}