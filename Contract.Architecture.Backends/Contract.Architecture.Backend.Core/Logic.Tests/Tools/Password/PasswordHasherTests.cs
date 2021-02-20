using Contract.Architecture.Backend.Core.Contract.Logic.Services.Password;
using Contract.Architecture.Backend.Core.Logic.Tools.Password;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Contract.Architecture.Backend.Core.Logic.Tests.Services.Password
{
    [TestClass]
    public class PasswordHasherTests
    {
        [TestMethod]
        public void GetPasswordHashAndSalt()
        {
            // Arrange
            string password = ")Test&Password123(";
            PasswordHasher PasswordHasher = new PasswordHasher();

            // Act
            IPasswordHash passwordHash = PasswordHasher.HashPassword(password);
            IPasswordHash passwordHash2 = PasswordHasher.HashPassword(password);

            // Assert
            Assert.AreNotEqual(passwordHash.PasswordHash, passwordHash2.PasswordHash);
            Assert.AreNotEqual(passwordHash.Salt, passwordHash2.Salt);
        }

        [TestMethod]
        public void GetPasswordHashOfSalt()
        {
            // Arrange
            string password = ")Test&Password123(";
            string salt = "50000.lrqV9R0IfJiFGjQN1wQvTIlhCPYAwgFS+7WjcjsAjAO/1g==";
            PasswordHasher PasswordHasher = new PasswordHasher();

            // Act
            IPasswordHash passwordHash = PasswordHasher.HashPassword(password, salt);

            // Assert
            string hash = "dsrVUMMTclkN6d5xky/3/M2ervMlIvPByFA/g7LuORGLl1K6O0oXvKqmN+0/nakTqDhSUu3+tCKrSm8RXNkEng==";

            Assert.AreEqual(hash, passwordHash.PasswordHash);
            Assert.AreEqual(salt, passwordHash.Salt);
        }

        [TestMethod]
        public void ComparePasswords()
        {
            // Arrange
            string password = ")Test&Password123(";
            PasswordHasher PasswordHasher = new PasswordHasher();
            IPasswordHash passwordHash = PasswordHasher.HashPassword(password);

            // Act
            bool isValid = PasswordHasher.ComparePasswords(password, passwordHash.PasswordHash, passwordHash.Salt);

            // Assert
            Assert.IsTrue(isValid);
        }
    }
}