using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServerHost.Quickstart.UI
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(20, ErrorMessage = "FirstName length can't be more than 20.")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "LastName length can't be more than 20.")]
        public string LastName { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "Username length can't be more than 20.")]
        public string Username { get; set; }
        [Required]
        [MaxLength(50,ErrorMessage ="Password length must be between 8 and 50 characters")]
        [MinLength(8,ErrorMessage = "Password length must be between 8 and 50 characters")]
        public string Password { get; set; }
        [Required]
        [EmailAddress]
        [Remote(action:"CheckEmail",controller:"Register")]
        public string Email { get; set; }
        [Required]
        [Compare("Password",ErrorMessage ="Password and ConfirmPassword does not match")]
        public string ConfirmPassword { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        public string ReturnUrl { get; set; }
    }
}
