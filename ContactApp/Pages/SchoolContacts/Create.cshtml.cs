using ContactApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace ContactApp.Pages.SchoolContacts
{
    public class CreateModel : PageModel
    {
        private readonly ContactApp.Data.ContactAppDbContext _context;

        public CreateModel(ContactApp.Data.ContactAppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public SchoolContact SchoolContact { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.SchoolContact.Add(SchoolContact);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}