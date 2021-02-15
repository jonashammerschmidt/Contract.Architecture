using Contract.Architecture.Backend.Core.Contract.Persistence.Model.Users.EmailUsers;
using Contract.Architecture.Backend.Core.Persistence.Model.Users.EmailUserPasswortReset;
using Contract.Architecture.Backend.Core.Persistence.Model.Users.EmailUsers;
using Contract.Architecture.Backend.Core.Persistence.Tests.Mocking;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Contract.Architecture.Backend.Core.Persistence.Tests.Model.Users.EmailUserPasswordResetTokens
{
    [TestClass]
    public class EmailUserPasswortResetTokensRepositoryTests
    {
        private static readonly Guid EmailUserId = Guid.Parse("a4533231-7b3d-44c5-b843-3cc5e6ddc3c6");

        private static readonly string Token1 = "UDGywIO7BEWT269CsJekdwrp0eZto8TEGKmAEE6hHt4Q";
        private static readonly string Token2 = "kdwrp0eZto8TEGKmAEE6hHt4QUDGywIO7BEWT269CsJe";

        private static readonly DateTime Time1 = new DateTime(2020, 1, 1, 0, 0, 0);
        private static readonly DateTime Time2 = new DateTime(2020, 1, 1, 0, 20, 0);
        private static readonly DateTime TimeOlderThan = new DateTime(2020, 1, 1, 0, 10, 0);

        [TestMethod]
        public void CreateTokenAndGetTokenTest()
        {
            // Arrange
            InMemoryRepositories repos = new InMemoryRepositories();
            EmailUsersRepository emailUsersRepository = repos.GetEmailUsersRepository();
            IDbEmailUser emailUserToAdd = DbEmailUserMocking.CreateWithMandant();
            emailUsersRepository.CreateEmailUser(emailUserToAdd);

            EmailUserPasswortResetTokensRepository emailUserPasswordResetTokenRepository = repos.GetEmailUserPasswordResetTokenRepository();

            // Act
            var emailUserPasswordResetTokenToAdd = new DbEmailUserPasswordResetToken()
            {
                Token = Token1,
                EmailUserId = EmailUserId,
                ExpiresOn = Time1
            };
            emailUserPasswordResetTokenRepository.CreateToken(emailUserPasswordResetTokenToAdd);

            // Assert
            var token = emailUserPasswordResetTokenRepository.GetToken(Token1);

            Assert.AreEqual(emailUserPasswordResetTokenToAdd.Token, token.Token);
            Assert.AreEqual(emailUserPasswordResetTokenToAdd.EmailUserId, token.EmailUserId);
            Assert.AreEqual(emailUserPasswordResetTokenToAdd.ExpiresOn, token.ExpiresOn);
        }

        [TestMethod]
        public void DeleteTokenTest()
        {
            // Arrange
            InMemoryRepositories repos = new InMemoryRepositories();
            EmailUsersRepository emailUsersRepository = repos.GetEmailUsersRepository();
            IDbEmailUser emailUserToAdd = DbEmailUserMocking.CreateWithMandant();
            emailUsersRepository.CreateEmailUser(emailUserToAdd);

            EmailUserPasswortResetTokensRepository emailUserPasswordResetTokenRepository = repos.GetEmailUserPasswordResetTokenRepository();

            var emailUserPasswordResetTokenToAdd = new DbEmailUserPasswordResetToken()
            {
                Token = Token1,
                EmailUserId = EmailUserId,
                ExpiresOn = Time1
            };
            emailUserPasswordResetTokenRepository.CreateToken(emailUserPasswordResetTokenToAdd);

            // Act
            emailUserPasswordResetTokenRepository.DeleteToken(Token1);

            // Assert
            var token = emailUserPasswordResetTokenRepository.GetToken(Token1);
            Assert.IsNull(token);
        }

        [TestMethod]
        public void DeleteTokenOlderThanTest()
        {
            // Arrange
            InMemoryRepositories repos = new InMemoryRepositories();

            EmailUsersRepository emailUsersRepository = repos.GetEmailUsersRepository();
            IDbEmailUser emailUserToAdd = DbEmailUserMocking.CreateWithMandant();
            emailUsersRepository.CreateEmailUser(emailUserToAdd);

            EmailUserPasswortResetTokensRepository emailUserPasswordResetTokenRepository = repos.GetEmailUserPasswordResetTokenRepository();

            var emailUserPasswordResetTokenToAdd = new DbEmailUserPasswordResetToken() { Token = Token1, EmailUserId = EmailUserId, ExpiresOn = Time1 };
            var emailUserPasswordResetTokenToAdd2 = new DbEmailUserPasswordResetToken() { Token = Token2, EmailUserId = EmailUserId, ExpiresOn = Time2 };
            emailUserPasswordResetTokenRepository.CreateToken(emailUserPasswordResetTokenToAdd);
            emailUserPasswordResetTokenRepository.CreateToken(emailUserPasswordResetTokenToAdd2);

            // Act
            emailUserPasswordResetTokenRepository.DeleteToken(TimeOlderThan);

            // Assert
            var token1 = emailUserPasswordResetTokenRepository.GetToken(Token1);
            Assert.IsNull(token1);
            var token2 = emailUserPasswordResetTokenRepository.GetToken(Token2);
            Assert.IsNotNull(token2);
        }
    }
}