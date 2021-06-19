using Contract.Architecture.Backend.Core.Contract.Contexts;
using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.GegoennterKundenstamm.GegoennteKunden;
using Contract.Architecture.Backend.Core.Contract.Persistence.Tools.Pagination;
using Contract.Architecture.Backend.Core.Persistence.Modules.GegoennterKundenstamm.GegoennteKunden;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
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
        public void GetAllGegoennteKundenDefaultTest()
        {
            // Arrange
            GegoennteKundenCrudRepository gegoennteKundenCrudRepository = this.GetGegoennteKundenCrudRepositoryDefault();

            // Act
            IDbGegoennterKunde[] dbGegoennteKunden = gegoennteKundenCrudRepository.GetAllGegoennteKunden().ToArray();

            // Assert
            Assert.AreEqual(2, dbGegoennteKunden.Length);
            DbGegoennterKundeTest.AssertDbDefault(dbGegoennteKunden[0]);
            DbGegoennterKundeTest.AssertDbDefault2(dbGegoennteKunden[1]);
        }

        [TestMethod]
        public void GetGegoennteKundenDefaultTest()
        {
            // Arrange
            GegoennteKundenCrudRepository gegoennteKundenCrudRepository = this.GetGegoennteKundenCrudRepositoryDefault();

            // Act
            IDbPagedResult<IDbGegoennterKunde> dbGegoennteKundenPagedResult =
                gegoennteKundenCrudRepository.GetGegoennteKunden();

            // Assert
            IDbGegoennterKunde[] dbGegoennteKunden = dbGegoennteKundenPagedResult.Data.ToArray();
            Assert.AreEqual(2, dbGegoennteKunden.Length);
            DbGegoennterKundeTest.AssertDbDefault(dbGegoennteKunden[0]);
            DbGegoennterKundeTest.AssertDbDefault2(dbGegoennteKunden[1]);
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
            return new GegoennteKundenCrudRepository(
                this.GetPaginationContext(),
                InMemoryDbContext.CreatePersistenceDbContextWithDefault());
        }

        private GegoennteKundenCrudRepository GetGegoennteKundenCrudRepositoryEmpty()
        {
            return new GegoennteKundenCrudRepository(
                this.GetPaginationContext(),
                InMemoryDbContext.CreatePersistenceDbContext());
        }

        private IPaginationContext GetPaginationContext()
        {
            Mock<IPaginationContext> paginationContext = new Mock<IPaginationContext>();
            paginationContext.Setup(context => context.Limit).Returns(10);
            paginationContext.Setup(context => context.Offset).Returns(0);
            paginationContext.Setup(context => context.Sort).Returns(Array.Empty<IPaginationSortItem>());
            paginationContext.Setup(context => context.Filter).Returns(Array.Empty<IPaginationFilterItem>());
            return paginationContext.Object;
        }
    }
}