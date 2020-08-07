using Doctrina___Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Doctrina___Web.Models
{
    public interface IDoctrinaGroupRepository
    {
        /// <summary>
        /// Creates and returns a group.
        /// </summary>
        /// <param name="model">Data from form</param>
        /// <param name="ownerId">Id of a user who creates the group</param>
        /// <returns></returns>
        public DoctrinaGroup CreateGroup(CreateGroupViewModel model, string ownerId);

        /// <summary>
        /// Returns list of groups of particular user.
        /// </summary>
        /// <param name="ownerId"></param>
        /// <returns></returns>
        public IList<DoctrinaGroup> GetGroups(string ownerId);

        /// <summary>
        /// Returns group by provided Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DoctrinaGroup GetGroup(string id);

        /// <summary>
        /// Returns collection of group member id's by provided id of a group
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IList<string> GetGroupMemberIds(string id);

        /// <summary>
        /// Creates and returns section inside the group
        /// </summary>
        /// <param name="model">Section info and group Id</param>
        /// <returns></returns>
        public DoctrinaGroupSection CreateSection(CreateSectionViewModel model);

        /// <summary>
        /// Returns DoctrinaGroupSection object by provided id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DoctrinaGroupSection GetSection(int id);

        /// <summary>
        /// Returns collection of sections of a particular group
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public IList<DoctrinaGroupSection> GetSections(string groupId);

        /// <summary>
        /// Deletes the group with given id and all relationships
        /// </summary>
        /// <param name="id"></param>
        public void DeleteGroup(string id);

        /// <summary>
        /// Deletes the section with given id
        /// </summary>
        /// <param name="id"></param>
        public void DeleteSection(int id);

        /// <summary>
        /// Updates group information, updates only non-null properties
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newModel">model with updated info</param>
        public void UpdateGroup(string id, GroupSettingsViewModel newModel);

        /// <summary>
        /// Updates section information, updates only non-null properties
        /// </summary>
        /// <param name="id">Section Id</param>
        /// <param name="sectionSettings">model with updated info</param>
        public void UpdateSection(int id, SectionSettingsViewModel sectionSettings);

        /// <summary>
        /// Creates new script inside section.
        /// </summary>
        /// <param name="model"></param>
        public DoctrinaScript CreateScript(CreateScriptViewModel model);

        /// <summary>
        /// Returns script by provided id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DoctrinaScript GetScript(string id);

        /// <summary>
        /// Returns scripts for requested section
        /// </summary>
        /// <param name="sectionId">Id of particular section</param>
        /// <returns></returns>
        public IList<DoctrinaScript> GetScripts(int sectionId);

        /// <summary>
        /// Updates and returns script by proided id
        /// </summary>
        /// <param name="model">model with updated info</param>
        /// <returns></returns>
        public DoctrinaScript UpdateScript(EditScriptViewModel model);

        /// <summary>
        /// Finds and deletes a script by provided id
        /// </summary>
        /// <param name="id"></param>
        public void DeleteScript(string id);


    }
}
