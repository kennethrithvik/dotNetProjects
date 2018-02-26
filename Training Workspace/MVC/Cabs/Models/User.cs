using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Cabs.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required]
        [StringLength(25, ErrorMessage = "Name should be less than 25 characters")]
        [Display(Name = "Cust Name")]
        public String UserName { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Mobile no. is 10 digits only")]
        public String MobileNo { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The Password must be at least 6 characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The Password must be at least 6 characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Passwords not matching")]
        [NotMapped]
        public string ConfirmPassword { get; set; }
    }
}