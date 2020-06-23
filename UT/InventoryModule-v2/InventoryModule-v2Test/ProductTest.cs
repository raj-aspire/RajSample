using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using InventoryModule_v2;
using System;
using System.Collections.Generic;

namespace InventoryModule_v2Test
{
    [TestClass]
    public class ProductTest
    {
        [TestMethod]
        public void Products_CreateProduct_NewProduct_ReturnInsertedProduct()
        {
            //Arrange
            //=== To avoid service dependencies mock the serivce interface and perform unit testing
            var mockService = new Mock<IInventoryService>() { CallBase = true };
            
            Product product = new Product(mockService.Object) { ProductId = 1, ProductName = "Washing Machine", StockIn = 4, UnitPrice = 1220, ReorderLevel = 2 };

            mockService.Setup(x => x.CreateProduct(It.IsAny<Product>())).Returns(product);//Mock CreateProduct to return product object setup in previous line

            ///=== To perform unit testing on concrete implementation use this
            //var service = new InventoryService();
            //Product product = new Product(service) { ProductId = 1, ProductName = "Washing Machine", StockIn = 4, UnitPrice = 1220, ReorderLevel = 2 };

            //Act
            var result = product.Create();

            //Assert
            Assert.AreEqual(product, result);
            Assert.AreEqual(product.ProductId, result.ProductId);
            Assert.AreEqual(product.ProductName, result.ProductName);
        }

        [TestMethod]
        public void Products_UpdateProduct_ModifyProduct_ReturnUpdatedProduct()
        {
            //Arrange
            //=== To avoid service dependencies mock the serivce interface and perform unit testing
            var mockService = new Mock<IInventoryService>() { CallBase = true };

            Product product = new Product(mockService.Object) { ProductId = 1, ProductName = "Washing Machine 7Kg", StockIn = 4, UnitPrice = 1500, ReorderLevel = 2 };
            mockService.Setup(x => x.UpdateProduct(It.IsAny<int>(),It.IsAny<Product>())).Returns(product); //Mock CreateProduct to return product object setup in previous line

            ///=== To perform unit testing on concrete implementation use this
            //var service = new InventoryService();
            //Product product = new Product(service) { ProductId = 1, ProductName = "Washing Machine", StockIn = 4, UnitPrice = 1220, ReorderLevel = 2 };

            //Act
            var result = product.Update();

            //Assert
            Assert.AreEqual(product, result);
            Assert.AreEqual(product.ProductName, result.ProductName);
            Assert.AreEqual(product.UnitPrice, result.UnitPrice);
        }

