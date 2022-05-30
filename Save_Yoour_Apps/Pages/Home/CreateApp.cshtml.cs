using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Save_Yoour_Apps.Models;

namespace Save_Yoour_Apps.Pages.Home
{
    [Authorize]
    public class CreateAppModel : PageModel
    {
        [BindProperty]
        public App NewApp { get; set; } = new();


        public async Task<IActionResult> OnPostAsync()
        {
            NewApp.Identity = Work.AppsWorker.IdentityCreator();
            if (ModelState.IsValid)
            {
                //addUser
                bool app = Work.AppsWorker.CheckName(HttpContext.User.Identity.Name, NewApp.Name);

                if (app == true)
                {
                    ModelState.AddModelError(string.Empty, "[ff[f[[f");
                    return Page();
                }
                Work.AppsWorker.CreateApp(NewApp, HttpContext.User.Identity.Name);

                return RedirectToAction("Apps", "Home");
            }

            // Something failed. Redisplay the form.
            return Page();
        }
    }
}
