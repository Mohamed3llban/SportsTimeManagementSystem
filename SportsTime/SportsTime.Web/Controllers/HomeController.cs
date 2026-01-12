using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using SportsTime.Models;
using Microsoft.AspNetCore.Authorization;
using SportsTime.Web.Models;

namespace SportsTime.Web.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}
		[Authorize]
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult ComingSoon()
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