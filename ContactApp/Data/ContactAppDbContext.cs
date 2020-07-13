using Microsoft.EntityFrameworkCore;

namespace ContactApp.Data
{
    public class ContactAppDbContext : DbContext
    {
        public ContactAppDbContext(DbContextOptions<ContactAppDbContext> options)
            : base(options)
        {
        }

        public DbSet<ContactApp.Models.SchoolContact> SchoolContact { get; set; }
    }
}
