using Contract.Architecture.Backend.Core.Contract.Logic.LogicResults;
using Contract.Architecture.Backend.Core.Contract.Logic.Modules.GegoenntesBankwesen.GegoennteBanken;
using Contract.Architecture.Backend.Core.Contract.Logic.Tools.Identifier;
using Contract.Architecture.Backend.Core.Contract.Logic.Tools.Pagination;
using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.GegoenntesBankwesen.GegoennteBanken;
using Contract.Architecture.Backend.Core.Logic.Modules.GegoenntesBankwesen.GegoennteBanken;
using Contract.Architecture.Backend.Core.Logic.Tests.Tools.Pagination;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Contract.Architecture.Backend.Core.Logic.Tests.Modules.GegoenntesBankwesen.GegoennteBanken
{
    [TestClass]
    public class GegoennteBankenCrudLogicTests
    {
        [TestMethod]
        public void CreateGegoennteBankDefaultTest()
        {
            // Arrange
            Mock<IGegoennteBankenCrudRepository> gegoennteBankenCrudRepository = this.SetupGegoennteBankenCrudRepositoryEmpty();
            Mock<IGuidGenerator> guidGenerator = this.SetupGuidGeneratorDefault();
            var logger = Mock.Of<ILogger<GegoennteBankenCrudLogic>>();

            GegoennteBankenCrudLogic gegoennteBankenCrudLogic = new GegoennteBankenCrudLogic(
                gegoennteBankenCrudRepository.Object,
                guidGenerator.Object,
                logger);

            // Act
            ILogicResult<Guid> result = gegoennteBankenCrudLogic.CreateGegoennteBank(GegoennteBankCreateTest.ForCreate());

            // Assert
            Assert.AreEqual(LogicResultState.Ok, result.State);
            Assert.AreEqual(GegoennteBankTestValues.IdForCreate, result.Data);
            gegoennteBankenCrudRepository.Verify((repository) => repository.CreateGegoennteBank(It.IsAny<IDbGegoennteBank>()), Times.Once);
        }

        [TestMethod]
        public void DeleteGegoennteBankConflictTest()
        {
            Mock<IGegoennteBankenCrudRepository> gegoennteBankenCrudRepository = this.SetupGegoennteBankenCrudRepositoryDeleteConflict();
            Mock<IGuidGenerator> guidGenerator = this.SetupGuidGeneratorDefault();
            var logger = Mock.Of<ILogger<GegoennteBankenCrudLogic>>();

            GegoennteBankenCrudLogic gegoennteBankenCrudLogic = new GegoennteBankenCrudLogic(
                gegoennteBankenCrudRepository.Object,
                guidGenerator.Object,
                logger);

            // Act
            ILogicResult result = gegoennteBankenCrudLogic.DeleteGegoennteBank(GegoennteBankTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.Conflict, result.State);
        }

        [TestMethod]
        public void DeleteGegoennteBankDefaultTest()
        {
            // Arrange
            Mock<IGegoennteBankenCrudRepository> gegoennteBankenCrudRepository = this.SetupGegoennteBankenCrudRepositoryDefaultExists();
            var logger = Mock.Of<ILogger<GegoennteBankenCrudLogic>>();

            GegoennteBankenCrudLogic gegoennteBankenCrudLogic = new GegoennteBankenCrudLogic(
                gegoennteBankenCrudRepository.Object,
                null,
                logger);

            // Act
            ILogicResult result = gegoennteBankenCrudLogic.DeleteGegoennteBank(GegoennteBankTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.Ok, result.State);
            gegoennteBankenCrudRepository.Verify((repository) => repository.DeleteGegoennteBank(GegoennteBankTestValues.IdDefault), Times.Once);
        }

        [TestMethod]
        public void DeleteGegoennteBankNotExistsTest()
        {
            // Arrange
            Mock<IGegoennteBankenCrudRepository> gegoennteBankenCrudRepository = this.SetupGegoennteBankenCrudRepositoryEmpty();
            var logger = Mock.Of<ILogger<GegoennteBankenCrudLogic>>();

            GegoennteBankenCrudLogic gegoennteBankenCrudLogic = new GegoennteBankenCrudLogic(
                gegoennteBankenCrudRepository.Object,
                null,
                logger);

            // Act
            ILogicResult result = gegoennteBankenCrudLogic.DeleteGegoennteBank(GegoennteBankTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.NotFound, result.State);
            gegoennteBankenCrudRepository.Verify((repository) => repository.DeleteGegoennteBank(GegoennteBankTestValues.IdDefault), Times.Never);
        }

        [TestMethod]
        public void GetGegoennteBankDetailDefaultTest()
        {
            // Arrange
            Mock<IGegoennteBankenCrudRepository> gegoennteBankenCrudRepository = this.SetupGegoennteBankenCrudRepositoryDefaultExists();
            var logger = Mock.Of<ILogger<GegoennteBankenCrudLogic>>();

            GegoennteBankenCrudLogic gegoennteBankenCrudLogic = new GegoennteBankenCrudLogic(
                gegoennteBankenCrudRepository.Object,
                null,
                logger);

            // Act
            ILogicResult<IGegoennteBankDetail> result = gegoennteBankenCrudLogic.GetGegoennteBankDetail(GegoennteBankTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.Ok, result.State);
            GegoennteBankDetailTest.AssertDefault(result.Data);
        }

        [TestMethod]
        public void GetGegoennteBankDetailNotExistsTest()
        {
            // Arrange
            Mock<IGegoennteBankenCrudRepository> gegoennteBankenCrudRepository = this.SetupGegoennteBankenCrudRepositoryEmpty();
            var logger = Mock.Of<ILogger<GegoennteBankenCrudLogic>>();

            GegoennteBankenCrudLogic gegoennteBankenCrudLogic = new GegoennteBankenCrudLogic(
                gegoennteBankenCrudRepository.Object,
                null,
                logger);

            // Act
            ILogicResult<IGegoennteBankDetail> result = gegoennteBankenCrudLogic.GetGegoennteBankDetail(GegoennteBankTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.NotFound, result.State);
        }

        [TestMethod]
        public void GetGegoennteBankenDefaultTest()
        {
            // Arrange
            Mock<IGegoennteBankenCrudRepository> gegoennteBankenCrudRepository = this.SetupGegoennteBankenCrudRepositoryDefaultExists();
            var logger = Mock.Of<ILogger<GegoennteBankenCrudLogic>>();

            GegoennteBankenCrudLogic gegoennteBankenCrudLogic = new GegoennteBankenCrudLogic(
                gegoennteBankenCrudRepository.Object,
                null,
                logger);

            // Act
            ILogicResult<IPagedResult<IGegoennteBank>> result = gegoennteBankenCrudLogic.GetGegoennteBanken();

            // Assert
            Assert.AreEqual(LogicResultState.Ok, result.State);
            IGegoennteBank[] gegoennteBankResults = result.Data.Data.ToArray();
            Assert.AreEqual(2, gegoennteBankResults.Length);
            GegoennteBankTest.AssertDefault(gegoennteBankResults[0]);
            GegoennteBankTest.AssertDefault2(gegoennteBankResults[1]);
        }

        [TestMethod]
        public void UpdateGegoennteBankNotExistsTest()
        {
            // Arrange
            Mock<IGegoennteBankenCrudRepository> gegoennteBankenCrudRepository = this.SetupGegoennteBankenCrudRepositoryEmpty();
            var logger = Mock.Of<ILogger<GegoennteBankenCrudLogic>>();

            GegoennteBankenCrudLogic gegoennteBankenCrudLogic = new GegoennteBankenCrudLogic(
                gegoennteBankenCrudRepository.Object,
                null,
                logger);

            // Act
            ILogicResult result = gegoennteBankenCrudLogic.UpdateGegoennteBank(GegoennteBankUpdateTest.ForUpdate());

            // Assert
            Assert.AreEqual(LogicResultState.NotFound, result.State);
            gegoennteBankenCrudRepository.Verify((repository) => repository.UpdateGegoennteBank(DbGegoennteBankTest.Default()), Times.Never);
        }

        [TestMethod]
        public void UpdateGegoennteBankDefaultTest()
        {
            // Arrange
            Mock<IGegoennteBankenCrudRepository> gegoennteBankenCrudRepository = this.SetupGegoennteBankenCrudRepositoryDefaultExists();
            var logger = Mock.Of<ILogger<GegoennteBankenCrudLogic>>();

            GegoennteBankenCrudLogic gegoennteBankenCrudLogic = new GegoennteBankenCrudLogic(
                gegoennteBankenCrudRepository.Object,
                null,
                logger);

            // Act
            ILogicResult result = gegoennteBankenCrudLogic.UpdateGegoennteBank(GegoennteBankUpdateTest.ForUpdate());

            // Assert
            Assert.AreEqual(LogicResultState.Ok, result.State);
            gegoennteBankenCrudRepository.Verify((repository) => repository.UpdateGegoennteBank(It.IsAny<IDbGegoennteBank>()), Times.Once);
        }

        private Mock<IGegoennteBankenCrudRepository> SetupGegoennteBankenCrudRepositoryDefaultExists()
        {
            var gegoennteBankenCrudRepository = new Mock<IGegoennteBankenCrudRepository>(MockBehavior.Strict);
            gegoennteBankenCrudRepository.Setup(repository => repository.DoesGegoennteBankExist(GegoennteBankTestValues.IdDefault)).Returns(true);
            gegoennteBankenCrudRepository.Setup(repository => repository.DoesGegoennteBankExist(GegoennteBankTestValues.IdDefault2)).Returns(true);
            gegoennteBankenCrudRepository.Setup(repository => repository.GetGegoennteBank(GegoennteBankTestValues.IdDefault)).Returns(DbGegoennteBankTest.Default());
            gegoennteBankenCrudRepository.Setup(repository => repository.GetGegoennteBank(GegoennteBankTestValues.IdDefault2)).Returns(DbGegoennteBankTest.Default2());
            gegoennteBankenCrudRepository.Setup(repository => repository.GetGegoennteBankDetail(GegoennteBankTestValues.IdDefault)).Returns(DbGegoennteBankDetailTest.Default());
            gegoennteBankenCrudRepository.Setup(repository => repository.GetGegoennteBankDetail(GegoennteBankTestValues.IdDefault2)).Returns(DbGegoennteBankDetailTest.Default2());
            gegoennteBankenCrudRepository.Setup(repository => repository.GetGegoennteBanken()).Returns(new DbPagedResult<IDbGegoennteBank>()
            {
                Data = new List<IDbGegoennteBank>() { DbGegoennteBankTest.Default(), DbGegoennteBankTest.Default2() },
                TotalCount = 2,
                Count = 2,
                Limit = 20,
                Offset = 0
            });
            gegoennteBankenCrudRepository.Setup(repository => repository.UpdateGegoennteBank(It.IsAny<IDbGegoennteBank>())).Callback((IDbGegoennteBank dbGegoennteBank) =>
            {
                DbGegoennteBankTest.AssertUpdated(dbGegoennteBank);
            });
            gegoennteBankenCrudRepository.Setup(repository => repository.DeleteGegoennteBank(GegoennteBankTestValues.IdDefault));
            gegoennteBankenCrudRepository.Setup(repository => repository.DeleteGegoennteBank(GegoennteBankTestValues.IdDefault2));
            return gegoennteBankenCrudRepository;
        }

        private Mock<IGegoennteBankenCrudRepository> SetupGegoennteBankenCrudRepositoryEmpty()
        {
            var gegoennteBankenCrudRepository = new Mock<IGegoennteBankenCrudRepository>(MockBehavior.Strict);
            gegoennteBankenCrudRepository.Setup(repository => repository.DoesGegoennteBankExist(GegoennteBankTestValues.IdDefault)).Returns(false);
            gegoennteBankenCrudRepository.Setup(repository => repository.DoesGegoennteBankExist(GegoennteBankTestValues.IdDefault2)).Returns(false);
            gegoennteBankenCrudRepository.Setup(repository => repository.GetGegoennteBank(GegoennteBankTestValues.IdDefault)).Returns(() => null);
            gegoennteBankenCrudRepository.Setup(repository => repository.GetGegoennteBank(GegoennteBankTestValues.IdDefault2)).Returns(() => null);
            gegoennteBankenCrudRepository.Setup(repository => repository.GetGegoennteBankDetail(GegoennteBankTestValues.IdDefault)).Returns(() => null);
            gegoennteBankenCrudRepository.Setup(repository => repository.GetGegoennteBankDetail(GegoennteBankTestValues.IdDefault2)).Returns(() => null);
            gegoennteBankenCrudRepository.Setup(repository => repository.CreateGegoennteBank(It.IsAny<IDbGegoennteBank>())).Callback((IDbGegoennteBank dbGegoennteBank) =>
            {
                DbGegoennteBankTest.AssertCreated(dbGegoennteBank);
            });
            return gegoennteBankenCrudRepository;
        }

        private Mock<IGegoennteBankenCrudRepository> SetupGegoennteBankenCrudRepositoryDeleteConflict()
        {
            // Arrange
            var gegoennteBankenCrudRepository = new Mock<IGegoennteBankenCrudRepository>(MockBehavior.Strict);
            gegoennteBankenCrudRepository.Setup(repository => repository.DoesGegoennteBankExist(GegoennteBankTestValues.IdDefault)).Returns(true);
            gegoennteBankenCrudRepository.Setup(repository => repository.DoesGegoennteBankExist(GegoennteBankTestValues.IdDefault2)).Returns(true);
            gegoennteBankenCrudRepository.Setup(repository => repository.DeleteGegoennteBank(GegoennteBankTestValues.IdDefault)).Throws(new Exception());
            gegoennteBankenCrudRepository.Setup(repository => repository.DeleteGegoennteBank(GegoennteBankTestValues.IdDefault2)).Throws(new Exception());
            return gegoennteBankenCrudRepository;
        }

        private Mock<IGuidGenerator> SetupGuidGeneratorDefault()
        {
            var guidGeneration = new Mock<IGuidGenerator>(MockBehavior.Strict);
            guidGeneration.Setup(generator => generator.NewGuid()).Returns(GegoennteBankTestValues.IdForCreate);
            return guidGeneration;
        }
    }
}