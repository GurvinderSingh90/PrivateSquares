using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PrivateSquares.Data.Configurations;
using PrivateSquares.Data.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrivateSquares.Data.Persistences
{
    public class PrivateSquaresDbContext : DbContext
    {

        public PrivateSquaresDbContext(DbContextOptions<PrivateSquaresDbContext>options):base(options){ }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; } 
        public DbSet<Verify> Verifies { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Portfolio> Portfolio { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected  override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new UserConfiguration(modelBuilder.Entity<User>());
            new UserRoleConfiguration(modelBuilder.Entity<UserRole>());
            new RoleConfiguration(modelBuilder.Entity<Role>());
            new VerifyConfiguration(modelBuilder.Entity<Verify>());
            new EducationConfiguration(modelBuilder.Entity<Education>());
            new ExperienceConfiguration(modelBuilder.Entity<Experience>());
            new PortfolioConfiguration(modelBuilder.Entity<Portfolio>());
        }
    }
}
