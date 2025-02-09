using System.ComponentModel.DataAnnotations;

namespace assignment1C_.Models
{
	// Represents a category in the application, used to group contacts.
	public class Category
	{
		// Primary key for the Category entity.
		[Key] // Marks this property as the primary key in the database.
		public int CategoryId { get; set; }

		// Name of the category, which is required and displayed with a custom label.
		[Required(ErrorMessage = "Category is required.")] // Ensures this field cannot be null or empty.
		[Display(Name = "Category Name")] // Sets the display name for forms and validation messages.
		public string CategoryName { get; set; }

		// Navigation property for related contacts.
		// This represents a one-to-many relationship where a category can have multiple contacts.
		[Required(ErrorMessage = "Contacts not found.")] // Ensures the collection is initialized
		public ICollection<Contact> Contacts { get; set; } // A collection of contacts associated with this category.
	}
}