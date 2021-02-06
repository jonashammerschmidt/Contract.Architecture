﻿using System.ComponentModel.DataAnnotations;

namespace Contract.Architecture.API.Model.Users.EmailUserPasswordReset
{
    public class ResetPassword
    {
        [Required]
        [StringLength(64)]
        public string Token { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "Mindestens acht Zeichen, mindestens ein Großbuchstabe, ein Kleinbuchstabe, eine Zahl und ein Sonderzeichen.")]
        public string NewPassword { get; set; }
    }
}