using System.Diagnostics;
using assignment1C_.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace assignment1C_.Controllers
{
    public class HomeController : Controller
    {
		private readonly ILogger<HomeController> _logger;
		private readonly ManagerContext _context;

		public HomeController(ILogger<HomeController> logger, ManagerContext context)
		{
			_logger = logger;
			_context = context;
		}

		public IActionResult Index()
		{
			var contacts = _context.Contacts.ToList(); // Fetch data from the database
			return View(contacts); // Pass the data to the view
		}

		public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
