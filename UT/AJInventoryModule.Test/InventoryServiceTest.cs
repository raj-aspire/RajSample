using AJInventoryModule.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
///     BP-3.	If possible, cover every code path. Creating more number of test cases
///     BP-6.	Name your test very clearly and don’t worry about the long names
/// </summary>
namespace AJInventoryModule.Test
{
    [TestClass]
    public class InventoryServiceTest
    {
        [TestMethod]
        public void CreateProduct_AddingNewProduct_ReturnTrue()
        {
            //BP-2.	Follow AAA rule. Arrange, Act and Assert
            //Arrange
            InventoryService invService = new InventoryService();
            Product newProduct = new Product { ProductId = 1, ProductName = "Fridge", ReorderLevel = 4, StockIn = 10, UnitPrice = 1200 };
            Product expectedProduct = new Product { ProductId = 1, ProductName = "Fridge", ReorderLevel = 4, StockIn = 10, UnitPrice = 1200 };

            //Act
            int result = invService.CreateProduct(newProduct);
         
            //Assert
            Assert.AreEqual(expectedProduct.ProductId, result);
        }

        [TestMethod]
        public void UpdateProduct_UpdateSelectedProduct_ReturnTrue()
        {
            throw new NotSupportedException();
        }

        [TestMethod]
        public void GetAllProduct_ListAllProducts_ReturnTrue()
        {
            throw new NotSupportedException();
        }

        [TestMethod]
        public void GetProduct_RetriveSelectedProduct_ReturnTrue()
        {
            //int productId
            throw new NotSupportedException();
        }

        [TestMethod]
        //[ExpectedException(typeof(DivideByZeroException))] // If we expect DivideByZeroException test will fail because DeleteProduct has NotImplementedException
        [ExpectedException(typeof(NotImplementedException))]
        public void DeleteProduct_DeleteSelectedProduct_ReturnTrue()
        {
            int productId = 1;
            InventoryService invService = new InventoryService();

            bool result = invService.DeleteProduct(productId);
        }

        [TestMethod]
        public void CreateCustomer_AddingNewCustomer_ReturnTrue()
        {
            throw new NotSupportedException();
        }

        [TestMethod]
        public void UpdateCustomer_UpdatedSelectedCustomer_ReturnTrue()
        {
            throw new DivideByZeroException();
        }

        [TestMethod]
        public void GetAllCustomers_ListAllCustomers_ReturnTrue()
        {
            throw new NotSupportedException();
        }

        [TestMethod]
        public void GetCustomer_RetrieveSelectedCustomer_ReturnTrue()
        {
            //int customerId
            throw new NotSupportedException();
        }

        [TestMethod]
        public void DeleteCustomer_DeleteSelectedCustomer_ReturnTrue()
        {
            //int customerId
            throw new NotSupportedException();
        }

