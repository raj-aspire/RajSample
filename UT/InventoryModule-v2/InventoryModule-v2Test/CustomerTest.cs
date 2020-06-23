using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using InventoryModule_v2;
using System.Collections.Generic;

namespace InventoryModule_v2Test
{
    [TestClass]
    public class CustomerTest
    {
        [TestMethod]
        public void Customers_CreateCustomer_NewCustomer_ReturnCustomer()
        {
            //Arrange
            var mockService = new Mock<IInventoryService>() { CallBase = true };

            Customer customer = new Customer(mockService.Object) { CustomerId = 1, CustomerName = "Raj", CustomerContact = "98410", Address = "Chennai" };
            mockService.Setup(x => x.CreateCustomer(It.IsAny<Customer>())).Returns(customer);
            
            //var service = new InventoryService();
            //Customer customer = new Customer(service) { CustomerId = 1, CustomerName = "Raj", CustomerContact = "98410", Address = "Chennai" };

            //Act
            var result = customer.Create();

            //Assert
            Assert.AreEqual(customer, result);
            Assert.AreEqual(customer.CustomerId, result.CustomerId);
            Assert.AreEqual(customer.CustomerName, result.CustomerName);
        }

        [TestMethod]
        public void Customers_UpdateCustomer_ModifyCustomer_ReturnCustomer()
        {
            //Arrange
            var mockService = new Mock<IInventoryService>() { CallBase = true };

            Customer customer = new Customer(mockService.Object) { CustomerId = 1, CustomerName = "Raj", CustomerContact = "98410", Address = "Chennai" };
            mockService.Setup(x => x.UpdateCustomer(It.IsAny<int>(), It.IsAny<Customer>())).Returns(customer);

            //var service = new InventoryService();
            //Customer customer = new Customer(service) { CustomerId = 1, CustomerName = "Raj", CustomerContact = "98410", Address = "Chennai" };

            //Act
            var result = customer.Update();

            //Assert
            Assert.AreEqual(customer, result);
            Assert.AreEqual(customer.CustomerName, result.CustomerName);
        }

        [TestMethod]
        public void Customers_Delete_DeleteCustomer_ReturnsTrue()
        {
            //Arrange
            int customerId = 1;

            //=== To avoid service dependencies mock the serivce interface and perform unit testing
            var mockService = new Mock<IInventoryService>() { CallBase = true };
            Customer customer = new Customer(mockService.Object);
            mockService.Setup(x => x.DeleteCustomer(It.IsAny<int>())).Returns(true); //Mock DeleteCustomer service method to return true

            ///=== To perform unit testing on concrete implementation use this
            //var service = new InventoryService();
            //Customer customer = new Customer(service);

            //Act
            var result = customer.Delete(customerId);

            //Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Customers_GetAllCustomers_NoProducts_ReturnsExceptionNoCustomersExists()
        {
            //Arrange
            //=== To avoid service dependencies mock the serivce interface and perform unit testing
            var mockService = new Mock<IInventoryService>() { CallBase = true };
            Customer customer = new Customer(mockService.Object);
            mockService.Setup(x => x.GetCustomers()).Returns(() => null); //Mock GetCustomers service method to return null to test the validation

            ///=== To perform unit testing on concrete implementation use this
            //var service = new InventoryService();
            //Customer customer = new Customer(service);

            //Act
            try
            {
                var result = customer.GetAllCustomers();
            }
            catch (Exception ex)
            {
                //Assert
                Assert.AreEqual("No customer exists.", ex.Message);
                throw;
            }
        }

        [TestMethod]
        public void Customers_GetAllCustomers_HasCustomer_ReturnsListOfCustomers()
        {
            //Arrange
            //=== To avoid service dependencies mock the serivce interface and perform unit testing
            var mockService = new Mock<IInventoryService>() { CallBase = true };
            Customer customer = new Customer(mockService.Object);
            List<Customer> customers = new List<Customer>()
            {
                new Customer(mockService.Object) { CustomerId = 1, CustomerName = "Sankar", Address = "Chennai", CustomerContact = "98323", PinCode = 600123  },
                new Customer(mockService.Object) { CustomerId = 1, CustomerName = "Ramesh", Address = "Banglore", CustomerContact = "86757", PinCode = 400101 },
                new Customer(mockService.Object) { CustomerId = 1, CustomerName = "Suresh", Address = "Delhi", CustomerContact = "76544", PinCode = 100103 }
            };

            mockService.Setup(x => x.GetCustomers()).Returns(customers); //Mock GetCustomers service method to return above populated customer list

            ///=== To perform unit testing on concrete implementation use this
            //var service = new InventoryService();
            //Customer customer = new Customer(service);

            //Act
            var result = customer.GetAllCustomers();

            //Assert
            Assert.AreEqual(customers.Count, result.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Customers_GetCustomer_NoMatchingCustomerExists_ReturnsExceptionNoCustomerExists()
        {
            //Arrange
            int customerId = 1;
            //=== To avoid service dependencies mock the serivce interface and perform unit testing
            var mockService = new Mock<IInventoryService>() { CallBase = true };
            Customer customer = new Customer(mockService.Object);
            mockService.Setup(x => x.GetCustomer(It.IsAny<int>())).Returns(() => null); //Mock GetCustomer service method to return null to test the validation

            ///=== To perform unit testing on concrete implementation use this
            //var service = new InventoryService();
            //Customer customer = new Customer(service);

            //Act
            try
            {
                var result = customer.GetCustomer(customerId);
            }
            catch (Exception ex)
            {
                //Assert
                Assert.AreEqual("No customer exist for customer id : " + customerId.ToString(), ex.Message);
                throw;
            }
        }

        [TestMethod]
        public void Customers_GetCustomer_MatchingCustomerExists_ReturnsCustomer()
        {
            //Arrange
            int customerId = 1;
            //=== To avoid service dependencies mock the serivce interface and perform unit testing
            var mockService = new Mock<IInventoryService>() { CallBase = true };
            Customer customer = new Customer(mockService.Object) { CustomerId = 1, CustomerName = "Sankar", Address = "Chennai", CustomerContact = "98323", PinCode = 600123 };
            
            mockService.Setup(x => x.GetCustomer(It.IsAny<int>())).Returns(customer); //Mock GetCustomer service method to return above populated customer object

            ///=== To perform unit testing on concrete implementation use this
            //var service = new InventoryService();
            //Customer customer = new Customer(service);

            //Act
            var result = customer.GetCustomer(customerId);

            //Assert
            Assert.AreEqual(customer.CustomerId, result.CustomerId);
            Assert.AreEqual(customer.CustomerName, result.CustomerName);
        }
    }
}
