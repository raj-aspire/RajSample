using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AJInventoryModule.Library
{
    public class InventoryService: IInventoryService
    {
        public bool IsBannedArea { get; set; } = true;

        #region Product
        public int CreateProduct(Product product)
        {
            //return 1;
            return 2; //If I return 2 test will fail
        }

        public int UpdateProduct(int productId, Product product)
        {
            return 1;
        }

        public List<Product> GetProducts()
        {
            var productList = new List<Product>();

            return productList;
        }

        public Product GetProduct(int productId)
        {
            var product = new Product();

            return product;
        }

        public bool DeleteProduct(int productId)
        {
            throw new NotImplementedException();
        } 
        #endregion

        #region Customer
        public int CreateCustomer(Customer customer)
        {
            return 1;
        }

        public int UpdateCustomer(int customerId, Customer customer)
        {
            return 1;
        }

        public List<Customer> GetCustomers()
        {
            var customerList = new List<Customer>();

            return customerList;
        }

        public Customer GetCustomer(int customerId)
        {
            var customer = new Customer();

            return customer;
        }

        public bool DeleteCustomer(int customerId)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Order
        public int CreateOrder(IOrderConfig orderConfig, Order order)
        {
            if (orderConfig.IsOrderBanned)
                return 0;

            bool stockStatus = true;
            foreach (var product in order.Details)
            {
                if (!IsStockAvailable(product.ProductId, product.Quantity))
                {
                    stockStatus = false;
                }
            }
            if (!stockStatus)
            {
                return 0;
            }
            return order.OrderId;
        }

        public int UpdateOrder(int orderId, Order order)
        {
            return 1;
        }

        public List<Order> GetOrders()
        {
            var orderList = new List<Order>();

            return orderList;
        }

        public Order GetOrder(int orderId)
        {
            var order = new Order();

            return order;
        }

        public bool DeleteOrder(int orderId)
        {
            throw new NotImplementedException();
        }

        public virtual bool IsStockAvailable(int productId, int quantity)
        {
            //Not implemented yet
            //throw new NotImplementedException();
            return true;
        }

        public bool CheckReorderLevel(int productId)
        {
            //Not implemented yet
            return false;
        } 
        #endregion
    }
}
