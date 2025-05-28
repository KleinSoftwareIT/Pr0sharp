using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using pr0sharp.Samples.Models;

namespace pr0sharp.Samples.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            if (User.Identity!.IsAuthenticated)
            {
                return View("Samples", new OverviewViewModel() { Username = User.Identity.Name! });
            }

            return View("Login");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
