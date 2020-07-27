using Doctrina___Web.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doctrina___Web.Models
{
    public class DoctrinaGroupRepository : IDoctrinaGroupRepository
    {
        private readonly DoctrinaDBContext _db;
        private readonly UserManager<DoctrinaUser> _userManager;

        public DoctrinaGroupRepository(DoctrinaDBContext db, UserManager<DoctrinaUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }
        public DoctrinaGroup CreateGroup(CreateGroupViewModel model, string ownerId)
        {
            DoctrinaGroup result = new DoctrinaGroup
            { 
                Name = model.Name
            };

            _db.Add<DoctrinaGroup>(result);
            _db.SaveChanges();

            _db.Entry(result).GetDatabaseValues();

            DoctrinaUserDoctrinaGroup newUserGroup = new DoctrinaUserDoctrinaGroup
            { 
                DoctrinaGroupId = result.Id,
                DoctrinaUserId = ownerId,
                IsAdmin = true,
                IsInvitePending = false,
                IsRequestPending = false,
            };

            _db.Add<DoctrinaUserDoctrinaGroup>(newUserGroup);
            _db.SaveChanges();

            return result;
        }

        public DoctrinaGroupSection CreateSection(CreateSectionViewModel model)
        {
            DoctrinaGroup currentGroup = this.GetGroup(model.GroupId);

            DoctrinaGroupSection newSection = new DoctrinaGroupSection
            {
                Name = model.Name,
                DoctrinaGroup = currentGroup
            };

            _db.Add<DoctrinaGroupSection>(newSection);
            _db.SaveChanges();

            return newSection;
        }

        public DoctrinaGroup GetGroup(string id)
        {
            var result = _db.DoctrinaGroups.Where(g => g.Id == id).FirstOrDefault();
            return result;
        }

        public IList<string> GetGroupMemberIds(string id)
        {
            List<DoctrinaUserDoctrinaGroup> userGroup = _db.DoctrinaUserDoctrinaGroup.Where(g => g.DoctrinaGroupId == id).ToList();
            List<string> result = new List<string>();
            foreach(var user in userGroup)
            {
                result.Add(user.DoctrinaUserId);
            }

            return result;
        }

        public IList<DoctrinaGroup> GetGroups(string ownerId)
        {
            List<DoctrinaGroup> result = _db.DoctrinaGroups.Where(g => g.DoctrinaUserDoctrinaGroups.Any(u => u.DoctrinaUserId == ownerId)).ToList();
            return result;
        }

        public IList<DoctrinaGroupSection> GetSections(string groupId)
        {
            List<DoctrinaGroupSection> result = _db.DoctrinaGroupSections.Where(g => g.DoctrinaGroup.Id == groupId).ToList();
            return result;
        }
    }
}