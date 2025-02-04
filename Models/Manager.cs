namespace assignment1C_.Models
{
	public class Manager
	{
		[Required(ErrorMessage = "First name is required")]
		public string firstName { get; set;}
		[Required(ErrorMessage = "Last name is required")]
		public string lastName { get; set;}
		[Required(ErrorMessage = "Phone number is required")]
		public string phoneNumber { get; set;}
		[Required(ErrorMessage="Email is required")]
		public string email { get; set;}
		[Required(ErrorMessage = "CategoryId is required"),Range(1,99999)]
		public int categoryId { get; set;}
		public string? organization {  get; set;}
	}
}
