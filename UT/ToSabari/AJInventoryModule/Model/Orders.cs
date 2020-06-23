using AJInventoryModule.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AJInventoryModule
{
    public class Order
    {
        public int OrderId { get; set; }

        public DateTime OrderDate { get; set; }

        public int CustomerId { get; set; }

        public DateTime DeliveryDate { get; set; }

        public List<OrderDetail> Details { get; set; }
    }

    public class OrderDetail
    {
        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

        public decimal Price {
            get {
                return UnitPrice * Quantity;
            }
        }
    }
}
