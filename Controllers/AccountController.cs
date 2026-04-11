using ExamMeAI.Models;
using ExamMeAI.Providers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ExamMeAI.Controllers
{
    public class AccountController : Controller
    {

        [HttpGet]
        public IActionResult Login(string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string? returnUrl = null)
        {
            if (!ModelState.IsValid) View(model);

            var user = new AuthenticatedUser().Authenticate(model.Email, model.Password); // Twoja logika

            if (user == null) Unauthorized();

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user._name),
                new Claim(ClaimTypes.Email, user._email),
                new Claim(ClaimTypes.Role, user._role),
            };

            var identity = new ClaimsIdentity(
                claims,
                CookieAuthenticationDefaults.AuthenticationScheme
            );

            var principal = new ClaimsPrincipal(identity);

            var authProps = new AuthenticationProperties
            {
                IsPersistent = true, // "Remember me"
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(20)
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                principal,
                authProps
            );

            //Tylko administrator
            if (returnUrl is not null)
            {
                if (returnUrl.Contains("Domain") && user._role != "Administrator")
                    return RedirectToAction("Index", "Home");
            }

            if (!string.IsNullOrEmpty(returnUrl))
                return Redirect(returnUrl);

            return RedirectToAction("Index", "Home");
        }
    }
}