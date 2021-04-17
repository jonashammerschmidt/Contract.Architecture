using Contract.Architecture.Backend.Core.Contract.Logic.LogicResults;
using Contract.Architecture.Backend.Core.Contract.Logic.Modules.Kundenstamm.Kunden;
using Contract.Architecture.Backend.Core.Contract.Logic.Tools.Identifier;
using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.Bankwesen.Banken;
using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.Kundenstamm.Kunden;
using Contract.Architecture.Backend.Core.Logic.Modules.Kundenstamm.Kunden;
using Contract.Architecture.Backend.Core.Logic.Tests.Modules.Bankwesen.Banken;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Contract.Architecture.Backend.Core.Logic.Tests.Modules.Kundenstamm.Kunden
{
    [TestClass]
    public class KundenCrudLogicTests
    {
        [TestMethod]
        public void CreateKundeDefaultTest()
        {
            // Arrange
            Mock<IKundenCrudRepository> kundenCrudRepository = this.SetupKundenCrudRepositoryEmpty();
            Mock<IBankenCrudRepository> bankenCrudRepository = this.SetupBankenRepositoryDefault();
            Mock<IGuidGenerator> guidGenerator = this.SetupGuidGeneratorDefault();
            var logger = Mock.Of<ILogger<KundenCrudLogic>>();

            KundenCrudLogic kundenCrudLogic = new KundenCrudLogic(
                kundenCrudRepository.Object,
                bankenCrudRepository.Object,
                guidGenerator.Object,
                logger);

            // Act
            ILogicResult<Guid> result = kundenCrudLogic.CreateKunde(KundeCreateTest.ForCreate());

            // Assert
            Assert.AreEqual(LogicResultState.Ok, result.State);
            Assert.AreEqual(KundeTestValues.IdForCreate, result.Data);
            kundenCrudRepository.Verify((repository) => repository.CreateKunde(It.IsAny<IDbKunde>()), Times.Once);
        }

        [TestMethod]
        public void DeleteKundeConflictTest()
        {
            Mock<IKundenCrudRepository> kundenCrudRepository = this.SetupKundenCrudRepositoryDeleteConflict();
            Mock<IGuidGenerator> guidGenerator = this.SetupGuidGeneratorDefault();
            var logger = Mock.Of<ILogger<KundenCrudLogic>>();

            KundenCrudLogic kundenCrudLogic = new KundenCrudLogic(
                kundenCrudRepository.Object,
                null,
                guidGenerator.Object,
                logger);

            // Act
            ILogicResult result = kundenCrudLogic.DeleteKunde(KundeTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.Conflict, result.State);
        }

        [TestMethod]
        public void DeleteKundeDefaultTest()
        {
            // Arrange
            Mock<IKundenCrudRepository> kundenCrudRepository = this.SetupKundenCrudRepositoryDefaultExists();
            var logger = Mock.Of<ILogger<KundenCrudLogic>>();

            KundenCrudLogic kundenCrudLogic = new KundenCrudLogic(
                kundenCrudRepository.Object,
                null,
                null,
                logger);

            // Act
            ILogicResult result = kundenCrudLogic.DeleteKunde(KundeTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.Ok, result.State);
            kundenCrudRepository.Verify((repository) => repository.DeleteKunde(KundeTestValues.IdDefault), Times.Once);
        }

        [TestMethod]
        public void DeleteKundeNotExistsTest()
        {
            // Arrange
            Mock<IKundenCrudRepository> kundenCrudRepository = this.SetupKundenCrudRepositoryEmpty();
            var logger = Mock.Of<ILogger<KundenCrudLogic>>();

            KundenCrudLogic kundenCrudLogic = new KundenCrudLogic(
                kundenCrudRepository.Object,
                null,
                null,
                logger);

            // Act
            ILogicResult result = kundenCrudLogic.DeleteKunde(KundeTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.NotFound, result.State);
            kundenCrudRepository.Verify((repository) => repository.DeleteKunde(KundeTestValues.IdDefault), Times.Never);
        }

        [TestMethod]
        public void GetKundeDetailDefaultTest()
        {
            // Arrange
            Mock<IKundenCrudRepository> kundenCrudRepository = this.SetupKundenCrudRepositoryDefaultExists();
            var logger = Mock.Of<ILogger<KundenCrudLogic>>();

            KundenCrudLogic kundenCrudLogic = new KundenCrudLogic(
                kundenCrudRepository.Object,
                null,
                null,
                logger);

            // Act
            ILogicResult<IKundeDetail> result = kundenCrudLogic.GetKundeDetail(KundeTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.Ok, result.State);
            KundeDetailTest.AssertDefault(result.Data);
        }

        [TestMethod]
        public void GetKundeDetailNotExistsTest()
        {
            // Arrange
            Mock<IKundenCrudRepository> kundenCrudRepository = this.SetupKundenCrudRepositoryEmpty();
            var logger = Mock.Of<ILogger<KundenCrudLogic>>();

            KundenCrudLogic kundenCrudLogic = new KundenCrudLogic(
                kundenCrudRepository.Object,
                null,
                null,
                logger);

            // Act
            ILogicResult<IKundeDetail> result = kundenCrudLogic.GetKundeDetail(KundeTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.NotFound, result.State);
        }

        [TestMethod]
        public void GetKundenDefaultTest()
        {
            // Arrange
            Mock<IKundenCrudRepository> kundenCrudRepository = this.SetupKundenCrudRepositoryDefaultExists();
            var logger = Mock.Of<ILogger<KundenCrudLogic>>();

            KundenCrudLogic kundenCrudLogic = new KundenCrudLogic(
                kundenCrudRepository.Object,
                null,
                null,
                logger);

            // Act
            ILogicResult<IEnumerable<IKunde>> result = kundenCrudLogic.GetKunden();

            // Assert
            Assert.AreEqual(LogicResultState.Ok, result.State);
            IKunde[] kundeResults = result.Data.ToArray();
            Assert.AreEqual(1, kundeResults.Length);
            KundeTest.AssertDefault(kundeResults[0]);
        }

        [TestMethod]
        public void UpdateKundeNotExistsTest()
        {
            // Arrange
            Mock<IKundenCrudRepository> kundenCrudRepository = this.SetupKundenCrudRepositoryEmpty();
            Mock<IBankenCrudRepository> bankenCrudRepository = this.SetupBankenRepositoryDefault();
            var logger = Mock.Of<ILogger<KundenCrudLogic>>();

            KundenCrudLogic kundenCrudLogic = new KundenCrudLogic(
                kundenCrudRepository.Object,
                bankenCrudRepository.Object,
                null,
                logger);

            // Act
            ILogicResult result = kundenCrudLogic.UpdateKunde(KundeUpdateTest.ForUpdate());

            // Assert
            Assert.AreEqual(LogicResultState.NotFound, result.State);
            kundenCrudRepository.Verify((repository) => repository.UpdateKunde(DbKundeTest.Default()), Times.Never);
        }

        [TestMethod]
        public void UpdateKundeDefaultTest()
        {
            // Arrange
            Mock<IKundenCrudRepository> kundenCrudRepository = this.SetupKundenCrudRepositoryDefaultExists();
            Mock<IBankenCrudRepository> bankenCrudRepository = this.SetupBankenRepositoryDefault();
            var logger = Mock.Of<ILogger<KundenCrudLogic>>();

            KundenCrudLogic kundenCrudLogic = new KundenCrudLogic(
                kundenCrudRepository.Object,
                bankenCrudRepository.Object,
                null,
                logger);

            // Act
            ILogicResult result = kundenCrudLogic.UpdateKunde(KundeUpdateTest.ForUpdate());

            // Assert
            Assert.AreEqual(LogicResultState.Ok, result.State);
            kundenCrudRepository.Verify((repository) => repository.UpdateKunde(It.IsAny<IDbKunde>()), Times.Once);
        }

        private Mock<IKundenCrudRepository> SetupKundenCrudRepositoryDefaultExists()
        {
            var kundenCrudRepository = new Mock<IKundenCrudRepository>(MockBehavior.Strict);
            kundenCrudRepository.Setup(repository => repository.DoesKundeExist(KundeTestValues.IdDefault)).Returns(true);
            kundenCrudRepository.Setup(repository => repository.GetKunde(KundeTestValues.IdDefault)).Returns(DbKundeTest.Default());
            kundenCrudRepository.Setup(repository => repository.GetKundeDetail(KundeTestValues.IdDefault)).Returns(DbKundeDetailTest.Default());
            kundenCrudRepository.Setup(repository => repository.GetKunden()).Returns(new List<IDbKunde> { DbKundeTest.Default() });
            kundenCrudRepository.Setup(repository => repository.UpdateKunde(It.IsAny<IDbKunde>())).Callback((IDbKunde dbKunde) =>
            {
                DbKundeTest.AssertUpdated(dbKunde);
            });
            kundenCrudRepository.Setup(repository => repository.DeleteKunde(KundeTestValues.IdDefault));
            return kundenCrudRepository;
        }

        private Mock<IKundenCrudRepository> SetupKundenCrudRepositoryEmpty()
        {
            var kundenCrudRepository = new Mock<IKundenCrudRepository>(MockBehavior.Strict);
            kundenCrudRepository.Setup(repository => repository.DoesKundeExist(KundeTestValues.IdDefault)).Returns(false);
            kundenCrudRepository.Setup(repository => repository.GetKunde(KundeTestValues.IdDefault)).Returns(() => null);
            kundenCrudRepository.Setup(repository => repository.GetKundeDetail(KundeTestValues.IdDefault)).Returns(() => null);
            kundenCrudRepository.Setup(repository => repository.CreateKunde(It.IsAny<IDbKunde>())).Callback((IDbKunde dbKunde) =>
            {
                DbKundeTest.AssertCreated(dbKunde);
            });
            return kundenCrudRepository;
        }

        private Mock<IKundenCrudRepository> SetupKundenCrudRepositoryDeleteConflict()
        {
            // Arrange
            var kundenCrudRepository = new Mock<IKundenCrudRepository>(MockBehavior.Strict);
            kundenCrudRepository.Setup(repository => repository.DoesKundeExist(KundeTestValues.IdDefault)).Returns(true);
            kundenCrudRepository.Setup(repository => repository.DeleteKunde(KundeTestValues.IdDefault)).Throws(new Exception());
            return kundenCrudRepository;
        }

        private Mock<IGuidGenerator> SetupGuidGeneratorDefault()
        {
            var guidGeneration = new Mock<IGuidGenerator>(MockBehavior.Strict);
            guidGeneration.Setup(generator => generator.NewGuid()).Returns(KundeTestValues.IdForCreate);
            return guidGeneration;
        }

        private Mock<IBankenCrudRepository> SetupBankenRepositoryDefault()
        {
            var bankenCrudRepository = new Mock<IBankenCrudRepository>(MockBehavior.Strict);
            bankenCrudRepository.Setup(repository => repository.DoesBankExist(BankTestValues.IdDefault)).Returns(true);
            bankenCrudRepository.Setup(repository => repository.DoesBankExist(BankTestValues.IdForCreate)).Returns(true);
            bankenCrudRepository.Setup(repository => repository.DoesBankExist(BankTestValues.IdForUpdate)).Returns(true);
            return bankenCrudRepository;
        }
    }
}