using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.GegoenntesBankwesen.GegoennteBanken;
using Contract.Architecture.Backend.Core.Persistence.Modules.GegoenntesBankwesen.GegoennteBanken;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Contract.Architecture.Backend.Core.Persistence.Tests.Modules.GegoenntesBankwesen.GegoennteBanken
{
    [TestClass]
    public class GegoennteBankenCrudRepositoryTests
    {
        [TestMethod]
        public void CreateGegoennteBankTest()
        {
            // Arrange
            GegoennteBankenCrudRepository gegoennteBankenCrudRepository = this.GetGegoennteBankenCrudRepositoryEmpty();

            // Act
            gegoennteBankenCrudRepository.CreateGegoennteBank(DbGegoennteBankTest.ForCreate());

            // Assert
            IDbGegoennteBank dbGegoennteBank = gegoennteBankenCrudRepository.GetGegoennteBank(GegoennteBankTestValues.IdForCreate);
            DbGegoennteBankTest.AssertForCreate(dbGegoennteBank);
        }

        [TestMethod]
        public void DeleteGegoennteBankTest()
        {
            // Arrange
            GegoennteBankenCrudRepository gegoennteBankenCrudRepository = this.GetGegoennteBankenCrudRepositoryDefault();

            // Act
            gegoennteBankenCrudRepository.DeleteGegoennteBank(GegoennteBankTestValues.IdDbDefault);

            // Assert
            bool doesGegoennteBankExist = gegoennteBankenCrudRepository.DoesGegoennteBankExist(GegoennteBankTestValues.IdDbDefault);
            Assert.IsFalse(doesGegoennteBankExist);
        }

        [TestMethod]
        public void DoesGegoennteBankExistFalseTest()
        {
            // Arrange
            GegoennteBankenCrudRepository gegoennteBankenCrudRepository = this.GetGegoennteBankenCrudRepositoryEmpty();

            // Act
            bool doesGegoennteBankExist = gegoennteBankenCrudRepository.DoesGegoennteBankExist(GegoennteBankTestValues.IdDbDefault);

            // Assert
            Assert.IsFalse(doesGegoennteBankExist);
        }

        [TestMethod]
        public void DoesGegoennteBankExistTrueTest()
        {
            // Arrange
            GegoennteBankenCrudRepository gegoennteBankenCrudRepository = this.GetGegoennteBankenCrudRepositoryDefault();

            // Act
            bool doesGegoennteBankExist = gegoennteBankenCrudRepository.DoesGegoennteBankExist(GegoennteBankTestValues.IdDbDefault);

            // Assert
            Assert.IsTrue(doesGegoennteBankExist);
        }

        [TestMethod]
        public void GetGegoennteBankDefaultTest()
        {
            // Arrange
            GegoennteBankenCrudRepository gegoennteBankenCrudRepository = this.GetGegoennteBankenCrudRepositoryDefault();

            // Act
            IDbGegoennteBank dbGegoennteBank = gegoennteBankenCrudRepository.GetGegoennteBank(GegoennteBankTestValues.IdDbDefault);

            // Assert
            DbGegoennteBankTest.AssertDbDefault(dbGegoennteBank);
        }

        [TestMethod]
        public void GetGegoennteBankDetailDefaultTest()
        {
            // Arrange
            GegoennteBankenCrudRepository gegoennteBankenCrudRepository = this.GetGegoennteBankenCrudRepositoryDefault();

            // Act
            IDbGegoennteBankDetail dbGegoennteBankDetail = gegoennteBankenCrudRepository.GetGegoennteBankDetail(GegoennteBankTestValues.IdDbDefault);

            // Assert
            DbGegoennteBankDetailTest.AssertDbDefault(dbGegoennteBankDetail);
        }

        [TestMethod]
        public void GetGegoennteBankDetailNullTest()
        {
            // Arrange
            GegoennteBankenCrudRepository gegoennteBankenCrudRepository = this.GetGegoennteBankenCrudRepositoryEmpty();

            // Act
            IDbGegoennteBankDetail dbGegoennteBankDetail = gegoennteBankenCrudRepository.GetGegoennteBankDetail(GegoennteBankTestValues.IdDbDefault);

            // Assert
            Assert.IsNull(dbGegoennteBankDetail);
        }

        [TestMethod]
        public void GetGegoennteBankenDefaultTest()
        {
            // Arrange
            GegoennteBankenCrudRepository gegoennteBankenCrudRepository = this.GetGegoennteBankenCrudRepositoryDefault();

            // Act
            IDbGegoennteBank[] gegoennteBanken = gegoennteBankenCrudRepository.GetGegoennteBanken().ToArray();

            // Assert
            Assert.AreEqual(2, gegoennteBanken.Length);
            DbGegoennteBankTest.AssertDbDefault(gegoennteBanken[0]);
            DbGegoennteBankTest.AssertDbDefault2(gegoennteBanken[1]);
        }

        [TestMethod]
        public void GetGegoennteBankNullTest()
        {
            // Arrange
            GegoennteBankenCrudRepository gegoennteBankenCrudRepository = this.GetGegoennteBankenCrudRepositoryEmpty();

            // Act
            IDbGegoennteBank dbGegoennteBank = gegoennteBankenCrudRepository.GetGegoennteBank(GegoennteBankTestValues.IdDbDefault);

            // Assert
            Assert.IsNull(dbGegoennteBank);
        }

        [TestMethod]
        public void UpdateGegoennteBankTest()
        {
            // Arrange
            GegoennteBankenCrudRepository gegoennteBankenCrudRepository = this.GetGegoennteBankenCrudRepositoryDefault();

            // Act
            gegoennteBankenCrudRepository.UpdateGegoennteBank(DbGegoennteBankTest.ForUpdate());

            // Assert
            IDbGegoennteBank dbGegoennteBank = gegoennteBankenCrudRepository.GetGegoennteBank(GegoennteBankTestValues.IdDbDefault);
            DbGegoennteBankTest.AssertForUpdate(dbGegoennteBank);
        }

        private GegoennteBankenCrudRepository GetGegoennteBankenCrudRepositoryDefault()
        {
            return new GegoennteBankenCrudRepository(InMemoryDbContext.CreatePersistenceDbContextWithDefault());
        }

        private GegoennteBankenCrudRepository GetGegoennteBankenCrudRepositoryEmpty()
        {
            return new GegoennteBankenCrudRepository(InMemoryDbContext.CreatePersistenceDbContext());
        }
    }
}