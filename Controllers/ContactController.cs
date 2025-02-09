using assignment1C_.Controllers;
using assignment1C_.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;

namespace assignment1C_.Controllers
{
	// Controller for managing contacts.
	public class ContactController : Controller
	{
		private readonly ManagerContext _context;

		// Constructor to inject the database context into the controller.
		public ContactController(ManagerContext context)
		{
			_context = context; // Initialize the database context.
		}

		// Action to display the list of all contacts.
		public async Task<IActionResult> Index()
		{
			// Fetch all contacts from the database asynchronously.
			var contacts = await _context.Contacts.ToListAsync();

			// Debugging: Log the number of contacts fetched.
			Console.WriteLine($"Contacts Count: {contacts.Count}");

			// Pass the list of contacts to the view.
			return View(contacts);
		}

		// Action to display details of a specific contact using an optional slug.
		[Route("Contact/ContactDetails/{id}/{slug?}")]
		public async Task<IActionResult> ContactDetails(int? id, string? slug)
		{
			// If no ID is provided, return a 404 error.
			if (id == null)
			{
				return NotFound();
			}

			// Fetch the contact from the database, including related Category data.
			var contact = await _context.Contacts
				.Include(c => c.Category) // Include the related Category entity.
				.FirstOrDefaultAsync(c => c.ContactId == id);

			// If no matching contact is found, return a 404 error.
			if (contact == null)
			{
				return NotFound();
			}

			// Pass the contact object to the view for rendering.
			return View(contact);
		}

		// Action to display the form for adding a new contact.
		public IActionResult Add()
		{
			// Populate the dropdown list of categories.
			var categories = _context.Categories.ToList();
			if (categories == null || !categories.Any())
			{
				categories = new List<Category>(); // Provide an empty list as a fallback.
			}

			// Create a new empty contact object.
			var contact = new Contact
			{
				ContactId = 0,
				FirstName = string.Empty,
				LastName = string.Empty
			};

			// Populate ViewBag with the dropdown list of categories.
			ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName");

			// Render the "Edit" view with the new contact object.
			return View("Edit", contact);
		}

		// Action to display the form for creating a new contact (unused in current flow).
		public IActionResult CreateContact()
		{
			return View();
		}

		// Action to display the form for editing an existing contact.
		public async Task<IActionResult> Edit(int? id)
		{
			// If no ID is provided, return a 404 error.
			if (id == null)
			{
				return NotFound();
			}

			// Fetch the contact from the database, including related Category data.
			var contact = await _context.Contacts
				.Include(c => c.Category) // Include the related Category entity.
				.FirstOrDefaultAsync(c => c.ContactId == id);

			// If no matching contact is found, return a 404 error.
			if (contact == null)
			{
				return NotFound();
			}

			// Populate the dropdown list of categories.
			var categories = await _context.Categories.ToListAsync();
			ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName", contact.CategoryId);

			// Render the "Edit" view with the fetched contact object.
			return View(contact);
		}

		// POST action to handle form submission for adding or updating a contact.
		[HttpPost]
		[ValidateAntiForgeryToken] // Protect against cross-site request forgery (CSRF).
		public async Task<IActionResult> Edit(int id, [Bind("ContactId,FirstName,LastName,PhoneNumber,Email,CategoryId,Organization,Slug")] Contact contact)
		{
			// Ensure the provided ID matches the contact's ID.
			if (id != contact.ContactId)
			{
				return NotFound();
			}

			// If the model state is invalid, log validation errors and return to the form.
			if (!ModelState.IsValid)
			{
				// Log validation errors for debugging purposes.
				foreach (var key in ModelState.Keys)
				{
					var errors = ModelState[key].Errors;
					foreach (var error in errors)
					{
						Console.WriteLine($"Key: {key}, Error: {error.ErrorMessage}");
					}
				}

				// Generate a slug for the contact.
				contact.Slug = GenerateSlug(contact);

				// Repopulate the dropdown list of categories.
				var categories = await _context.Categories.ToListAsync();
				ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName", contact.CategoryId);

				// Return to the form with the invalid contact object.
				return View(contact);
			}

			try
			{
				// Set the DateAdded field for new records.
				if (contact.DateAdded == default)
				{
					contact.DateAdded = DateTime.Now;
				}

				// Update the contact in the database.
				_context.Update(contact);
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				// Handle concurrency exceptions by checking if the contact still exists.
				if (!ContactExists(contact.ContactId))
				{
					return NotFound();
				}
				else
				{
					throw; // Re-throw the exception if the contact exists but there's another issue.
				}
			}

			// Redirect to the home page after successful update.
			return RedirectToAction("Index", "Home");
		}

		// Action to display the confirmation page for deleting a contact.
		public IActionResult DeleteContact(int id)
		{
			// Fetch the contact from the database.
			var contact = _context.Contacts.Find(id);

			// If no matching contact is found, return a 404 error.
			if (contact == null)
			{
				return NotFound();
			}

			// Render the delete confirmation view with the contact object.
			return View(contact);
		}

		// POST action to handle the deletion of a contact.
		[HttpPost, ActionName("DeleteContact")]
		[ValidateAntiForgeryToken] // Protect against CSRF.
		public IActionResult DeleteContactConfirmed(int id)
		{
			// Fetch the contact from the database.
			var contact = _context.Contacts.Find(id);

			// If the contact exists, remove it from the database.
			if (contact != null)
			{
				_context.Contacts.Remove(contact);
				_context.SaveChanges();
			}

			// Redirect to the home page after successful deletion.
			return RedirectToAction("Index", "Home");
		}

		// Helper method to check if a contact with the given ID exists.
		private bool ContactExists(int id)
		{
			return _context.Contacts.Any(e => e.ContactId == id);
		}

		// Helper method to generate a slug for a contact.
		private string GenerateSlug(Contact contact)
		{
			// Generate a slug that includes the ContactId, first name, and last name.
			string firstNamePart = string.IsNullOrWhiteSpace(contact.FirstName) ? "unknown" : contact.FirstName.Trim().ToLower();
			string lastNamePart = string.IsNullOrWhiteSpace(contact.LastName) ? "unknown" : contact.LastName.Trim().ToLower();
			return $"{contact.ContactId}/{firstNamePart}-{lastNamePart}/";
		}

		// POST action to handle upsert (create or update) operations for a contact.
		[HttpPost]
		[ValidateAntiForgeryToken] // Protect against CSRF.
		public async Task<IActionResult> Upsert([Bind("ContactId,FirstName,LastName,PhoneNumber,Email,CategoryId,Organization,Slug")] Contact contact)
		{
			// If the model state is valid, proceed with the operation.
			if (ModelState.IsValid)
			{
				if (contact.ContactId == 0)
				{
					// Create a new contact.
					_context.Add(contact);
				}
				else
				{
					// Update an existing contact.
					_context.Update(contact);
				}

				// Save changes to the database.
				await _context.SaveChangesAsync();

				// Redirect to the index page after successful operation.
				return RedirectToAction(nameof(Index));
			}

			// If the model state is invalid, return to the form with the contact object.
			return View(contact);
		}
	}
}