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
    }
}
