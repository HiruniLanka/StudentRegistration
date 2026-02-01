using Microsoft.AspNetCore.Mvc;
using StudentRegistration.Application.Services;
using StudentRegistration.Domain.Entities;

namespace StudentRegistration.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        // --------------------
        // LOGIN
        // --------------------
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            User? user = _authService.Login(email, password);

            if (user == null)
            {
                ViewBag.Error = "Invalid email or password";
                return View();
            }

            return RedirectToAction("Index", "Student");
        }

        // --------------------
        // REGISTER
        // --------------------
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user, string password)
        {
            _authService.Register(user, password);
            return RedirectToAction("Login");
        }

        // --------------------
        // FORGOT PASSWORD (NO TOKEN)
        // --------------------
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ForgotPassword(string email, string newPassword)
        {
            bool success = _authService.ResetPasswordByEmail(email, newPassword);

            if (!success)
            {
                ViewBag.Error = "Email not found";
                return View();
            }

            TempData["Message"] = "Password reset successful. Please login.";
            return RedirectToAction("Login");
        }
    }
}
