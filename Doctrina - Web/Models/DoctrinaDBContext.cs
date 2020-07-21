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

        /// <summary>
        /// Configruing Many-To-Many relationship between Users and Groups, and One-To-Many relationship between group and sections
        /// </summary>
        /// <param name="builder"></param>
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
            base.OnModelCreating(builder);
        }
    }
}
