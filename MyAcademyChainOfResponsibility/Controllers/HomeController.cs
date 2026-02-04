using Microsoft.AspNetCore.Mvc;
using MyAcademyChainOfResponsibility.Models;
using System.Diagnostics;

namespace MyAcademyChainOfResponsibility.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var userFullname = HttpContext.Session.GetString("UserFullname");
            var model = new CustomerProcessViewModel();
            if (!string.IsNullOrEmpty(userFullname))
            {
                model.Name = userFullname;
            }
            return View(model);
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
