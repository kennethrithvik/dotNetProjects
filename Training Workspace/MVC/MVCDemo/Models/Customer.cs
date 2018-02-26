using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCDemo.Models
{
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CustomerID { get; set; }

        [Required]
        [StringLength(25,ErrorMessage="Name should be less than 25 characters")]
        [Display(Name="Cust Name")]
        public String CustomerName { get; set; }

        [Required]
        [StringLength(10,MinimumLength=10,ErrorMessage="Mobile no. is 10 digits only")]
        public String  MobileNo { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name="Date of Birth")]
        public DateTime DOB { get; set; }

        [Required]
        [Range(1,500,ErrorMessage="Trvel Range should be only from 1 to 500 kms")]
        public int RangeOfTravel { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [MaxLength(50)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}",ErrorMessage="Please enter valid Email Address")]
        public string Email { get; set; }
    }
}