using InventoryModule_v2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryModuleConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            IInventoryService service = new InventoryService();
            Customer cust = new Customer(service)
            {
                CustomerId =1,
                CustomerName = "Raja",
                Address = "Chennai",
                CustomerContact = "98406"
            };

            var result = cust.Create();
            Console.WriteLine(result);
            Console.ReadLine();

        }
    }
}
