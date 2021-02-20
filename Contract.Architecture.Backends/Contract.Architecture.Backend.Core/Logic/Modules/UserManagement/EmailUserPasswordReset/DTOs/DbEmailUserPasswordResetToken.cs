using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.UserManagement.EmailUserPasswortResetTokens;
using System;

namespace Contract.Architecture.Backend.Core.Logic.Modules.UserManagement.EmailUserPasswordReset
{
    internal class DbEmailUserPasswordResetToken : IDbEmailUserPasswordResetToken
    {
        public DateTime ExpiresOn { get; set; }

        public string Token { get; set; }

        public Guid EmailUserId { get; set; }
    }
}