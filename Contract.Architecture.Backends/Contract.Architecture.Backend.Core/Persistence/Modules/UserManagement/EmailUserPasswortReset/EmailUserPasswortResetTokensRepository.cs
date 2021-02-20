using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.UserManagement.EmailUserPasswortResetTokens;
using System;
using System.Linq;

namespace Contract.Architecture.Backend.Core.Persistence.Modules.UserManagement.EmailUserPasswortReset
{
    internal class EmailUserPasswortResetTokensRepository : IEmailUserPasswortResetTokensRepository
    {
        private readonly PersistenceDbContext context;

        public EmailUserPasswortResetTokensRepository(PersistenceDbContext context)
        {
            this.context = context;
        }

        public IDbEmailUserPasswordResetToken GetToken(string token)
        {
            EfEmailUserPasswordResetToken emailUserPasswordResetToken = this.context.EmailUserPasswordResetTokens.Find(token);
            return DbEmailUserPasswordResetToken.FromEfEmailUserPasswordResetToken(emailUserPasswordResetToken);
        }

        public void CreateToken(IDbEmailUserPasswordResetToken emailUserPasswordResetToken)
        {
            EfEmailUserPasswordResetToken efEmailUserPasswordResetToken = DbEmailUserPasswordResetToken.ToEfEmailUserPasswordResetToken(emailUserPasswordResetToken);
            this.context.EmailUserPasswordResetTokens.Add(efEmailUserPasswordResetToken);
            this.context.SaveChanges();
        }

        public void DeleteToken(string token)
        {
            this.context.EmailUserPasswordResetTokens.Remove(this.context.EmailUserPasswordResetTokens.Find(token));
            this.context.SaveChanges();
        }

        public void DeleteToken(DateTime olderThan)
        {
            var tokensToDelete = this.context.EmailUserPasswordResetTokens
                .Where(attempt => attempt.ExpiresOn < olderThan);

            this.context.EmailUserPasswordResetTokens.RemoveRange(tokensToDelete);
            this.context.SaveChanges();
        }
    }
}