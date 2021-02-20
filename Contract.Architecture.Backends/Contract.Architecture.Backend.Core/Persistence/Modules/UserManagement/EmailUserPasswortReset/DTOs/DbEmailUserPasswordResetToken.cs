using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.UserManagement.EmailUserPasswortResetTokens;
using System;

namespace Contract.Architecture.Backend.Core.Persistence.Modules.UserManagement.EmailUserPasswortReset
{
    internal class DbEmailUserPasswordResetToken : IDbEmailUserPasswordResetToken
    {
        public string Token { get; set; }

        public Guid EmailUserId { get; set; }

        public DateTime ExpiresOn { get; set; }

        public static IDbEmailUserPasswordResetToken FromEfEmailUserPasswordResetToken(EfEmailUserPasswordResetToken efEmailUserPasswordResetToken)
        {
            if (efEmailUserPasswordResetToken == null)
            {
                return null;
            }

            return new DbEmailUserPasswordResetToken()
            {
                Token = efEmailUserPasswordResetToken.Token,
                EmailUserId = efEmailUserPasswordResetToken.EmailUserId,
                ExpiresOn = efEmailUserPasswordResetToken.ExpiresOn
            };
        }

        public static EfEmailUserPasswordResetToken ToEfEmailUserPasswordResetToken(IDbEmailUserPasswordResetToken emailUserPasswordResetToken)
        {
            return new EfEmailUserPasswordResetToken()
            {
                Token = emailUserPasswordResetToken.Token,
                EmailUserId = emailUserPasswordResetToken.EmailUserId,
                ExpiresOn = emailUserPasswordResetToken.ExpiresOn
            };
        }
    }
}