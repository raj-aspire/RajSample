using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ContactApp.Data;
using ContactApp.Models;

namespace ContactApp.Pages.SchoolContacts
{
    public class DetailsModel : PageModel
    {
        private readonly ContactApp.Data.ContactAppDbContext _context;

        public DetailsModel(ContactApp.Data.ContactAppDbContext context)
        {
            _context = context;
        }

        public SchoolContact SchoolContact { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SchoolContact = await _context.SchoolContact.FirstOrDefaultAsync(m => m.Id == id);

            if (SchoolContact == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
