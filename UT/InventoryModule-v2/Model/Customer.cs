using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryModule_v2
{
    public class Customer
    {
        #region Private Members
        private readonly IInventoryService _service; 
        #endregion

        #region Constructor
        public Customer(IInventoryService service)
        {
            _service = service;
        }
        #endregion

        #region Instance Properties
        public int CustomerId { get; set; }

        public string CustomerName { get; set; }

        public string CustomerContact { get; set; }

        public string Address { get; set; }

        public int PinCode { get; set; }
        #endregion

        #region Instance Methods
        public Customer Create()
        {
            return _service.CreateCustomer(this);
        }

        public Customer Update()
        {
            return _service.UpdateCustomer(this.CustomerId, this);
        }

        public bool Delete(int customerId)
        {
            return _service.DeleteCustomer(customerId);
        }

        public List<Customer> GetAllCustomers()
        {
            if (_service.GetCustomers() == null || _service.GetCustomers().Count < 0)
            {
                throw new ArgumentException("No customer exists.");
            }

            return _service.GetCustomers();
        }

        public Customer GetCustomer(int customerId)
        {
            if (_service.GetCustomer(customerId) == null)
            {
                throw new ArgumentException("No customer exist for customer id : " + customerId.ToString());
            }

            return _service.GetCustomer(customerId);
        } 
        #endregion
    }
}
