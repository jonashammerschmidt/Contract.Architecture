using Contract.Architecture.Backend.Core.Contract.Logic.Tools.Identifier;
using Contract.Architecture.Backend.Core.Logic.Tools.Identifier;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Text.RegularExpressions;

namespace Contract.Architecture.Backend.Core.Logic.Tests.Tools.Identifier
{
    [TestClass]
    public class SHA256TokenGeneratorTests
    {
        [TestMethod]
        public void GenerateTests()
        {
            // Arrange
            Mock<IGuidGenerator> guidGenerator = this.SetupGuidGeneratorDefault();

            var sha256 = new SHA256TokenGenerator(guidGenerator.Object);

            // Act
            var token = sha256.Generate();

            // Assert
            var isMatch = new Regex("\\b[A-Fa-f0-9]{64}\\b").IsMatch(token);
            Assert.IsTrue(isMatch);
        }

        private Mock<IGuidGenerator> SetupGuidGeneratorDefault()
        {
            var guidGenerator = new Mock<IGuidGenerator>(MockBehavior.Strict);
            guidGenerator.Setup(generator => generator.NewGuid()).Returns(Guid.NewGuid());
            return guidGenerator;
        }
    }
}