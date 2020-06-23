using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using InventoryModule_v2;
using System.Collections.Generic;

namespace InventoryModule_v2Test
{
    [TestClass]
    public class OrderTest
    {
        [TestMethod]
        public void Orders_CreateOrder_NewOrder_ReturnsOrder()
        {
            //Arrange
            //=== To avoid service dependencies mock the serivce interface and perform unit testing
            var mockService = new Mock<IInventoryService>() { CallBase = true };

            Order order = new Order(mockService.Object) {
                CustomerId = 1,
                OrderId = 1,
                OrderDate = new DateTime(2020,05,02),
                DeliveryDate = new DateTime(2020, 05, 12),
                Details = new List<OrderDetail>
                {
                    new OrderDetail { OrderId = 1, ProductId = 1, Quantity = 2, UnitPrice = 1200 },
                    new OrderDetail { OrderId = 1, ProductId = 2, Quantity = 1, UnitPrice = 1700 }
                }
            };

            mockService.Setup(x => x.CreateOrder(It.IsAny<Order>())).Returns(order);//Mock CreateOrder to return order object setup in previous line

            ///=== To perform unit testing on concrete implementation use this
            //var service = new InventoryService();
            //Order order = new Order(mockService.Object)
            //{
            //    CustomerId = 1,
            //    OrderId = 1,
            //    OrderDate = new DateTime(2020, 05, 02),
            //    DeliveryDate = new DateTime(2020, 05, 12),
            //    Details = new List<OrderDetail>
            //    {
            //        new OrderDetail { OrderId = 1, ProductId = 1, Quantity = 2, UnitPrice = 1200 },
            //        new OrderDetail { OrderId = 1, ProductId = 2, Quantity = 1, UnitPrice = 1700 }
            //    }
            //};

            //Act
            var result = order.Create();

            //Assert
            Assert.AreEqual(order, result);
            Assert.AreEqual(order.OrderId, result.OrderId);
            Assert.AreEqual(order.OrderTotal, result.OrderTotal);
        }

        [TestMethod]
        public void Orders_UpdateOrder_ModifyOrder_ReturnsOrder()
        {
            //Arrange
            //=== To avoid service dependencies mock the serivce interface and perform unit testing
            var mockService = new Mock<IInventoryService>() { CallBase = true };

            Order order = new Order(mockService.Object)
            {
                CustomerId = 1,
                OrderId = 1,
                OrderDate = new DateTime(2020, 05, 02),
                DeliveryDate = new DateTime(2020, 05, 12),
                Details = new List<OrderDetail>
                {
                    new OrderDetail { OrderId = 1, ProductId = 1, Quantity = 2, UnitPrice = 1200 },
                    new OrderDetail { OrderId = 1, ProductId = 2, Quantity = 1, UnitPrice = 1000 }
                }
            };

            mockService.Setup(x => x.UpdateOrder(It.IsAny<int>(), It.IsAny<Order>())).Returns(order);//Mock CreateOrder to return order object setup in previous line

            ///=== To perform unit testing on concrete implementation use this
            //var service = new InventoryService();
            //Order order = new Order(mockService.Object)
            //{
            //    CustomerId = 1,
            //    OrderId = 1,
            //    OrderDate = new DateTime(2020, 05, 02),
            //    DeliveryDate = new DateTime(2020, 05, 12),
            //    Details = new List<OrderDetail>
            //    {
            //        new OrderDetail { OrderId = 1, ProductId = 1, Quantity = 2, UnitPrice = 1200 },
            //        new OrderDetail { OrderId = 1, ProductId = 2, Quantity = 1, UnitPrice = 1700 }
            //    }
            //};

            //Act
            var result = order.Update();

            //Assert
            Assert.AreEqual(order, result);
            Assert.AreEqual(order.OrderId, result.OrderId);
            Assert.AreEqual(order.OrderTotal, result.OrderTotal);
        }

