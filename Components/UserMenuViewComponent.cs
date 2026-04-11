using ExamMeAI.Providers;
//using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ExamMeAI.Components
{
    public class UserMenuViewComponent : ViewComponent
    {
        //private readonly UserManager<IdentityUser> _userManager;

        //public UserMenuViewComponent(UserManager<IdentityUser> userManager)
        //{
        //    _userManager = userManager;
        //}
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = new AuthenticatedUser
            {
                _name = HttpContext.User.FindFirst(ClaimTypes.Name)?.Value,
                _email = HttpContext.User.FindFirst(ClaimTypes.Email)?.Value,
                _role = HttpContext.User.FindFirst(ClaimTypes.Role)?.Value
            };

            return View(viewName: "Default", model: user);
        }
    }
}
