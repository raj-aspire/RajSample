using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContactApp.Data;
using ContactApp.Models;

namespace ContactApp.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolContactsController : ControllerBase
    {
        private readonly ContactAppDbContext _context;

        public SchoolContactsController(ContactAppDbContext context)
        {
            _context = context;
        }

        // GET: api/SchoolContacts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SchoolContact>>> GetSchoolContact()
        {
            return await _context.SchoolContact.ToListAsync();
        }

        // GET: api/SchoolContacts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SchoolContact>> GetSchoolContact(int id)
        {
            var schoolContact = await _context.SchoolContact.FindAsync(id);

            if (schoolContact == null)
            {
                return NotFound();
            }

            return schoolContact;
        }

        // PUT: api/SchoolContacts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSchoolContact(int id, SchoolContact schoolContact)
        {
            if (id != schoolContact.Id)
            {
                return BadRequest();
            }

            _context.Entry(schoolContact).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SchoolContactExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/SchoolContacts
        [HttpPost]
        public async Task<ActionResult<SchoolContact>> PostSchoolContact(SchoolContact schoolContact)
        {
            _context.SchoolContact.Add(schoolContact);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSchoolContact", new { id = schoolContact.Id }, schoolContact);
        }

        // DELETE: api/SchoolContacts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SchoolContact>> DeleteSchoolContact(int id)
        {
            var schoolContact = await _context.SchoolContact.FindAsync(id);
            if (schoolContact == null)
            {
                return NotFound();
            }

            _context.SchoolContact.Remove(schoolContact);
            await _context.SaveChangesAsync();

            return schoolContact;
        }

        private bool SchoolContactExists(int id)
        {
            return _context.SchoolContact.Any(e => e.Id == id);
        }
    }
}
