using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace corepractice.Models
{
    public class User
    {
        [Key]
        [Required]
        [Display(Name = "User Id")]
        public int UserId { get; set; }

        [StringLength(50)]
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(128, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [Display(Name = "Password")]
        [RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$", ErrorMessage = "Passwords must be at least 8 characters and contain at 3 of 4 of the following: upper case (A-Z), lower case (a-z), number (0-9) and special character (e.g. !@#$%^&*)")]
        public string Password { get; set; }

        //[DataType(DataType.Password)]
        //[Display(Name = "Confirm password")]
        //[Compare("Password", ErrorMessage = "The passwords do not match.")]
        //public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(100, ErrorMessage = "{0} must be at least {2} characters long.", MinimumLength = 2)]
        public string Firstname { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(100, ErrorMessage = "{0} must be at least {2} characters long.", MinimumLength = 2)]
        public string Lastname { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Of Birth")]
        public DateTime DateOfBirth { get; set; }

        [StringLength(256)]
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        //[Required]
        //[EmailAddress]
        //[Compare("Email", ErrorMessage = "The email addresses do not match.")]
        //[Display(Name = "Confirmation Email")]
        //public string EmailConfirm { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string Mobile { get; set; }

        [Required]
        [Display(Name = "Group Index")]
        public int GroupIndex { get; set; }
    }
}
