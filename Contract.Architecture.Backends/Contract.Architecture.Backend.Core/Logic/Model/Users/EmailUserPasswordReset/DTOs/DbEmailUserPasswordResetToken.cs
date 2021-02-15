using Contract.Architecture.Backend.Core.Contract.Persistence.Model.Users.EmailUserPasswortReset;
using System;

namespace Contract.Architecture.Backend.Core.Logic.Model.Users.EmailUserPasswordReset
{
    internal class DbEmailUserPasswordResetToken : IDbEmailUserPasswordResetToken
    {
        public DateTime ExpiresOn { get; set; }

        public string Token { get; set; }

        public Guid EmailUserId { get; set; }
    }
}