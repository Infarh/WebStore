using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebStore.Entities.Identity;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _UserManager;
        private readonly SignInManager<User> _SignInManager;

        public AccountController(UserManager<User> UserManager, SignInManager<User> SignInManager)
        {
            _UserManager = UserManager;
            _SignInManager = SignInManager;
        }

        [HttpGet] public IActionResult Login() => View(new LoginUserViewModel());

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            var login_result = await _SignInManager.PasswordSignInAsync(
                model.UserName, model.Password, model.RememberMe, false);
            if (login_result.Succeeded)
                return Url.IsLocalUrl(model.ReturnUrl)
                    ? (IActionResult) Redirect(model.ReturnUrl)
                    : RedirectToAction("Index", "Home");
            ModelState.AddModelError("", "Неверное имя пользователя либо пароль");
            return View(model);
        }

        #region public IActionResult Register() => View(new RegisterUserViewModel());
        [HttpGet]
        public IActionResult Register() => View(new RegisterUserViewModel());

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            var user = new User { UserName = model.UserName };
            var creation_result = await _UserManager.CreateAsync(user, model.Password);
            if (creation_result.Succeeded)
            {
                await _SignInManager.SignInAsync(user, false);
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            foreach (var identity_error in creation_result.Errors)
                ModelState.AddModelError("", identity_error.Description);

            return View(model);
        } 
        #endregion

        public async Task<IActionResult> Logout()
        {
            await _SignInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}