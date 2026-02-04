using Microsoft.AspNetCore.Mvc;
using MyAcademyChainOfResponsibility.DataAccess.Context;
using MyAcademyChainOfResponsibility.DataAccess.Entities;

namespace MyAcademyChainOfResponsibility.Controllers
{
    public class LoginController : Controller
    {
        private readonly CoFContext _context;

        public LoginController(CoFContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(AppUser appUser)
        {
            var user = _context.AppUsers.FirstOrDefault(x => x.Username == appUser.Username && x.Password == appUser.Password);

            if (user != null)
            {
                HttpContext.Session.SetString("UserFullname", user.Name + " " + user.Surname);
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Kullanıcı adı veya şifre hatalı.";
            return View();
        }
    }
}
