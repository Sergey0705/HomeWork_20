using HomeWork_20.Models;
using HomeWork_20.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeWork_20.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ShoppingCart _shoppingCart;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, ShoppingCart shoppingCart)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _shoppingCart = shoppingCart;
        }

        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.isAdd = false;
            ViewBag.isHome = false;
            ViewBag.isCourses = false;
            ViewBag.isLogin = false;
            ViewBag.isRegister = true;

            return View(new UserRegistration());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserRegistration model)
        {
            ViewBag.isAdd = false;
            ViewBag.isHome = false;
            ViewBag.isCourses = false;
            ViewBag.isLogin = false;
            ViewBag.isRegister = false;

            if (ModelState.IsValid)
            {
                var user = new User { UserName = model.LoginProp };
          
                var createResult = await _userManager.CreateAsync(user, model.Password);

                if (createResult.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var identityError in createResult.Errors)
                    {
                        ModelState.AddModelError("", identityError.Description);
                    }
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            ViewBag.isAdd = false;
            ViewBag.isHome = false;
            ViewBag.isCourses = false;
            ViewBag.isLogin = true;
            ViewBag.isRegister = false;

            return View(new UserLogin()
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserLogin model)
        {
            ViewBag.isAdd = false;
            ViewBag.isHome = false;
            ViewBag.isCourses = false;
            ViewBag.isLogin = false;
            ViewBag.isRegister = false;

            if (ModelState.IsValid)
            {
                var loginResult = await _signInManager.PasswordSignInAsync(model.LoginProp,
                    model.Password,
                    false,
                    lockoutOnFailure: false);

                if (loginResult.Succeeded)
                {
                    if (Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }

                    return RedirectToAction("Index", "Home");
                }

            }

            ModelState.AddModelError("", "Пользователь не найден");
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            _shoppingCart.ClearCart();
            return RedirectToAction("Index", "Home");
        }
    }
}
