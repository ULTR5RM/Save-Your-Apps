using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Save_Yoour_Apps.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Save_Yoour_Apps.Views
{
    public class loginModel : PageModel
    {
        [BindProperty]
        public User UUser { get; set; } = new();

        public IActionResult OnGet()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            if (ModelState.IsValid)
            {
                bool user = Work.UserWorker.AuthUser(UUser.Email, UUser.Password);

                if (user == false)
                {
                    ModelState.AddModelError(string.Empty, "Такого пользователя не существует, пожалуйста, зарегестрируйтесь!");
                    return Page();
                }

                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, UUser.Email)
        };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                   
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                ////_logger.LogInformation("User {Email} logged in at {Time}.",
                //    user.Email, DateTime.UtcNow);
                return RedirectToAction("Index", "Home");
                //return LocalRedirect(Url.GetLocalUrl(returnUrl));
            }
            return Page();
        }

    }
}
