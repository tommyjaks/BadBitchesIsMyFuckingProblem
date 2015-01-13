using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class EditUserModel
    {
        [Display(Name="Change Firstname:")]
        [Required(ErrorMessage = "firstname required")]
        public string firstname { get; set; }
        [Display(Name = "Change Lastname:")]
        [Required(ErrorMessage = "Lastname required")]
        public string lastname { get; set; }
        [Display(Name = "Change City:")]
        [Required(ErrorMessage = "City is required")]
        public string city { get; set; }
        [Display(Name = "Change Email:")]
        [Required(ErrorMessage = "A valid email is required")]
        [EmailAddress]
        public string email { get; set; }
        [Display(Name = "Change Password:")]
        [Required(ErrorMessage = "Password is required")]
        [RegularExpression(@"^(?:.*[a-z]){7,}$", ErrorMessage = "Password length must be greater than or equal 7 characters.")]
        public string password { get; set; }
        [Display(Name = "Change Username:")]
        [Required(ErrorMessage = "A username is required")]
        public string username { get; set; }
        [Display(Name = "Searchable or not")]
        public bool searchable { get; set; }
    }
}