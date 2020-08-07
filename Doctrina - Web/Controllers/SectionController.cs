using Doctrina___Web.Models;
using Doctrina___Web.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doctrina___Web.Controllers
{
    public class SectionController : Controller
    {
        private readonly IDoctrinaGroupRepository _doctrinaGroupRepository;
        private readonly UserManager<DoctrinaUser> _userManager;

        public SectionController(IDoctrinaGroupRepository doctrinaGroupRepository, UserManager<DoctrinaUser> userManager)
        {
            _doctrinaGroupRepository = doctrinaGroupRepository;
            _userManager = userManager;
        }

        [HttpGet]
        [Route("groups/{groupId}/{sectionId}")]
        public IActionResult Index(string groupId, int sectionId)
        {
            DoctrinaGroup currentGroup = _doctrinaGroupRepository.GetGroup(groupId);
            DoctrinaGroupSection currentSection = _doctrinaGroupRepository.GetSection(sectionId);
            IList<DoctrinaScript> scripts = _doctrinaGroupRepository.GetScripts(sectionId);

            SectionIndexViewModel model = new SectionIndexViewModel
            {
                Group = currentGroup,
                CurrentSection = currentSection,
                Scripts = scripts
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateSettings(SectionIndexViewModel model)
        {
            if(ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(model.SectionSettings.NewName))
                {
                    _doctrinaGroupRepository.UpdateSection(model.CurrentSection.Id, model.SectionSettings);
                }
            }

            return Redirect($"/groups/{model.Group.Id}/{model.CurrentSection.Id}");
        }

        [HttpPost]
        public IActionResult DeleteSection(SectionIndexViewModel model)
        {
            _doctrinaGroupRepository.DeleteSection(model.CurrentSection.Id);

            return Redirect($"/groups/{model.Group.Id}");
        }

        [HttpPost]
        [Route("groups/{groupId}/{sectionId}")]
        public async Task<IActionResult> CreateScript(SectionIndexViewModel model)
        {
            model.CreatedScript.GroupId = model.Group.Id;
            model.CreatedScript.SectionId = model.CurrentSection.Id;
            model.CreatedScript.Creator = await _userManager.GetUserAsync(User);
            model.CreatedScript.DateCreated = DateTime.Now;

            DoctrinaScript newScript = _doctrinaGroupRepository.CreateScript(model.CreatedScript);

            return Redirect($"/groups/{model.Group.Id}/{model.CurrentSection.Id}/{newScript.Id}");
        }

        [HttpGet]
        [Route("groups/{groupId}/{sectionId}/{scriptId}")]
        public IActionResult EditScript(string groupId, int sectionId, string scriptId, EditScriptViewModel model)
        {
            model.ThisScript = _doctrinaGroupRepository.GetScript(scriptId);
            model.GroupId = groupId;
            model.SectionId = sectionId;

            return View(model);
        }

        [HttpPost]
        [Route("groups/{groupId}/{sectionId}/{scriptId}")]
        public async Task<IActionResult> EditScript(EditScriptViewModel model)
        {
            model.ThisScript.LastModifiedBy = await _userManager.GetUserAsync(User);
            model.ThisScript.DateLastModified = DateTime.Now;

            _doctrinaGroupRepository.UpdateScript(model);

            return View(model);
        }

        [HttpPost]
        public IActionResult DeleteScript(EditScriptViewModel model)
        {
            _doctrinaGroupRepository.DeleteScript(model.ThisScript.Id);

            return Redirect($"/groups/{model.GroupId}/{model.SectionId}");
        }

    }
}
