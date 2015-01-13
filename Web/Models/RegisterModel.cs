using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class RegisterModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "First Name is a Required field.")]
        [DataType(DataType.Text)]
        [Display(Name = "First Name")]
        [StringLength(100, ErrorMessage = "First Name Max Length is 100")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Last Name is a Required field.")]
        [DataType(DataType.Text)]
        [Display(Name = "Last Name")]
        [StringLength(100, ErrorMessage = "Last Name Max Length is 100")]
        public string Lastname { get; set; }

        [Required]
        [Display(Name = "User name")]
        [RegularExpression(@"[^\s]+", ErrorMessage = "Username is required and must be properly formatted.")]
        [Remote("CheckIfUsernameExists", "Image", HttpMethod = "POST", ErrorMessage = "User name already exists. Please enter a different user name.")]
        public string Username { get; set; }

        [Display(Name = "Gender")]
        [Required]
        [RegularExpression("Female|Male|female|male", ErrorMessage = "Male or Female!")]
        public string Gender { get; set; }

        [Display(Name = "Email")]
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm password")]
        [Required]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "City is a Required field.")]
        [DataType(DataType.Text)]
        [Display(Name = "City")]
        [StringLength(100, ErrorMessage = "City Max Length is 100")]
        public string City { get; set; }

        [Display(Name = "Age")]
        [Required]
        public Nullable<int> Age { get; set; }

        [Display(Name = "Image")]
        public string img_path { get; set; }

        [Display(Name = "Searchable")]
        public bool Searchable { get; set; }
    }
}