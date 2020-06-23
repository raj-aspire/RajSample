using System;
using System.Data.Entity;
using AJWebAPI_v2.Models;

namespace AJWebAPI_v2.Tests
{
    public class TestStoreAppContext : IStoreAppContext
    {
        public TestStoreAppContext()
        {
            this.Products = new TestProductDbSet();
        }

        public DbSet<Product> Products { get; set; }

        public int SaveChanges()
        {
            return 0;
        }

        public void MarkAsModified(Product item) { }
        public void Dispose() { }
    }
}
