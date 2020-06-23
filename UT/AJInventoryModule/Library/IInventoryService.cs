using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AJInventoryModule.Library
{
    public interface IInventoryService
    {
        bool IsBannedArea { get; set; }

        #region Product
        int CreateProduct(Product product);

        int UpdateProduct(int productId, Product product);

        List<Product> GetProducts();

        Product GetProduct(int productId);

        bool DeleteProduct(int productId);
        #endregion

        #region Customer
        int CreateCustomer(Customer customer);

        int UpdateCustomer(int customerId, Customer customer);

        List<Customer> GetCustomers();

        Customer GetCustomer(int customerId);

        bool DeleteCustomer(int customerId);
        #endregion

        #region Order
        int CreateOrder(IOrderConfig orderConfig, Order order);

        int UpdateOrder(int orderId, Order order);

        List<Order> GetOrders();

        Order GetOrder(int orderId);

        bool DeleteOrder(int orderId);

        bool IsStockAvailable(int productId, int quantity);

        bool CheckReorderLevel(int productId); 
        #endregion
    }
}