        [TestMethod]
        public void Products_Delete_DeleteProduct_ReturnTrue()
        {
            //Arrange
            int productId = 1;

            //=== To avoid service dependencies mock the serivce interface and perform unit testing
            var mockService = new Mock<IInventoryService>() { CallBase = true };
            Product product = new Product(mockService.Object);
            mockService.Setup(x => x.DeleteProduct(It.IsAny<int>())).Returns(true); //Mock DeleteProduct service method to return true

            ///=== To perform unit testing on concrete implementation use this
            //var service = new InventoryService();
            //Product product = new Product(service);

            //Act
            var result = product.Delete(productId);

            //Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Products_GetAllProducts_NoProducts_ReturnsExceptionNoProductsExists()
        {
            //Arrange
            //=== To avoid service dependencies mock the serivce interface and perform unit testing
            var mockService = new Mock<IInventoryService>() { CallBase = true };
            Product product = new Product(mockService.Object);
            mockService.Setup(x => x.GetProducts()).Returns(() => null); //Mock GetProducts service method to return null to test the validation

            ///=== To perform unit testing on concrete implementation use this
            //var service = new InventoryService();
            //Product product = new Product(service);

            //Act
            try
            {
                var result = product.GetAllProducts();
            }
            catch (Exception ex)
            {
                //Assert
                Assert.AreEqual("No products exists.", ex.Message);
                throw;
            }
        }

        [TestMethod]
        public void Products_GetAllProducts_HasProducts_ReturnsListOfProducts()
        {
            //Arrange
            //=== To avoid service dependencies mock the serivce interface and perform unit testing
            var mockService = new Mock<IInventoryService>() { CallBase = true };
            Product product = new Product(mockService.Object);
            List<Product> products = new List<Product>()
            {
                new Product(mockService.Object) { ProductId = 1, ProductName = "Washing Machine", UnitPrice = 1200, StockIn = 4, ReorderLevel = 2 },
                new Product(mockService.Object) { ProductId = 2, ProductName = "Fridge", UnitPrice = 1900, StockIn = 7, ReorderLevel = 5 },
                new Product(mockService.Object) { ProductId = 3, ProductName = "Television", UnitPrice = 2200, StockIn = 3, ReorderLevel = 2 }
            };

            mockService.Setup(x => x.GetProducts()).Returns(products); //Mock GetProducts service method to return above populated product list

            ///=== To perform unit testing on concrete implementation use this
            //var service = new InventoryService();
            //Product product = new Product(service);

            //Act
            var result = product.GetAllProducts();

            //Assert
            Assert.AreEqual(products.Count, result.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Products_GetProduct_NoMatchingProductExists_ReturnsExceptionNoProductExists()
        {
            //Arrange
            int productId = 1;
            //=== To avoid service dependencies mock the serivce interface and perform unit testing
            var mockService = new Mock<IInventoryService>() { CallBase = true };
            Product product = new Product(mockService.Object);
            mockService.Setup(x => x.GetProduct(It.IsAny<int>())).Returns(() => null); //Mock GetProduct service method to return null to test the validation

            ///=== To perform unit testing on concrete implementation use this
            //var service = new InventoryService();
            //Product product = new Product(service);

            //Act
            try
            {
                var result = product.GetProduct(productId);
            }
            catch (Exception ex)
            {
                //Assert
                Assert.AreEqual("No product exist for product id : " + productId.ToString(), ex.Message);
                throw;
            }
        }

        [TestMethod]
        public void Products_GetProduct_MatchingProductExists_ReturnsProduct()
        {
            //Arrange
            int productId = 1;
            //=== To avoid service dependencies mock the serivce interface and perform unit testing
            var mockService = new Mock<IInventoryService>() { CallBase = true };
            Product product = new Product(mockService.Object) { ProductId = 1, ProductName = "Washing Machine", UnitPrice = 1200, StockIn = 4, ReorderLevel = 2 };

            mockService.Setup(x => x.GetProduct(It.IsAny<int>())).Returns(product); //Mock GetProduct service method to return above populated product object

            ///=== To perform unit testing on concrete implementation use this
            //var service = new InventoryService();
            //Product product = new Product(service);

            //Act
            var result = product.GetProduct(productId);

            //Assert
            Assert.AreEqual(product.ProductId, result.ProductId);
            Assert.AreEqual(product.ProductName, result.ProductName);
        }

        [TestMethod]
        public void Products_IsStockAvailable_StockExists_ReturnsTrue()
        {
            //Arrange
            int productId = 1;
            int quantity = 2;
            //=== To avoid service dependencies mock the serivce interface and perform unit testing
            var mockService = new Mock<IInventoryService>() { CallBase = true };
            Product product = new Product(mockService.Object);

            mockService.Setup(x => x.IsStockAvailable(It.IsAny<int>(), It.IsAny<int>())).Returns(true); //Mock IsStockAvailable service method to return true saying that stock available

            ///=== To perform unit testing on concrete implementation use this
            //var service = new InventoryService();
            //Product product = new Product(service);

            //Act
            var result = product.IsStockAvailable(productId, quantity);

            //Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void Products_IsStockAvailable_NoStockExists_ReturnsFalse()
        {
            //Arrange
            int productId = 1;
            int quantity = 2;
            //=== To avoid service dependencies mock the serivce interface and perform unit testing
            var mockService = new Mock<IInventoryService>() { CallBase = true };
            Product product = new Product(mockService.Object);

            mockService.Setup(x => x.IsStockAvailable(It.IsAny<int>(), It.IsAny<int>())).Returns(false); //Mock IsStockAvailable service method to return false saying that stock not available

            ///=== To perform unit testing on concrete implementation use this
            //var service = new InventoryService();
            //Product product = new Product(service);

            //Act
            var result = product.IsStockAvailable(productId, quantity);

            //Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Products_IsReorderLevelReached_ReachedReOrderLevel_ReturnsTrue()
        {
            //Arrange
            int productId = 1;

            //=== To avoid service dependencies mock the serivce interface and perform unit testing
            var mockService = new Mock<IInventoryService>() { CallBase = true };
            Product product = new Product(mockService.Object);

            mockService.Setup(x => x.CheckReorderLevel(It.IsAny<int>())).Returns(true); //Mock IsStockAvailable service method to return true saying that reorder level reached

            ///=== To perform unit testing on concrete implementation use this
            //var service = new InventoryService();
            //Product product = new Product(service);

            //Act
            var result = product.IsReorderLevelReached(productId);

            //Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void Products_IsReorderLevelReached_NotReachedReOrderLevel_ReturnsFalse()
        {
            //Arrange
            int productId = 1;

            //=== To avoid service dependencies mock the serivce interface and perform unit testing
            var mockService = new Mock<IInventoryService>() { CallBase = true };
            Product product = new Product(mockService.Object);

            mockService.Setup(x => x.CheckReorderLevel(It.IsAny<int>())).Returns(false); //Mock IsStockAvailable service method to return false saying that reorder level not reached

            ///=== To perform unit testing on concrete implementation use this
            //var service = new InventoryService();
            //Product product = new Product(service);

            //Act
            var result = product.IsReorderLevelReached(productId);

            //Assert
            Assert.AreEqual(false, result);
        }
    }
}
