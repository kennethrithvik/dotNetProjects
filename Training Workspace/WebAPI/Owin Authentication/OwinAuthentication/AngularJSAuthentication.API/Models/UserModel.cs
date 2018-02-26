using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AngularJSAuthentication.API.Models
{
    public class UserModel
    {
        [Required]
        [Display(Name = "Employee ID")]
        public int EmpID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FName { get; set; }

        [Display(Name = "Last Name")]
        public string LName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Enter Valid Email")]
        [MaxLength(50)]
        [Display(Name = "Login Name (Email)")]
        public string userName { get; set; }


        [Required]
        [StringLength(14, MinimumLength = 10, ErrorMessage = "Enter Valid Mobile no.")]
        public String MobileNo { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; }

        [Display(Name = "Gender")]
        public Gender Gender { get; set; }
       
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}