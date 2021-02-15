using Contract.Architecture.Backend.Core.Contract.Logic.Model.Users.EmailUserPasswordReset;
using System.ComponentModel.DataAnnotations;

namespace Contract.Architecture.Backend.Core.API.Model.Users.EmailUserPasswordReset
{
    public class BrowserInfo : IBrowserInfo
    {
        [Required]
        [StringLength(64, MinimumLength = 1)]
        public string Browser { get; set; }

        [Required]
        [StringLength(64, MinimumLength = 1)]
        public string OperatingSystem { get; set; }
    }
}