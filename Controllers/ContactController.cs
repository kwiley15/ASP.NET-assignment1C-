using assignment1C_.Controllers;
using assignment1C_.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;

namespace assignment1C_.Controllers
{
    public class ContactController : Controller
    {
        private readonly ManagerContext _context;

        public ContactController(ManagerContext context)
        {
            _context = context;
        }

       
        public async Task<IActionResult> Index()
        {
            var contacts = await _context.Contacts.ToListAsync();


            Console.WriteLine($"Contacts Count: {contacts.Count}"); // Debugging


            return View(contacts);
        }

		public IActionResult ContactDetails(int id)
		{
			// Fetch the contact with the specified ID from the database
			var contact = _context.Contacts.FirstOrDefault(c => c.ContactId == id);

			if (contact == null)
			{
				return NotFound(); // Return a 404 error if the contact is not found
			}

			return View(contact); // Pass the contact to the view
		}
		public IActionResult Add()
		{
			return View("Edit", new Contact());
		}
		public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _context.Contacts
                .FirstOrDefaultAsync(m => m.ContactId == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

      
        public IActionResult CreateContact()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContactId,FirstName,LastName,PhoneNumber,Email,CategoryId,Organization")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contact);
        }

        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }
            return View(contact);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContactId,FirstName,LastName,PhoneNumber,Email,CategoryId,Organization")] Contact contact)
        {
            if (id != contact.ContactId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactExists(contact.ContactId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(contact);
        }

   
        public async Task<IActionResult> DeleteContact(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _context.Contacts
                .FirstOrDefaultAsync(m => m.ContactId == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) // or Guid id
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }

            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index)); // Redirect to the list of contacts after deletion
        }

        private bool ContactExists(int id)
        {
            return _context.Contacts.Any(e => e.ContactId == id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert([Bind("ContactId,FirstName,LastName,PhoneNumber,Email,CategoryId,Organization")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                if (contact.ContactId == 0)
                {
                    // Create new contact
                    _context.Add(contact);
                }
                else
                {
                    // Update existing contact
                    _context.Update(contact);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(contact);
        }








        // firstName
        // lastName
        // phoneNumber
        // email
        // categoryId
        // organization


    }
}
