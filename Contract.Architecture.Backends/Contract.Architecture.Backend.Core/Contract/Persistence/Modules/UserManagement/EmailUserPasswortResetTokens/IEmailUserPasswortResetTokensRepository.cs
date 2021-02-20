using System;

namespace Contract.Architecture.Backend.Core.Contract.Persistence.Modules.Users.EmailUserPasswortReset
{
    public interface IEmailUserPasswortResetTokensRepository
    {
        void CreateToken(IDbEmailUserPasswordResetToken emailUserPasswordResetToken);

        void DeleteToken(string token);

        void DeleteToken(DateTime olderThan);

        IDbEmailUserPasswordResetToken GetToken(string token);
    }
}