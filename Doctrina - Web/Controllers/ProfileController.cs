using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Doctrina___Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Doctrina___Web.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly UserManager<DoctrinaUser> _userManager;

        public ProfileController(UserManager<DoctrinaUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        [Route("/user/{userName}")]
        public async Task<IActionResult> Index(string userName)
        {
            DoctrinaUser user = await _userManager.FindByNameAsync(userName);
            
            return View(user);
        }
    }
}