using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrivateSquares.Data.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrivateSquares.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public UserConfiguration(EntityTypeBuilder<User> entityTypeBuilder)
        {
            Configure(entityTypeBuilder);
        }

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.ID);
            builder.HasIndex(x => x.UserID).IsUnique();
            builder.Property(x => x.Title).HasMaxLength(500).IsRequired(false);
            builder.Property(x => x.FirtsName).IsRequired().HasMaxLength(50).IsRequired(false);
            builder.Property(x => x.LastName).HasMaxLength(50).IsRequired(false);
            builder.Property(x => x.Email).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Mobile).HasMaxLength(10).IsRequired(false);
            builder.Property(x => x.Password).HasMaxLength(30).IsRequired(true);
            builder.Property(x => x.Photo).HasMaxLength(200).IsRequired(false);
            builder.Property(x => x.CreatedOn).IsRequired(true);
        }

    }
}
