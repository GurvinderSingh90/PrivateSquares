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

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected  override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new UserConfiguration(modelBuilder.Entity<User>());
        }
    }
}
