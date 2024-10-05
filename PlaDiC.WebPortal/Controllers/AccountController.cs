using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PlaDiC.Data;
using PlaDiC.WebPortal.Data;
using PlaDiC.WebPortal.ViewModels;

namespace PlaDiC.WebPortal.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;


        public AccountController(SignInManager<User> signInManager, UserManager<User> userManager)
        { 
            this.signInManager = signInManager;
            this.userManager = userManager;
        }
        public IActionResult Login()
        {

            var result = userManager.Users.Count();
            if (result > 0)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Register");

            }
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            var result = await signInManager.PasswordSignInAsync(model.Username!, model.Password!, model.RememberMe, false);
            if (result.Succeeded)
            {

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Intento de inicio incorrecto");
            return View(model);
        }

        public IActionResult Register()
        {
            var result = userManager.Users.Count();
            if (result == 0)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");

            }
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if(ModelState.IsValid)
            {
                User user = new User()
                {

                    UserName = model.Email,
                    Email = model.Email,
                    Name = model.Name!,
                    Address = ""// model.Address!
                };
                var result = await userManager.CreateAsync(user, model.Password!);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            //return RedirectToAction(nameof(HomeController.Index));
            return RedirectToAction("Index", "Home");

        }

        public IActionResult Detail()
        {
            return View();
        }

        public IActionResult Messages()
        {
            return View();
        }
    }
}
