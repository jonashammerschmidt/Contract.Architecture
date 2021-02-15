using Contract.Architecture.Backend.Core.Persistence.Model.Users.EmailUserPasswortReset;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contract.Architecture.Backend.Core.Persistence.Model.Users.EmailUsers
{
    [Table("EmailUsers")]
    public partial class EfEmailUser
    {
        public EfEmailUser()
        {
            this.EmailUserPasswordResetTokens = new HashSet<EfEmailUserPasswordResetToken>();
        }

        public Guid Id { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public string PasswordSalt { get; set; }

        public virtual ICollection<EfEmailUserPasswordResetToken> EmailUserPasswordResetTokens { get; set; }
    }
}