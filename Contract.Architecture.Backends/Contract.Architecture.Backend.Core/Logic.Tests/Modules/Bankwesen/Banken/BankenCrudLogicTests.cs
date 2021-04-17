using Contract.Architecture.Backend.Core.Contract.Logic.LogicResults;
using Contract.Architecture.Backend.Core.Contract.Logic.Modules.Bankwesen.Banken;
using Contract.Architecture.Backend.Core.Contract.Logic.Tools.Identifier;
using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.Bankwesen.Banken;
using Contract.Architecture.Backend.Core.Logic.Modules.Bankwesen.Banken;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Contract.Architecture.Backend.Core.Logic.Tests.Modules.Bankwesen.Banken
{
    [TestClass]
    public class BankenCrudLogicTests
    {
        [TestMethod]
        public void CreateBankDefaultTest()
        {
            // Arrange
            Mock<IBankenCrudRepository> bankenCrudRepository = this.SetupBankenCrudRepositoryEmpty();
            Mock<IGuidGenerator> guidGenerator = this.SetupGuidGeneratorDefault();
            var logger = Mock.Of<ILogger<BankenCrudLogic>>();

            BankenCrudLogic bankenCrudLogic = new BankenCrudLogic(
                bankenCrudRepository.Object,
                guidGenerator.Object,
                logger);

            // Act
            ILogicResult<Guid> result = bankenCrudLogic.CreateBank(BankCreateTest.ForCreate());

            // Assert
            Assert.AreEqual(LogicResultState.Ok, result.State);
            Assert.AreEqual(BankTestValues.IdForCreate, result.Data);
            bankenCrudRepository.Verify((repository) => repository.CreateBank(It.IsAny<IDbBank>()), Times.Once);
        }

        [TestMethod]
        public void DeleteBankConflictTest()
        {
            Mock<IBankenCrudRepository> bankenCrudRepository = this.SetupBankenCrudRepositoryDeleteConflict();
            Mock<IGuidGenerator> guidGenerator = this.SetupGuidGeneratorDefault();
            var logger = Mock.Of<ILogger<BankenCrudLogic>>();

            BankenCrudLogic bankenCrudLogic = new BankenCrudLogic(
                bankenCrudRepository.Object,
                guidGenerator.Object,
                logger);

            // Act
            ILogicResult result = bankenCrudLogic.DeleteBank(BankTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.Conflict, result.State);
        }

        [TestMethod]
        public void DeleteBankDefaultTest()
        {
            // Arrange
            Mock<IBankenCrudRepository> bankenCrudRepository = this.SetupBankenCrudRepositoryDefaultExists();
            var logger = Mock.Of<ILogger<BankenCrudLogic>>();

            BankenCrudLogic bankenCrudLogic = new BankenCrudLogic(
                bankenCrudRepository.Object,
                null,
                logger);

            // Act
            ILogicResult result = bankenCrudLogic.DeleteBank(BankTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.Ok, result.State);
            bankenCrudRepository.Verify((repository) => repository.DeleteBank(BankTestValues.IdDefault), Times.Once);
        }

        [TestMethod]
        public void DeleteBankNotExistsTest()
        {
            // Arrange
            Mock<IBankenCrudRepository> bankenCrudRepository = this.SetupBankenCrudRepositoryEmpty();
            var logger = Mock.Of<ILogger<BankenCrudLogic>>();

            BankenCrudLogic bankenCrudLogic = new BankenCrudLogic(
                bankenCrudRepository.Object,
                null,
                logger);

            // Act
            ILogicResult result = bankenCrudLogic.DeleteBank(BankTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.NotFound, result.State);
            bankenCrudRepository.Verify((repository) => repository.DeleteBank(BankTestValues.IdDefault), Times.Never);
        }

        [TestMethod]
        public void GetBankDetailDefaultTest()
        {
            // Arrange
            Mock<IBankenCrudRepository> bankenCrudRepository = this.SetupBankenCrudRepositoryDefaultExists();
            var logger = Mock.Of<ILogger<BankenCrudLogic>>();

            BankenCrudLogic bankenCrudLogic = new BankenCrudLogic(
                bankenCrudRepository.Object,
                null,
                logger);

            // Act
            ILogicResult<IBankDetail> result = bankenCrudLogic.GetBankDetail(BankTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.Ok, result.State);
            BankDetailTest.AssertDefault(result.Data);
        }

        [TestMethod]
        public void GetBankDetailNotExistsTest()
        {
            // Arrange
            Mock<IBankenCrudRepository> bankenCrudRepository = this.SetupBankenCrudRepositoryEmpty();
            var logger = Mock.Of<ILogger<BankenCrudLogic>>();

            BankenCrudLogic bankenCrudLogic = new BankenCrudLogic(
                bankenCrudRepository.Object,
                null,
                logger);

            // Act
            ILogicResult<IBankDetail> result = bankenCrudLogic.GetBankDetail(BankTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.NotFound, result.State);
        }

        [TestMethod]
        public void GetBankenDefaultTest()
        {
            // Arrange
            Mock<IBankenCrudRepository> bankenCrudRepository = this.SetupBankenCrudRepositoryDefaultExists();
            var logger = Mock.Of<ILogger<BankenCrudLogic>>();

            BankenCrudLogic bankenCrudLogic = new BankenCrudLogic(
                bankenCrudRepository.Object,
                null,
                logger);

            // Act
            ILogicResult<IEnumerable<IBank>> result = bankenCrudLogic.GetBanken();

            // Assert
            Assert.AreEqual(LogicResultState.Ok, result.State);
            IBank[] bankResults = result.Data.ToArray();
            Assert.AreEqual(1, bankResults.Length);
            BankTest.AssertDefault(bankResults[0]);
        }

        [TestMethod]
        public void UpdateBankNotExistsTest()
        {
            // Arrange
            Mock<IBankenCrudRepository> bankenCrudRepository = this.SetupBankenCrudRepositoryEmpty();
            var logger = Mock.Of<ILogger<BankenCrudLogic>>();

            BankenCrudLogic bankenCrudLogic = new BankenCrudLogic(
                bankenCrudRepository.Object,
                null,
                logger);

            // Act
            ILogicResult result = bankenCrudLogic.UpdateBank(BankUpdateTest.ForUpdate());

            // Assert
            Assert.AreEqual(LogicResultState.NotFound, result.State);
            bankenCrudRepository.Verify((repository) => repository.UpdateBank(DbBankTest.Default()), Times.Never);
        }

        [TestMethod]
        public void UpdateBankDefaultTest()
        {
            // Arrange
            Mock<IBankenCrudRepository> bankenCrudRepository = this.SetupBankenCrudRepositoryDefaultExists();
            var logger = Mock.Of<ILogger<BankenCrudLogic>>();

            BankenCrudLogic bankenCrudLogic = new BankenCrudLogic(
                bankenCrudRepository.Object,
                null,
                logger);

            // Act
            ILogicResult result = bankenCrudLogic.UpdateBank(BankUpdateTest.ForUpdate());

            // Assert
            Assert.AreEqual(LogicResultState.Ok, result.State);
            bankenCrudRepository.Verify((repository) => repository.UpdateBank(It.IsAny<IDbBank>()), Times.Once);
        }

        private Mock<IBankenCrudRepository> SetupBankenCrudRepositoryDefaultExists()
        {
            var bankenCrudRepository = new Mock<IBankenCrudRepository>(MockBehavior.Strict);
            bankenCrudRepository.Setup(repository => repository.DoesBankExist(BankTestValues.IdDefault)).Returns(true);
            bankenCrudRepository.Setup(repository => repository.GetBank(BankTestValues.IdDefault)).Returns(DbBankTest.Default());
            bankenCrudRepository.Setup(repository => repository.GetBankDetail(BankTestValues.IdDefault)).Returns(DbBankDetailTest.Default());
            bankenCrudRepository.Setup(repository => repository.GetBanken()).Returns(new List<IDbBank> { DbBankTest.Default() });
            bankenCrudRepository.Setup(repository => repository.UpdateBank(It.IsAny<IDbBank>())).Callback((IDbBank dbBank) =>
            {
                DbBankTest.AssertUpdated(dbBank);
            });
            bankenCrudRepository.Setup(repository => repository.DeleteBank(BankTestValues.IdDefault));
            return bankenCrudRepository;
        }

        private Mock<IBankenCrudRepository> SetupBankenCrudRepositoryEmpty()
        {
            var bankenCrudRepository = new Mock<IBankenCrudRepository>(MockBehavior.Strict);
            bankenCrudRepository.Setup(repository => repository.DoesBankExist(BankTestValues.IdDefault)).Returns(false);
            bankenCrudRepository.Setup(repository => repository.GetBank(BankTestValues.IdDefault)).Returns(() => null);
            bankenCrudRepository.Setup(repository => repository.GetBankDetail(BankTestValues.IdDefault)).Returns(() => null);
            bankenCrudRepository.Setup(repository => repository.CreateBank(It.IsAny<IDbBank>())).Callback((IDbBank dbBank) =>
            {
                DbBankTest.AssertCreated(dbBank);
            });
            return bankenCrudRepository;
        }

        private Mock<IBankenCrudRepository> SetupBankenCrudRepositoryDeleteConflict()
        {
            // Arrange
            var bankenCrudRepository = new Mock<IBankenCrudRepository>(MockBehavior.Strict);
            bankenCrudRepository.Setup(repository => repository.DoesBankExist(BankTestValues.IdDefault)).Returns(true);
            bankenCrudRepository.Setup(repository => repository.DeleteBank(BankTestValues.IdDefault)).Throws(new Exception());
            return bankenCrudRepository;
        }

        private Mock<IGuidGenerator> SetupGuidGeneratorDefault()
        {
            var guidGeneration = new Mock<IGuidGenerator>(MockBehavior.Strict);
            guidGeneration.Setup(generator => generator.NewGuid()).Returns(BankTestValues.IdForCreate);
            return guidGeneration;
        }
    }
}