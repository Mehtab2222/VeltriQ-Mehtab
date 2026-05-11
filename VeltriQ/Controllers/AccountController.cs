using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VeltriQ.Models.Core;
using VeltriQ.ViewModels;
using VeltriQ.Data;

using VeltriQ.Models.Master;
namespace VeltriQ.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser>
            _signInManager;

        private readonly UserManager<ApplicationUser>
            _userManager;

        private readonly MasterDbContext
           _masterContext;

        public AccountController
        (
            SignInManager<ApplicationUser> signInManager,

            UserManager<ApplicationUser> userManager,

            MasterDbContext masterContext
        )
        {
            _signInManager = signInManager;

            _userManager = userManager;

            _masterContext = masterContext;
        }

        // LOGIN PAGE

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // LOGIN POST

        [HttpPost]
        public async Task<IActionResult> Login
        (
            LoginViewModel model
        )
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager
                .FindByEmailAsync(model.Email);

            if (user == null)
            {
                ModelState.AddModelError
                (
                    "",
                    "Invalid email or password."
                );

                return View(model);
            }

            var result =
                await _signInManager.PasswordSignInAsync
                (
                    user.UserName,
                    model.Password,
                    model.RememberMe,
                    false
                );
            if (result.Succeeded)
            {
                var defaultCompany =
                    (
                        from access in _masterContext.UserCompanyAccesses

                        join comp in _masterContext.Companies
                        on access.CompanyId equals comp.CompanyId

                        where access.UserId == user.Id
                              && access.IsDefault

                        select comp
                    )

                    .FirstOrDefault();

                if (defaultCompany != null)
                {
                    HttpContext.Session.SetInt32
                    (
                        "ActiveCompanyId",
                        defaultCompany.CompanyId
                    );

                    HttpContext.Session.SetString
                    (
                        "ActiveCompanyName",
                        defaultCompany.CompanyName
                    );
                }

                return RedirectToAction
                (
                    "Index",
                    "Dashboard"
                );
            }

            ModelState.AddModelError
            (
                "",
                "Invalid email or password."
            );

            return View(model);

        }

        // LOGOUT

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            // Clear the Session
            HttpContext.Session.Clear();

            // If using Cookie Auth, sign out
            // await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login", "Account");
        }
    }
}