        [TestMethod]
        public void Orders_Delete_DeleteOrder_ReturnsTrue()
        {
            //Arrange
            int orderId = 1;

            //=== To avoid service dependencies mock the serivce interface and perform unit testing
            var mockService = new Mock<IInventoryService>() { CallBase = true };
            Order order = new Order(mockService.Object);
            mockService.Setup(x => x.DeleteOrder(It.IsAny<int>())).Returns(true); //Mock DeleteOrder service method to return true

            ///=== To perform unit testing on concrete implementation use this
            //var service = new InventoryService();
            //Order order = new Order(service);

            //Act
            var result = order.Delete(orderId);

            //Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Orders_GetAllOrders_NoOrders_ReturnsExceptionNoOrdersExists()
        {
            //Arrange
            //=== To avoid service dependencies mock the serivce interface and perform unit testing
            var mockService = new Mock<IInventoryService>() { CallBase = true };
            Order order = new Order(mockService.Object);
            mockService.Setup(x => x.GetOrders()).Returns(() => null); //Mock GetOrders service method to return null to test the validation

            ///=== To perform unit testing on concrete implementation use this
            //var service = new InventoryService();
            //Order order = new Order(service);

            //Act
            try
            {
                var result = order.GetAllOrders();
            }
            catch (Exception ex)
            {
                //Assert
                Assert.AreEqual("No order exists.", ex.Message);
                throw;
            }
        }

        [TestMethod]
        public void Orders_GetAllOrders_HasOrders_ReturnsListOfOrders()
        {
            //Arrange
            //=== To avoid service dependencies mock the serivce interface and perform unit testing
            var mockService = new Mock<IInventoryService>() { CallBase = true };
            Order order = new Order(mockService.Object);
            List<Order> orders = new List<Order>()
            {
               new Order(mockService.Object)
                {
                    CustomerId = 1,
                    OrderId = 1,
                    OrderDate = new DateTime(2020, 05, 02),
                    DeliveryDate = new DateTime(2020, 05, 12),
                    Details = new List<OrderDetail>
                    {
                        new OrderDetail { OrderId = 1, ProductId = 1, Quantity = 2, UnitPrice = 1200 },
                        new OrderDetail { OrderId = 1, ProductId = 2, Quantity = 1, UnitPrice = 1000 }
                    }
               },
               new Order(mockService.Object)
                {
                    CustomerId = 2,
                    OrderId = 2,
                    OrderDate = new DateTime(2020, 04, 22),
                    DeliveryDate = new DateTime(2020, 05, 01),
                    Details = new List<OrderDetail>
                    {
                        new OrderDetail { OrderId = 2, ProductId = 1, Quantity = 1, UnitPrice = 1200 },
                        new OrderDetail { OrderId = 2, ProductId = 2, Quantity = 1, UnitPrice = 1000 }
                    }
               }
            };

            mockService.Setup(x => x.GetOrders()).Returns(orders); //Mock GetOrders service method to return above populated order list

            ///=== To perform unit testing on concrete implementation use this
            //var service = new InventoryService();
            //Order order = new Order(service);

            //Act
            var result = order.GetAllOrders();

            //Assert
            Assert.AreEqual(orders.Count, result.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Orders_GetOrder_NoMatchingOrderExists_ReturnsExceptionNoOrderExists()
        {
            //Arrange
            int orderId = 1;
            //=== To avoid service dependencies mock the serivce interface and perform unit testing
            var mockService = new Mock<IInventoryService>() { CallBase = true };
            Order order = new Order(mockService.Object);
            mockService.Setup(x => x.GetOrder(It.IsAny<int>())).Returns(() => null); //Mock GetCustomer service method to return null to test the validation

            ///=== To perform unit testing on concrete implementation use this
            //var service = new InventoryService();
            //Order order = new Order(service);

            //Act
            try
            {
                var result = order.GetOrder(orderId);
            }
            catch (Exception ex)
            {
                //Assert
                Assert.AreEqual("No order exist for order id : " + orderId.ToString(), ex.Message);
                throw;
            }
        }

        [TestMethod]
        public void Orders_GetOrder_MatchingOrderExists_ReturnsOrder()
        {
            //Arrange
            int orderId = 1;

            //=== To avoid service dependencies mock the serivce interface and perform unit testing
            var mockService = new Mock<IInventoryService>() { CallBase = true };
            Order order = new Order(mockService.Object)
            {
                CustomerId = 1,
                OrderId = 1,
                OrderDate = new DateTime(2020, 05, 02),
                DeliveryDate = new DateTime(2020, 05, 12),
                Details = new List<OrderDetail>
                    {
                        new OrderDetail { OrderId = 1, ProductId = 1, Quantity = 2, UnitPrice = 1200 },
                        new OrderDetail { OrderId = 1, ProductId = 2, Quantity = 1, UnitPrice = 1000 }
                    }
            };
            
            mockService.Setup(x => x.GetOrder(It.IsAny<int>())).Returns(order); //Mock GetOrder service method to return above populated order object

            ///=== To perform unit testing on concrete implementation use this
            //var service = new InventoryService();
            //Order order = new Order(service);

            //Act
            var result = order.GetOrder(orderId);

            //Assert
            Assert.AreEqual(orderId, result.OrderId);
        }
    }
}
