using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Save_Yoour_Apps.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Save_Yoour_Apps.Work;


namespace Save_Yoour_Apps.Pages
{
    public class registerModel : PageModel
    {
        [BindProperty]
        public RegUser NewUser { get; set; } = new();

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
                //addUser
                bool user =Work.UserWorker.CheckMail(NewUser.Email);

                if (user == true)
                {
                    ModelState.AddModelError(string.Empty, "Эта почта уже зарегестриована в приложении, пожалуйста, перейдите на страницу входа!");
                    return Page();
                }

                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, NewUser.Email)
        };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    
                };
                UserWorker.AddUser(NewUser);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);
                return RedirectToAction("Index", "Home");
            }
            return Page();
        }
    }
}