        [TestMethod]
        public void CreateOrder_AddNewOrder_HasStock_ReturnTrue()
        {
            var mockStock = new Mock<InventoryService>();
            var mockOrderConfig = new Mock<IOrderConfig>();
            // If MockBehavior.Strict and NOT setup and NOT Asserted [IsStockAvailable] below exception will be thrown
            // If MockBehavior.Strict and NOT setup and Asserted [IsStockAvailable] below exception will be thrown
            // Exception: Moq.MockException: InventoryService.IsStockAvailable(1, 2) invocation failed with mock behavior Strict. All invocations on the mock must have a corresponding setup.
            // If MockBehavior.Strict and setup and NOT Asserted [IsStockAvailable] ==> Test Passed
            // If MockBehavior.Strict and setup and Asserted [IsStockAvailable] ==> Test Passed

            // If MockBehavior.Loose and NOT setup and NOT Asserted ==> No Exception 
            // If MockBehavior.Loose and NOT setup and Asserted ==> Test failed. Since IsStockAvailable() method is not implemented yet.
            // If MockBehavior.Strict and NOT setup and Asserted [IsStockAvailable] below exception will be thrown
            // If MockBehavior.Loose and setup and NOT Asserted ==> No Exception. Test Pass if [IsStockAvailable] returns true. Test Failed if [IsStockAvailable] returns false.

            //Use of stub - Methods
            mockStock.Setup(x => x.IsStockAvailable(It.IsAny<int>(), It.IsAny<int>())).Returns(true); //This is method stubbing
            //mockOrderConfig.SetupGet(x => x.IsOrderBanned).Returns(false); //Otherway to set property stubbing
            mockOrderConfig.SetupProperty(x => x.IsOrderBanned, false);

            var order = new Order();
            order.CustomerId = 1;
            order.DeliveryDate = new DateTime(2020, 5, 20);
            order.OrderDate = new DateTime(2020, 5, 18);
            order.OrderId = 1;
            order.Details = new List<OrderDetail>
            {
                new OrderDetail { ProductId=1, Quantity=2, UnitPrice=21 },
                new OrderDetail { ProductId=2, Quantity=4, UnitPrice=34 }
            };

            var resultOrderId = mockStock.Object.CreateOrder(mockOrderConfig.Object,order);
            Assert.AreEqual(order.OrderId, resultOrderId);

            //Use of Mock - Verify the method is invoked or not. If yes, how many times it was invoked is checked here
            mockStock.Verify(c => c.IsStockAvailable(It.IsAny<int>(), It.IsAny<int>()), Times.Exactly(2));
            mockOrderConfig.VerifyGet(x => x.IsOrderBanned);
            //mockOrderConfig.VerifySet(x => x.IsOrderBanned = It.IsAny<bool>()); //This can be used if value is get thru program
        }

        [TestMethod]
        public void CreateOrder_AddNewOrder_NoStock_ReturnFalse()
        {
            var mockStock = new Mock<InventoryService>();
            var mockOrderConfig = new Mock<IOrderConfig>();

            mockStock.Setup(x => x.IsStockAvailable(It.IsAny<int>(), It.IsAny<int>())).Returns(false);
            mockOrderConfig.SetupProperty(x => x.IsOrderBanned, false);
            
            var order = new Order
                {
                    OrderId = 1,
                    CustomerId = 1,
                    DeliveryDate = new DateTime(2020, 5, 20),
                    OrderDate = new DateTime(2020, 5, 18),
                    Details = new List<OrderDetail>
                        {
                            new OrderDetail { ProductId=1, Quantity=2, UnitPrice=21 }
                        }
                };
            
            var resultOrderId = mockStock.Object.CreateOrder(mockOrderConfig.Object, order);
            Assert.AreEqual(0, resultOrderId);
        }

        [TestMethod]
        public void UpdateOrder_UpdateSelectedOrder_ReturnTrue()
        {
            throw new NotSupportedException();
        }

        [TestMethod]
        public void GetOrders_ListAllOrders_ReturnTrue()
        {
            throw new NotSupportedException();
        }

        [TestMethod]
        public void GetOrder_RetrieveSelectedOrder_ReturnTrue()
        {
            //int orderId
            throw new NotSupportedException();
        }

        [TestMethod]
        public void DeleteOrder_DeleteSelectedOrder_ReturnTrue()
        {
            //int orderId
            throw new NotSupportedException();
        }

        [TestMethod]
        public void CheckStock_CheckProductStock_HasRequestedQty_ReturnTrue()
        {
            //int productId
            throw new NotSupportedException();
        }

        [TestMethod]
        public void CheckStock_CheckProductStock_NoRequestedQty_ReturnFalse()
        {
            //int productId
            throw new NotSupportedException();
        }

        [TestMethod]
        public void CheckReorderLevel_ReachedLevel_ReturnTrue()
        {
            //int productId
            throw new NotSupportedException();
        }

        [TestMethod]
        public void CheckReorderLevel_NotReachedLevel_ReturnFalse()
        {
            //int productId
            throw new NotSupportedException();
            //UTA007: Method CheckReorderLevel_NotReachedLevel_ReturnFalse defined in class AJInventoryModule.Test.InventoryServiceTest does not have correct signature. 
            //Test method marked with the [TestMethod] attribute must be non-static, public, return-type as void  and should not take any parameter. 
            //Example: public void Test.Class1.Test(). 
            //Additionally, return-type must be Task if you are running async unit tests. 
            //Example: public async Task Test.Class1.Test2()
        }
    }
}
