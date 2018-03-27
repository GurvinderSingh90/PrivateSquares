using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrivateSquares.Data.EntityModels;

namespace PrivateSquares.Data.Configurations
{
    public class EducationConfiguration
    {
        public EducationConfiguration(EntityTypeBuilder<Education> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Institute).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Location).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Description).HasColumnType("nText");
        }
    }
}
