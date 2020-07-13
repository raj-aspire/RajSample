using ContactApp.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactApp.Pages.SchoolContacts
{
    public class IndexModel : PageModel
    {
        private readonly ContactApp.Data.ContactAppDbContext _context;

        public IndexModel(ContactApp.Data.ContactAppDbContext context)
        {
            _context = context;
        }

        public IList<SchoolContact> SchoolContact { get; set; }

        public async Task OnGetAsync()
        {
            SchoolContact = await _context.SchoolContact.ToListAsync();
        }
    }
}
