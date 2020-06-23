using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ContactApp.Models;

namespace ContactApp.Data
{
    public class ContactAppDbContext : DbContext
    {
        public ContactAppDbContext (DbContextOptions<ContactAppDbContext> options)
            : base(options)
        {
        }

        public DbSet<ContactApp.Models.SchoolContact> SchoolContact { get; set; }
    }
}
