namespace assignment1C_.Models
{
	using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
	using System.ComponentModel.DataAnnotations;

	// Represents a contact in the application.
	public class Contact
	{
		// Primary key for the Contact entity.
		[Key] // Marks this property as the primary key in the database.
		public int ContactId { get; set; }

		// First Name of the contact, which is required.
		[Required(ErrorMessage = "First Name is required.")] // Ensures this field cannot be null or empty.
		public string FirstName { get; set; }

		// Last Name of the contact, which is required.
		[Required(ErrorMessage = "Last Name is required.")] // Ensures this field cannot be null or empty.
		public string LastName { get; set; }

		// Phone Number of the contact, which is required.
		[Required(ErrorMessage = "Phone Number is required.")] // Ensures this field cannot be null or empty.
		public string PhoneNumber { get; set; }

		// Email of the contact, which is required and must be a valid email address.
		[Required(ErrorMessage = "Email is required.")] // Ensures this field cannot be null or empty.
		[EmailAddress(ErrorMessage = "Invalid Email Address.")] // Validates that the input is a properly formatted email address.
		public string Email { get; set; }

		// Foreign Key for the associated category.
		[Required(ErrorMessage = "Category is required.")] // Ensures this field cannot be null or empty.
		public int CategoryId { get; set; }

		// Navigation property for the associated category.
		[ValidateNever] // Skips validation for this property during model binding.
		public Category Category { get; set; }

		// Optional Organization field.
		[ValidateNever] // Skips validation for this property during model binding.
		public string? Organization { get; set; }

		// Date the contact was added, automatically set when the record is created.
		public DateTime DateAdded { get; set; }

		// Slug for generating SEO-friendly URLs.
		[ValidateNever] // Skips validation for this property during model binding.
		public string Slug { get; set; }

		// Private method to generate a slug based on the contact's first name, last name, and ID.
		public void GenerateSlug()
		{
			if (!string.IsNullOrWhiteSpace(FirstName) && !string.IsNullOrWhiteSpace(LastName))
			{
				// Generate a slug using the ContactId, FirstName, and LastName.
				Slug = $"{ContactId}/{FirstName.ToLower().Trim()}-{LastName.ToLower().Trim()}/";
			}
			else
			{
				// Default slug if FirstName or LastName is missing.
				Slug = "unknown-contact";
			}
		}
	}
}