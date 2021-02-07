﻿using Contract.Architecture.Contract.Persistence.Model.Users.EmailUserPasswortReset;
using System;

namespace Contract.Architecture.Persistence.Model.Users.EmailUserPasswortReset
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