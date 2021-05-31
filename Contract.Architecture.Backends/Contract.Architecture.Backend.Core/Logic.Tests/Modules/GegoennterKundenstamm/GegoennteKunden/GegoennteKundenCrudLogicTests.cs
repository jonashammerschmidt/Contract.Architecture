using Contract.Architecture.Backend.Core.Contract.Logic.LogicResults;
using Contract.Architecture.Backend.Core.Contract.Logic.Modules.GegoennterKundenstamm.GegoennteKunden;
using Contract.Architecture.Backend.Core.Contract.Logic.Tools.Identifier;
using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.GegoennterKundenstamm.GegoennteKunden;
using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.GegoenntesBankwesen.GegoennteBanken;
using Contract.Architecture.Backend.Core.Logic.Modules.GegoennterKundenstamm.GegoennteKunden;
using Contract.Architecture.Backend.Core.Logic.Tests.Modules.GegoenntesBankwesen.GegoennteBanken;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Contract.Architecture.Backend.Core.Logic.Tests.Modules.GegoennterKundenstamm.GegoennteKunden
{
    [TestClass]
    public class GegoennteKundenCrudLogicTests
    {
        [TestMethod]
        public void CreateGegoennterKundeDefaultTest()
        {
            // Arrange
            Mock<IGegoennteKundenCrudRepository> gegoennteKundenCrudRepository = this.SetupGegoennteKundenCrudRepositoryEmpty();
            Mock<IGegoennteBankenCrudRepository> gegoennteBankenCrudRepository = this.SetupGegoennteBankenRepositoryDefault();
            Mock<IGuidGenerator> guidGenerator = this.SetupGuidGeneratorDefault();
            var logger = Mock.Of<ILogger<GegoennteKundenCrudLogic>>();

            GegoennteKundenCrudLogic gegoennteKundenCrudLogic = new GegoennteKundenCrudLogic(
                gegoennteKundenCrudRepository.Object,
                gegoennteBankenCrudRepository.Object,
                guidGenerator.Object,
                logger);

            // Act
            ILogicResult<Guid> result = gegoennteKundenCrudLogic.CreateGegoennterKunde(GegoennterKundeCreateTest.ForCreate());

            // Assert
            Assert.AreEqual(LogicResultState.Ok, result.State);
            Assert.AreEqual(GegoennterKundeTestValues.IdForCreate, result.Data);
            gegoennteKundenCrudRepository.Verify((repository) => repository.CreateGegoennterKunde(It.IsAny<IDbGegoennterKunde>()), Times.Once);
        }

        [TestMethod]
        public void DeleteGegoennterKundeConflictTest()
        {
            Mock<IGegoennteKundenCrudRepository> gegoennteKundenCrudRepository = this.SetupGegoennteKundenCrudRepositoryDeleteConflict();
            Mock<IGuidGenerator> guidGenerator = this.SetupGuidGeneratorDefault();
            var logger = Mock.Of<ILogger<GegoennteKundenCrudLogic>>();

            GegoennteKundenCrudLogic gegoennteKundenCrudLogic = new GegoennteKundenCrudLogic(
                gegoennteKundenCrudRepository.Object,
                null,
                guidGenerator.Object,
                logger);

            // Act
            ILogicResult result = gegoennteKundenCrudLogic.DeleteGegoennterKunde(GegoennterKundeTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.Conflict, result.State);
        }

        [TestMethod]
        public void DeleteGegoennterKundeDefaultTest()
        {
            // Arrange
            Mock<IGegoennteKundenCrudRepository> gegoennteKundenCrudRepository = this.SetupGegoennteKundenCrudRepositoryDefaultExists();
            var logger = Mock.Of<ILogger<GegoennteKundenCrudLogic>>();

            GegoennteKundenCrudLogic gegoennteKundenCrudLogic = new GegoennteKundenCrudLogic(
                gegoennteKundenCrudRepository.Object,
                null,
                null,
                logger);

            // Act
            ILogicResult result = gegoennteKundenCrudLogic.DeleteGegoennterKunde(GegoennterKundeTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.Ok, result.State);
            gegoennteKundenCrudRepository.Verify((repository) => repository.DeleteGegoennterKunde(GegoennterKundeTestValues.IdDefault), Times.Once);
        }

        [TestMethod]
        public void DeleteGegoennterKundeNotExistsTest()
        {
            // Arrange
            Mock<IGegoennteKundenCrudRepository> gegoennteKundenCrudRepository = this.SetupGegoennteKundenCrudRepositoryEmpty();
            var logger = Mock.Of<ILogger<GegoennteKundenCrudLogic>>();

            GegoennteKundenCrudLogic gegoennteKundenCrudLogic = new GegoennteKundenCrudLogic(
                gegoennteKundenCrudRepository.Object,
                null,
                null,
                logger);

            // Act
            ILogicResult result = gegoennteKundenCrudLogic.DeleteGegoennterKunde(GegoennterKundeTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.NotFound, result.State);
            gegoennteKundenCrudRepository.Verify((repository) => repository.DeleteGegoennterKunde(GegoennterKundeTestValues.IdDefault), Times.Never);
        }

        [TestMethod]
        public void GetGegoennterKundeDetailDefaultTest()
        {
            // Arrange
            Mock<IGegoennteKundenCrudRepository> gegoennteKundenCrudRepository = this.SetupGegoennteKundenCrudRepositoryDefaultExists();
            var logger = Mock.Of<ILogger<GegoennteKundenCrudLogic>>();

            GegoennteKundenCrudLogic gegoennteKundenCrudLogic = new GegoennteKundenCrudLogic(
                gegoennteKundenCrudRepository.Object,
                null,
                null,
                logger);

            // Act
            ILogicResult<IGegoennterKundeDetail> result = gegoennteKundenCrudLogic.GetGegoennterKundeDetail(GegoennterKundeTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.Ok, result.State);
            GegoennterKundeDetailTest.AssertDefault(result.Data);
        }

        [TestMethod]
        public void GetGegoennterKundeDetailNotExistsTest()
        {
            // Arrange
            Mock<IGegoennteKundenCrudRepository> gegoennteKundenCrudRepository = this.SetupGegoennteKundenCrudRepositoryEmpty();
            var logger = Mock.Of<ILogger<GegoennteKundenCrudLogic>>();

            GegoennteKundenCrudLogic gegoennteKundenCrudLogic = new GegoennteKundenCrudLogic(
                gegoennteKundenCrudRepository.Object,
                null,
                null,
                logger);

            // Act
            ILogicResult<IGegoennterKundeDetail> result = gegoennteKundenCrudLogic.GetGegoennterKundeDetail(GegoennterKundeTestValues.IdDefault);

            // Assert
            Assert.AreEqual(LogicResultState.NotFound, result.State);
        }

        [TestMethod]
        public void GetGegoennteKundenDefaultTest()
        {
            // Arrange
            Mock<IGegoennteKundenCrudRepository> gegoennteKundenCrudRepository = this.SetupGegoennteKundenCrudRepositoryDefaultExists();
            var logger = Mock.Of<ILogger<GegoennteKundenCrudLogic>>();

            GegoennteKundenCrudLogic gegoennteKundenCrudLogic = new GegoennteKundenCrudLogic(
                gegoennteKundenCrudRepository.Object,
                null,
                null,
                logger);

            // Act
            ILogicResult<IEnumerable<IGegoennterKunde>> result = gegoennteKundenCrudLogic.GetGegoennteKunden();

            // Assert
            Assert.AreEqual(LogicResultState.Ok, result.State);
            IGegoennterKunde[] gegoennterKundeResults = result.Data.ToArray();
            Assert.AreEqual(2, gegoennterKundeResults.Length);
            GegoennterKundeTest.AssertDefault(gegoennterKundeResults[0]);
            GegoennterKundeTest.AssertDefault2(gegoennterKundeResults[1]);
        }

        [TestMethod]
        public void UpdateGegoennterKundeNotExistsTest()
        {
            // Arrange
            Mock<IGegoennteKundenCrudRepository> gegoennteKundenCrudRepository = this.SetupGegoennteKundenCrudRepositoryEmpty();
            Mock<IGegoennteBankenCrudRepository> gegoennteBankenCrudRepository = this.SetupGegoennteBankenRepositoryDefault();
            var logger = Mock.Of<ILogger<GegoennteKundenCrudLogic>>();

            GegoennteKundenCrudLogic gegoennteKundenCrudLogic = new GegoennteKundenCrudLogic(
                gegoennteKundenCrudRepository.Object,
                gegoennteBankenCrudRepository.Object,
                null,
                logger);

            // Act
            ILogicResult result = gegoennteKundenCrudLogic.UpdateGegoennterKunde(GegoennterKundeUpdateTest.ForUpdate());

            // Assert
            Assert.AreEqual(LogicResultState.NotFound, result.State);
            gegoennteKundenCrudRepository.Verify((repository) => repository.UpdateGegoennterKunde(DbGegoennterKundeTest.Default()), Times.Never);
        }

        [TestMethod]
        public void UpdateGegoennterKundeDefaultTest()
        {
            // Arrange
            Mock<IGegoennteKundenCrudRepository> gegoennteKundenCrudRepository = this.SetupGegoennteKundenCrudRepositoryDefaultExists();
            Mock<IGegoennteBankenCrudRepository> gegoennteBankenCrudRepository = this.SetupGegoennteBankenRepositoryDefault();
            var logger = Mock.Of<ILogger<GegoennteKundenCrudLogic>>();

            GegoennteKundenCrudLogic gegoennteKundenCrudLogic = new GegoennteKundenCrudLogic(
                gegoennteKundenCrudRepository.Object,
                gegoennteBankenCrudRepository.Object,
                null,
                logger);

            // Act
            ILogicResult result = gegoennteKundenCrudLogic.UpdateGegoennterKunde(GegoennterKundeUpdateTest.ForUpdate());

            // Assert
            Assert.AreEqual(LogicResultState.Ok, result.State);
            gegoennteKundenCrudRepository.Verify((repository) => repository.UpdateGegoennterKunde(It.IsAny<IDbGegoennterKunde>()), Times.Once);
        }

        private Mock<IGegoennteKundenCrudRepository> SetupGegoennteKundenCrudRepositoryDefaultExists()
        {
            var gegoennteKundenCrudRepository = new Mock<IGegoennteKundenCrudRepository>(MockBehavior.Strict);
            gegoennteKundenCrudRepository.Setup(repository => repository.DoesGegoennterKundeExist(GegoennterKundeTestValues.IdDefault)).Returns(true);
            gegoennteKundenCrudRepository.Setup(repository => repository.DoesGegoennterKundeExist(GegoennterKundeTestValues.IdDefault2)).Returns(true);
            gegoennteKundenCrudRepository.Setup(repository => repository.GetGegoennterKunde(GegoennterKundeTestValues.IdDefault)).Returns(DbGegoennterKundeTest.Default());
            gegoennteKundenCrudRepository.Setup(repository => repository.GetGegoennterKunde(GegoennterKundeTestValues.IdDefault2)).Returns(DbGegoennterKundeTest.Default2());
            gegoennteKundenCrudRepository.Setup(repository => repository.GetGegoennterKundeDetail(GegoennterKundeTestValues.IdDefault)).Returns(DbGegoennterKundeDetailTest.Default());
            gegoennteKundenCrudRepository.Setup(repository => repository.GetGegoennterKundeDetail(GegoennterKundeTestValues.IdDefault2)).Returns(DbGegoennterKundeDetailTest.Default2());
            gegoennteKundenCrudRepository.Setup(repository => repository.GetGegoennteKunden()).Returns(new List<IDbGegoennterKunde> { DbGegoennterKundeTest.Default(), DbGegoennterKundeTest.Default2() });
            gegoennteKundenCrudRepository.Setup(repository => repository.UpdateGegoennterKunde(It.IsAny<IDbGegoennterKunde>())).Callback((IDbGegoennterKunde dbGegoennterKunde) =>
            {
                DbGegoennterKundeTest.AssertUpdated(dbGegoennterKunde);
            });
            gegoennteKundenCrudRepository.Setup(repository => repository.DeleteGegoennterKunde(GegoennterKundeTestValues.IdDefault));
            gegoennteKundenCrudRepository.Setup(repository => repository.DeleteGegoennterKunde(GegoennterKundeTestValues.IdDefault2));
            return gegoennteKundenCrudRepository;
        }

        private Mock<IGegoennteKundenCrudRepository> SetupGegoennteKundenCrudRepositoryEmpty()
        {
            var gegoennteKundenCrudRepository = new Mock<IGegoennteKundenCrudRepository>(MockBehavior.Strict);
            gegoennteKundenCrudRepository.Setup(repository => repository.DoesGegoennterKundeExist(GegoennterKundeTestValues.IdDefault)).Returns(false);
            gegoennteKundenCrudRepository.Setup(repository => repository.DoesGegoennterKundeExist(GegoennterKundeTestValues.IdDefault2)).Returns(false);
            gegoennteKundenCrudRepository.Setup(repository => repository.GetGegoennterKunde(GegoennterKundeTestValues.IdDefault)).Returns(() => null);
            gegoennteKundenCrudRepository.Setup(repository => repository.GetGegoennterKunde(GegoennterKundeTestValues.IdDefault2)).Returns(() => null);
            gegoennteKundenCrudRepository.Setup(repository => repository.GetGegoennterKundeDetail(GegoennterKundeTestValues.IdDefault)).Returns(() => null);
            gegoennteKundenCrudRepository.Setup(repository => repository.GetGegoennterKundeDetail(GegoennterKundeTestValues.IdDefault2)).Returns(() => null);
            gegoennteKundenCrudRepository.Setup(repository => repository.CreateGegoennterKunde(It.IsAny<IDbGegoennterKunde>())).Callback((IDbGegoennterKunde dbGegoennterKunde) =>
            {
                DbGegoennterKundeTest.AssertCreated(dbGegoennterKunde);
            });
            return gegoennteKundenCrudRepository;
        }

        private Mock<IGegoennteKundenCrudRepository> SetupGegoennteKundenCrudRepositoryDeleteConflict()
        {
            // Arrange
            var gegoennteKundenCrudRepository = new Mock<IGegoennteKundenCrudRepository>(MockBehavior.Strict);
            gegoennteKundenCrudRepository.Setup(repository => repository.DoesGegoennterKundeExist(GegoennterKundeTestValues.IdDefault)).Returns(true);
            gegoennteKundenCrudRepository.Setup(repository => repository.DoesGegoennterKundeExist(GegoennterKundeTestValues.IdDefault2)).Returns(true);
            gegoennteKundenCrudRepository.Setup(repository => repository.DeleteGegoennterKunde(GegoennterKundeTestValues.IdDefault)).Throws(new Exception());
            gegoennteKundenCrudRepository.Setup(repository => repository.DeleteGegoennterKunde(GegoennterKundeTestValues.IdDefault2)).Throws(new Exception());
            return gegoennteKundenCrudRepository;
        }

        private Mock<IGuidGenerator> SetupGuidGeneratorDefault()
        {
            var guidGeneration = new Mock<IGuidGenerator>(MockBehavior.Strict);
            guidGeneration.Setup(generator => generator.NewGuid()).Returns(GegoennterKundeTestValues.IdForCreate);
            return guidGeneration;
        }

        private Mock<IGegoennteBankenCrudRepository> SetupGegoennteBankenRepositoryDefault()
        {
            var gegoennteBankenCrudRepository = new Mock<IGegoennteBankenCrudRepository>(MockBehavior.Strict);
            gegoennteBankenCrudRepository.Setup(repository => repository.DoesGegoennteBankExist(GegoennteBankTestValues.IdDefault)).Returns(true);
            gegoennteBankenCrudRepository.Setup(repository => repository.DoesGegoennteBankExist(GegoennteBankTestValues.IdDefault2)).Returns(true);
            gegoennteBankenCrudRepository.Setup(repository => repository.DoesGegoennteBankExist(GegoennteBankTestValues.IdForCreate)).Returns(false);
            return gegoennteBankenCrudRepository;
        }
    }
}