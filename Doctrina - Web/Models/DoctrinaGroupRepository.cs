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

        public void DeleteGroup(string id)
        {
            DoctrinaGroup group = _db.Find<DoctrinaGroup>(id);

            IList<DoctrinaGroupSection> sections = _db.DoctrinaGroupSections.Where(s => s.DoctrinaGroup.Id == group.Id).ToList();
            IList<DoctrinaUserDoctrinaGroup> userGroupRelations = _db.DoctrinaUserDoctrinaGroup.Where(gu => gu.DoctrinaGroupId == group.Id).ToList();

            foreach(var section in sections)
            {
                _db.Remove<DoctrinaGroupSection>(section);
            }

            foreach (var relation in userGroupRelations)
            {
                _db.Remove<DoctrinaUserDoctrinaGroup>(relation);
            }

            _db.Remove<DoctrinaGroup>(group);          
            _db.SaveChanges();
        }

        public void DeleteSection(int id)
        {
            DoctrinaGroupSection section = _db.Find<DoctrinaGroupSection>(id);

            _db.Remove<DoctrinaGroupSection>(section);
            _db.SaveChanges();
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

        public DoctrinaGroupSection GetSection(int id)
        {
            DoctrinaGroupSection result = _db.DoctrinaGroupSections.Where(s => s.Id == id).FirstOrDefault();
            return result;
        }

        public IList<DoctrinaGroupSection> GetSections(string groupId)
        {
            List<DoctrinaGroupSection> result = _db.DoctrinaGroupSections.Where(g => g.DoctrinaGroup.Id == groupId).ToList();
            return result;
        }

        public void UpdateGroup(string id, GroupSettingsViewModel newModel)
        {
            DoctrinaGroup group = _db.Find<DoctrinaGroup>(id);

            if(group!=null)
            {
                if(!string.IsNullOrEmpty(newModel.NewName))
                {
                    group.Name = newModel.NewName;
                }

                _db.DoctrinaGroups.Attach(group);
                _db.Entry(group).State = EntityState.Modified;
                _db.SaveChanges();
            }
        }

        public void UpdateSection(int id, SectionSettingsViewModel newModel)
        {
            DoctrinaGroupSection section = _db.Find<DoctrinaGroupSection>(id);

            if(section!=null)
            {
                if(!string.IsNullOrEmpty(newModel.NewName))
                {
                    section.Name = newModel.NewName;
                }

                _db.DoctrinaGroupSections.Attach(section);
                _db.Entry(section).State = EntityState.Modified;
                _db.SaveChanges();
            }
        }

        
    }
}