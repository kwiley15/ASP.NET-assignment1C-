using System.ComponentModel.DataAnnotations;
namespace assignment1C_.Models
{
	public class Manager

	{
		[Key]
		public int ContactId { get; set; }

		[Required(ErrorMessage = "First name is required")]
		public string FirstName { get; set;}
		[Required(ErrorMessage = "Last name is required")]
		public string LastName { get; set;}
		[Required(ErrorMessage = "Phone number is required")]
		public string PhoneNumber { get; set;}
		[Required(ErrorMessage="Email is required")]
		public string Email { get; set;}
		[Required(ErrorMessage = "CategoryId is required"),Range(1,99999)]
		public int CategoryId { get; set;}
		public string? Organization {  get; set;}
	}
}
