using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AJInventoryModule
{
    public class Customer : ICustomer
    {
        public int CustomerId { get; set; }

        public string CustomerName { get; set; }

        public string CustomerContact { get; set; }

        public string Address { get; set; }

        public bool IsBannedArea { get; set; }
    }

    public interface ICustomer
    {
        int CustomerId { get; set; }

        string CustomerName { get; set; }

        string CustomerContact { get; set; }

        string Address { get; set; }

        bool IsBannedArea { get; set; }
    }
}
