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

			if (!ModelState.IsValid)
			{
				// Log validation errors for debugging
				foreach (var key in ModelState.Keys)
				{
					var errors = ModelState[key].Errors;
					foreach (var error in errors)
					{
						Console.WriteLine($"Key: {key}, Error: {error.ErrorMessage}");
					}
				}
				return View(contact); // Return to the form with errors
			}

			try
			{
				// Set DateAdded to the current date and time
				contact.DateAdded = DateTime.Now;

				// Update the contact in the database
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
					throw; // Consider logging or handling this more gracefully
				}
			}

			return RedirectToAction("Index", "Home"); // Redirects to /Home/Index
		}


		public IActionResult DeleteContact(int id)
		{
			var contact = _context.Contacts.Find(id);
			if (contact == null)
			{
				return NotFound();
			}
			return View(contact);
		}


		[HttpPost, ActionName("DeleteContact")]
		[ValidateAntiForgeryToken]
		public IActionResult DeleteContactConfirmed(int id)
		{
			var contact = _context.Contacts.Find(id);
			if (contact != null)
			{
				_context.Contacts.Remove(contact);
				_context.SaveChanges();
			}
			return RedirectToAction("Index", "Home"); // Redirects to /Home/Index
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
