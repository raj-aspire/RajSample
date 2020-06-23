using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryModule_v2
{
    public class InventoryService: IInventoryService
    {
        #region Product
        public Product CreateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Product UpdateProduct(int productId, Product product)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProducts()
        {
            var productList = new List<Product>();

            return productList;
        }

        public Product GetProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public bool DeleteProduct(int productId)
        {
            throw new NotImplementedException();
        } 
        #endregion

        #region Customer
        public Customer CreateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Customer UpdateCustomer(int customerId, Customer customer)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetCustomers()
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomer(int customerId)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCustomer(int customerId)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Order
        public Order CreateOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public Order UpdateOrder(int orderId, Order order)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetOrders()
        {
            var orderList = new List<Order>();

            return orderList;
        }

        public Order GetOrder(int orderId)
        {
            throw new NotImplementedException();
        }

        public bool DeleteOrder(int orderId)
        {
            throw new NotImplementedException();
        }

        public bool IsStockAvailable(int productId, int quantity)
        {
            throw new NotImplementedException();
        }

        public bool CheckReorderLevel(int productId)
        {
            throw new NotImplementedException();
        } 
        #endregion
    }
}
