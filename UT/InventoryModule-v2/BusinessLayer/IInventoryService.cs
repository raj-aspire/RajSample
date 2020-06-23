using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryModule_v2
{
    public interface IInventoryService
    {
        #region Product
        Product CreateProduct(Product product);

        Product UpdateProduct(int productId, Product product);

        List<Product> GetProducts();

        Product GetProduct(int productId);

        bool DeleteProduct(int productId);
        #endregion

        #region Customer
        Customer CreateCustomer(Customer customer);

        Customer UpdateCustomer(int customerId, Customer customer);

        List<Customer> GetCustomers();

        Customer GetCustomer(int customerId);

        bool DeleteCustomer(int customerId);
        #endregion

        #region Order
        Order CreateOrder(Order order);

        Order UpdateOrder(int orderId, Order order);

        List<Order> GetOrders();

        Order GetOrder(int orderId);

        bool DeleteOrder(int orderId);

        bool IsStockAvailable(int productId, int quantity);

        bool CheckReorderLevel(int productId); 
        #endregion
    }
}
