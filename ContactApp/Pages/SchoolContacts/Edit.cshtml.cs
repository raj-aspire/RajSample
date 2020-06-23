using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ContactApp.Data;
using ContactApp.Models;

namespace ContactApp.Pages.SchoolContacts
{
    public class EditModel : PageModel
    {
        private readonly ContactApp.Data.ContactAppDbContext _context;

        public EditModel(ContactApp.Data.ContactAppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(SchoolContact).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SchoolContactExists(SchoolContact.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SchoolContactExists(int id)
        {
            return _context.SchoolContact.Any(e => e.Id == id);
        }
    }
}
