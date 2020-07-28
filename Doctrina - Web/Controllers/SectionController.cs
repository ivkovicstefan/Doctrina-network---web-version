using Doctrina___Web.Models;
using Doctrina___Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doctrina___Web.Controllers
{
    public class SectionController:Controller
    {
        private readonly IDoctrinaGroupRepository _doctrinaGroupRepository;

        public SectionController(IDoctrinaGroupRepository doctrinaGroupRepository)
        {
            _doctrinaGroupRepository = doctrinaGroupRepository;
        }

        [HttpGet]
        [Route("mygroups/{groupId}/{sectionId}")]
        public IActionResult Index(string groupId, int sectionId)
        {
            DoctrinaGroup currentGroup = _doctrinaGroupRepository.GetGroup(groupId);
            DoctrinaGroupSection currentSection = _doctrinaGroupRepository.GetSection(sectionId);

            ScriptIndexViewModel model = new ScriptIndexViewModel
            {
                Group = currentGroup,
                CurrentSection = currentSection
            };

            return View(model);
        }
    }
}
