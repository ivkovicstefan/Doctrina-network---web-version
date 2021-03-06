﻿using Doctrina___Web.Models;
using Doctrina___Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doctrina___Web.Controllers
{
    [Authorize]
    public class GroupController : Controller
    {
        private readonly IDoctrinaGroupRepository _doctrinaGroupRepository;
        private readonly UserManager<DoctrinaUser> _userManager;

        public GroupController(IDoctrinaGroupRepository doctrinaGroupRepository, UserManager<DoctrinaUser> userManager)
        {
            _doctrinaGroupRepository = doctrinaGroupRepository;
            _userManager = userManager;
        }

        [HttpGet]
        [Route("/groups/create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("/groups/create")]
        public async Task<IActionResult> Create(CreateGroupViewModel model)
        {
            if(ModelState.IsValid)
            {
                var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);
                DoctrinaGroup newGroup = _doctrinaGroupRepository.CreateGroup(model, currentUser.Id);
                if (newGroup != null)
                {
                    return Redirect($"/groups/{newGroup.Id}");
                }
            }

            return View(model);
        }

        [HttpGet]
        [Route("/groups/{id}")]
        public async Task<IActionResult> Index(string id)
        {
            DoctrinaGroup group = _doctrinaGroupRepository.GetGroup(id);
            GroupViewModel model = new GroupViewModel
            {
                Group = group,
                Members = new List<DoctrinaUser>(),
                Sections = _doctrinaGroupRepository.GetSections(id)
            };

            foreach(var userId in _doctrinaGroupRepository.GetGroupMemberIds(id))
            {
                var user = await _userManager.FindByIdAsync(userId);
                model.Members.Add(user);
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateSettings(GroupViewModel model)
        {
            if(ModelState.IsValid)
            {
                if(!string.IsNullOrEmpty(model.Settings.NewName))
                {
                    _doctrinaGroupRepository.UpdateGroup(model.Group.Id, model.Settings);
                }
            }

            return Redirect($"/groups/{model.Group.Id}");
        }

        [HttpPost]
        public IActionResult DeleteGroup(GroupViewModel model)
        {
            _doctrinaGroupRepository.DeleteGroup(model.Group.Id);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Route("/groups/all")]
        public async Task<IActionResult> MyGroups()
        {
            var user = await _userManager.GetUserAsync(User);

            HomeViewModel model = new HomeViewModel
            {
                Groups = _doctrinaGroupRepository.GetGroups(user.Id)
            };

            return View(model);
        }

        [HttpGet]
        [Route("groups/{id}/sections/create")]
        public IActionResult CreateSection(string id)
        {
            CreateSectionViewModel model = new CreateSectionViewModel
            {
                GroupId = id
            };

            return View(model);
        }

        [HttpPost]
        [Route("groups/{id}/sections/create")]
        public IActionResult CreateSection(CreateSectionViewModel model)
        {
            if(ModelState.IsValid)
            {
                _doctrinaGroupRepository.CreateSection(model);

                return RedirectToAction("Index", "Group", $"{model.GroupId}");
            }

            return View(model);
        }
    }
}
