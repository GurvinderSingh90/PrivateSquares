using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrivateSquares.Data.EntityModels;

namespace PrivateSquares.Data.Configurations
{
    public class ExperienceConfiguration
    {
        public ExperienceConfiguration(EntityTypeBuilder<Experience> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.OrgName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Designation).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Description).HasColumnType("nText");
            builder.Property(x => x.Location).HasMaxLength(200);
        }
    }
}
