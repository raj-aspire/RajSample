using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryModule_v2
{
    public class Order
    {
        #region Private Members
        private readonly IInventoryService _service; 
        #endregion

        #region Constructor
        public Order(IInventoryService service)
        {
            _service = service;
        }
        #endregion

        #region Instance Properties
        public int OrderId { get; set; }

        public DateTime OrderDate { get; set; }

        public int CustomerId { get; set; }

        public DateTime DeliveryDate { get; set; }

        public decimal OrderTotal
        {
            get
            {
                return (from p in Details select p.Price).Sum();
            }
        }

        public List<OrderDetail> Details { get; set; }
        #endregion

        #region Instance Methods
        public Order Create()
        {
            return _service.CreateOrder(this);
        }

        public Order Update()
        {
            return _service.UpdateOrder(this.OrderId, this);
        }

        public bool Delete(int orderId)
        {
            return _service.DeleteOrder(orderId);
        }

        public List<Order> GetAllOrders()
        {
            if (_service.GetOrders() == null || _service.GetOrders().Count < 0)
            {
                throw new ArgumentException("No order exists.");
            }

            return _service.GetOrders();
        }

        public Order GetOrder(int orderId)
        {
            if (_service.GetOrder(orderId) == null)
            {
                throw new ArgumentException("No order exist for order id : " + orderId.ToString());
            }

            return _service.GetOrder(orderId);
        } 
        #endregion
    }

    public class OrderDetail
    {
        #region Instance Properties
        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

        public decimal Price
        {
            get
            {
                return UnitPrice * Quantity;
            }
        } 
        #endregion
    }
}
