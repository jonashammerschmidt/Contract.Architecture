using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.GegoennterKundenstamm.GegoennteKunden;
using Contract.Architecture.Backend.Core.Persistence.Modules.GegoennterKundenstamm.GegoennteKunden;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Contract.Architecture.Backend.Core.Persistence.Tests.Modules.GegoennterKundenstamm.GegoennteKunden
{
    [TestClass]
    public class GegoennteKundenCrudRepositoryTests
    {
        [TestMethod]
        public void CreateGegoennterKundeTest()
        {
            // Arrange
            GegoennteKundenCrudRepository gegoennteKundenCrudRepository = this.GetGegoennteKundenCrudRepositoryEmpty();

            // Act
            gegoennteKundenCrudRepository.CreateGegoennterKunde(DbGegoennterKundeTest.ForCreate());

            // Assert
            IDbGegoennterKunde dbGegoennterKunde = gegoennteKundenCrudRepository.GetGegoennterKunde(GegoennterKundeTestValues.IdForCreate);
            DbGegoennterKundeTest.AssertForCreate(dbGegoennterKunde);
        }

        [TestMethod]
        public void DeleteGegoennterKundeTest()
        {
            // Arrange
            GegoennteKundenCrudRepository gegoennteKundenCrudRepository = this.GetGegoennteKundenCrudRepositoryDefault();

            // Act
            gegoennteKundenCrudRepository.DeleteGegoennterKunde(GegoennterKundeTestValues.IdDbDefault);

            // Assert
            bool doesGegoennterKundeExist = gegoennteKundenCrudRepository.DoesGegoennterKundeExist(GegoennterKundeTestValues.IdDbDefault);
            Assert.IsFalse(doesGegoennterKundeExist);
        }

        [TestMethod]
        public void DoesGegoennterKundeExistFalseTest()
        {
            // Arrange
            GegoennteKundenCrudRepository gegoennteKundenCrudRepository = this.GetGegoennteKundenCrudRepositoryEmpty();

            // Act
            bool doesGegoennterKundeExist = gegoennteKundenCrudRepository.DoesGegoennterKundeExist(GegoennterKundeTestValues.IdDbDefault);

            // Assert
            Assert.IsFalse(doesGegoennterKundeExist);
        }

        [TestMethod]
        public void DoesGegoennterKundeExistTrueTest()
        {
            // Arrange
            GegoennteKundenCrudRepository gegoennteKundenCrudRepository = this.GetGegoennteKundenCrudRepositoryDefault();

            // Act
            bool doesGegoennterKundeExist = gegoennteKundenCrudRepository.DoesGegoennterKundeExist(GegoennterKundeTestValues.IdDbDefault);

            // Assert
            Assert.IsTrue(doesGegoennterKundeExist);
        }

        [TestMethod]
        public void GetGegoennterKundeDefaultTest()
        {
            // Arrange
            GegoennteKundenCrudRepository gegoennteKundenCrudRepository = this.GetGegoennteKundenCrudRepositoryDefault();

            // Act
            IDbGegoennterKunde dbGegoennterKunde = gegoennteKundenCrudRepository.GetGegoennterKunde(GegoennterKundeTestValues.IdDbDefault);

            // Assert
            DbGegoennterKundeTest.AssertDbDefault(dbGegoennterKunde);
        }

        [TestMethod]
        public void GetGegoennterKundeDetailDefaultTest()
        {
            // Arrange
            GegoennteKundenCrudRepository gegoennteKundenCrudRepository = this.GetGegoennteKundenCrudRepositoryDefault();

            // Act
            IDbGegoennterKundeDetail dbGegoennterKundeDetail = gegoennteKundenCrudRepository.GetGegoennterKundeDetail(GegoennterKundeTestValues.IdDbDefault);

            // Assert
            DbGegoennterKundeDetailTest.AssertDbDefault(dbGegoennterKundeDetail);
        }

        [TestMethod]
        public void GetGegoennterKundeDetailNullTest()
        {
            // Arrange
            GegoennteKundenCrudRepository gegoennteKundenCrudRepository = this.GetGegoennteKundenCrudRepositoryEmpty();

            // Act
            IDbGegoennterKundeDetail dbGegoennterKundeDetail = gegoennteKundenCrudRepository.GetGegoennterKundeDetail(GegoennterKundeTestValues.IdDbDefault);

            // Assert
            Assert.IsNull(dbGegoennterKundeDetail);
        }

        [TestMethod]
        public void GetGegoennteKundenDefaultTest()
        {
            // Arrange
            GegoennteKundenCrudRepository gegoennteKundenCrudRepository = this.GetGegoennteKundenCrudRepositoryDefault();

            // Act
            IDbGegoennterKunde[] gegoennteKunden = gegoennteKundenCrudRepository.GetGegoennteKunden().ToArray();

            // Assert
            Assert.AreEqual(2, gegoennteKunden.Length);
            DbGegoennterKundeTest.AssertDbDefault(gegoennteKunden[0]);
            DbGegoennterKundeTest.AssertDbDefault2(gegoennteKunden[1]);
        }

        [TestMethod]
        public void GetGegoennterKundeNullTest()
        {
            // Arrange
            GegoennteKundenCrudRepository gegoennteKundenCrudRepository = this.GetGegoennteKundenCrudRepositoryEmpty();

            // Act
            IDbGegoennterKunde dbGegoennterKunde = gegoennteKundenCrudRepository.GetGegoennterKunde(GegoennterKundeTestValues.IdDbDefault);

            // Assert
            Assert.IsNull(dbGegoennterKunde);
        }

        [TestMethod]
        public void UpdateGegoennterKundeTest()
        {
            // Arrange
            GegoennteKundenCrudRepository gegoennteKundenCrudRepository = this.GetGegoennteKundenCrudRepositoryDefault();

            // Act
            gegoennteKundenCrudRepository.UpdateGegoennterKunde(DbGegoennterKundeTest.ForUpdate());

            // Assert
            IDbGegoennterKunde dbGegoennterKunde = gegoennteKundenCrudRepository.GetGegoennterKunde(GegoennterKundeTestValues.IdDbDefault);
            DbGegoennterKundeTest.AssertForUpdate(dbGegoennterKunde);
        }

        private GegoennteKundenCrudRepository GetGegoennteKundenCrudRepositoryDefault()
        {
            return new GegoennteKundenCrudRepository(InMemoryDbContext.CreatePersistenceDbContextWithDefault());
        }

        private GegoennteKundenCrudRepository GetGegoennteKundenCrudRepositoryEmpty()
        {
            return new GegoennteKundenCrudRepository(InMemoryDbContext.CreatePersistenceDbContext());
        }
    }
}