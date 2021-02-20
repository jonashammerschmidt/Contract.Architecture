using System.ComponentModel.DataAnnotations;

namespace Contract.Architecture.Backend.Core.API.Modules.LoginSystem.EmailUserLogin
{
    public class EmailUserLogin
    {
        [Required]
        [EmailAddress]
        [StringLength(256, MinimumLength = 1)]
        public string Email { get; set; }

        [Required]
        [StringLength(256, MinimumLength = 8)]
        public string Password { get; set; }
    }
}