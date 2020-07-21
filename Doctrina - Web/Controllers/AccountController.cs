using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Doctrina___Web.Models;
using Doctrina___Web.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Doctrina___Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<DoctrinaUser> _signInManager;
        private readonly UserManager<DoctrinaUser> _userManager;

        public AccountController(SignInManager<DoctrinaUser> signInManager, UserManager<DoctrinaUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [AcceptVerbs("GET","POST")]
        public async Task<IActionResult> IsEmailTaken(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if(user == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"Email '{email}' is already taken.");
            }
        }

        [AcceptVerbs("GET", "POST")]
        public async Task<IActionResult> IsUserNameTaken(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"Username '{userName}' is already taken.");
            }
        }

        [HttpGet]
        public IActionResult Login()
        {
            if(User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);

                if(result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Email or password are wrong.");
                }
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if(ModelState.IsValid)
            {
                DoctrinaUser newUser = new DoctrinaUser
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    UserName = model.UserName,
                    Email = model.Email,
                    Country = model.Country,
                    City = model.City
                };

                var result = await _userManager.CreateAsync(newUser, model.Password);

                if(result.Succeeded)
                {
                    await _signInManager.SignInAsync(newUser, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            return View(model);
        }
    }
}