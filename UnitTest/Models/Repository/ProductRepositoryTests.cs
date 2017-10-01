using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using UnitTest.Models.Repository;

namespace refactor_me.Models.Tests
{
    [TestClass()]
    public class ProductRepositoryTests
    {        
        [TestMethod()]
        public void ProductRepositoryTest()
        {
            //Arrange
            DBUtil.InitDB();
            //Action
            using (ProductRepository productRepository = new ProductRepository())
            {
                //Assert
                Assert.IsNotNull(productRepository);
            }

        }

        [TestMethod()]
        public void ProductRepositoryGetByNameTest()
        {
            //Arrange
            string productName = "Apple";

            //Action
            using (ProductRepository productRepository = new ProductRepository())
            {          
                IQueryable<Product> queryable = productRepository.GetByName(productName);
                //Assert
                Assert.IsNotNull(queryable);
            }
        }

        [TestMethod()]
        public void ProductRepositoryGetAllTest()
        {
            //Arrange
            using (ProductRepository productRepository = new ProductRepository())
            {
                //Action
                IQueryable<Product> queryable = productRepository.GetAll();
                //Assert
                Assert.IsNotNull(queryable);
            }

        }

        [TestMethod()]
        public void ProductRepositoryGetOneTest()
        {
            //Arrange
            Guid guid = new Guid("de1287c0-4b15-4a7b-9d8a-dd21b3cafec3");
            using (ProductRepository productRepository = new ProductRepository())
            {
                //Action
                Product product = productRepository.GetOne(guid);
                //Assert
                Assert.IsNotNull(product);
            }

        }

        [TestMethod()]
        public void ProductRepositoryAddTest()
        {
            //Arrange
            Product product = new Product
            {
                Id = Guid.NewGuid(),
                Name = "HUAWEI",
                Description = "HUAWEI HONOR",
                Price = 8888.88m,
                DeliveryPrice = 8.88m
            };

            //Action
            using (ProductRepository productRepository = new ProductRepository())
            {
                //Assert
                Assert.AreEqual(1, productRepository.Add(product));               
            }

        }

        [TestMethod()]
        public void ProductRepositoryUpdateTest()
        {
            //Arrange
            Product product = new Product
            {
                Id = new Guid("de1287c0-4b15-4a7b-9d8a-dd21b3cafe88"),
                Name = "HUAWEI",
                Description = "HUAWEI HONOR",
                Price = 8888.88m,
                DeliveryPrice = 8.88m
            };

            //Action
            using (ProductRepository productRepository = new ProductRepository())
            {
                //Assert
                Assert.AreEqual(1, productRepository.Update(product.Id,product));
            }
        }

        [TestMethod()]
        public void ProductRepositoryDeleteByEntityTest()
        {
            //Arrange
            Product product = new Product
            {
                Id = new Guid("de1287c0-4b15-4a7b-9d8a-dd21b3cafec3"),
                Name = "HUAWEI",
                Description = "HUAWEI HONOR",
                Price = 8888.88m,
                DeliveryPrice = 8.88m
            };

            //Action
            using (ProductRepository productRepository = new ProductRepository())
            {
                //Assert
                Assert.AreNotEqual(0, productRepository.Delete(product));
                
            }            
        }
    }
}