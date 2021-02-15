﻿using Contract.Architecture.Backend.Core.Persistence.Modules.Users.EmailUsers;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contract.Architecture.Backend.Core.Persistence.Modules.Users.EmailUserPasswortReset
{
    [Table("EmailUserPasswordResetTokens")]
    public partial class EfEmailUserPasswordResetToken
    {
        public string Token { get; set; }

        public Guid EmailUserId { get; set; }

        public DateTime ExpiresOn { get; set; }

        public virtual EfEmailUser EmailUser { get; set; }
    }
}