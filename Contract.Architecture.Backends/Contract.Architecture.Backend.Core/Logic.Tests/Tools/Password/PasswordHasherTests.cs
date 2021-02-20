using Contract.Architecture.Backend.Core.Contract.Logic.Tools.Password;
using Contract.Architecture.Backend.Core.Logic.Tools.Password;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Contract.Architecture.Backend.Core.Logic.Tests.Tools.Password
{
    [TestClass]
    public class PasswordHasherTests
    {
        [TestMethod]
        public void GetPasswordHashAndSalt()
        {
            // Arrange
            string password = ")Test&Password123(";
            PasswordHasher passwordHasher = new PasswordHasher();

            // Act
            IPasswordHash passwordHash = passwordHasher.HashPassword(password);
            IPasswordHash passwordHash2 = passwordHasher.HashPassword(password);

            // Assert
            Assert.AreNotEqual(passwordHash.Hash, passwordHash2.Hash);
            Assert.AreNotEqual(passwordHash.Salt, passwordHash2.Salt);
        }

        [TestMethod]
        public void GetPasswordHashOfSalt()
        {
            // Arrange
            string password = ")Test&Password123(";
            string salt = "50000.lrqV9R0IfJiFGjQN1wQvTIlhCPYAwgFS+7WjcjsAjAO/1g==";
            PasswordHasher passwordHasher = new PasswordHasher();

            // Act
            IPasswordHash passwordHash = passwordHasher.HashPassword(password, salt);

            // Assert
            string hash = "dsrVUMMTclkN6d5xky/3/M2ervMlIvPByFA/g7LuORGLl1K6O0oXvKqmN+0/nakTqDhSUu3+tCKrSm8RXNkEng==";

            Assert.AreEqual(hash, passwordHash.Hash);
            Assert.AreEqual(salt, passwordHash.Salt);
        }

        [TestMethod]
        public void ComparePasswords()
        {
            // Arrange
            string password = ")Test&Password123(";
            PasswordHasher passwordHasher = new PasswordHasher();
            IPasswordHash passwordHash = passwordHasher.HashPassword(password);

            // Act
            bool isValid = passwordHasher.ComparePasswords(password, passwordHash.Hash, passwordHash.Salt);

            // Assert
            Assert.IsTrue(isValid);
        }
    }
}