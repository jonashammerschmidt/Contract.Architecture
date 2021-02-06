﻿using System.ComponentModel.DataAnnotations;

namespace Contract.Architecture.API.Model.Users.EmailUserPasswordReset
{
    public class ForgotPassword
    {
        [Required]
        [EmailAddress]
        [StringLength(256, MinimumLength = 1)]
        public string Email { get; set; }
    }
}