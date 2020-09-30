using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doctrina___Web.Models
{
    public class DoctrinaDBContext:IdentityDbContext<DoctrinaUser>
    {
        public DoctrinaDBContext(DbContextOptions<DoctrinaDBContext> options)
            :base(options)
        {

        }

        public DbSet<DoctrinaUser> DoctrinaUsers { get; set; }
        public DbSet<DoctrinaGroup> DoctrinaGroups { get; set; }
        public DbSet<DoctrinaUserDoctrinaGroup> DoctrinaUserDoctrinaGroup { get; set; }
        public DbSet<DoctrinaGroupSection> DoctrinaGroupSections { get; set; }
        public DbSet<Friendship> Friendships { get; set; }
        public DbSet<DoctrinaScript> DoctrinaScripts { get; set; }
        public DbSet<DoctrinaSchool> DoctrinaSchools { get; set; }
        public DbSet<DoctrinaUserDoctrinaSchool> DoctrinaUserDoctrinaSchool { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<DoctrinaUserDoctrinaGroup>()
                .HasKey(cs => new { cs.DoctrinaUserId, cs.DoctrinaGroupId });
            builder.Entity<DoctrinaUserDoctrinaGroup>()
                .HasOne(gu => gu.DoctrinaUser)
                .WithMany(u => u.DoctrinaUserDoctrinaGroups)
                .HasForeignKey(gu => gu.DoctrinaUserId);
            builder.Entity<DoctrinaUserDoctrinaGroup>()
                .HasOne(gu => gu.DoctrinaGroup)
                .WithMany(u => u.DoctrinaUserDoctrinaGroups)
                .HasForeignKey(gu => gu.DoctrinaGroupId);
            builder.Entity<DoctrinaGroup>()
                .HasMany(g => g.DoctrinaSections)
                .WithOne(s => s.DoctrinaGroup);
            builder.Entity<Friendship>()
                .HasKey(ck => new { ck.UserId, ck.FriendId });
            builder.Entity<Friendship>()
                .HasOne(f => f.Friend)
                .WithMany(t => t.FriendOf)
                .HasForeignKey(fk => fk.FriendId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Friendship>()
                .HasOne(f => f.User)
                .WithMany(t => t.Friend)
                .HasForeignKey(fk => fk.UserId);
            builder.Entity<DoctrinaUserDoctrinaSchool>()
                .HasKey(cs => new { cs.DoctrinaUserId, cs.DoctrinaSchoolId });
            builder.Entity<DoctrinaUserDoctrinaSchool>()
                .HasOne(us => us.DoctrinaUser)
                .WithMany(u => u.DoctrinaUserDoctrinaSchools)
                .HasForeignKey(us => us.DoctrinaUserId);
            builder.Entity<DoctrinaUserDoctrinaSchool>()
                .HasOne(us => us.DoctrinaSchool)
                .WithMany(u => u.DoctrinaUserDoctrinaSchools)
                .HasForeignKey(us => us.DoctrinaSchoolId);
            base.OnModelCreating(builder);
        }
    }
}
