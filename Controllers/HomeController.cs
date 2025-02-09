using System.Diagnostics;
using assignment1C_.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace assignment1C_.Controllers
{
	// Controller for handling general application actions like the home page and privacy policy.
	public class HomeController : Controller
	{
		private readonly ManagerContext _context; // Database context for accessing contacts.
		private readonly ILogger<HomeController> _logger; // Logger for logging application events.

		// Constructor to inject dependencies (Logger and Database Context) into the controller.
		public HomeController(ILogger<HomeController> logger, ManagerContext context)
		{
			_logger = logger; // Initialize the logger for logging purposes.
			_context = context; // Initialize the database context for data access.
		}

		// Action to display the home page with a list of contacts.
		public IActionResult Index()
		{
			// Fetch all contacts from the database and convert them to a list.
			var contacts = _context.Contacts.ToList();

			// Pass the list of contacts to the view for rendering.
			return View(contacts);
		}

		// Action to display the privacy policy page.
		public IActionResult Privacy()
		{
			// Render the Privacy view.
			return View();
		}

		// Action to handle errors and display an error page.
		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		// The ResponseCache attribute ensures that the error page is not cached.
		public IActionResult Error()
		{
			// Create an ErrorViewModel containing the request ID for debugging purposes.
			return View(new ErrorViewModel
			{
				RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
			});
		}
	}
}
