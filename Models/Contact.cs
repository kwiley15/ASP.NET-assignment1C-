using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
namespace assignment1C_.Models
{
	using System.ComponentModel.DataAnnotations;

	public class Contact
	{
		[Key]
		public int ContactId { get; set; }

		[Required(ErrorMessage = "First Name is required.")]
		public string FirstName { get; set; }

		[Required(ErrorMessage = "Last Name is required.")]
		public string LastName { get; set; }

		[Required(ErrorMessage = "Phone Number is required.")]
		public string PhoneNumber { get; set; }

		[Required(ErrorMessage = "Email is required.")]
		[EmailAddress(ErrorMessage = "Invalid Email Address.")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Category is required.")]
		public int CategoryId { get; set; }
		public string Organization { get; set; }

		public DateTime DateAdded { get; set; }
	}
}

