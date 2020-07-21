using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Doctrina___Web.Models;
using Doctrina___Web.ViewModels;

namespace Doctrina___Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly UserManager<DoctrinaUser> _userManager;
        private readonly IDoctrinaUserRepository _userRepository;
        private readonly IDoctrinaGroupRepository _groupRepository;

        public HomeController(UserManager<DoctrinaUser> userManager, IDoctrinaUserRepository userRepository, IDoctrinaGroupRepository groupRepository)
        {
            _userManager = userManager;
            _userRepository = userRepository;
            _groupRepository = groupRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            HomeViewModel model = new HomeViewModel();
            var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);
            model.Groups = _groupRepository.GetGroups(currentUser.Id);
            return View(model);
        }

        [HttpGet]
        [Route("/search/{searchText}")]
        public IActionResult Search(string searchText)
        {
            HomeSearchViewModel model = new HomeSearchViewModel
            {
                Results = _userRepository.SearchUsers(searchText),
                Query = searchText
            };
            return View(model);
        }

    }
}
