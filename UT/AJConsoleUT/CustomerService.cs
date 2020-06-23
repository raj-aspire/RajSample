using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AJConsoleUT
{
    public interface ICustomerAddressBuilder
    {
        Address From(CustomerToCreateDto customerToCreateDto);
    }

    public interface ICustomerRepository
    {
        void Save(Customer customer);
    }

    public interface IIdFactory
    {
        int Create();
    }

    public class CustomerToCreateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address MailingAddress { get; set; }
        
    }

    public class Address
    {

    }

    //public class CustomerService
    //{
    //    private readonly ICustomerAddressBuilder _customerAddressBuilder;
    //    private readonly ICustomerRepository _customerRepository;

    //    public CustomerService(ICustomerAddressBuilder customerAddressBuilder, ICustomerRepository customerRepository)
    //    {
    //        _customerAddressBuilder = customerAddressBuilder;
    //        _customerRepository = customerRepository;
    //    }

    //    public void Create(CustomerToCreateDto customerToCreate)
    //    {
    //        var customer = new Customer { FirstName = customerToCreate.FirstName, LastName = customerToCreate.LastName };

    //        customer.MailingAddress = _customerAddressBuilder.From(customerToCreate);

    //        if (customer.MailingAddress == null)
    //            throw new InvalidCustomerMailingAddressException();

    //        _customerRepository.Save(customer);
    //    }
    //}

    public class CustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IIdFactory _idFactory;

        public CustomerService(ICustomerRepository customerRepository, IIdFactory idFactory)
        {
            _customerRepository = customerRepository;
            _idFactory = idFactory;
        }

        public void Create(IEnumerable<CustomerToCreateDto> customerToCreate)
        {
            foreach (var customerToCreateDto in customerToCreate)
            {
                var customer = new Customer { FirstName = customerToCreateDto.FirstName, LastName = customerToCreateDto.LastName };

                customer.Id = _idFactory.Create();

                _customerRepository.Save(customer);
            }
            
        }
    }

    [Serializable]
    public class InvalidCustomerMailingAddressException : Exception
    {
        public InvalidCustomerMailingAddressException() { }
        public InvalidCustomerMailingAddressException(string message) : base(message) { }
        public InvalidCustomerMailingAddressException(string message, Exception inner) : base(message, inner) { }
        protected InvalidCustomerMailingAddressException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
