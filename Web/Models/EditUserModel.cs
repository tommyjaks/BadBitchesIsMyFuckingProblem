using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class EditUserModel
    {
        [Required(ErrorMessage = "First Name is a Required field.")]
        [DataType(DataType.Text)]
        [Display(Name = "First Name")]
        [StringLength(100, ErrorMessage = "First Name Max Length is 100")]
        public string firstname { get; set; }

        [Required(ErrorMessage = "Last Name is a Required field.")]
        [DataType(DataType.Text)]
        [Display(Name = "Last Name")]
        [StringLength(100, ErrorMessage = "Last Name Max Length is 100")]
        public string lastname { get; set; }

        [Required(ErrorMessage = "City is a Required field.")]
        [DataType(DataType.Text)]
        [Display(Name = "City")]
        [StringLength(100, ErrorMessage = "City Max Length is 100")]
        public string city { get; set; }

        [Display(Name = "Email")]
        [Required]
        [EmailAddress]
        public string email { get; set; }

        [Display(Name = "Password")]
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Display(Name = "Confirm password")]
        [Required]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("password", ErrorMessage = "The password and confirmation password do not match.")]
        public string confirmPassword { get; set; }

        [Required]
        [Display(Name = "User name")]
        [RegularExpression(@"[^\s]+", ErrorMessage = "Username is required and must be properly formatted.")]
        [Remote("CheckIfUsernameExists", "Image", HttpMethod = "POST", ErrorMessage = "User name already exists. Please enter a different user name.")]
        public string username { get; set; }

        [Display(Name = "Searchable or not")]
        public bool searchable { get; set; }
    }
}