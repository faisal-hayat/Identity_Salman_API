﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IdentityWebApi.Models.Authentication.Signup
{
    public class RegisterUser
    {
        [Required(ErrorMessage = "Username is required")]
        public string? Username { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
