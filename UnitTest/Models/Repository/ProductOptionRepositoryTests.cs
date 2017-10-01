using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using UnitTest.Models.Repository;

namespace refactor_me.Models.Tests
{
    [TestClass()]
    public class ProductOptionRepositoryTests
    {
        [TestMethod()]
        public void ProductOptionRepositoryTest()
        {
            //Arrange
            DBUtil.InitDB();
            //Action
            using (ProductOptionRepository productOptionRepository = new ProductOptionRepository())
            {
                //Assert
                Assert.IsNotNull(productOptionRepository);
            }
        }

        [TestMethod()]
        public void ProductOptionRepositoryGetAllTest()
        {
            //Arrange
            using (ProductOptionRepository productOptionRepository = new ProductOptionRepository())
            {
                //Action
                IQueryable<ProductOption> queryable = productOptionRepository.GetAll();
                //Assert
                Assert.IsNotNull(queryable);
            }

        }

        [TestMethod()]
        public void ProductOptionRepositoryGetOneTest()
        {
            //Arrange
            Guid guid = new Guid("0643ccf0-ab00-4862-b3c5-40e2731abcc9");
            using (ProductOptionRepository productOptionRepository = new ProductOptionRepository())
            {
                //Action
                ProductOption productOption = productOptionRepository.GetOne(guid);
                //Assert
                Assert.IsNotNull(productOption);
            }

        }

        [TestMethod()]
        public void ProductOptionRepositoryAddTest()
        {
            //Arrange
            ProductOption productOption = new ProductOption
            {
                Id = Guid.NewGuid(),
                ProductId = new Guid("de1287c0-4b15-4a7b-9d8a-dd21b3cafec3"),
                Name = "New Color",
                Description = "New Color Apple",
            };

            //Action
            using (ProductOptionRepository productOptionRepository = new ProductOptionRepository())
            {
                //Assert
                Assert.AreEqual(1, productOptionRepository.Add(productOption));
            }
        }

        [TestMethod()]
        public void ProductOptionRepositoryUpdateTest()
        {
            //Arrange
            ProductOption productOption = new ProductOption
            {
                Id = new Guid("0643ccf0-ab00-4862-b3c5-40e2731abcc9"),
                ProductId = new Guid("8f2e9176-35ee-4f0a-ae55-83023d2db1a3"),
                Name = "HUAWEI",
                Description = "HUAWEI HONOR Updated"
            };

            //Action
            using (ProductOptionRepository productOptionRepository = new ProductOptionRepository())
            {
                //Assert
                Assert.AreEqual(1, productOptionRepository.Update(productOption.Id, productOption));
            }

        }

        [TestMethod()]
        public void ProductOptionRepositoryDeleteByEntityTest()
        {
            //Arrange
            ProductOption productOption = new ProductOption
            {
                Id = new Guid("a21d5777-a655-4020-b431-624bb331e9a2"),
                ProductId = new Guid("8f2e9176-35ee-4f0a-ae55-83023d2db1a3"),
                Name = "HUAWEI",
                Description = "HUAWEI HONOR Updated"
            };

            //Action
            using (ProductOptionRepository productOptionRepository = new ProductOptionRepository())
            {
                //Assert
                Assert.AreEqual(1, productOptionRepository.Delete(productOption));
            }
        }
    }
}