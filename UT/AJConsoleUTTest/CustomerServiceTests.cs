using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AJConsoleUT;
using Moq;
using System.Collections.Generic;

namespace AJConsoleUTTest
{
    [TestClass]
    public class CustomerServiceTests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidCustomerMailingAddressException))]
        public void Exception_Should_Be_Thrown_If_Address_is_not_entered()
        {
            //Arrange
            var customerToCreateDto = new CustomerToCreateDto { FirstName = "Raj", LastName = "Kumar" };
            var mockAddressBuilder = new Mock<ICustomerAddressBuilder>();
            var mockCustomerRepository = new Mock<ICustomerRepository>();

            mockAddressBuilder
              .Setup(x => x.From(It.IsAny<CustomerToCreateDto>()))
              .Returns(() => null);

            var customerService = new CustomerService(mockAddressBuilder.Object, mockCustomerRepository.Object);

            //Act
            customerService.Create(customerToCreateDto);

        }

        [TestMethod]
        public void Customer_Should_Be_Saved_If_Address_Entered()
        {
            //Arrange
            var customerToCreateDto = new CustomerToCreateDto { FirstName = "Raj", LastName = "Kumar" };
            var mockAddressBuilder = new Mock<ICustomerAddressBuilder>();
            var mockCustomerRepository = new Mock<ICustomerRepository>();

            mockAddressBuilder
              .Setup(x => x.From(It.IsAny<CustomerToCreateDto>()))
              .Returns(() => new Address());

            var customerService = new CustomerService(mockAddressBuilder.Object, mockCustomerRepository.Object);

            //Act
            customerService.Create(customerToCreateDto);

            //Assert
            mockCustomerRepository.Verify(y => y.Save(It.IsAny<Customer>()));
        }

        [TestMethod]
        public void each_customer_should_be_assigned_an_id()
        {
            //Arrange
            var listOfCustomersToCreate = new List<CustomerToCreateDto>
              {
                new CustomerToCreateDto(),
                new CustomerToCreateDto(),
                new CustomerToCreateDto(),
                new CustomerToCreateDto()
              };

            var mockCustomerRepository = new Mock<ICustomerRepository>();
            var mockIdFactory = new Mock<IIdFactory>();

            var i = 1;
            mockIdFactory.Setup(x => x.Create())
                .Returns(() => i)
                .Callback(() => i++);

            var customerService = new CustomerService(mockCustomerRepository.Object, mockIdFactory.Object);

            //Act
            customerService.Create(listOfCustomersToCreate);

            //Assert
            mockIdFactory.Verify(y => y.Create(), Times.AtLeast(4));
        }
    }
}
