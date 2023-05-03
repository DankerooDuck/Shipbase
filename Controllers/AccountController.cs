using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using GundamEvolutionDatabase.Models;
using GundamEvolutionDatabase.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GundamEvolutionDatabase.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private UserManager<AppUser> userManager;
        private SignInManager<AppUser> signInManager;
        public AccountController(UserManager<AppUser> usrMgr, SignInManager<AppUser> signInMgr)
        {
            userManager = usrMgr;
            signInManager = signInMgr;
        }

        // LOGIN
        [AllowAnonymous]
        public ViewResult Login(string? returnUrl)
        {
            return View(new LoginModel
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                AppUser user = await userManager.FindByNameAsync(loginModel.UName);
                if ((await signInManager.PasswordSignInAsync(user,
                    loginModel.Password, false, false)).Succeeded)
                {
                    return Redirect(loginModel?.ReturnUrl ?? "/");
                }
            }
            ModelState.AddModelError("", "Invalid name or password.");
            return View(loginModel);
        }

        // LOGOUT
        public async Task<RedirectResult> Logout(string returnUrl = "/")
        {
            await signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }

        // CREATE
        [AllowAnonymous]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateModel createModel)
        {
            if (!ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
                    UName = createModel.UName,
                    Email = createModel.Email,
                    FName = createModel.FName,
                    LName = createModel.LName,
                };
                IdentityResult result = await userManager.CreateAsync(user, createModel.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home", new { returnUrl = createModel?.ReturnUrl });
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(createModel);
        }

        // ERRORS
        public void AddErrors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
            {
                ModelState.TryAddModelError("", error.Description);
            }
        }

        // DELETE
        public async Task<IActionResult> Delete(string id)
        {
            AppUser user = await userManager.FindByIdAsync(id);

            if (user != null)
            {
                IdentityResult result = await userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    AddErrors(result);
                }
            }
            else
            {
                ModelState.AddModelError("", "User Not Found");
            }
            return View("Index", userManager.Users);
        }

        // EDIT
        public async Task<IActionResult> Edit(string id)
        {
            AppUser user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                return View(user);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }


    } // end class
} // end namespace

